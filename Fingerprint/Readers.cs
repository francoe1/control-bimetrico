using DPFP.Capture;
using System;
using System.Collections.Generic;

namespace Fingerprint
{
    public static class Readers
    {
        public static ReaderDescription[] Collection { get; private set; }

        public static void Search()
        {
            List<ReaderDescription> availables = new List<ReaderDescription>();
            foreach(KeyValuePair<Guid, ReaderDescription> reader in new ReadersCollection())
            {
                if ((reader.Value.Vendor == "Digital Persona, Inc.") || (reader.Value.Vendor == "DigitalPersona, Inc."))
                {
                    try
                    {
                        new Capture(reader.Value.SerialNumber, Priority.Normal);
                        availables.Add(reader.Value);
                    }
                    catch { continue; }
                }
            }
            Collection = availables.ToArray();
        }
    }
}
