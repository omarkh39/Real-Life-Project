namespace Project
{
    public class TelecomSubscription
    {
        public enum PackgeTypeEnum { PostPaid, PrePaid }
        private string _subscriptionName;
        private string _subcriptionCode;
        private float _subscriptionFees;
        public PackgeTypeEnum _packgeType;

        public string SubscriptionName
        {
            get { return this._subscriptionName; }
            set { this._subscriptionName = value; }
        }
        public string SubscriptionCode
        {
            get { return this._subcriptionCode; }
            set { this._subcriptionCode = value; }
        }

        public PackgeTypeEnum SubscriptionPackge
        {
            get { return this._packgeType; }
            set { this._packgeType = value; }
        }
        public float SubscriptionFee
        {
            get { return this._subscriptionFees; }
            set { this._subscriptionFees = value; }
        }
        public TelecomSubscription() { }

        public TelecomSubscription(string name, string code, float fees, string packge)
        {
            this._subscriptionName = name;
            this._subcriptionCode = code;
            this._subscriptionFees = fees;
            if (packge == PackgeTypeEnum.PostPaid.ToString())
            {
                this._packgeType = PackgeTypeEnum.PostPaid;
            }
            else
            {
                this._packgeType = PackgeTypeEnum.PrePaid;
            }
        }

        public void SetSubscriptionName(string subscriptionName) { _subscriptionName = subscriptionName; }
        public void SetSubscriptionFees(float subscriptionFees) { _subscriptionFees = subscriptionFees; }
        public void SetSubscriptionCode(string subscriptionCode) { _subcriptionCode = subscriptionCode; }
        public void SetSubscriptionPackge(PackgeTypeEnum packgeType) { _packgeType = packgeType; }
    }
}
