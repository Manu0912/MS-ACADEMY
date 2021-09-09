using System;

namespace AgenciaAutos
{
    public class TransientFaultHandlingOptions
    {
        public bool Enabled { get; set; }
        public TimeSpan AutoRetryDelay { get; set; }
    }
}