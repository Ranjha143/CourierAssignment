using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.VirtualKeyboard;

namespace Order_Processing
{
    public partial class RemoveOrderCourier : Form
    {
        public RemoveOrderCourier()
        {
            InitializeComponent();
            courierList = null;
        }
        List<CUSTOM_ORDER_CITY> CityList = new List<CUSTOM_ORDER_CITY>();
        List<CUSTOM_ORDER_COURIER> courierList { get; set; }
        private void RemoveOrderCourier_Load(object sender, EventArgs e)
        {
            CityList = Program.FullCityList.GroupBy(c => c.CITY_NAME).Select(g => g.First()).ToList();

            courierList = Program.CourierList.Select(s => s).ToList();

            courierList.Insert(0, new CUSTOM_ORDER_COURIER
            {
                COURIER_ID = 0,
                COURIERNAME = "-- Select Courier --"
            });

            cbxCourier.DataSource = courierList;
            cbxCourier.ValueMember = "COURIER_ID";
            cbxCourier.DisplayMember = "COURIERNAME";

            cbxPickupLocation.ValueMember = "PICKUP_ID";
            cbxPickupLocation.DisplayMember = "PICKUP_NAME";

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrderNumser.Text.Trim()))
            {
                var query = $@"select 
                    BT_FIRST_NAME, 
                    BT_LAST_NAME, 
                    BT_PRIMARY_PHONE_NO, 
                    BT_EMAIL, 
                    BT_ADDRESS_LINE, 
                    BT_CITY, BT_COUNTRY, 
                    TRACKING_NO, 
                    COURIER_NAME 
                    from custom_order_picker_doc 
                    where shopify_order_no = '{txtOrderNumser.Text}'";

                using (IDbConnection connection = new OracleConnection(Program.ConnectionString))
                {

                    var orderInfo = (await connection.QueryAsync<OrderInfo>(query)).ToList();

                    var info = orderInfo.FirstOrDefault();

                    if (info != null)
                    { 
                                        lblCustomerData.Text = $"{info.BT_FIRST_NAME} {info.BT_LAST_NAME}";
                    lblPhoneNoData.Text = info.BT_PRIMARY_PHONE_NO;
                    lblAddressData.Text = $"{info.BT_ADDRESS_LINE}, {info.BT_CITY}, {info.BT_COUNTRY}";
                    lblPreviousCourierData.Text = $"{info.COURIER_NAME} - {info.TRACKING_NO}";
                        button2.Enabled = true;
                        cbxCourier.Enabled = true;
                        cbxPickupLocation.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Nothing to Process");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxCourier_SelectedValueChanged(object sender, EventArgs e)
        {
            int.TryParse(cbxCourier.SelectedValue.ToString(), out int courierId);

            if (courierId > 0)
            {
                var pickupLocations = Program.PickUpLocations.Where(p => p.COURIER_ID == courierId).ToList();
                cbxPickupLocation.DataSource = pickupLocations;
            }
            else
            {
                cbxPickupLocation.DataSource = null;
            }
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrderNumser.Text.Trim()))
            {
                var dialodRedult = MessageBox.Show(this, $"Are you sure you want to reassign courier to order # {txtOrderNumser.Text} ?", "Confirm Reassignment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialodRedult == DialogResult.Yes)
                {
                    var updateQry = $@"update CUSTOM_ORDER_PICKER_DOC set 
                    SUGGESTED_COURIER_ID = {cbxCourier.SelectedValue.ToString()},
                    SUGGESTED_PICKUP_ID = {cbxPickupLocation.SelectedValue.ToString()} ,
                    TRACKING_NO = null, courier_Status = null, COURIER_NAME = null,
                    ERRORFLAG = 0, PERMANENT_COURIER_ERROR = 0, COURIER_ERROR_FLAG = 0, 
                    COURIER_ASSIGNMENT_FLAG = 0, COURIER_ERROR_MESSAGE = null, COURIER_RETRY = 0 
                    where SHOPIFY_ORDER_NO ='{txtOrderNumser.Text}'";

                    using (IDbConnection connection = new OracleConnection(Program.ConnectionString))
                    {
                        var res = await connection.ExecuteAsync(updateQry);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Nothing to Process");
            }
        }
    }

    internal class OrderInfo
    {
        public string BT_FIRST_NAME { get; set; } = string.Empty;
        public string BT_LAST_NAME { get; set; } = string.Empty;
        public string BT_PRIMARY_PHONE_NO { get; set; } = string.Empty;
        public string BT_EMAIL { get; set; } = string.Empty;
        public string BT_ADDRESS_LINE { get; set; } = string.Empty;
        public string BT_CITY { get; set; } = string.Empty;
        public string BT_COUNTRY { get; set; } = string.Empty;
        public string TRACKING_NO { get; set; } = string.Empty;
        public string COURIER_NAME { get; set; } = string.Empty;
    }
}
