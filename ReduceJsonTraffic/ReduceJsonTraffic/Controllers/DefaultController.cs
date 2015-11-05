using System.Web.Http;
using ReduceJsonTrafficModels;

namespace ReduceJsonTraffic.Controllers
{
    public class DefaultController : ApiController
    {
        // GET api/default
        public Message[] Get()
        {
            var messages = new[]
            {
                Message.Factory(),
                Message.Factory()
            };

            return messages;
        }

        // GET api/default/5
        public Message Get(int id)
        {
            var message = Message.Factory();
            message.AnInt = id;

            return message;
        }
    }
}