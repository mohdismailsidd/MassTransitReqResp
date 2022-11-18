// See https://aka.ms/new-console-template for more information

namespace ReqResp.Abstraction.Interface
{
    public interface ISimpleRequest
    {
        /// <summary>
        /// When the request was created
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The customer id for the request (or whatever data you want here)
        /// </summary>
        string CustomerId { get; }
    }
}
