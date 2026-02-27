namespace Order_Processing
{
    partial class OrderListing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderListing));
            this.orderGrid = new Telerik.WinControls.UI.RadGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            //this.windows11Theme1 = new Telerik.WinControls.Themes.Windows11Theme();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderGrid
            // 
            this.orderGrid.AutoScroll = true;
            this.orderGrid.BackColor = System.Drawing.SystemColors.Control;
            this.orderGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.orderGrid.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.orderGrid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.orderGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.orderGrid.Location = new System.Drawing.Point(0, 117);
            this.orderGrid.Margin = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.orderGrid.MasterTemplate.AllowAddNewRow = false;
            this.orderGrid.MasterTemplate.AllowColumnChooser = false;
            this.orderGrid.MasterTemplate.AllowDragToGroup = false;
            this.orderGrid.MasterTemplate.AllowRowResize = false;
            this.orderGrid.MasterTemplate.AutoGenerateColumns = false;
            this.orderGrid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Row_Id";
            gridViewTextBoxColumn1.HeaderText = "RowId";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.MinWidth = 31288;
            gridViewTextBoxColumn1.Name = "RowId";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 32274;
            gridViewTextBoxColumn2.AllowGroup = false;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "ShopifyOrderNo";
            gridViewTextBoxColumn2.HeaderText = "Order No";
            gridViewTextBoxColumn2.MinWidth = 190;
            gridViewTextBoxColumn2.Name = "ShopifyOrderNo";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Descending;
            gridViewTextBoxColumn2.Width = 190;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ORDER_CREATE_DATE";
            gridViewTextBoxColumn3.FormatString = "{0:MM/dd/yyyy HH:mm}";
            gridViewTextBoxColumn3.HeaderText = "Created Date";
            gridViewTextBoxColumn3.MinWidth = 190;
            gridViewTextBoxColumn3.Name = "ORDER_CREATE_DATE";
            gridViewTextBoxColumn3.Width = 190;
            gridViewTextBoxColumn4.AllowGroup = false;
            gridViewTextBoxColumn4.AllowSort = false;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "CustomerName";
            gridViewTextBoxColumn4.HeaderText = "Customer Name";
            gridViewTextBoxColumn4.MinWidth = 190;
            gridViewTextBoxColumn4.Name = "CustomerName";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 190;
            gridViewTextBoxColumn5.AllowFiltering = false;
            gridViewTextBoxColumn5.AllowGroup = false;
            gridViewTextBoxColumn5.AllowSort = false;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "DeliveryAddress";
            gridViewTextBoxColumn5.HeaderText = "Delivery Address";
            gridViewTextBoxColumn5.MinWidth = 190;
            gridViewTextBoxColumn5.Name = "DeliveryAddress";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 190;
            gridViewTextBoxColumn6.AllowGroup = false;
            gridViewTextBoxColumn6.AllowSort = false;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "PhoneNo";
            gridViewTextBoxColumn6.HeaderText = "Phone No";
            gridViewTextBoxColumn6.MinWidth = 190;
            gridViewTextBoxColumn6.Name = "PhoneNo";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 190;
            gridViewTextBoxColumn7.AllowGroup = false;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "OriginalCity";
            gridViewTextBoxColumn7.HeaderText = "Original City";
            gridViewTextBoxColumn7.MinWidth = 190;
            gridViewTextBoxColumn7.Name = "OriginalCity";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 190;
            gridViewTextBoxColumn8.AllowFiltering = false;
            gridViewTextBoxColumn8.AllowGroup = false;
            gridViewTextBoxColumn8.AllowSort = false;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "TrackingNo";
            gridViewTextBoxColumn8.HeaderText = "Tracking No";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.MinWidth = 190;
            gridViewTextBoxColumn8.Name = "TrackingNo";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 8655;
            gridViewTextBoxColumn9.AllowFiltering = false;
            gridViewTextBoxColumn9.AllowGroup = false;
            gridViewTextBoxColumn9.AllowSort = false;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "COURIER_ERROR_MESSAGE";
            gridViewTextBoxColumn9.HeaderText = "Courier Error";
            gridViewTextBoxColumn9.MinWidth = 190;
            gridViewTextBoxColumn9.Name = "COURIER_ERROR_MESSAGE";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 190;
            gridViewComboBoxColumn1.AllowFiltering = false;
            gridViewComboBoxColumn1.AllowGroup = false;
            gridViewComboBoxColumn1.AllowSort = false;
            gridViewComboBoxColumn1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "SuggestedCity";
            gridViewComboBoxColumn1.HeaderText = "Suggested City";
            gridViewComboBoxColumn1.MinWidth = 190;
            gridViewComboBoxColumn1.Name = "SuggestedCity";
            gridViewComboBoxColumn1.Width = 190;
            gridViewComboBoxColumn2.AllowFiltering = false;
            gridViewComboBoxColumn2.AllowGroup = false;
            gridViewComboBoxColumn2.AllowSort = false;
            gridViewComboBoxColumn2.EnableExpressionEditor = false;
            gridViewComboBoxColumn2.FieldName = "COURIER_ID";
            gridViewComboBoxColumn2.HeaderText = "Courier";
            gridViewComboBoxColumn2.MinWidth = 190;
            gridViewComboBoxColumn2.Name = "COURIER_ID";
            gridViewComboBoxColumn2.Width = 190;
            this.orderGrid.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewComboBoxColumn1,
            gridViewComboBoxColumn2});
            this.orderGrid.MasterTemplate.EnableFiltering = true;
            this.orderGrid.MasterTemplate.EnableGrouping = false;
            this.orderGrid.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.orderGrid.MasterTemplate.ShowFilteringRow = false;
            this.orderGrid.MasterTemplate.ShowHeaderCellButtons = true;
            sortDescriptor1.Direction = System.ComponentModel.ListSortDirection.Descending;
            sortDescriptor1.PropertyName = "ShopifyOrderNo";
            this.orderGrid.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.orderGrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.orderGrid.Name = "orderGrid";
            this.orderGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.orderGrid.ShowGroupPanel = false;
            this.orderGrid.ShowHeaderCellButtons = true;
            this.orderGrid.Size = new System.Drawing.Size(1167, 449);
            this.orderGrid.TabIndex = 0;
            this.orderGrid.ThemeName = "Windows11";
            this.orderGrid.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.orderGrid_CellEditorInitialized);
            this.orderGrid.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.orderGrid_CommandCellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 74);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(788, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(974, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Update All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrderListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 575);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.orderGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderListing";
            this.Text = "Order Listing";
            this.Load += new System.EventHandler(this.OrderListing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView orderGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Telerik.WinControls.Themes.Windows11Theme windows11Theme1;
    }
}