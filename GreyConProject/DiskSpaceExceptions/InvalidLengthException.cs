using System;
using System.Collections.Generic;
using System.Text;

namespace GreyConProject.DiskSpaceExceptions
{
    public class InvalidLengthException : Exception
    {
        public InvalidLengthException(string message) : base(message)
        {

        }
    }
}
