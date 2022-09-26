using System;
using System.Globalization;

namespace Project
{
    public class TelecomCustomer
    {
        public static string DateFormat = "dd/MM/yyyy";
        private DateTime _customerSubscriptionExpirydate;
        private string _customerFirstName;
        private string _customerLastName;
        private string _customerPhonenumber;
        private string _customerSubscriptionType;
        private float _customerAmount;

        public float GetAmount() { return _customerAmount; }
        public void SetAmount(float amount) { _customerAmount = amount; }

        public string CustomerFirstName
        {
            set { this._customerFirstName = value; }
            get { return this._customerFirstName; }
        }

        public string CustomerLastName
        {
            set { this._customerLastName = value; }
            get { return this._customerLastName; }
        }

        public string CustomerPhoneNumber
        {
            set { this._customerPhonenumber = value; }
            get { return this._customerPhonenumber; }
        }

        public string ExpiryDate
        {
            set { this._customerSubscriptionExpirydate = DateTime.ParseExact(value,DateFormat, CultureInfo.InvariantCulture);  }
            get { return this._customerSubscriptionExpirydate.ToString(CustomerXmlDocument.DateFormat); }
        }

        public string CustomerSubscriptionType
        {
            set { this._customerSubscriptionType = value; }
            get { return this._customerSubscriptionType; }
        }

        public TelecomCustomer() { }

        public TelecomCustomer(string customerFirstName, string customerLastName, string customerPhonenumber, float customerAmount, string customerSubscription)
        {
            this._customerFirstName = customerFirstName;
            this._customerLastName = customerLastName;
            this._customerPhonenumber = customerPhonenumber;
            _customerSubscriptionExpirydate = DateTime.Now.AddDays(60);
            this._customerAmount = customerAmount;
            this._customerSubscriptionType = customerSubscription;
        }

        public TelecomCustomer(string customerFirstName, string customerLastName, string customerPhonenumber, float customerAmount, string customerSubscription, DateTime customerSubscriptionExpirydate)
        {
            this._customerFirstName = customerFirstName;
            this._customerLastName = customerLastName;
            this._customerPhonenumber = customerPhonenumber;
            _customerSubscriptionExpirydate = customerSubscriptionExpirydate;
            this._customerAmount = customerAmount;
            this._customerSubscriptionType = customerSubscription;
        }

        public DateTime GetExpiryDate() { return _customerSubscriptionExpirydate; }

        public string GetCustomerPhoneNumber()
        {
            return this._customerPhonenumber;
        }

    }
}
