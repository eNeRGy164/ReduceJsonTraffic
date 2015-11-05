using System;
using System.ComponentModel;

namespace ReduceJsonTrafficModels
{
    public class Message
    {
        public string AString { get; set; }

        public int AnInt { get; set; }

        [DefaultValue(14)]
        public int Fourteen { get; set; }

        public byte? ANullableByte { get; set; }

        public string[] AStringArray { get; set; }

        public Uri NoUri { get; set; }

        public Uri SomeUri { get; set; }

        public DateTime TheDate { get; set; }

        public DateTime AnEmptyDate { get; set; }

        public DateTime AFixedDate { get; set; }

        public SomeObject SingleObject { get; set; }

        public SomeObject[] SomeEmptyObjects { get; set; }

        public SomeObject[] SomeObjects { get; set; }

        public static Message Factory()
        {
            return new Message
            {
                SomeObjects = new[]
                {
                    new SomeObject(),
                    new SomeObject { ADouble = 3.14 },
                    new SomeObject { ADouble = 1.23456789 }
                },
                Fourteen = 14,
                SomeEmptyObjects = new SomeObject[0],
                SomeUri = new Uri("http://reducejsontraffic.azurewebsites.net/api/"),
                TheDate = DateTime.Now,
                AFixedDate = new DateTime(2015, 7, 2, 13, 14, 0, DateTimeKind.Local)
            };
        }
    }

    public class SomeObject
    {
        [DefaultValue(3.14)]
        public double ADouble { get; set; }
    }
}
