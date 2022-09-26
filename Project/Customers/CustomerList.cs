using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Project
{
    public static class CustomerList
    {
        private static BindingList<TelecomCustomer> _customerList = new BindingList<TelecomCustomer>();

        public static void AddCustomer(TelecomCustomer customer)
        {
            _customerList.Add(customer);
        }

        public static void DeleteCustomerFromList(string phoneNumber)
        {
            foreach (TelecomCustomer customer in _customerList)
            {
                if (customer.GetCustomerPhoneNumber().Equals(phoneNumber))
                {
                    _customerList.Remove(customer);
                    break;
                }
            }
        }

        public static void EditCustomer(TelecomCustomer telecomCustomer)
        {
            foreach (TelecomCustomer customer in _customerList)
            {
                if (customer.CustomerPhoneNumber.Equals(telecomCustomer.CustomerPhoneNumber))
                {
                    customer.CustomerFirstName = telecomCustomer.CustomerFirstName;
                    customer.CustomerLastName = telecomCustomer.CustomerLastName;
                    customer.ExpiryDate = telecomCustomer.ExpiryDate;
                    customer.CustomerSubscriptionType = telecomCustomer.CustomerSubscriptionType;
                    customer.SetAmount(telecomCustomer.GetAmount());
                    break;
                }
            }
        }

        public static BindingList<TelecomCustomer> GetCustomersList()
        {
            return _customerList;
        }

        public static bool CheckPhoneNumberAvailability(string phoneNumber)
        {
            bool resultFlag = true;
            foreach (TelecomCustomer customer in _customerList)
            {
                if (customer.CustomerPhoneNumber.Equals(phoneNumber))
                {
                    resultFlag = false;
                    break;
                }
            }
            return resultFlag;
        }

        public static TelecomCustomer GetCustomer(string phoneNumber)
        {
            foreach (TelecomCustomer customer in _customerList)
            {
                if (customer.CustomerPhoneNumber.Equals(phoneNumber))
                {
                    return customer;
                }
            }
            return null;
        }

        public static bool CheckSubscriptionExistance(string subscription)
        {
            bool checkResult = false;

            foreach (TelecomCustomer customer in _customerList)
            {
                if (customer.CustomerSubscriptionType.Equals(subscription))
                {
                    checkResult = true;
                    break;
                }
            }
            return checkResult;
        }

        public static void EditCustomersSubscription(string oldSubscriptionName, string newSubscriptionName)
        {
            foreach (TelecomCustomer customer in _customerList)
            {
                if (customer.CustomerSubscriptionType.Equals(oldSubscriptionName))
                {
                    customer.CustomerSubscriptionType = newSubscriptionName;
                }
            }
        }

        public static BindingList<TelecomCustomer> SearchResultList(string searchText)
        {
            BindingList<TelecomCustomer> subCustomers = new BindingList<TelecomCustomer>();
            foreach (TelecomCustomer customer in _customerList)
            {
                if (Regex.IsMatch(searchText, "^[a-zA-Z]*$"))
                {
                    if (customer.CustomerFirstName.ToLower().Contains(searchText.ToLower()))
                    {
                        subCustomers.Add(customer);
                    }
                }
                else
                {
                    if (customer.CustomerPhoneNumber.Contains(searchText))
                    {
                        subCustomers.Add(customer);
                    }
                }
            }
            return subCustomers;
        }
    }
}
