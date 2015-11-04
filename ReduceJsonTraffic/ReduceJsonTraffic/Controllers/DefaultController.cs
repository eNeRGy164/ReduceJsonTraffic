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
                new Message(),
                new Message()
            };

            return messages;
        }

        // GET api/default/5
        public Message Get(int id)
        {
            var message = new Message
            {
                AnInt = id
            };

            return message;
        }
    }
}