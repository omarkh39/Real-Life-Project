using System.ComponentModel;

namespace Project
{
    interface ICustomerDataLayer
    {
        // Create
        void CreateCustomer(TelecomCustomer customer);

        // Retrieve
        TelecomCustomer GetCustomer(string phoneNumber);

        // Update
        void EditCustomer(TelecomCustomer customer);

        // Delete
        void DeleteCustomer(string phoneNumber);

        bool CheckPhoneNumberAvailability(string phoneNumber);

        bool CheckSubscriptionExistance(string subscription);

        BindingList<TelecomCustomer> SearchResultList(string searchText);

        void EditCustomersSubscription(string oldSubscriptionName, string newSubscriptionName);

        BindingList<TelecomCustomer> GetCustomerList();

    }
}
