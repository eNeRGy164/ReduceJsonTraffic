using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Controllers;
using Newtonsoft.Json;
using ReduceJsonTrafficModels;

namespace ReduceJsonTraffic.Controllers
{
    [DefaultValueHandlingConfig]
    public class DefaultValueHandlingController : ApiController
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

    public class DefaultValueHandlingConfigAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            controllerSettings.Formatters.Clear();
            controllerSettings.Formatters.Add(new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
                }
            });
        }
    }
}