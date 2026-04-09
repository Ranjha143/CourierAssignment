using Dapper;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.Input.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Telerik.WinControls.VirtualKeyboard;
namespace Order_Processing
{
    public partial class DataGrid1 : Form
    {
        #region Constructor
        public DataGrid1()
        {
            InitializeComponent();

            Program.ConnectionString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={ConfigurationManager.AppSettings["DbServer"]})(PORT=1521)))" +
                  "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=RPROODS)));" +
                  "User Id = reportuser; " +
                  "Password = report; ";

            var configurationsTask = Task.Factory.StartNew(() => LoadConfigurations().Wait());
            Task.WaitAll(configurationsTask);


            this.sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ShopifyOrderNo", HeaderText = "Shopify Order No", AllowEditing = false });
            this.sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "CustomerName", HeaderText = "Customer Name", AllowEditing = false });
            this.sfDataGrid.Columns.Add(new GridTextColumn { MappingName = "OriginalCity", HeaderText = "Original City", AllowEditing = false });

            this.sfDataGrid.Columns.Add(new GridComboBoxColumn { MappingName = "SuggestedCity", HeaderText = "New City", ValueMember = "CITY_ID", DisplayMember = "CITY_NAME" });
            (this.sfDataGrid.Columns["SuggestedCity"] as GridComboBoxColumn).DataSource = CityList;

            this.sfDataGrid.Columns.Add(new GridComboBoxColumn { MappingName = "COURIER_ID", HeaderText = "Courier", ValueMember = "COURIER_ID", DisplayMember = "COURIERNAME" });
            (this.sfDataGrid.Columns["COURIER_ID"] as GridComboBoxColumn).DataSource = Program.CourierList.Where(c => c.IS_ENABLED && c.PRIORITY_ORDER > 0).Select(s => s).ToList();

            this.sfDataGrid.Columns.Add(new GridComboBoxColumn { MappingName = "PICKUP_ID", HeaderText = "Pick-Up Location", ValueMember = "PICKUP_ID", DisplayMember = "PICKUP_NAME" });



            this.sfDataGrid.Columns.Add(new GridButtonColumn() { MappingName = "Row_Id", HeaderText = "" });
            (this.sfDataGrid.Columns["Row_Id"] as GridButtonColumn).Width = 80;
            (this.sfDataGrid.Columns["Row_Id"] as GridButtonColumn).MinimumWidth = 80;
            (this.sfDataGrid.Columns["Row_Id"] as GridButtonColumn).AllowDefaultButtonText = true;
            (this.sfDataGrid.Columns["Row_Id"] as GridButtonColumn).DefaultButtonText = " Submit";

            this.sfDataGrid.CellButtonClick += sfDataGrid_CellButtonClick;

            sfDataGrid.RowHeight = 30;
            sfDataGrid.ShowPreviewRow = true;
            sfDataGrid.PreviewRowMappingName = "OrderDetails";
            sfDataGrid.PreviewRowHeightMode = PreviewRowHeightMode.Fixed;
            sfDataGrid.PreviewRowPadding = new Padding(30, 0, 0, 0);
            sfDataGrid.PreviewRowHeight = 40;

            sfDataGrid.Style.PreviewRowStyle.BackColor = ColorTranslator.FromHtml("#e8e9eb");
            //sfDataGrid.ExpandAllPreviewRow();
            this.sfDataGrid.ThemeName = "Office2016Colorful";
            this.sfDataGrid.HeaderRowHeight = 40;

            sfDataGrid.DataSource = failedOrderInfos;

            this.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * .95);
            this.Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * .90);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private async void sfDataGrid_CellButtonClick(object sender, CellButtonClickEventArgs e)
        {
            var recordEntry = e.Record as Syncfusion.WinForms.DataGrid.DataRow;
            var orderObject = recordEntry.RowData;
            var orderJson = JsonConvert.SerializeObject(orderObject);

            var orderToUpdate = JsonConvert.DeserializeObject<FailedOrderInfo>(orderJson);

            if (orderToUpdate.COURIER_ID > 0)
            {
                DialogResult result = MessageBox.Show(
                $"Are you sure you want to Update order # {orderToUpdate.ShopifyOrderNo} ?",
                "Confirmation",
                MessageBoxButtons.YesNo, // Yes and No buttons
                MessageBoxIcon.Question  // Question mark icon
                );

                if (result == DialogResult.Yes)
                {

                    if (orderToUpdate.SuggestedCity == 0)
                    {
                        orderToUpdate.SuggestedCity = CityList.Where(c => c.CITY_NAME == orderToUpdate.OriginalCity).Select(c => c.CITY_ID).FirstOrDefault();
                        orderToUpdate.SuggestedCityName = orderToUpdate.OriginalCity;
                    }
                    else
                    {
                        orderToUpdate.SuggestedCityName = CityList.Where(c => c.CITY_ID == orderToUpdate.SuggestedCity).Select(c => c.CITY_NAME).FirstOrDefault();
                    }

                    var updateQry = $"update CUSTOM_ORDER_PICKER_DOC set BT_CITY = '{orderToUpdate.SuggestedCityName}', ST_CITY ='{orderToUpdate.SuggestedCityName}', SUGGESTED_CITY ='{orderToUpdate.SuggestedCityName}', SUGGESTED_COURIER_ID = {orderToUpdate.COURIER_ID},SUGGESTED_PICKUP_ID = {orderToUpdate.PICKUP_ID} ,ERRORFLAG = 0, PERMANENT_COURIER_ERROR = 0, COURIER_ERROR_FLAG = 0, COURIER_ASSIGNMENT_FLAG = 1, COURIER_ERROR_MESSAGE = null,COURIER_RETRY = 0 where ROW_ID = {orderToUpdate.Row_Id} AND SHOPIFY_ORDER_NO ='{orderToUpdate.ShopifyOrderNo}'";

                    using (IDbConnection connection = new OracleConnection(Program.ConnectionString))
                    {
                        var res = await connection.ExecuteAsync(updateQry);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                $"Nothing to Update. Please select Courier Name!",
                "Confirmation",
                MessageBoxButtons.OK, // Yes and No buttons
                MessageBoxIcon.Exclamation// Question mark icon
                );
            }
        }
        List<FailedOrderInfo> failedOrderInfos = new List<FailedOrderInfo>();
        List<CUSTOM_ORDER_CITY> CityList = new List<CUSTOM_ORDER_CITY>();
        private async void GetOrdersAsync()
        {
            CityList = Program.FullCityList.GroupBy(c => c.CITY_NAME).Select(g => g.First()).ToList();

            var qry = @"
                        select ROW_ID as Row_Id ,'' as StoreName, shopify_order_no as ShopifyOrderNo, bt_first_name || ' ' || bt_last_name as CustomerName,
                        ST_ADDRESS_LINE as DeliveryAddress, ST_PRIMARY_PHONE_NO as PhoneNo, ST_CITY as OriginalCity, ST_COUNTRY as Country, ST_EMAIL as CustomerEmail, 
                        tracking_no as TrackingNo, COURIER_ERROR_MESSAGE, ORDER_CREATE_DATE
                        from CUSTOM_ORDER_PICKER_DOC where ORDER_CANCELED = 0 AND COURIER_ASSIGNMENT_FLAG = 0 AND Tracking_No is null
                    ";

            using (IDbConnection connection = new OracleConnection(Program.ConnectionString))
            {
                failedOrderInfos = (await connection.QueryAsync<FailedOrderInfo>(qry)).OrderByDescending(o => o.ORDER_CREATE_DATE).ToList();
            }

            failedOrderInfos.ForEach(o =>
            {

                o.OrderDetails = o.DeliveryAddress + " " + o.OriginalCity + ", PhoneNo: " + o.PhoneNo + "\nError Message: " + o.CourierError;

            });

        }


        private async Task<bool> LoadConfigurations()
        {
            using (IDbConnection connection = new OracleConnection(Program.ConnectionString))
            {
                var configurationQuery = "select * from CUSTOM_ORDER_COURIER_CONFIG";
                Program.CourierConfigurations = (await connection.QueryAsync<CUSTOM_ORDER_COURIER_CONFIG>(configurationQuery)).ToList();

                var courierQuery = " select * from CUSTOM_ORDER_COURIER where IS_ENABLED = 1 order by PRIORITY_ORDER ";
                Program.CourierList = (await connection.QueryAsync<CUSTOM_ORDER_COURIER>(courierQuery)).ToList();

                //var pickLocQry = "select To_char(PICKUP_ID) as PICKUP_ID, PICKUP_NAME, COURIER_ID from custom_order_pickup_location";
                //Program.PickUpLocations = (connection.QueryAsync<CUSTOM_ORDER_PICKUP_LOCATION>(pickLocQry).Result).ToList() ;

                foreach (var courier in Program.CourierList)
                {
                    courier.PRIORITY_CITY = courier.PRIORITY_CITY + ',' + courier.PRIORITY_CITY_2;
                }

                var fullCityListQuery = " select city.* from CUSTOM_ORDER_CITY city inner join CUSTOM_ORDER_COURIER courier on  city.COURIER_ID = courier.COURIER_ID where courier.IS_ENABLED = 1 AND  courier.PRIORITY_ORDER > 0 ";
                Program.FullCityList = (await connection.QueryAsync<CUSTOM_ORDER_CITY>(fullCityListQuery)).ToList();
            }
            GetOrdersAsync();
            return true;
        }

        #endregion

        private void DataGrid1_Load(object sender, EventArgs e)
        {
            panel1.Height = 74;
            panel1.Width = this.Width - 10;
            panel1.Left = 0;
            panel1.Top = 0;
            sfDataGrid.Width = this.Width;
            sfDataGrid.Height = this.Height - 74;
            sfDataGrid.Left = 0;
            sfDataGrid.Top = 74;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetOrdersAsync();
            sfDataGrid.DataSource = null;
            sfDataGrid.DataSource = failedOrderInfos;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<OrderstoUpdate> dataRows = JsonConvert.DeserializeObject<List<OrderstoUpdate>>(JsonConvert.SerializeObject(sfDataGrid.DataSource));

            var selectedRows = dataRows.Where(row => row.COURIER_ID > 0)
           .Select(s => s).ToList();

            if (selectedRows.Count > 0)
            {
                foreach (var row in selectedRows)
                {
                    if (row.SuggestedCity == 0)
                    {
                        row.SuggestedCity = CityList.Where(c => c.CITY_NAME == row.OriginalCity).Select(c => c.CITY_ID).FirstOrDefault();
                        row.SuggestedCityName = row.OriginalCity;
                    }
                    else
                    {
                        row.SuggestedCityName = CityList.Where(c => c.CITY_ID == row.SuggestedCity).Select(c => c.CITY_NAME).FirstOrDefault();
                    }
                    var updateQry = $"update CUSTOM_ORDER_PICKER_DOC set BT_CITY = '{row.SuggestedCityName}', ST_CITY ='{row.SuggestedCityName}', SUGGESTED_CITY ='{row.SuggestedCityName}', SUGGESTED_COURIER_ID = {row.COURIER_ID},SUGGESTED_PICKUP_ID = {row.PICKUP_ID} ,ERRORFLAG = 0, PERMANENT_COURIER_ERROR = 0, COURIER_ERROR_FLAG = 0, COURIER_ASSIGNMENT_FLAG = 1, COURIER_ERROR_MESSAGE = null,COURIER_RETRY = 0 where ROW_ID = {row.Row_Id} AND SHOPIFY_ORDER_NO ='{row.ShopifyOrderNo}'";
                    using (IDbConnection connection = new OracleConnection(Program.ConnectionString))
                    {
                        var res = await connection.ExecuteAsync(updateQry);
                    }
                }
                ;
            }
            else
            {
                MessageBox.Show(
                    $"Nothing to Update. Please select Courier Name!",
                    "Confirmation",
                    MessageBoxButtons.OK, // Yes and No buttons
                    MessageBoxIcon.Exclamation// Question mark icon
                    );
            }
        }

        private void sfDataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {
            if (e.DataColumn.GridColumn.MappingName == "COURIER_ID")
            {
                var rowData = e.DataRow.RowData as FailedOrderInfo;
                var pickupLocations = Program.PickUpLocations.Where(s => s.COURIER_ID == rowData.COURIER_ID).Select(p => p).ToList();

                (sfDataGrid.Columns["PICKUP_ID"] as GridComboBoxColumn).DataSource = pickupLocations;
            }
        }

        private void btn_remove_order_courier_Click(object sender, EventArgs e)
        {
            RemoveOrderCourier removeOrderCourier = new RemoveOrderCourier();
            removeOrderCourier.ShowDialog();
        }
    }


    public class OrderstoUpdate
    {
        public long Row_Id { get; set; }
        public string ShopifyOrderNo { get; set; }
        public string OriginalCity { get; set; }
        public int? SuggestedCity { get; set; } = 0;
        public string SuggestedCityName { get; set; }
        public long COURIER_ID { get; set; } = 0;
        public string PICKUP_ID { get; set; }
    }

    public class FailedOrderInfo
    {
        public decimal Row_Id { get; set; }
        public string StoreName { get; set; }
        public string ShopifyOrderNo { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public string PhoneNo { get; set; }
        public string OriginalCity { get; set; }
        public int? SuggestedCity { get; set; } = 0;
        public string SuggestedCityName { get; set; }
        public string Country { get; set; }
        public long COURIER_ID { get; set; } = 0;
        public string CourierName { get; set; }
        public string CustomerEmail { get; set; }
        public string CourierError { get; set; }
        public string COURIER_ERROR_MESSAGE { get; set; }
        public string TrackingNo { get; set; }
        public string TwoCheckoutReferenceId { get; set; }
        public DateTime ORDER_CREATE_DATE { get; set; }

        public string OrderDetails { get; set; }
        public string PICKUP_ID { get; set; }
    }
}
