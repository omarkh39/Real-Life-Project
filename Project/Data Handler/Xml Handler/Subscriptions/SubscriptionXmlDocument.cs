using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Project
{
    class SubscriptionXmlDocument : ISubscriptionDataLayer
    {
        public static int alive = 0;
        private XmlDocument _subscriptioXmlDocument;
        public static Dictionary<string, string> SubscriptionDicnary = new Dictionary<string, string>();

        private const string XmlPath = @"Subscription.xml";
        private const string XmlStartTag = "Subscriptions";
        private const string XmlParentTag = "Subscription";
        private const string SubscriptionNameTag = "SubscriptionName";
        private const string SubscriptionCodeTag = "SubscriptionCode";
        private const string SubscriptionTypeTag = "SubscriptionType";
        private const string SubscriptionFees = "SubscriptionFees";

        private const string SubscriptionNameTagName = "SubscriptionName";
        private const string CodeTagName = "SubscriptionCode";
        private const string FeesTagName = "SubscriptionFees";
        private const string PackgeTagName = "SubscriptionType";

        public SubscriptionXmlDocument()
        {
            if (alive==0)
            {
                alive++;
                _subscriptioXmlDocument = new XmlDocument();
                CheckXmlExistence();
                XmlToSubscription();
            }
        }

        public List<string> GetXmlSubscriptiontype()
        {
            CheckXmlExistence();
            List<string> xmlSubscriptionList = new List<string>();
            XmlNodeList subscriptionTypeNodeList = _subscriptioXmlDocument.GetElementsByTagName(SubscriptionNameTag);

            foreach (XmlNode subscriptionNode in subscriptionTypeNodeList)
            {
                xmlSubscriptionList.Add(subscriptionNode.InnerText.ToString());
            }
            return xmlSubscriptionList;
        }

        public void CheckXmlExistence()
        {
            FileInfo fileInfo = new FileInfo(XmlPath);

            if (File.Exists(XmlPath) && fileInfo.Length==0)
            {
                using (XmlWriter writer = XmlWriter.Create(XmlPath))
                {
                    writer.WriteStartElement(XmlStartTag);
                    writer.WriteEndElement();
                    writer.Flush();
                }
                _subscriptioXmlDocument.Load(XmlPath);
            }
            else if (File.Exists(XmlPath))
            {
                _subscriptioXmlDocument.Load(XmlPath);
            }
            else
            {
                using (XmlWriter writer = XmlWriter.Create(XmlPath))
                {
                    writer.WriteStartElement(XmlStartTag);
                    writer.WriteEndElement();
                    writer.Flush();
                }
                _subscriptioXmlDocument.Load(XmlPath);
            }
        }

        public void XmlToSubscription()
        {
            XmlNodeList subscriptionsNodeList = _subscriptioXmlDocument.GetElementsByTagName(XmlParentTag);
            foreach (XmlNode subscriptionNode in subscriptionsNodeList)
            {
                XmlNodeList childNodeList = subscriptionNode.ChildNodes;
                TelecomSubscription subscription = new TelecomSubscription();
                foreach (XmlNode childNode in childNodeList)
                {

                    if (childNode.Name.Equals(SubscriptionNameTagName))
                    {
                        subscription.SetSubscriptionName(childNode.InnerText);
                    }
                    else if (childNode.Name.Equals(CodeTagName))
                    {
                        subscription.SetSubscriptionCode(childNode.InnerText);
                    }
                    else if (childNode.Name.Equals(FeesTagName))
                    {
                        subscription.SetSubscriptionFees(float.Parse(childNode.InnerText));
                    }
                    else if (childNode.Name.Equals(PackgeTagName))
                    {
                        if (childNode.InnerText.Equals(TelecomSubscription.PackgeTypeEnum.PostPaid.ToString()))
                        {
                            subscription.SetSubscriptionPackge(TelecomSubscription.PackgeTypeEnum.PostPaid);
                        }
                        else if (childNode.InnerText.Equals(TelecomSubscription.PackgeTypeEnum.PrePaid.ToString()))
                        {
                            subscription.SetSubscriptionPackge(TelecomSubscription.PackgeTypeEnum.PrePaid);
                        }
                        else
                        {
                            MessageBox.Show("Didn't find subscription packge");
                        }
                    }

                }
                SubscriptionList.AddSubscriptionToList(subscription);
                SubscriptionDicnary.Add(subscription.SubscriptionCode, subscription.SubscriptionName);
            }
        }

        public void CreateSubscription(TelecomSubscription telecomSubscription)
        {
            XmlNode subscriptionParentNode = _subscriptioXmlDocument.CreateElement(XmlParentTag);
            XmlNode subscriptionNameNode = _subscriptioXmlDocument.CreateElement(SubscriptionNameTag);
            XmlNode subscriptionCodeNode = _subscriptioXmlDocument.CreateElement(SubscriptionCodeTag);
            XmlNode subscriptionTypeNode = _subscriptioXmlDocument.CreateElement(SubscriptionTypeTag);
            XmlNode subscriptionFeesNode = _subscriptioXmlDocument.CreateElement(SubscriptionFees);

            subscriptionNameNode.InnerText = telecomSubscription.SubscriptionName;
            subscriptionCodeNode.InnerText = telecomSubscription.SubscriptionCode;
            subscriptionTypeNode.InnerText = telecomSubscription.SubscriptionPackge.ToString();
            subscriptionFeesNode.InnerText = telecomSubscription.SubscriptionFee.ToString();

            subscriptionParentNode.AppendChild(subscriptionNameNode);
            subscriptionParentNode.AppendChild(subscriptionCodeNode);
            subscriptionParentNode.AppendChild(subscriptionTypeNode);
            subscriptionParentNode.AppendChild(subscriptionFeesNode);
            _subscriptioXmlDocument.DocumentElement.AppendChild(subscriptionParentNode);

            SubscriptionList.AddSubscriptionToList(telecomSubscription);
            SubscriptionDicnary.Add(telecomSubscription.SubscriptionCode, telecomSubscription.SubscriptionName);
            _subscriptioXmlDocument.Save(XmlPath);
            MessageBox.Show("Added Sucessfully");
            Logger.LogTransactionWritter("Subscription added Sucessfully");
        }

        public void EditSubscription(TelecomSubscription telecomSubscription)
        {
            XmlNodeList subscriptionTypeNodeList = _subscriptioXmlDocument.GetElementsByTagName(CodeTagName);

            foreach (XmlNode subscriptionNode in subscriptionTypeNodeList)
            {
                if (subscriptionNode.InnerText.Equals(telecomSubscription.SubscriptionCode))
                {
                    XmlNodeList subscriptionChildsNodeList = subscriptionNode.ParentNode.ChildNodes;

                    foreach (XmlNode subscriptionChild in subscriptionChildsNodeList)
                    {
                        if (subscriptionChild.Name.Equals(SubscriptionNameTagName))
                        {
                            subscriptionChild.InnerText = telecomSubscription.SubscriptionName;
                        }
                        else if (subscriptionChild.Name.Equals(PackgeTagName))
                        {
                            subscriptionChild.InnerText = telecomSubscription.SubscriptionPackge.ToString();
                        }
                        else if (subscriptionChild.Name.Equals(FeesTagName))
                        {
                            subscriptionChild.InnerText = telecomSubscription.SubscriptionFee.ToString();
                        }
                    }
                    break;
                }

            }
            SubscriptionList.EditSubscriptionList(telecomSubscription);
            SubscriptionDicnary[telecomSubscription.SubscriptionCode] = telecomSubscription.SubscriptionName;
            _subscriptioXmlDocument.Save(XmlPath);
            MessageBox.Show("Editted Sucessfully");
            Logger.LogTransactionWritter("Subscription Editted Sucessfully");
        }

        public void DeleteSubscription(string code)
        {
            XmlNodeList subscriptionTypeNodeList = _subscriptioXmlDocument.GetElementsByTagName(CodeTagName);

            foreach (XmlNode subscriptionNode in subscriptionTypeNodeList)
            {
                if (subscriptionNode.InnerText.Equals(code))
                {
                    subscriptionNode.ParentNode.ParentNode.RemoveChild(subscriptionNode.ParentNode);
                    SubscriptionDicnary.Remove(subscriptionNode.InnerText);
                    break;
                }
            }
            SubscriptionList.DeleteSubscription(code);
            MessageBox.Show("Deleted Sucessfully");
            Logger.LogTransactionWritter("Deleted Sucessfully");
            _subscriptioXmlDocument.Save(XmlPath);
        }

        public bool CheckSubsciptionCodeAvailability(string code)
        {
            return SubscriptionList.CheckSubsciptionCodeAvailability(code);
        }

        public TelecomSubscription GetSubscription(string code)
        {
            return SubscriptionList.GetSubscription(code);
        }

        public List<string> GetSubscriptionsName()
        {
            return SubscriptionList.GetSubscriptionsName();
        }

        public bool CheckSubscriptionNameAvilability(string subscriptionName, string code)
        {
            return SubscriptionList.CheckSubscriptionNameAvilability(subscriptionName, code);
        }

        public BindingList<TelecomSubscription> GetSubscriptionsList()
        {
            return SubscriptionList.GetSubscriptionList();
        }
    }
}
