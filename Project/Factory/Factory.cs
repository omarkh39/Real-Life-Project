using System.Configuration;

namespace Project
{
    class Factory
    {
        const string DataSource = "DataSource";
        const string Database = "Database";

        public static ICustomerDataLayer CreateCustomer()
        {
            if (ConfigurationManager.AppSettings[DataSource] == Database)
            {
                return new CustomerDatabaseHandler();
            }
            else
            {
                return new CustomerXmlDocument();
            }
        }

        public static ISubscriptionDataLayer CreateSubscription()
        {
            if (ConfigurationManager.AppSettings[DataSource] == Database)
            {
                return new SubscriptionDatabaseHandler();
            }
            else
            {
                return new SubscriptionXmlDocument();
            }
        }
    }
}
