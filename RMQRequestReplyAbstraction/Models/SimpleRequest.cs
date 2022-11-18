// See https://aka.ms/new-console-template for more information

using ReqResp.Abstraction.Interface;

namespace ReqResp.Abstraction.Models
{
    public class SimpleRequest :
                ISimpleRequest
    {
        readonly string _customerId;
        readonly DateTime _timestamp;

        public SimpleRequest(string customerId)
        {
            _customerId = customerId;
            _timestamp = DateTime.UtcNow;
        }

        public DateTime Timestamp
        {
            get { return _timestamp; }
        }

        public string CustomerId
        {
            get { return _customerId; }
        }
    }
}
