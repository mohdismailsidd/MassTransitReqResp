
using ReqResp.Abstraction.Interface;

namespace ReqResp.Abstraction.Models
{
    public class SimpleResponse :
            ISimpleResponse
    {
        public string CusomerName { get; set; }
    }
}