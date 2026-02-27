using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using System.Drawing;
namespace Order_Processing
{
    partial class DataGrid1
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
            this.sfDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_remove_order_courier = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sfDataGrid
            // 
            this.sfDataGrid.AccessibleName = "Table";
            this.sfDataGrid.AllowDraggingColumns = true;
            this.sfDataGrid.AllowFiltering = true;
            this.sfDataGrid.AllowGrouping = false;
            this.sfDataGrid.AllowResizingColumns = true;
            this.sfDataGrid.AllowResizingHiddenColumns = true;
            this.sfDataGrid.AllowSorting = false;
            this.sfDataGrid.AutoGenerateColumns = false;
            this.sfDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.sfDataGrid.BackColor = System.Drawing.SystemColors.Window;
            this.sfDataGrid.Location = new System.Drawing.Point(0, 71);
            this.sfDataGrid.Name = "sfDataGrid";
            this.sfDataGrid.RowHeight = 21;
            this.sfDataGrid.Size = new System.Drawing.Size(900, 329);
            this.sfDataGrid.TabIndex = 1;
            this.sfDataGrid.CurrentCellEndEdit += new Syncfusion.WinForms.DataGrid.Events.CurrentCellEndEditEventHandler(this.sfDataGrid_CurrentCellEndEdit);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_remove_order_courier);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 60);
            this.panel1.TabIndex = 2;
            // 
            // btn_remove_order_courier
            // 
            this.btn_remove_order_courier.BackColor = System.Drawing.Color.Red;
            this.btn_remove_order_courier.FlatAppearance.BorderSize = 0;
            this.btn_remove_order_courier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_remove_order_courier.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remove_order_courier.ForeColor = System.Drawing.Color.White;
            this.btn_remove_order_courier.Location = new System.Drawing.Point(15, 11);
            this.btn_remove_order_courier.Name = "btn_remove_order_courier";
            this.btn_remove_order_courier.Size = new System.Drawing.Size(204, 35);
            this.btn_remove_order_courier.TabIndex = 2;
            this.btn_remove_order_courier.Text = "Reassign Order Courier";
            this.btn_remove_order_courier.UseVisualStyleBackColor = false;
            this.btn_remove_order_courier.Click += new System.EventHandler(this.btn_remove_order_courier_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(591, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(730, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Update All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataGrid1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(900, 400);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sfDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(10, 10);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "DataGrid1";
            this.Text = "DataGrid1";
            this.Load += new System.EventHandler(this.DataGrid1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private SfDataGrid sfDataGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_remove_order_courier;
    }
}
