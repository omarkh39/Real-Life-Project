using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml;

namespace Project
{
    class CustomerXmlDocument : ICustomerDataLayer
    {
        private XmlDocument _customersXmlDocument = new XmlDocument();

        private const string XmlPath = @"Customers.xml";
        private const string XmlStartTag = "Customers";
        private const string ParentTag = "Customer";
        private const string FirstNameTag = "CustomerFirstName";
        private const string LastNameTag = "CustomerLastName";
        private const string MobileNumber = "MobileNumber";
        private const string ExpiryDate = "ExpiryDate";
        private const string Amount = "Amount";
        private const string SubscriptionType = "SubscriptionType";
        public static string DateFormat = "dd/MM/yyyy";

        private const string FirstNameTagName = "CustomerFirstName";
        private const string LastNameTagName = "CustomerLastName";
        private const string PhoneNumberTagName = "MobileNumber";
        private const string ExpiryDateTagName = "ExpiryDate";
        private const string AmountTagName = "Amount";
        private const string SubscriptionCodeTagName = "SubscriptionCode";

        public CustomerXmlDocument()
        {
            CheckXmlExistence();
            XmlToCustomer();
        }

        public void CheckXmlExistence()
        {
            if (File.Exists(XmlPath))
            {
                _customersXmlDocument.Load(XmlPath);
            }
            else
            {
                using (XmlWriter writer = XmlWriter.Create(XmlPath))
                {
                    writer.WriteStartElement(XmlStartTag);
                    writer.WriteEndElement();
                    writer.Flush();
                }
                _customersXmlDocument.Load(XmlPath);
            }
        }

        public void XmlToCustomer()
        {
            XmlNodeList customersNodeList = _customersXmlDocument.GetElementsByTagName(ParentTag);
            foreach (XmlNode customerNode in customersNodeList)
            {
                TelecomCustomer customer = new TelecomCustomer();

                XmlNodeList childNodeList = customerNode.ChildNodes;
                foreach (XmlNode childNode in childNodeList)
                {
                    if (childNode.Name.Equals(FirstNameTagName))
                    {
                        customer.CustomerFirstName = childNode.InnerText;
                    }
                    else if (childNode.Name.Equals(LastNameTagName))
                    {
                        customer.CustomerLastName = childNode.InnerText;
                    }
                    else if (childNode.Name.Equals(PhoneNumberTagName))
                    {
                        customer.CustomerPhoneNumber = childNode.InnerText;
                    }
                    else if (childNode.Name.Equals(ExpiryDateTagName))
                    {
                        customer.ExpiryDate = childNode.InnerText.ToString();
                    }
                    else if (childNode.Name.Equals(AmountTagName))
                    {
                        customer.SetAmount(float.Parse(childNode.InnerText));
                    }
                    else if (childNode.Name.Equals(SubscriptionCodeTagName))
                    {
                        customer.CustomerSubscriptionType = SubscriptionXmlDocument.SubscriptionDicnary[childNode.InnerText];
                    }
                }
                CustomerList.AddCustomer(customer);
                Logger.LogTransactionWritter("Customer Added Sucessfully To Xml");
            }
        }

        public void CreateCustomer(TelecomCustomer customer)
        {
            XmlNode customerParentNode = _customersXmlDocument.CreateElement(ParentTag);
            XmlNode customerFirstNameNode = _customersXmlDocument.CreateElement(FirstNameTag);
            XmlNode customerLastNameNode = _customersXmlDocument.CreateElement(LastNameTag);
            XmlNode customerMobileNumberNode = _customersXmlDocument.CreateElement(MobileNumber);
            XmlNode customerexpiryDateNode = _customersXmlDocument.CreateElement(ExpiryDate);
            XmlNode customerAmountNode = _customersXmlDocument.CreateElement(Amount);
            XmlNode customerSubscriptionNode = _customersXmlDocument.CreateElement(SubscriptionType);

            customerFirstNameNode.InnerText = customer.CustomerFirstName;
            customerLastNameNode.InnerText = customer.CustomerLastName;
            customerMobileNumberNode.InnerText = customer.GetCustomerPhoneNumber();
            customerexpiryDateNode.InnerText = customer.ExpiryDate;
            customerAmountNode.InnerText = customer.GetAmount().ToString();
            customerSubscriptionNode.InnerText = customer.CustomerSubscriptionType;

            customerParentNode.AppendChild(customerFirstNameNode);
            customerParentNode.AppendChild(customerLastNameNode);
            customerParentNode.AppendChild(customerMobileNumberNode);
            customerParentNode.AppendChild(customerexpiryDateNode);
            customerParentNode.AppendChild(customerAmountNode);
            customerParentNode.AppendChild(customerSubscriptionNode);
            _customersXmlDocument.DocumentElement.AppendChild(customerParentNode);

            CustomerList.AddCustomer(customer);
            _customersXmlDocument.Save(XmlPath);
        }

        public void DeleteCustomer(string phoneNumber)
        {
            XmlNodeList customersNodeList = _customersXmlDocument.GetElementsByTagName(PhoneNumberTagName);
            foreach (XmlNode customerNode in customersNodeList)
            {
                if (customerNode.InnerText.Equals(phoneNumber))
                {
                    customerNode.ParentNode.ParentNode.RemoveChild(customerNode.ParentNode);
                    break;
                }
            }
            CustomerList.DeleteCustomerFromList(phoneNumber);
            _customersXmlDocument.Save(XmlPath);
        }

        public bool CheckPhoneNumberAvailability(string phoneNumber)
        {
            return CustomerList.CheckPhoneNumberAvailability(phoneNumber);
        }

        public TelecomCustomer GetCustomer(string phoneNumber)
        {
            return CustomerList.GetCustomer(phoneNumber);
        }

        public bool CheckSubscriptionExistance(string subscription)
        {
            return CustomerList.CheckSubscriptionExistance(subscription);
        }

        public BindingList<TelecomCustomer> SearchResultList(string searchText)
        {
            return CustomerList.SearchResultList(searchText);
        }

        public void EditCustomersSubscription(string oldSubscriptionName, string newSubscriptionName)
        {
            CustomerList.EditCustomersSubscription(oldSubscriptionName, newSubscriptionName);
        }

        public void EditCustomer(TelecomCustomer customer)
        {
            XmlNodeList customerNodeList = _customersXmlDocument.GetElementsByTagName(PhoneNumberTagName);

            foreach (XmlNode customerNode in customerNodeList)
            {
                if (customerNode.InnerText.Equals(customer.CustomerPhoneNumber))
                {
                    XmlNodeList customerChildsNodeList = customerNode.ParentNode.ChildNodes;

                    foreach (XmlNode customerChild in customerChildsNodeList)
                    {
                        if (customerChild.Name.Equals(FirstNameTagName))
                        {
                            customerChild.InnerText = customer.CustomerFirstName;
                        }
                        else if (customerChild.Name.Equals(LastNameTagName))
                        {
                            customerChild.InnerText = customer.CustomerLastName;
                        }
                        else if (customerChild.Name.Equals(AmountTagName))
                        {
                            customerChild.InnerText = customer.GetAmount().ToString();
                        }
                        else if (customerChild.Name.Equals(ExpiryDateTagName))
                        {
                            customerChild.InnerText = customer.ExpiryDate;
                        }
                        else if (customerChild.Name.Equals(SubscriptionCodeTagName))
                        {
                            customerChild.InnerText = SubscriptionXmlDocument.SubscriptionDicnary.FirstOrDefault(dictionary => dictionary.Value.Equals(customer.CustomerSubscriptionType)).Key;
                        }
                    }
                    break;
                }
            }
            CustomerList.EditCustomer(customer);

            _customersXmlDocument.Save(XmlPath);
        }

        public BindingList<TelecomCustomer> GetCustomerList()
        {
            return CustomerList.GetCustomersList();
        }
    }
}