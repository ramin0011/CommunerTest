using System;

namespace Communer.Core.Models.Excepions
{
    /// A very simple exception class that needs to be extended later
    public class MendixException :Exception
    {
        public MendixException(string message) :base(message)
        {
            
        }
    }
}
