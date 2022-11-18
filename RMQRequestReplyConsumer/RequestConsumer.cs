using MassTransit;
using ReqResp.Abstraction.Models;
using ReqResp.Abstraction.Interface;

namespace ReqResp.Consumer
{
    public class RequestConsumer :
            IConsumer<ISimpleRequest>
    {
        public async Task Consume(ConsumeContext<ISimpleRequest> context)
        {
            Console.WriteLine("Returning name for {0}", context.Message.CustomerId);

            Console.WriteLine("Customer Number for Cust-{0}", context.Message.CustomerId);
            await context.RespondAsync(new SimpleResponse
            {
                CusomerName = string.Format("Customer Number Cust-{0}", context.Message.CustomerId)
            });
            if (context.IsResponseAccepted<ISimpleResponse>())
                Console.WriteLine("Accepted");
            else
                Console.WriteLine("Not Accepted");
        }
    }
}