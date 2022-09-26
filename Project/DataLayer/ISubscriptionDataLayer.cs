using System.Collections.Generic;
using System.ComponentModel;

namespace Project
{
    interface ISubscriptionDataLayer
    {
        // Create
        void CreateSubscription(TelecomSubscription subscription);

        // Update
        void EditSubscription(TelecomSubscription subscription);

        // Delete
        void DeleteSubscription(string phoneNumber);

        // Retrieve
        TelecomSubscription GetSubscription(string code);

        bool CheckSubsciptionCodeAvailability(string code);

        List<string> GetSubscriptionsName();

        bool CheckSubscriptionNameAvilability(string subscriptionName, string code);

        BindingList<TelecomSubscription> GetSubscriptionsList();
    }
}
