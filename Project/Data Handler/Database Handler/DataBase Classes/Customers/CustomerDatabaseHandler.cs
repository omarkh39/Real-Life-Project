using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Project
{
    public class CustomerDatabaseHandler : ICustomerDataLayer
    {
        public CustomerDatabaseHandler()
        {
            DataBaseToList();
        }

        public void DataBaseToList()
        {
            using (TelecomEntities Entity = new TelecomEntities())
            {
                foreach (Customer customer in Entity.Customers.ToList())
                {
                    TelecomCustomer telecomCustomer = new TelecomCustomer { 
                    CustomerFirstName=customer.CustomerFirstName,
                    CustomerLastName=customer.CustomerLastName,
                    CustomerPhoneNumber=customer.CustomerPhoneNumber,
                    ExpiryDate=customer.ExpiryDate.ToString(TelecomCustomer.DateFormat),
                    CustomerSubscriptionType = Entity.Subscriptions.First<Subscription>(subscription => subscription.SubscriptionCode.Equals(customer.SubscriptionCode)).SubscriptionName
                    };

                    telecomCustomer.SetAmount(float.Parse(customer.Amount.ToString()));

                    CustomerList.AddCustomer(telecomCustomer);
                }
            }
        }

        public bool CheckPhoneNumberAvailability(string phoneNumber)
        {
            return CustomerList.CheckPhoneNumberAvailability(phoneNumber);
        }

        public bool CheckSubscriptionExistance(string subscription)
        {
            return CustomerList.CheckSubscriptionExistance(subscription);
        }

        public void CreateCustomer(TelecomCustomer customer)
        {

            using (TelecomEntities entity = new TelecomEntities())
            {
                Subscription subscription = entity.Subscriptions.FirstOrDefault<Subscription>(subscriptions => subscriptions.SubscriptionName.Equals(customer.CustomerSubscriptionType));
                if (subscription != null)
                {
                    entity.Customers.Add(new Customer
                    {
                        CustomerFirstName = customer.CustomerFirstName,
                        CustomerLastName = customer.CustomerLastName,
                        CustomerPhoneNumber = customer.CustomerPhoneNumber,
                        SubscriptionCode = subscription.SubscriptionCode,
                        Amount = customer.GetAmount(),
                        ExpiryDate = customer.GetExpiryDate(),
                        Subscription = subscription
                    });
                    entity.SaveChanges();

                    CustomerList.AddCustomer(customer);
                    MessageBox.Show("Customer Added Sucessfully To Database");
                    Logger.LogTransactionWritter("Customer Added Sucessfully To database");
                }
                else
                {
                    MessageBox.Show("Adding process didn't complete ,Please Try Again");
                    Logger.LogTransactionWritter("Adding process didn't complete , Please Try Again");
                    SubscriptionDatabaseHandler.ReloadSubscriptionList();
                }
            }
        }

        public void DeleteCustomer(string phoneNumber)
        {
            try
            {
                using (TelecomEntities entity = new TelecomEntities())
                {
                    Customer customer = entity.Customers.FirstOrDefault<Customer>(customers => customers.CustomerPhoneNumber.Equals(phoneNumber));

                    if (customer != null)
                    {
                        entity.Customers.Remove(customer);
                        entity.SaveChanges();
                        CustomerList.DeleteCustomerFromList(phoneNumber);
                        Logger.LogTransactionWritter("Customer Deleted Sucessfully");
                        MessageBox.Show("Deleted Sucessfully");
                    }
                    else
                    {
                        Logger.LogTransactionWritter("Customer Not Found, Please Try Again");
                        MessageBox.Show("Customer Not Found, Please Try Again");
                        ReloadList();
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogTransactionWritter("Customer Deleting Process Didn\t Complete");
                MessageBox.Show("Deleting Customer Didn't Complete");
            }
        }

        public void EditCustomer(TelecomCustomer telecomCustomer)
        {
            try
            {
                using (TelecomEntities entity = new TelecomEntities())
                {
                    Customer customer = entity.Customers.FirstOrDefault<Customer>(eCustomer => eCustomer.CustomerPhoneNumber.Equals(telecomCustomer.CustomerPhoneNumber));
                    if (customer != null)
                    {
                        Subscription subscription = entity.Subscriptions.FirstOrDefault<Subscription>(subscriptions => subscriptions.SubscriptionName.Equals(telecomCustomer.CustomerSubscriptionType));
                        if (subscription != null)
                        {
                            customer.CustomerFirstName = telecomCustomer.CustomerFirstName;
                            customer.CustomerLastName = telecomCustomer.CustomerLastName;
                            customer.SubscriptionCode = subscription.SubscriptionCode;
                            customer.ExpiryDate = telecomCustomer.GetExpiryDate();
                            customer.Amount = telecomCustomer.GetAmount();

                            entity.SaveChanges();

                            CustomerList.EditCustomer(telecomCustomer);
                            MessageBox.Show("Customer Data Edditted Sucessfully");
                            Logger.LogTransactionWritter("Customer Data Edditted Sucessfully to data base");
                        }
                        else
                        {
                            MessageBox.Show("New Subscription Not Found,Please Try Again");
                            Logger.LogTransactionWritter("New Subscription Not Found, Please Try Again");
                            SubscriptionDatabaseHandler.ReloadSubscriptionList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer Not Found, Please try Again");
                        Logger.LogTransactionWritter("Customer Not Found, Please Try Again");
                        ReloadList();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ediiting Customer Didn't Complete");
                Logger.LogTransactionWritter("Ediiting Customer Didn't Complete to data base");
            }
        }

        public void EditCustomersSubscription(string oldSubscriptionName, string newSubscriptionName)
        {
            CustomerList.EditCustomersSubscription(oldSubscriptionName, newSubscriptionName);
        }

        public TelecomCustomer GetCustomer(string phoneNumber)
        {
            TelecomCustomer telecomCustomer = null;
            using (TelecomEntities entity = new TelecomEntities())
            {
                Customer customer = entity.Customers.FirstOrDefault<Customer>(eCustomer => eCustomer.CustomerPhoneNumber.Equals(phoneNumber));
                Subscription subscription = entity.Subscriptions.FirstOrDefault<Subscription>(subscript => subscript.SubscriptionCode == customer.SubscriptionCode);
                
                if (subscription != null)
                {
                    telecomCustomer = new TelecomCustomer
                    {
                        CustomerFirstName = customer.CustomerFirstName,
                        CustomerLastName = customer.CustomerLastName,
                        CustomerPhoneNumber = customer.CustomerPhoneNumber,
                        CustomerSubscriptionType = subscription.SubscriptionName,
                        ExpiryDate = customer.ExpiryDate.ToString(TelecomCustomer.DateFormat)
                    };
                    telecomCustomer.SetAmount(float.Parse(customer.Amount.ToString()));
                }
                else
                {
                    MessageBox.Show("Please restart the Application");
                    Logger.LogTransactionWritter("Please restart the Application subscription Not Found");
                }
            }
            return telecomCustomer;
        }

        public BindingList<TelecomCustomer> SearchResultList(string searchText)
        {
            BindingList<TelecomCustomer> subCustomers = new BindingList<TelecomCustomer>();
            List<Customer> customerList = new List<Customer>();

            using (TelecomEntities entity = new TelecomEntities())
            {
                if (Regex.IsMatch(searchText, "^[a-zA-Z]*$"))
                {
                    customerList = entity.Customers.Where<Customer>(customer => customer.CustomerFirstName.ToLower().Contains(searchText)).ToList();
                }
                else
                {
                    customerList = entity.Customers.Where<Customer>(customer => customer.CustomerPhoneNumber.Contains(searchText)).ToList();
                }

                foreach (Customer customer in customerList)
                {
                    Subscription subscription = entity.Subscriptions.FirstOrDefault<Subscription>(subscriptions => subscriptions.SubscriptionCode.Equals(customer.SubscriptionCode));
                    if (subscription != null)
                    {
                        TelecomCustomer telecomCustomer = new TelecomCustomer
                        {
                            CustomerFirstName = customer.CustomerFirstName,
                            CustomerLastName = customer.CustomerLastName,
                            CustomerPhoneNumber = customer.CustomerPhoneNumber,
                            CustomerSubscriptionType = subscription.SubscriptionName,
                            ExpiryDate = customer.ExpiryDate.ToString(TelecomCustomer.DateFormat),

                        };
                        telecomCustomer.SetAmount(float.Parse(customer.Amount.ToString()));

                        subCustomers.Add(telecomCustomer);
                    }
                    else
                    {
                        MessageBox.Show("Please Restart The Application");
                    }
                }
            }
            return subCustomers;
        }

        private void ReloadList()
        {
            CustomerList.GetCustomersList().Clear();
            DataBaseToList();
        }

        public BindingList<TelecomCustomer> GetCustomerList()
        {
            return CustomerList.GetCustomersList();
        }
    }
}
