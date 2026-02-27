namespace Order_Processing
{
    partial class RemoveOrderCourier
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
            this.txtOrderNumser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbxCourier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPickupLocation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblCustomerData = new System.Windows.Forms.Label();
            this.lblPhoneNoData = new System.Windows.Forms.Label();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.lblAddressData = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPreviousCourierData = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOrderNumser
            // 
            this.txtOrderNumser.Location = new System.Drawing.Point(16, 103);
            this.txtOrderNumser.Name = "txtOrderNumser";
            this.txtOrderNumser.Size = new System.Drawing.Size(273, 27);
            this.txtOrderNumser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shopify Order Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(636, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(465, 574);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 39);
            this.button2.TabIndex = 4;
            this.button2.Text = "Assign New";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkGreen;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(16, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(273, 39);
            this.button3.TabIndex = 5;
            this.button3.Text = "Get Order Details";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbxCourier
            // 
            this.cbxCourier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCourier.FormattingEnabled = true;
            this.cbxCourier.Location = new System.Drawing.Point(20, 586);
            this.cbxCourier.Name = "cbxCourier";
            this.cbxCourier.Size = new System.Drawing.Size(206, 27);
            this.cbxCourier.TabIndex = 6;
            this.cbxCourier.SelectedValueChanged += new System.EventHandler(this.cbxCourier_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 556);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Courier ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxPickupLocation
            // 
            this.cbxPickupLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPickupLocation.FormattingEnabled = true;
            this.cbxPickupLocation.Location = new System.Drawing.Point(245, 586);
            this.cbxPickupLocation.Name = "cbxPickupLocation";
            this.cbxPickupLocation.Size = new System.Drawing.Size(206, 27);
            this.cbxPickupLocation.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(241, 556);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 27);
            this.label4.TabIndex = 9;
            this.label4.Text = "Pick up Location";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(12, 188);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(273, 27);
            this.lblCustomer.TabIndex = 10;
            this.lblCustomer.Text = "Customer ";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerData
            // 
            this.lblCustomerData.Location = new System.Drawing.Point(12, 215);
            this.lblCustomerData.Name = "lblCustomerData";
            this.lblCustomerData.Size = new System.Drawing.Size(655, 27);
            this.lblCustomerData.TabIndex = 11;
            this.lblCustomerData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPhoneNoData
            // 
            this.lblPhoneNoData.Location = new System.Drawing.Point(16, 279);
            this.lblPhoneNoData.Name = "lblPhoneNoData";
            this.lblPhoneNoData.Size = new System.Drawing.Size(655, 27);
            this.lblPhoneNoData.TabIndex = 13;
            this.lblPhoneNoData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNo.Location = new System.Drawing.Point(16, 252);
            this.lblPhoneNo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(273, 27);
            this.lblPhoneNo.TabIndex = 12;
            this.lblPhoneNo.Text = "Phone No";
            this.lblPhoneNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddressData
            // 
            this.lblAddressData.Location = new System.Drawing.Point(16, 343);
            this.lblAddressData.Name = "lblAddressData";
            this.lblAddressData.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblAddressData.Size = new System.Drawing.Size(655, 89);
            this.lblAddressData.TabIndex = 15;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(16, 316);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(273, 27);
            this.lblAddress.TabIndex = 14;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPreviousCourierData
            // 
            this.lblPreviousCourierData.Location = new System.Drawing.Point(16, 469);
            this.lblPreviousCourierData.Name = "lblPreviousCourierData";
            this.lblPreviousCourierData.Size = new System.Drawing.Size(655, 27);
            this.lblPreviousCourierData.TabIndex = 17;
            this.lblPreviousCourierData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 442);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(273, 27);
            this.label5.TabIndex = 16;
            this.label5.Text = "Previous Courier";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(610, 35);
            this.label2.TabIndex = 18;
            this.label2.Text = "Reassign Courier";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RemoveOrderCourier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(683, 631);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPreviousCourierData);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAddressData);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblPhoneNoData);
            this.Controls.Add(this.lblPhoneNo);
            this.Controls.Add(this.lblCustomerData);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxPickupLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxCourier);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOrderNumser);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RemoveOrderCourier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RemoveOrderCourier";
            this.Load += new System.EventHandler(this.RemoveOrderCourier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOrderNumser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbxCourier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxPickupLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblCustomerData;
        private System.Windows.Forms.Label lblPhoneNoData;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.Label lblAddressData;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPreviousCourierData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}