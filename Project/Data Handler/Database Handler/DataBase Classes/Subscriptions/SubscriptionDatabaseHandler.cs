using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Project
{
    class SubscriptionDatabaseHandler : ISubscriptionDataLayer
    {
        public SubscriptionDatabaseHandler()
        {
            DatabaseToList();
        }

        private static void DatabaseToList()
        {
            using (TelecomEntities subscriptionEntity = new TelecomEntities())
            {
                foreach (Subscription subscription in subscriptionEntity.Subscriptions.ToList())
                {
                    SubscriptionList.AddSubscriptionToList(new TelecomSubscription(subscription.SubscriptionName, subscription.SubscriptionCode, float.Parse(subscription.SubscriptionFee.ToString()), subscription.SubscriptionPackge));
                }
            }
        }
        public bool CheckSubsciptionCodeAvailability(string code)
        {
            return SubscriptionList.CheckSubsciptionCodeAvailability(code);
        }

        public bool CheckSubscriptionNameAvilability(string subscriptionName, string code)
        {
            return SubscriptionList.CheckSubscriptionNameAvilability(subscriptionName, code);
        }

        public void CreateSubscription(TelecomSubscription telecomSubscription)
        {
            try
            {
                using (TelecomEntities telecomEntity = new TelecomEntities())
                {
                    telecomEntity.Subscriptions.Add(new Subscription
                    {
                        SubscriptionName = telecomSubscription.SubscriptionName,
                        SubscriptionCode = telecomSubscription.SubscriptionCode,
                        SubscriptionFee = telecomSubscription.SubscriptionFee,
                        SubscriptionPackge = telecomSubscription.SubscriptionPackge.ToString()
                    });
                    telecomEntity.SaveChanges();
                }
                SubscriptionList.AddSubscriptionToList(telecomSubscription);
                MessageBox.Show("Added Sucessfully");
                Logger.LogTransactionWritter("Subscription added Sucessfully");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Adding didn't complete please restart The Application");
                Logger.LogTransactionWritter("Subscription adding Process Didn't complete Sucessfully");
            }
        }

        public void DeleteSubscription(string code)
        {
            try
            {
                using (TelecomEntities telecomEntity = new TelecomEntities())
                {
                    Subscription subscription = telecomEntity.Subscriptions.First(subscriptions => subscriptions.SubscriptionCode.Equals(code));
                    if (subscription != null)
                    {
                        telecomEntity.Subscriptions.Remove(subscription);
                        telecomEntity.SaveChanges();
                        SubscriptionList.DeleteSubscription(code);
                    }
                    else
                    {
                        MessageBox.Show("Subscription Not Found, Please Try Again");
                        Logger.LogTransactionWritter("Subscription Deletting Process Didn't Complete, Please Try Again");
                        ReloadSubscriptionList();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Deletting Didn't Complete");
                Logger.LogTransactionWritter("Subscription Deletting Process Didn't Complete");
            }
        }

        public void EditSubscription(TelecomSubscription telecomSubscription)
        {
            try
            {
                using (TelecomEntities telecomEntity = new TelecomEntities())
                {
                    Subscription subscriptionEntity = telecomEntity.Subscriptions.FirstOrDefault(subscription => subscription.SubscriptionCode.Equals(telecomSubscription.SubscriptionCode));

                    if (subscriptionEntity != null)
                    {
                        subscriptionEntity.SubscriptionName = telecomSubscription.SubscriptionName;
                        subscriptionEntity.SubscriptionPackge = telecomSubscription.SubscriptionPackge.ToString();
                        subscriptionEntity.SubscriptionFee = double.Parse(telecomSubscription.SubscriptionFee.ToString());
                        telecomEntity.SaveChanges();
                        SubscriptionList.EditSubscriptionList(telecomSubscription);
                        MessageBox.Show("Editted Sucessfully");
                        Logger.LogTransactionWritter("Subscription Editted Sucessfully");
                    }
                    else
                    {
                        MessageBox.Show("Subscription Not Found, Please Try Again");
                        Logger.LogTransactionWritter("Subscription Not Found, Please Try Again");
                        ReloadSubscriptionList();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Editting Didn't Complete");
                Logger.LogTransactionWritter("Subscription Editting Process Didn't Complete Sucessfully");
            }
        }

        public TelecomSubscription GetSubscription(string code)
        {
            return SubscriptionList.GetSubscription(code);
        }

        public List<string> GetSubscriptionsName()
        {
            return SubscriptionList.GetSubscriptionsName();
        }

        public static void ReloadSubscriptionList()
        {
            SubscriptionList.GetSubscriptionList().Clear();
            DatabaseToList();
        }

        public BindingList<TelecomSubscription> GetSubscriptionsList()
        {
            return SubscriptionList.GetSubscriptionList();
        }
    }
}
