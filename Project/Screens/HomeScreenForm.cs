using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Project
{
    public partial class HomeScreenForm : Form
    {
        private LoginPageForm _loginForm;
        private DataGridViewRow _customerSelectedRow;

        ISubscriptionDataLayer Subscriptions;
        ICustomerDataLayer Customers;

        private const int SelectedRowIndex = 0;
        private const int CustomerFirstNameCell = 0;
        private const int CustomerLastNameCell = 1;
        private const int CustomerMobileNumberCell = 2;
        private const int CustomerExpiryDateCell = 3;
        private const int CustomerSubscriptionTypeCell = 5;

        private DataGridViewRow _subscriptionSelectedRow;
        private const int SubscriptionNameCell = 0;
        private const int SubscriptionCodeCell = 1;
        private const int SubscriptionTypeCell = 2;
        private const int SubscriptionFeeCell = 3;

        private const int SelectedCellIndex = 0;

        public HomeScreenForm(LoginPageForm loginForm)
        {
            _loginForm = loginForm;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Subscriptions = Factory.CreateSubscription();
            Customers = Factory.CreateCustomer();

            Logger.LogTransactionWritter("Home Scrren Form Component Initilized\t\t");
        }

        private void HomeScreenForm_Load(object sender, EventArgs e)
        {
            //throw new Exception();

            SubscriptiondataGridView.DataSource = Subscriptions.GetSubscriptionsList();
            CustomerDataGridView.DataSource = Customers.GetCustomerList();

            ResetCustomerTab();
            Logger.LogTransactionWritter("Home scrren Form Loaded\t\t");
        }


        //Customer Tab Controll


        private void ClearAddCustomerFormButton_Click(object sender, EventArgs e)
        {
            //throw new Exception("test exception");
            Logger.LogTransactionWritter("Clear button Pressed \t\t");
            ResetCustomerTab();
        }


        private void CustomerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (CustomerDataGridView.SelectedRows.Count.Equals(1))
            {
                try
                {
                    _customerSelectedRow = CustomerDataGridView.SelectedRows[SelectedRowIndex];
                    if (_customerSelectedRow.Cells[SelectedCellIndex].Value != null)
                    {
                        Logger.LogTransactionWritter("Customer Tab DatagridView Row Selected\t " + "CustomerFirstName:    " + _customerSelectedRow.Cells[CustomerFirstNameCell].Value.ToString()
                                                        + "\tCustomerLastName:    " + _customerSelectedRow.Cells[CustomerLastNameCell].Value.ToString()
                                                        + " \tCustomerMobileNumber:    " + _customerSelectedRow.Cells[CustomerMobileNumberCell].Value.ToString()
                                                        + "\tExpiryDate:    " + DateTime.ParseExact(_customerSelectedRow.Cells[CustomerExpiryDateCell].Value.ToString(), TelecomCustomer.DateFormat, CultureInfo.InvariantCulture)
                                                        + "\tSubscriptionType:    " + _customerSelectedRow.Cells[CustomerSubscriptionTypeCell - 1].Value.ToString()
                                                        + "\t\t");

                        TelecomCustomer customer = Customers.GetCustomer(_customerSelectedRow.Cells[CustomerMobileNumberCell].Value.ToString());
                        if (customer != null)
                        {
                            CustomerFirstNameTextbox.Text = customer.CustomerFirstName;
                            CustomerLastNameTextbox.Text = customer.CustomerLastName;
                            CustomerMobileNumberTextbox.Text = customer.CustomerPhoneNumber;
                            ExpiryDatePicker.Value = DateTime.ParseExact(customer.ExpiryDate, TelecomCustomer.DateFormat, CultureInfo.InvariantCulture);
                            AmountTextbox.Text = customer.GetAmount().ToString();
                            CustomerSubscriptionTypeCombobox.SelectedIndex = CustomerSubscriptionTypeCombobox.FindStringExact(customer.CustomerSubscriptionType);

                            Logger.LogTransactionWritter("Customer Fields Filled Sucessfully from Data Grid View Data");
                        }
                        else
                        {
                            MessageBox.Show("Customer Not Found");
                            Logger.LogTransactionWritter("Customer Diddn't found");
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Invalid");
                    // Logger.LogExceptionWritter(exception);
                }
            }
        }

        private void DeleteCustomerButton_Click(object sender, EventArgs e)
        {
            Logger.LogTransactionWritter("Customer Tab Delete Button Pressed\t\t");
            if (CustomerMobileNumberTextbox.Text != "")
            {
                if (CustomerDataGridView.SelectedRows.Count.Equals(1))
                {
                    Logger.LogTransactionWritter("Message Box Are You Sure You want to delte Customer:    " + _customerSelectedRow.Cells[CustomerFirstNameCell].Value.ToString() + "\t" + _customerSelectedRow.Cells[CustomerLastNameCell].Value.ToString() + "\tCustomer");
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete\n" + _customerSelectedRow.Cells[CustomerFirstNameCell].Value.ToString() + "  " + _customerSelectedRow.Cells[CustomerLastNameCell].Value.ToString() + "\tCustomer", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dialogResult.Equals(DialogResult.OK))
                    {
                        Logger.LogTransactionWritter("User Pressed Ok");
                        CustomerDataGridView.Rows.RemoveAt(CustomerDataGridView.SelectedRows[0].Index);
                        Customers.DeleteCustomer(CustomerMobileNumberTextbox.Text);
                        ResetCustomerTab();
                        CustomerDataGridView.Refresh();
                    }
                    else
                    {
                        Logger.LogTransactionWritter("User Pressed Cancle");
                    }
                }
                else
                {

                    MessageBox.Show("Please selct one row only");
                }
            }
            else
            {
                MessageBox.Show("Please select Row First", "Alert");
            }

        }

        private void ResetCustomerTab()
        {
            Logger.LogTransactionWritter("Ressiting Customer Tab data\t\t");
            CustomerSearchTextbox.Text = "";
            CustomerFirstNameTextbox.Text = "";
            CustomerLastNameTextbox.Text = "";
            CustomerMobileNumberTextbox.Text = "";
            AmountTextbox.Text = "";
            CustomerSubscriptionTypeCombobox.SelectedIndex = -1;
            ExpiryDatePicker.Value = DateTime.Now.AddDays(60);

            ReloadSubscriptionTypeComboBox();
            Logger.LogTransactionWritter("Customer Tab Data Resetted");
        }

        private bool CustomerTabValidity()
        {
            Logger.LogTransactionWritter("Checking Customer tab Data Validity\t\t");
            Logger.LogTransactionWritter("Customer First Name:    " + CustomerFirstNameTextbox.Text + "\tCustomer Last Name:    " + CustomerLastNameTextbox.Text
                                          + "\tCustomer Monile Phone:    " + CustomerMobileNumberTextbox.Text + "\tAmount:    " + AmountTextbox.Text
                                          + "\t Expiry Date:    " + ExpiryDatePicker.Value);
            string errorState = "clear";
            if (CustomerFirstNameTextbox.Text.Equals("") || CustomerFirstNameTextbox.TextLength < 3 || !Regex.IsMatch(CustomerFirstNameTextbox.Text, "^[a-zA-Z]*$"))
            {
                errorState = "FirstName";
            }

            if (CustomerLastNameTextbox.Text.Equals("") || CustomerLastNameTextbox.TextLength < 3 || !Regex.IsMatch(CustomerLastNameTextbox.Text, "^[a-zA-Z]*$"))
            {
                errorState = "LastName";
            }

            if (CustomerMobileNumberTextbox.Text.Equals("") || !CustomerMobileNumberTextbox.Text.StartsWith("079") || !Regex.IsMatch(CustomerMobileNumberTextbox.Text, @"^\d{10}$"))
            {
                errorState = "MobilePhone";
            }

            if (AmountTextbox.Text.Equals("") || !Regex.IsMatch(AmountTextbox.Text, @"^(?:[1-9]\d*|0)?(?:\.\d+)?$"))
            {
                errorState = "Amount";
            }

            if (ExpiryDatePicker.Value < DateTime.Now)
            {
                errorState = "ExpiryDate";
            }

            switch (errorState)
            {
                case "clear":
                    break;

                case "FirstName":
                    MessageBox.Show("Customer First Name Should Contain at least 3 Characher");
                    Logger.LogTransactionWritter("Unvalid First Name");
                    break;

                case "LastName":
                    MessageBox.Show("Customer last Name Should Contain at least 3 Characher");
                    Logger.LogTransactionWritter("Unvalid Lastt Name");
                    break;

                case "MobilePhone":
                    MessageBox.Show("Customer Mobile Phone Should Contain 10 digit number starting with 079");
                    Logger.LogTransactionWritter("Unvalid PhoneNumber");
                    break;

                case "Amount":
                    MessageBox.Show("Amount Should Contain non empty numeric value");
                    Logger.LogTransactionWritter("Unvalid Amount");
                    break;

                case "ExpiryDate":
                    MessageBox.Show("expiry date should be in the future only");
                    Logger.LogTransactionWritter("Unvalid Expiry Date");
                    break;
            }
            if (errorState.Equals("clear"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Subscription Tab Controll
        private void EditSubscriptionButton_Click(object sender, EventArgs e)
        {
            Logger.LogTransactionWritter("Subscription Tab Edit Button Pressed\t\t");
            Logger.LogTransactionWritter("Values   SubscriptionName:    " + SubscriptionNameTextbox.Text + "SubscriptionCode:    " + SubscriptionCodeTextbox.Text + "SubscriptionFee:    " + SubscriptionFeeTextbox.Text + "SubscriptionType:    " + SubscriptionTypeCombobox.Text);

            if (SubscriptionTabValidate())
            {
                if (Subscriptions.CheckSubscriptionNameAvilability(SubscriptionNameTextbox.Text, SubscriptionCodeTextbox.Text))
                {
                    if (Customers.CheckSubscriptionExistance(_subscriptionSelectedRow.Cells[SubscriptionNameCell].Value.ToString()))
                    {
                        MessageBox.Show("Subscription " + "\t have already registered users ");
                        Logger.LogTransactionWritter(SubscriptionCodeTextbox.Text + "\t have already registered users ");

                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to Edit\n" + _subscriptionSelectedRow.Cells[SubscriptionNameCell].Value.ToString() + "\tSubscription", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        Logger.LogTransactionWritter("Are You Sure to edit Subscription data to SubscriptionName:    " + SubscriptionNameTextbox.Text + "SubscriptionCode:    " + SubscriptionCodeTextbox.Text + "SubscriptionFee:    " + SubscriptionFeeTextbox.Text + "SubscriptionType:    " + SubscriptionTypeCombobox.Text);

                        if (dialogResult.Equals(DialogResult.OK))
                        {
                            Logger.LogTransactionWritter("User Pressed Ok");

                            if (!Subscriptions.GetSubscription(SubscriptionCodeTextbox.Text).SubscriptionName.Equals(SubscriptionNameTextbox.Text))
                            {
                                Customers.EditCustomersSubscription(Subscriptions.GetSubscription(SubscriptionCodeTextbox.Text).SubscriptionName, SubscriptionNameTextbox.Text);
                            }


                            if (SubscriptionTypeCombobox.Text.Equals(TelecomSubscription.PackgeTypeEnum.PostPaid.ToString()))
                            {
                                Subscriptions.EditSubscription(new TelecomSubscription(SubscriptionNameTextbox.Text, SubscriptionCodeTextbox.Text, float.Parse(SubscriptionFeeTextbox.Text), TelecomSubscription.PackgeTypeEnum.PostPaid.ToString()));
                            }
                            else
                            {
                                Subscriptions.EditSubscription(new TelecomSubscription(SubscriptionNameTextbox.Text, SubscriptionCodeTextbox.Text, float.Parse(SubscriptionFeeTextbox.Text), TelecomSubscription.PackgeTypeEnum.PrePaid.ToString()));
                            }

                            ResetSubscriptionTab();
                        }
                        else
                        {
                            Logger.LogTransactionWritter("User Pressed cancel");
                        }

                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to Edit\n" + _subscriptionSelectedRow.Cells[SubscriptionNameCell].Value.ToString() + "\tSubscription", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        Logger.LogTransactionWritter("Are You Sure to edit Subscription data to SubscriptionName:    " + SubscriptionNameTextbox.Text + "SubscriptionCode:    " + SubscriptionCodeTextbox.Text + "SubscriptionFee:    " + SubscriptionFeeTextbox.Text + "SubscriptionType:    " + SubscriptionTypeCombobox.Text);
                        if (dialogResult.Equals(DialogResult.OK))
                        {
                            Logger.LogTransactionWritter("User Pressed Ok");
                            if (SubscriptionTypeCombobox.Text.Equals(TelecomSubscription.PackgeTypeEnum.PostPaid.ToString()))
                            {
                                Subscriptions.EditSubscription(new TelecomSubscription(SubscriptionNameTextbox.Text, SubscriptionCodeTextbox.Text, float.Parse(SubscriptionFeeTextbox.Text), TelecomSubscription.PackgeTypeEnum.PostPaid.ToString()));
                            }
                            else if (SubscriptionTypeCombobox.Text.Equals(TelecomSubscription.PackgeTypeEnum.PrePaid.ToString()))
                            {
                                Subscriptions.EditSubscription(new TelecomSubscription(SubscriptionNameTextbox.Text, SubscriptionCodeTextbox.Text, float.Parse(SubscriptionFeeTextbox.Text), TelecomSubscription.PackgeTypeEnum.PrePaid.ToString()));
                            }
                            else
                            {
                                MessageBox.Show("Choosen Packge Isn't defined");
                            }
                            ResetSubscriptionTab();
                            SubscriptiondataGridView.Refresh();
                        }
                        else
                        {
                            Logger.LogTransactionWritter("User Pressed Cancle");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Subscription Name Already taken");
                    Logger.LogTransactionWritter("Subscription Name Already taken");
                }
            }

        }

        private void SubscriptiondataGridView_Click(object sender, EventArgs e)
        {
            Logger.LogTransactionWritter("Subscription Data Grid View Clicked\t\t");

            if (SubscriptiondataGridView.SelectedRows.Count.Equals(1))
            {
                Logger.LogTransactionWritter("Subscription DatagridView Row Selected");
                try
                {
                    _customerSelectedRow = SubscriptiondataGridView.SelectedRows[SelectedRowIndex];
                    if (_customerSelectedRow.Cells[SelectedCellIndex].Value != null)
                    {
                        _subscriptionSelectedRow = SubscriptiondataGridView.SelectedRows[SelectedRowIndex];

                        Logger.LogTransactionWritter("Subscription Tab DatagridView Row Selected\t "
                                                       + "\t SubscriptionName:    " + _subscriptionSelectedRow.Cells[SubscriptionNameCell].Value.ToString()
                                                       + " \tSubscriptionCode:    " + _subscriptionSelectedRow.Cells[SubscriptionCodeCell].Value.ToString()
                                                       + "\t SubscriptionFee:    " + _subscriptionSelectedRow.Cells[SubscriptionFeeCell].Value.ToString()
                                                       + "\tSubscriptionType:    " + _subscriptionSelectedRow.Cells[SubscriptionTypeCell].Value.ToString()
                                                       );
                        TelecomSubscription subscription = Subscriptions.GetSubscription(_subscriptionSelectedRow.Cells[SubscriptionCodeCell].Value.ToString());
                        if (subscription != null)
                        {
                            SubscriptionNameTextbox.Text = subscription.SubscriptionName;
                            SubscriptionCodeTextbox.Text = subscription.SubscriptionCode.ToString();
                            SubscriptionTypeCombobox.SelectedIndex = SubscriptionTypeCombobox.FindStringExact(subscription._packgeType.ToString());
                            SubscriptionFeeTextbox.Text = subscription.SubscriptionFee.ToString();
                        }
                        SubscriptionCodeTextbox.Enabled = false;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Invalid");
                }
            }
        }

        private void DeleteSubscriptionButton_Click(object sender, EventArgs e)
        {
            Logger.LogTransactionWritter("Subscription Tab Delete Button Pressed\t\t");
            if (SubscriptionCodeTextbox.Text != "")
            {
                if (Customers.CheckSubscriptionExistance(SubscriptionNameTextbox.Text))
                {
                    MessageBox.Show(SubscriptionNameTextbox.Text + "\t have already registered users cannot be deleted");
                    Logger.LogTransactionWritter(SubscriptionNameTextbox.Text + "\t have already registered users cannot be deleted");
                }
                else
                {
                    DialogResult dialgoResult = MessageBox.Show("Are you sure you want to Delete\n" + _subscriptionSelectedRow.Cells[SubscriptionNameCell].Value.ToString() + "\tSubscription", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Logger.LogTransactionWritter("Are You Sure you want to delete:    " + SubscriptionNameTextbox.Text + "SubscriptionCode:    " + SubscriptionCodeTextbox.Text + "SubscriptionFee:    " + SubscriptionFeeTextbox.Text + "SubscriptionType:    " + SubscriptionTypeCombobox.Text);
                    if (dialgoResult.Equals(DialogResult.OK))
                    {
                        Logger.LogTransactionWritter("User Pressed Ok");
                        SubscriptiondataGridView.Rows.RemoveAt(SubscriptiondataGridView.SelectedRows[0].Index);
                        Subscriptions.DeleteSubscription(SubscriptionCodeTextbox.Text);

                        ResetSubscriptionTab();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select Row First", "Alert");
            }
        }

        private void ClearAddSubscriptionFormButton_Click(object sender, EventArgs e)
        {
            ResetSubscriptionTab();
        }

        private void AddSubscriptionButton_Click(object sender, EventArgs e)
        {
            Logger.LogTransactionWritter("Subscription Tab Add Subscription Button Pressed\t\t");
            Logger.LogTransactionWritter("values" + "SubscriptionName:    " + SubscriptionNameTextbox.Text
                                                     + "\tSubscription Code:    " + SubscriptionCodeTextbox.Text
                                                     + "\tFees:    " + SubscriptionFeeTextbox.Text
                                                     + "\tPackgeType:    " + CustomerSubscriptionTypeCombobox.Text);
            if (SubscriptionCodeTextbox.Enabled.Equals(false))
            {
                MessageBox.Show("Please Clear The Form");
                Logger.LogTransactionWritter("Please Clear The Form Before You can add");
            }
            else if (SubscriptionTabValidate())
            {
                if (!Subscriptions.CheckSubsciptionCodeAvailability(SubscriptionCodeTextbox.Text.ToString()))
                {
                    MessageBox.Show("This Code Has Already been Taken for Diffrent Subscription");
                    Logger.LogTransactionWritter(int.Parse(SubscriptionCodeTextbox.Text.ToString()) + "\tCode Has been taken by ther subscription");
                }
                else
                {
                    if (Subscriptions.CheckSubscriptionNameAvilability(SubscriptionNameTextbox.Text, SubscriptionCodeTextbox.Text))
                    {
                        if (SubscriptionTypeCombobox.Text.Equals(TelecomSubscription.PackgeTypeEnum.PostPaid.ToString()))
                        {
                            Logger.LogTransactionWritter("Adding subscription:\t\t" + "SubscriptionName:    " + SubscriptionNameTextbox.Text
                                                         + "\tSubscription Code:    " + SubscriptionCodeTextbox.Text
                                                         + "\tFees:    " + SubscriptionFeeTextbox.Text
                                                         + "\tPackgeType:    " + TelecomSubscription.PackgeTypeEnum.PostPaid);

                            TelecomSubscription telecomSubscription = new TelecomSubscription
                            {
                                SubscriptionName = SubscriptionNameTextbox.Text,
                                SubscriptionCode = SubscriptionCodeTextbox.Text,
                                SubscriptionFee = float.Parse(SubscriptionFeeTextbox.Text),
                                SubscriptionPackge = TelecomSubscription.PackgeTypeEnum.PostPaid
                            };

                            Subscriptions.CreateSubscription(telecomSubscription);

                            ResetSubscriptionTab();
                        }
                        else if (SubscriptionTypeCombobox.Text.Equals(TelecomSubscription.PackgeTypeEnum.PrePaid.ToString()))
                        {
                            Logger.LogTransactionWritter("Adding subscription:\t\t" + "SubscriptionName   " + SubscriptionNameTextbox.Text
                                                         + "\tSubscription Code:    " + SubscriptionCodeTextbox.Text
                                                         + "\tFees:    " + SubscriptionFeeTextbox.Text
                                                         + "\tPackgeType:    " + TelecomSubscription.PackgeTypeEnum.PrePaid);

                            TelecomSubscription telecomSubscription = new TelecomSubscription
                            {
                                SubscriptionName = SubscriptionNameTextbox.Text,
                                SubscriptionCode = SubscriptionCodeTextbox.Text,
                                SubscriptionFee = float.Parse(SubscriptionFeeTextbox.Text),
                                SubscriptionPackge = TelecomSubscription.PackgeTypeEnum.PrePaid
                            };

                            Subscriptions.CreateSubscription(telecomSubscription);
                            ResetSubscriptionTab();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Subscription Name Already been Taken");
                        Logger.LogTransactionWritter("Subscription Name Already been Taken");
                    }
                }

            }
            SubscriptiondataGridView.Refresh();
        }

        private bool SubscriptionTabValidate()
        {
            Logger.LogTransactionWritter("Checking Subscription tab Data Validity");
            string errorFlag = "clear";

            if (SubscriptionCodeTextbox.Text.Equals(""))
            {
                MessageBox.Show("Please fill text box");
                errorFlag = "SubscriptionCode";
            }

            if (SubscriptionNameTextbox.Text.Equals(""))
            {
                MessageBox.Show("Subscription Name Cannot Be Empty", "Error");
                errorFlag = "SubscriptionName";
            }

            if (SubscriptionFeeTextbox.Text.Equals(""))
            {
                MessageBox.Show("Subscription Fees Cannot Be Empty", "Error");
                errorFlag = "SubscriptionFee";
            }
            else if (!Regex.IsMatch(SubscriptionFeeTextbox.Text, @"^(?:[1-9]\d*|0)?(?:\.\d+)?$"))
            {
                MessageBox.Show("Fees can only contain number");
                errorFlag = "SubscriptionFee";
            }

            switch (errorFlag)
            {
                case "clear":
                    Logger.LogTransactionWritter("Subscription Valid Data");
                    return true;
                case "SubscriptionCode":
                    MessageBox.Show("Subscription Code Cannot Be Empty");
                    Logger.LogTransactionWritter("Invalid Subsciption Code");
                    break;
                case "SubscriptionName":
                    MessageBox.Show("Subscription name Cannot Be Empty");
                    Logger.LogTransactionWritter("Invalid Subsciption Name");
                    break;
                case "SubscriptionFee":
                    MessageBox.Show("Subscription Fee should be numeric non empty value");
                    Logger.LogTransactionWritter("Invalid Subsciption Name");
                    break;
            }
            return false;
        }

        private void ResetSubscriptionTab()
        {
            Logger.LogTransactionWritter("Resetting Subscription Tab\t\t");
            SubscriptionNameTextbox.Text = "";
            SubscriptionCodeTextbox.Text = "";
            SubscriptionTypeCombobox.SelectedIndex = -1;
            SubscriptionFeeTextbox.Text = "";
            SubscriptionCodeTextbox.Enabled = true;

            Logger.LogTransactionWritter("Subscription Tab Ressetted");
        }

        //Tab Controll

        public void ReloadSubscriptionTypeComboBox()
        {
            try
            {
                Logger.LogTransactionWritter("Reloading Customer Tab Subscription Type Combo Box Values\t\t");
                CustomerSubscriptionTypeCombobox.Items.Clear();
                foreach (string element in Subscriptions.GetSubscriptionsName())
                {
                    CustomerSubscriptionTypeCombobox.Items.Add(element);
                }
                Logger.LogTransactionWritter("Subscription Type Combo Box Values Reloaded Successfully");
            }
            catch (Exception exception)
            {
                //  Logger.LogExceptionWritter(exception);
                MessageBox.Show("Subscription Courupted File");
            }
        }

        private void telecomTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (telecomTabControl.SelectedTab.Text.Equals("Customers"))
            {
                Logger.LogTransactionWritter("Customer Tab Selected ");
                ResetCustomerTab();
            }
            else if (telecomTabControl.SelectedTab.Text.Equals("Subscription"))
            {

                Logger.LogTransactionWritter("Subscription Tab Selected ");
                ResetSubscriptionTab();
            }
            else
            {
                MessageBox.Show("Who are you");
            }
        }

        private void SaveCustomerButton_Click(object sender, EventArgs e)
        {
            Logger.LogTransactionWritter("save button preesed \t Values   Customer Name:    " + CustomerFirstNameTextbox.Text + "  " + CustomerLastNameTextbox.Text
                                                        + "  Mobile Number:    " + CustomerMobileNumberTextbox.Text + " Subscription Type:    " + CustomerSubscriptionTypeCombobox.Text
                                                        + " Amount:    " + AmountTextbox.Text + "\t\t");
            if (CustomerTabValidity())
            {

                if (Customers.CheckPhoneNumberAvailability(CustomerMobileNumberTextbox.Text))
                {

                    DialogResult dialgoResult = MessageBox.Show("Are you sure you want add Customer with following Details \n\n" + "Customer Name:    " + CustomerFirstNameTextbox.Text + " " + CustomerLastNameTextbox.Text + "\n"
                                                            + "Mobile Number:    " + CustomerMobileNumberTextbox.Text + "\n Subscription Type:    " + CustomerSubscriptionTypeCombobox.Text
                                                            + "\n Amount:    " + AmountTextbox.Text
                                                            , "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    Logger.LogTransactionWritter("Are You sure about adding Customer :    Customer First Name:    " + CustomerFirstNameTextbox.Text + "\tCustomer Last Name:    " + CustomerLastNameTextbox.Text
                                      + "\tCustomer Monile Phone:    " + CustomerMobileNumberTextbox.Text + "\tAmount:    " + AmountTextbox.Text
                                      + "\t Expiry Date:    " + ExpiryDatePicker.Value);
                    if (dialgoResult.Equals(DialogResult.OK))
                    {
                        Logger.LogTransactionWritter("User Pressed Ok");


                        Customers.CreateCustomer(new TelecomCustomer(CustomerFirstNameTextbox.Text, CustomerLastNameTextbox.Text, CustomerMobileNumberTextbox.Text, float.Parse(AmountTextbox.Text.ToString()), CustomerSubscriptionTypeCombobox.Text));


                        ResetCustomerTab();
                    }
                    else
                    {
                        Logger.LogTransactionWritter("User Pressed Cancle");
                    }

                }
                else
                {
                    Logger.LogTransactionWritter("Customer New value to be editted Customer Name:    " + CustomerFirstNameTextbox.Text + "  " + CustomerLastNameTextbox.Text
                                                           + "  Mobile Number:    " + CustomerMobileNumberTextbox.Text + " Subscription Type:    " + CustomerSubscriptionTypeCombobox.Text
                                                           + " Amount:    " + AmountTextbox.Text);
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit\n" + _customerSelectedRow.Cells[CustomerFirstNameCell].Value.ToString() + "  " + _customerSelectedRow.Cells[CustomerLastNameCell].Value.ToString() + "\tCustomer", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Logger.LogTransactionWritter("Messege Box Are You Sure You want To edit ?");
                    if (dialogResult.Equals(DialogResult.OK))
                    {
                        Customers.EditCustomer(new TelecomCustomer(CustomerFirstNameTextbox.Text, CustomerLastNameTextbox.Text, CustomerMobileNumberTextbox.Text, float.Parse(AmountTextbox.Text), CustomerSubscriptionTypeCombobox.Text, ExpiryDatePicker.Value));
                        Logger.LogTransactionWritter("User Pressed Ok");

                        ResetCustomerTab();
                    }
                    else
                    {
                        Logger.LogTransactionWritter("User Pressed Cancle");
                    }
                }
            }
            CustomerDataGridView.Refresh();
        }

        private void HomeScreenForm_FormClosing(object sender, FormClosingEventArgs closeingEventArgs)
        {
            Logger.LogTransactionWritter("Close Button Pressed\t\t");
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Exist The Application\n", "!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            Logger.LogTransactionWritter("Are you sure you want to Exist The Application");
            if (dialogResult.Equals(DialogResult.Yes))
            {
                Logger.LogTransactionWritter("User Pressed Yes  Application Home Screen Closing");
                _loginForm.Close();
            }
            else
            {
                Logger.LogTransactionWritter("User Pressed Cancle ");
                closeingEventArgs.Cancel = true;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Logger.LogTransactionWritter("Search text box value Changed:    " + CustomerSearchTextbox.Text + "\t\t");

            if (CustomerSearchTextbox.Text != "")
            {
                CustomerDataGridView.DataSource = Customers.SearchResultList(CustomerSearchTextbox.Text);
            }
            else
            {
                CustomerDataGridView.DataSource = Customers.GetCustomerList();
            }

        }

        private void CustomerSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (CustomerSearchTextbox.Text.Equals(""))
            {
                CustomerDataGridView.DataSource = Customers.GetCustomerList();
            }
        }
    }
}
