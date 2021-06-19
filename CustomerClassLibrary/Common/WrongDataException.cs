using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CustomerClassLibrary.Common
{
    public class WrongDataException : Exception
    {
       

        public WrongDataException(string message) : base(message)
        {
        }

    }
}
