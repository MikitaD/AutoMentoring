using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace AirCompanyTest
{
    public class MenyEntryOutOfRangeException: Exception
    {
        public MenyEntryOutOfRangeException()
        {
        }

        public MenyEntryOutOfRangeException(string message)
        : base(message)
        {
        }
        public MenyEntryOutOfRangeException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

}
