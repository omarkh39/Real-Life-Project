
namespace Project
{
    partial class HomeScreenForm
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
            this.telecomTabControl = new System.Windows.Forms.TabControl();
            this.CustomersTabPage = new System.Windows.Forms.TabPage();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ExpiryDatePicker = new System.Windows.Forms.DateTimePicker();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.CustomerSearchTextbox = new System.Windows.Forms.TextBox();
            this.ClearAddCustomerFormButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AmountTextbox = new System.Windows.Forms.TextBox();
            this.CustomerSubscriptionTypeCombobox = new System.Windows.Forms.ComboBox();
            this.CustomerMobileNumberTextbox = new System.Windows.Forms.TextBox();
            this.CustomerLastNameTextbox = new System.Windows.Forms.TextBox();
            this.CustomerFirstNameTextbox = new System.Windows.Forms.TextBox();
            this.DeleteCustomerButton = new System.Windows.Forms.Button();
            this.EditCustomerButton = new System.Windows.Forms.Button();
            this.CustomerDataGridView = new System.Windows.Forms.DataGridView();
            this.SubscriptionTabPage = new System.Windows.Forms.TabPage();
            this.ClearAddSubscriptionFormButton = new System.Windows.Forms.Button();
            this.AddSubscriptionButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SubscriptionTypeCombobox = new System.Windows.Forms.ComboBox();
            this.SubscriptionFeeTextbox = new System.Windows.Forms.TextBox();
            this.SubscriptionCodeTextbox = new System.Windows.Forms.TextBox();
            this.SubscriptionNameTextbox = new System.Windows.Forms.TextBox();
            this.DeleteSubscriptionButton = new System.Windows.Forms.Button();
            this.EditSubscriptionButton = new System.Windows.Forms.Button();
            this.SubscriptiondataGridView = new System.Windows.Forms.DataGridView();
            this.ExitButton = new System.Windows.Forms.Button();
            this.telecomTabControl.SuspendLayout();
            this.CustomersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataGridView)).BeginInit();
            this.SubscriptionTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubscriptiondataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // telecomTabControl
            // 
            this.telecomTabControl.Controls.Add(this.CustomersTabPage);
            this.telecomTabControl.Controls.Add(this.SubscriptionTabPage);
            this.telecomTabControl.Location = new System.Drawing.Point(-3, 1);
            this.telecomTabControl.Name = "telecomTabControl";
            this.telecomTabControl.SelectedIndex = 0;
            this.telecomTabControl.Size = new System.Drawing.Size(887, 514);
            this.telecomTabControl.TabIndex = 0;
            this.telecomTabControl.SelectedIndexChanged += new System.EventHandler(this.telecomTabControl_SelectedIndexChanged);
            // 
            // CustomersTabPage
            // 
            this.CustomersTabPage.Controls.Add(this.SearchButton);
            this.CustomersTabPage.Controls.Add(this.ExpiryDatePicker);
            this.CustomersTabPage.Controls.Add(this.SearchLabel);
            this.CustomersTabPage.Controls.Add(this.CustomerSearchTextbox);
            this.CustomersTabPage.Controls.Add(this.ClearAddCustomerFormButton);
            this.CustomersTabPage.Controls.Add(this.label6);
            this.CustomersTabPage.Controls.Add(this.label5);
            this.CustomersTabPage.Controls.Add(this.label4);
            this.CustomersTabPage.Controls.Add(this.label3);
            this.CustomersTabPage.Controls.Add(this.label2);
            this.CustomersTabPage.Controls.Add(this.label1);
            this.CustomersTabPage.Controls.Add(this.AmountTextbox);
            this.CustomersTabPage.Controls.Add(this.CustomerSubscriptionTypeCombobox);
            this.CustomersTabPage.Controls.Add(this.CustomerMobileNumberTextbox);
            this.CustomersTabPage.Controls.Add(this.CustomerLastNameTextbox);
            this.CustomersTabPage.Controls.Add(this.CustomerFirstNameTextbox);
            this.CustomersTabPage.Controls.Add(this.DeleteCustomerButton);
            this.CustomersTabPage.Controls.Add(this.EditCustomerButton);
            this.CustomersTabPage.Controls.Add(this.CustomerDataGridView);
            this.CustomersTabPage.Location = new System.Drawing.Point(4, 22);
            this.CustomersTabPage.Name = "CustomersTabPage";
            this.CustomersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CustomersTabPage.Size = new System.Drawing.Size(879, 488);
            this.CustomersTabPage.TabIndex = 0;
            this.CustomersTabPage.Text = "Customers";
            this.CustomersTabPage.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(514, 12);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(83, 34);
            this.SearchButton.TabIndex = 42;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ExpiryDatePicker
            // 
            this.ExpiryDatePicker.CustomFormat = "dd/MM/yyyy";
            this.ExpiryDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ExpiryDatePicker.Location = new System.Drawing.Point(370, 360);
            this.ExpiryDatePicker.Name = "ExpiryDatePicker";
            this.ExpiryDatePicker.Size = new System.Drawing.Size(119, 20);
            this.ExpiryDatePicker.TabIndex = 41;
            this.ExpiryDatePicker.Value = new System.DateTime(2022, 7, 25, 0, 0, 0, 0);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(61, 20);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(41, 13);
            this.SearchLabel.TabIndex = 40;
            this.SearchLabel.Text = "Search";
            // 
            // CustomerSearchTextbox
            // 
            this.CustomerSearchTextbox.Location = new System.Drawing.Point(141, 20);
            this.CustomerSearchTextbox.Name = "CustomerSearchTextbox";
            this.CustomerSearchTextbox.Size = new System.Drawing.Size(323, 20);
            this.CustomerSearchTextbox.TabIndex = 39;
            this.CustomerSearchTextbox.TextChanged += new System.EventHandler(this.CustomerSearchTextbox_TextChanged);
            // 
            // ClearAddCustomerFormButton
            // 
            this.ClearAddCustomerFormButton.Location = new System.Drawing.Point(639, 244);
            this.ClearAddCustomerFormButton.Name = "ClearAddCustomerFormButton";
            this.ClearAddCustomerFormButton.Size = new System.Drawing.Size(104, 50);
            this.ClearAddCustomerFormButton.TabIndex = 37;
            this.ClearAddCustomerFormButton.Text = "Reset";
            this.ClearAddCustomerFormButton.UseVisualStyleBackColor = true;
            this.ClearAddCustomerFormButton.Click += new System.EventHandler(this.ClearAddCustomerFormButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(615, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Subscription Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Expiry Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Phone Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "First Name";
            // 
            // AmountTextbox
            // 
            this.AmountTextbox.Location = new System.Drawing.Point(508, 356);
            this.AmountTextbox.Name = "AmountTextbox";
            this.AmountTextbox.Size = new System.Drawing.Size(89, 20);
            this.AmountTextbox.TabIndex = 29;
            // 
            // CustomerSubscriptionTypeCombobox
            // 
            this.CustomerSubscriptionTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomerSubscriptionTypeCombobox.FormattingEnabled = true;
            this.CustomerSubscriptionTypeCombobox.Location = new System.Drawing.Point(615, 357);
            this.CustomerSubscriptionTypeCombobox.Name = "CustomerSubscriptionTypeCombobox";
            this.CustomerSubscriptionTypeCombobox.Size = new System.Drawing.Size(110, 21);
            this.CustomerSubscriptionTypeCombobox.TabIndex = 28;
            // 
            // CustomerMobileNumberTextbox
            // 
            this.CustomerMobileNumberTextbox.Location = new System.Drawing.Point(267, 359);
            this.CustomerMobileNumberTextbox.Name = "CustomerMobileNumberTextbox";
            this.CustomerMobileNumberTextbox.Size = new System.Drawing.Size(78, 20);
            this.CustomerMobileNumberTextbox.TabIndex = 26;
            // 
            // CustomerLastNameTextbox
            // 
            this.CustomerLastNameTextbox.Location = new System.Drawing.Point(176, 358);
            this.CustomerLastNameTextbox.Name = "CustomerLastNameTextbox";
            this.CustomerLastNameTextbox.Size = new System.Drawing.Size(67, 20);
            this.CustomerLastNameTextbox.TabIndex = 25;
            // 
            // CustomerFirstNameTextbox
            // 
            this.CustomerFirstNameTextbox.Location = new System.Drawing.Point(71, 355);
            this.CustomerFirstNameTextbox.Name = "CustomerFirstNameTextbox";
            this.CustomerFirstNameTextbox.Size = new System.Drawing.Size(81, 20);
            this.CustomerFirstNameTextbox.TabIndex = 24;
            // 
            // DeleteCustomerButton
            // 
            this.DeleteCustomerButton.Location = new System.Drawing.Point(639, 135);
            this.DeleteCustomerButton.Name = "DeleteCustomerButton";
            this.DeleteCustomerButton.Size = new System.Drawing.Size(104, 50);
            this.DeleteCustomerButton.TabIndex = 23;
            this.DeleteCustomerButton.Text = "Delete ";
            this.DeleteCustomerButton.UseVisualStyleBackColor = true;
            this.DeleteCustomerButton.Click += new System.EventHandler(this.DeleteCustomerButton_Click);
            // 
            // EditCustomerButton
            // 
            this.EditCustomerButton.Location = new System.Drawing.Point(744, 343);
            this.EditCustomerButton.Name = "EditCustomerButton";
            this.EditCustomerButton.Size = new System.Drawing.Size(108, 47);
            this.EditCustomerButton.TabIndex = 22;
            this.EditCustomerButton.Text = "Save ";
            this.EditCustomerButton.UseVisualStyleBackColor = true;
            this.EditCustomerButton.Click += new System.EventHandler(this.SaveCustomerButton_Click);
            // 
            // CustomerDataGridView
            // 
            this.CustomerDataGridView.AllowUserToAddRows = false;
            this.CustomerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDataGridView.Location = new System.Drawing.Point(61, 60);
            this.CustomerDataGridView.Name = "CustomerDataGridView";
            this.CustomerDataGridView.ReadOnly = true;
            this.CustomerDataGridView.Size = new System.Drawing.Size(544, 263);
            this.CustomerDataGridView.TabIndex = 21;
            this.CustomerDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerDataGridView_CellClick);
            // 
            // SubscriptionTabPage
            // 
            this.SubscriptionTabPage.Controls.Add(this.ClearAddSubscriptionFormButton);
            this.SubscriptionTabPage.Controls.Add(this.AddSubscriptionButton);
            this.SubscriptionTabPage.Controls.Add(this.label7);
            this.SubscriptionTabPage.Controls.Add(this.label8);
            this.SubscriptionTabPage.Controls.Add(this.label9);
            this.SubscriptionTabPage.Controls.Add(this.label10);
            this.SubscriptionTabPage.Controls.Add(this.SubscriptionTypeCombobox);
            this.SubscriptionTabPage.Controls.Add(this.SubscriptionFeeTextbox);
            this.SubscriptionTabPage.Controls.Add(this.SubscriptionCodeTextbox);
            this.SubscriptionTabPage.Controls.Add(this.SubscriptionNameTextbox);
            this.SubscriptionTabPage.Controls.Add(this.DeleteSubscriptionButton);
            this.SubscriptionTabPage.Controls.Add(this.EditSubscriptionButton);
            this.SubscriptionTabPage.Controls.Add(this.SubscriptiondataGridView);
            this.SubscriptionTabPage.Location = new System.Drawing.Point(4, 22);
            this.SubscriptionTabPage.Name = "SubscriptionTabPage";
            this.SubscriptionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SubscriptionTabPage.Size = new System.Drawing.Size(879, 488);
            this.SubscriptionTabPage.TabIndex = 1;
            this.SubscriptionTabPage.Text = "Subscription";
            this.SubscriptionTabPage.UseVisualStyleBackColor = true;
            // 
            // ClearAddSubscriptionFormButton
            // 
            this.ClearAddSubscriptionFormButton.Location = new System.Drawing.Point(634, 257);
            this.ClearAddSubscriptionFormButton.Name = "ClearAddSubscriptionFormButton";
            this.ClearAddSubscriptionFormButton.Size = new System.Drawing.Size(112, 52);
            this.ClearAddSubscriptionFormButton.TabIndex = 26;
            this.ClearAddSubscriptionFormButton.Text = "Clear Screen";
            this.ClearAddSubscriptionFormButton.UseVisualStyleBackColor = true;
            this.ClearAddSubscriptionFormButton.Click += new System.EventHandler(this.ClearAddSubscriptionFormButton_Click);
            // 
            // AddSubscriptionButton
            // 
            this.AddSubscriptionButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.AddSubscriptionButton.Location = new System.Drawing.Point(346, 413);
            this.AddSubscriptionButton.Name = "AddSubscriptionButton";
            this.AddSubscriptionButton.Size = new System.Drawing.Size(148, 46);
            this.AddSubscriptionButton.TabIndex = 25;
            this.AddSubscriptionButton.Text = "Add Subscription";
            this.AddSubscriptionButton.UseVisualStyleBackColor = true;
            this.AddSubscriptionButton.Click += new System.EventHandler(this.AddSubscriptionButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(522, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Fees";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(373, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Subscription Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(252, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Code";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(126, 342);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Subscription Name";
            // 
            // SubscriptionTypeCombobox
            // 
            this.SubscriptionTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubscriptionTypeCombobox.FormattingEnabled = true;
            this.SubscriptionTypeCombobox.Items.AddRange(new object[] {
            "PostPaid",
            "PrePaid"});
            this.SubscriptionTypeCombobox.Location = new System.Drawing.Point(373, 360);
            this.SubscriptionTypeCombobox.Name = "SubscriptionTypeCombobox";
            this.SubscriptionTypeCombobox.Size = new System.Drawing.Size(121, 21);
            this.SubscriptionTypeCombobox.TabIndex = 20;
            // 
            // SubscriptionFeeTextbox
            // 
            this.SubscriptionFeeTextbox.Location = new System.Drawing.Point(522, 362);
            this.SubscriptionFeeTextbox.Name = "SubscriptionFeeTextbox";
            this.SubscriptionFeeTextbox.Size = new System.Drawing.Size(100, 20);
            this.SubscriptionFeeTextbox.TabIndex = 19;
            // 
            // SubscriptionCodeTextbox
            // 
            this.SubscriptionCodeTextbox.Enabled = false;
            this.SubscriptionCodeTextbox.Location = new System.Drawing.Point(252, 360);
            this.SubscriptionCodeTextbox.Name = "SubscriptionCodeTextbox";
            this.SubscriptionCodeTextbox.Size = new System.Drawing.Size(100, 20);
            this.SubscriptionCodeTextbox.TabIndex = 18;
            // 
            // SubscriptionNameTextbox
            // 
            this.SubscriptionNameTextbox.Location = new System.Drawing.Point(126, 361);
            this.SubscriptionNameTextbox.Name = "SubscriptionNameTextbox";
            this.SubscriptionNameTextbox.Size = new System.Drawing.Size(100, 20);
            this.SubscriptionNameTextbox.TabIndex = 17;
            // 
            // DeleteSubscriptionButton
            // 
            this.DeleteSubscriptionButton.Location = new System.Drawing.Point(634, 135);
            this.DeleteSubscriptionButton.Name = "DeleteSubscriptionButton";
            this.DeleteSubscriptionButton.Size = new System.Drawing.Size(112, 62);
            this.DeleteSubscriptionButton.TabIndex = 16;
            this.DeleteSubscriptionButton.Text = "Delete Subscription";
            this.DeleteSubscriptionButton.UseVisualStyleBackColor = true;
            this.DeleteSubscriptionButton.Click += new System.EventHandler(this.DeleteSubscriptionButton_Click);
            // 
            // EditSubscriptionButton
            // 
            this.EditSubscriptionButton.Location = new System.Drawing.Point(634, 350);
            this.EditSubscriptionButton.Name = "EditSubscriptionButton";
            this.EditSubscriptionButton.Size = new System.Drawing.Size(116, 46);
            this.EditSubscriptionButton.TabIndex = 15;
            this.EditSubscriptionButton.Text = "Edit Subscription";
            this.EditSubscriptionButton.UseVisualStyleBackColor = true;
            this.EditSubscriptionButton.Click += new System.EventHandler(this.EditSubscriptionButton_Click);
            // 
            // SubscriptiondataGridView
            // 
            this.SubscriptiondataGridView.AllowUserToAddRows = false;
            this.SubscriptiondataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubscriptiondataGridView.Location = new System.Drawing.Point(129, 29);
            this.SubscriptiondataGridView.Name = "SubscriptiondataGridView";
            this.SubscriptiondataGridView.ReadOnly = true;
            this.SubscriptiondataGridView.Size = new System.Drawing.Size(444, 255);
            this.SubscriptiondataGridView.TabIndex = 14;
            this.SubscriptiondataGridView.Click += new System.EventHandler(this.SubscriptiondataGridView_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.ForeColor = System.Drawing.Color.Crimson;
            this.ExitButton.Location = new System.Drawing.Point(886, 21);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(64, 56);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // HomeScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 518);
            this.ControlBox = false;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.telecomTabControl);
            this.Name = "HomeScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zain ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeScreenForm_FormClosing);
            this.Load += new System.EventHandler(this.HomeScreenForm_Load);
            this.telecomTabControl.ResumeLayout(false);
            this.CustomersTabPage.ResumeLayout(false);
            this.CustomersTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataGridView)).EndInit();
            this.SubscriptionTabPage.ResumeLayout(false);
            this.SubscriptionTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubscriptiondataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl telecomTabControl;
        private System.Windows.Forms.TabPage CustomersTabPage;
        private System.Windows.Forms.TabPage SubscriptionTabPage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AmountTextbox;
        private System.Windows.Forms.ComboBox CustomerSubscriptionTypeCombobox;
        private System.Windows.Forms.TextBox CustomerMobileNumberTextbox;
        private System.Windows.Forms.TextBox CustomerLastNameTextbox;
        private System.Windows.Forms.TextBox CustomerFirstNameTextbox;
        private System.Windows.Forms.Button DeleteCustomerButton;
        private System.Windows.Forms.Button EditCustomerButton;
        private System.Windows.Forms.DataGridView CustomerDataGridView;
        private System.Windows.Forms.Button ClearAddCustomerFormButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox SubscriptionTypeCombobox;
        private System.Windows.Forms.TextBox SubscriptionFeeTextbox;
        private System.Windows.Forms.TextBox SubscriptionCodeTextbox;
        private System.Windows.Forms.TextBox SubscriptionNameTextbox;
        private System.Windows.Forms.Button DeleteSubscriptionButton;
        private System.Windows.Forms.Button EditSubscriptionButton;
        internal System.Windows.Forms.DataGridView SubscriptiondataGridView;
        private System.Windows.Forms.Button ClearAddSubscriptionFormButton;
        private System.Windows.Forms.Button AddSubscriptionButton;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox CustomerSearchTextbox;
        private System.Windows.Forms.DateTimePicker ExpiryDatePicker;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SearchButton;
    }
}

