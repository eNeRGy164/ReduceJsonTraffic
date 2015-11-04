using System;

namespace ReduceJsonTrafficModels
{
    public class Message
    {
        public Message()
        {
            SomeObjects = new []
            {
                new SomeObject(),
                new SomeObject { ADouble = 3.14 }
            };
            SomeEmptyObjects = new SomeObject[0];
            SomeUri = new Uri("http://reducejsontraffic.azurewebsites.net/");
            TheDate = DateTime.Now;
        }

        public string AString { get; set; }

        public int AnInt { get; set; }

        public byte? ANullableByte { get; set; }

        public string[] AStringArray { get; set; }

        public Uri NoUri { get; set; }

        public Uri SomeUri { get; set; }

        public DateTime TheDate { get; set; }

        public DateTime ADate { get; set; }

        public SomeObject SingleObject { get; set; }

        public SomeObject[] SomeEmptyObjects { get; set; }

        public SomeObject[] SomeObjects { get; set; }
    }

    public class SomeObject
    {
        public double ADouble { get; set; }
    }
}
