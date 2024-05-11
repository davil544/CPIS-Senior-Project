using System;

namespace CPIS_Senior_Project.DataModels
{
    public class Message
    {
        public int ID { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string MessageContents { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}