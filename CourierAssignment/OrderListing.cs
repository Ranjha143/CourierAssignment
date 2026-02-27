using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Order_Processing
{
    public partial class OrderListing : Form
    {

        List<CUSTOM_ORDER_CITY> CityList = new List<CUSTOM_ORDER_CITY>();
        public OrderListing()
        {
            InitializeComponent();

            InitializeApplication();

            this.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * .95);
            this.Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * .90);
            this.StartPosition = FormStartPosition.CenterScreen;

            
        }

        private void OrderListing_Load(object sender, EventArgs e)
        {
            panel1.Height = 74;
            panel1.Width = this.Width - 10;
            panel1.Left = 0;
            panel1.Top = 0;
            orderGrid.Width = this.Width;
            orderGrid.Height = this.Height - 74;
            orderGrid.Left = 0;
            orderGrid.Top = 74;

            var colWidth = ((this.Width - 110) / 9) ;

            foreach (var col in orderGrid.Columns)
            {
                if (col.Name == "DeliveryAddress")
                {
                    col.Width = colWidth + 180;
                    col.MaxWidth = colWidth + 180;
                    col.MinWidth = colWidth + 180;
                }
                else if (col.Name != "DeliveryAddress" && col.Name == "COURIER_ERROR_MESSAGE")
                {
                    col.Width = colWidth -50;
                    col.MaxWidth = colWidth - 50;
                    col.MinWidth = colWidth - 50;
                }
                else
                {
                    col.Width = colWidth - 20;
                    col.MaxWidth = colWidth - 20;
                    col.MinWidth = colWidth - 20;
                }
                //else if (col.Name == "COURIER_ERROR_MESSAGE")
                //{
                //    col.Width = colWidth ;
                //    col.MaxWidth = colWidth + 50;
                //    col.MinWidth = colWidth + 50;
                //}
                //else if (col.Name == "CommandColumn")
                //{
                //    col.Width = colWidth - 50;
                //    col.MaxWidth = colWidth - 50;
                //    col.MinWidth = colWidth - 50;
                //}
                //else if (col.Name == "ORDER_CREATE_DATE")
                //{
                //    col.Width = colWidth - 5;
                //    col.MaxWidth = colWidth - 5;
                //    col.MinWidth = colWidth - 5;
                //}
                //else if (col.Name != "DeliveryAddress" && col.Name != "COURIER_ERROR_MESSAGE" && col.Name != "CommandColumn" && col.Name == "ORDER_CREATE_DATE")
                //{
                //    col.Width = colWidth - 20;
                //    col.MaxWidth = colWidth - 20;
                //    col.MinWidth = colWidth - 20;
                //}

            }

            GridViewCommandColumn commandColumn = new GridViewCommandColumn();
            commandColumn.Name = "CommandColumn";
            commandColumn.UseDefaultText = true;
            commandColumn.DefaultText = "UPDATE";
            commandColumn.TextAlignment = ContentAlignment.MiddleCenter;
            commandColumn.FieldName = "ProductName";
            commandColumn.HeaderText = "";
            commandColumn.Width = 100;
            commandColumn.MaxWidth = 100;
            commandColumn.MinWidth = 100;
            orderGrid.MasterTemplate.Columns.Add(commandColumn);

            GetOrders();


        }

        private async void GetOrders()
        {

            CityList = Program.FullCityList.GroupBy(c => c.CITY_NAME).Select(g => g.First()).ToList();


            var qry = @"
                        select ROW_ID as Row_Id ,'' as StoreName, shopify_order_no as ShopifyOrderNo, bt_first_name || ' ' || bt_last_name as CustomerName,
                        ST_ADDRESS_LINE as DeliveryAddress, ST_PRIMARY_PHONE_NO as PhoneNo, ST_CITY as OriginalCity, ST_COUNTRY as Country, ST_EMAIL as CustomerEmail, 
                        tracking_no as TrackingNo, COURIER_ERROR_MESSAGE, ORDER_CREATE_DATE
                        from CUSTOM_ORDER_PICKER_DOC where ORDER_CANCELED = 0 AND COURIER_ASSIGNMENT_FLAG = 0 AND Tracking_No is null
                    ";


            var courierColumn = orderGrid.Columns["COURIER_ID"] as GridViewComboBoxColumn;
            if (courierColumn != null)
            {
                courierColumn.DisplayMember = "COURIERNAME";
                courierColumn.ValueMember = "COURIER_ID";

                courierColumn.DataSource = Program.CourierList.Where(c => c.IS_ENABLED && c.PRIORITY_ORDER > 0).Select(s => s).ToList(); ;

            }

            var cityColumn = orderGrid.Columns["SuggestedCity"] as GridViewComboBoxColumn;
            if (cityColumn != null)
            {
                cityColumn.DisplayMember = "CITY_NAME";
                cityColumn.ValueMember = "CITY_ID";

                cityColumn.DataSource = CityList;
            }


            using (IDbConnection connection = new OracleConnection(Program.ConnectionString))
            {
                orderGrid.DataSource = (await connection.QueryAsync<FailedOrderInfo>(qry)).OrderByDescending(o => o.ORDER_CREATE_DATE).ToList();
            }

            this.orderGrid.SortDescriptors.Clear(); // Clear existing sorts
            this.orderGrid.SortDescriptors.Add(new SortDescriptor("ShopifyOrderNo", ListSortDirection.Descending));
            orderGrid.CurrentRow = orderGrid.Rows[0];
            orderGrid.Rows[0].IsSelected = true;
        }

        private void orderGrid_CellEditorInitialized(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column is GridViewComboBoxColumn && e.ActiveEditor is RadDropDownListEditor)
            {
                RadDropDownListEditor editor = e.ActiveEditor as RadDropDownListEditor;
                RadDropDownListEditorElement editorElement = editor.EditorElement as RadDropDownListEditorElement;
                editorElement.NullText = "Select ...";
                editorElement.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Enables search as you type
                editorElement.DropDownStyle = RadDropDownStyle.DropDown;       // Allows text input
                //editorElement.EnableFiltering = true;                         // Enables filtering functionality
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<OrderstoUpdate> selectedRows = orderGrid.Rows
            .Where(row => Convert.ToInt32(row.Cells["COURIER_ID"].Value.ToString()) > 0)
            .Select(s =>
            new OrderstoUpdate
            {
                Row_Id = Convert.ToInt64(s.Cells["RowId"].Value.ToString()),
                ShopifyOrderNo = s.Cells["ShopifyOrderNo"].Value.ToString(),
                COURIER_ID = Convert.ToInt64(s.Cells["COURIER_ID"].Value.ToString()),
                OriginalCity = s.Cells["OriginalCity"].Value.ToString(),
                SuggestedCity = Convert.ToInt32(s.Cells["SuggestedCity"].Value.ToString())
            })
            .ToList();

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

                    var updateQry = $"update CUSTOM_ORDER_PICKER_DOC set SUGGESTED_CITY ='{row.SuggestedCityName}', SUGGESTED_COURIER_ID = {row.COURIER_ID},ERRORFLAG = 0, PERMANENT_COURIER_ERROR = 0, COURIER_ERROR_FLAG = 0, COURIER_ASSIGNMENT_FLAG = 1, COURIER_ERROR_MESSAGE = null,COURIER_RETRY = 0 where ROW_ID = {row.Row_Id} AND SHOPIFY_ORDER_NO ='{row.ShopifyOrderNo}'";
                    using (IDbConnection connection = new OracleConnection(Program.ConnectionString))
                    {
                        var res = await connection.ExecuteAsync(updateQry);
                    }

                };

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

        private void InitializeApplication()
        {
            Program.ConnectionString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={ConfigurationManager.AppSettings["DbServer"]})(PORT=1521)))" +
                  "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=RPROODS)));" +
                  "User Id = reportuser; " +
                  "Password = report; ";

            var configurationsTask = Task.Factory.StartNew(() => LoadConfigurations().Wait());
            Task.WaitAll(configurationsTask);
        }

        private async Task<bool> LoadConfigurations()
        {
            using (IDbConnection connection = new OracleConnection(Program.ConnectionString))
            {
                var configurationQuery = "select * from CUSTOM_ORDER_COURIER_CONFIG";
                Program.CourierConfigurations = (await connection.QueryAsync<CUSTOM_ORDER_COURIER_CONFIG>(configurationQuery)).ToList();

                var courierQuery = " select * from CUSTOM_ORDER_COURIER where IS_ENABLED = 1 order by PRIORITY_ORDER ";
                Program.CourierList = (await connection.QueryAsync<CUSTOM_ORDER_COURIER>(courierQuery)).ToList();

                foreach (var courier in Program.CourierList)
                {
                    courier.PRIORITY_CITY = courier.PRIORITY_CITY + ',' + courier.PRIORITY_CITY_2;
                }

                var fullCityListQuery = " select city.* from CUSTOM_ORDER_CITY city inner join CUSTOM_ORDER_COURIER courier on  city.COURIER_ID = courier.COURIER_ID where courier.IS_ENABLED = 1 AND  courier.PRIORITY_ORDER > 0 ";
                Program.FullCityList = (await connection.QueryAsync<CUSTOM_ORDER_CITY>(fullCityListQuery)).ToList();
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            orderGrid.DataSource = null;
            GetOrders();

        }

        private async void orderGrid_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var cmd = sender as GridCommandCellElement;
            var row = orderGrid.Rows[e.RowIndex];
            var orderToUpdate = new OrderstoUpdate
            {
                Row_Id = Convert.ToInt64(row.Cells["RowId"].Value.ToString()),
                ShopifyOrderNo = row.Cells["ShopifyOrderNo"].Value.ToString(),
                COURIER_ID = Convert.ToInt64(row.Cells["COURIER_ID"].Value.ToString()),
                OriginalCity = row.Cells["OriginalCity"].Value.ToString(),
                SuggestedCity = Convert.ToInt32(row.Cells["SuggestedCity"].Value.ToString())
            };

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
                    var updateQry = $"update CUSTOM_ORDER_PICKER_DOC set SUGGESTED_CITY ='{orderToUpdate.SuggestedCityName}', SUGGESTED_COURIER_ID = {orderToUpdate.COURIER_ID} ,ERRORFLAG = 0, PERMANENT_COURIER_ERROR = 0, COURIER_ERROR_FLAG = 0, COURIER_ASSIGNMENT_FLAG = 1, COURIER_ERROR_MESSAGE = null,COURIER_RETRY = 0 where ROW_ID = {orderToUpdate.Row_Id} AND SHOPIFY_ORDER_NO ='{orderToUpdate.ShopifyOrderNo}'";
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
    }

}
