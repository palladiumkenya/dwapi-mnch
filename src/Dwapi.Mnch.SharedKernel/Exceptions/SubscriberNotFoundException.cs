using System;

namespace Dwapi.Mnch.SharedKernel.Exceptions
{
    public class SubscriberNotFoundException : Exception
    {
        public SubscriberNotFoundException(string name) : base($"Subscriber {name} not found")
        {

        }
    }
}