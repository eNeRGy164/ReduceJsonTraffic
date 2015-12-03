using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Controllers;
using Newtonsoft.Json;
using ReduceJsonTrafficModels;

namespace ReduceJsonTraffic.Controllers
{
    [SkipEmptyCollectionConfig]
    public class SkipEmptyCollectionController : ApiController
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

    public class SkipEmptyCollectionConfigAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            controllerSettings.Formatters.Clear();
            controllerSettings.Formatters.Add(new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                    ContractResolver = new SkipEmptyCollectionsContractResolver()
                }
            });
        }
    }
}