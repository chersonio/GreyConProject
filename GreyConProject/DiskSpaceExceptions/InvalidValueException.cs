using System;
using System.Collections.Generic;
using System.Text;

namespace GreyConProject.DiskSpaceExceptions
{
    /// <summary>
    /// Write something here
    /// </summary>
    public class InvalidValueException : Exception
    {
        public int InvalidValueIndex { get; set; }

        public DiskSpaceArray InvalidValueArray { get; set; }

        public InvalidValueException(string message, DiskSpaceArray invalidValueArray, int invalidValueIndex) : base(message)
        {
            InvalidValueArray = invalidValueArray;
            InvalidValueIndex = invalidValueIndex;
        }
    }
}
