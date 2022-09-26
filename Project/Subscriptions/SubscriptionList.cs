using System.Collections.Generic;
using System.ComponentModel;

namespace Project
{
    static class SubscriptionList
    {
        static private BindingList<TelecomSubscription> _subscriptionsList = new BindingList<TelecomSubscription>();

        public static TelecomSubscription GetSubscription(string code)
        {
            TelecomSubscription telecomSubscription = null;
            foreach (TelecomSubscription subscription in _subscriptionsList)
            {
                if (subscription.SubscriptionCode.ToString().Equals(code))
                {
                    telecomSubscription = subscription;
                    break;
                }
            }
            return telecomSubscription;
        }

        public static List<string> GetSubscriptionsName()
        {
            List<string> subscriptionNameList = new List<string>();

            foreach (TelecomSubscription subscription in _subscriptionsList)
            {
                subscriptionNameList.Add(subscription.SubscriptionName);
            }
            return subscriptionNameList;
        }

        public static void EditSubscriptionList(TelecomSubscription telecomSubscription)
        {
            foreach (TelecomSubscription subscription in _subscriptionsList)
            {
                if (subscription.SubscriptionCode.Equals(telecomSubscription.SubscriptionCode))
                {
                    subscription.SubscriptionName = telecomSubscription.SubscriptionName;
                    subscription.SubscriptionFee = telecomSubscription.SubscriptionFee;
                    if (telecomSubscription.SubscriptionPackge.Equals(TelecomSubscription.PackgeTypeEnum.PostPaid))
                        subscription.SubscriptionPackge = TelecomSubscription.PackgeTypeEnum.PostPaid;
                    else
                        subscription.SubscriptionPackge = TelecomSubscription.PackgeTypeEnum.PrePaid;
                    break;
                }
            }
        }

        public static void DeleteSubscription(string code)
        {
            foreach (TelecomSubscription customer in _subscriptionsList)
            {
                if (customer.SubscriptionCode.ToString().Equals(code))
                {
                    _subscriptionsList.Remove(customer);
                    break;
                }
            }
        }

        public static bool CheckSubscriptionNameAvilability(string subscriptionName, string code)
        {
            bool result = true;
            foreach (TelecomSubscription subscription in _subscriptionsList)
            {
                if (subscription.SubscriptionName.Equals(subscriptionName) && !subscription.SubscriptionCode.ToString().Equals(code))
                {
                    result = false;
                    break;
                }

            }
            return result;
        }

        public static bool CheckSubsciptionCodeAvailability(string code)
        {
            bool avilabilityFlag = true;
            foreach (TelecomSubscription subscription in _subscriptionsList)
            {
                if (subscription.SubscriptionCode.ToString().Equals(code))
                {
                    avilabilityFlag = false;
                    break;
                }
            }
            return avilabilityFlag;
        }

        public static void AddSubscriptionToList(TelecomSubscription subscription)
        {
            _subscriptionsList.Add(subscription);
        }

        public static BindingList<TelecomSubscription> GetSubscriptionList()
        {
            return _subscriptionsList;
        }

    }
}
