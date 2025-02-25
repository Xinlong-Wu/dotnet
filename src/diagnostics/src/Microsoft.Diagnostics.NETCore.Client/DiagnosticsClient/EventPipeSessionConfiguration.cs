// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Diagnostics.NETCore.Client
{
    internal enum EventPipeSerializationFormat
    {
        NetPerf,
        NetTrace
    }

    internal class EventPipeSessionConfiguration
    {
        public EventPipeSessionConfiguration(int circularBufferSizeMB, EventPipeSerializationFormat format, IEnumerable<EventPipeProvider> providers, bool requestRundown = true)
        {
            if (circularBufferSizeMB == 0)
            {
                throw new ArgumentException($"Buffer size cannot be zero.");
            }

            if (format is not EventPipeSerializationFormat.NetPerf and not EventPipeSerializationFormat.NetTrace)
            {
                throw new ArgumentException("Unrecognized format");
            }

            if (providers is null)
            {
                throw new ArgumentNullException(nameof(providers));
            };

            CircularBufferSizeInMB = circularBufferSizeMB;
            Format = format;
            RequestRundown = requestRundown;
            _providers = new List<EventPipeProvider>(providers);
        }

        public bool RequestRundown { get; }
        public int CircularBufferSizeInMB { get; }
        public EventPipeSerializationFormat Format { get; }

        public IReadOnlyCollection<EventPipeProvider> Providers => _providers.AsReadOnly();

        private readonly List<EventPipeProvider> _providers;

        public byte[] SerializeV2()
        {
            byte[] serializedData = null;
            using (MemoryStream stream = new())
            using (BinaryWriter writer = new(stream))
            {
                writer.Write(CircularBufferSizeInMB);
                writer.Write((uint)Format);
                writer.Write(RequestRundown);

                writer.Write(Providers.Count);
                foreach (EventPipeProvider provider in Providers)
                {
                    writer.Write(provider.Keywords);
                    writer.Write((uint)provider.EventLevel);

                    writer.WriteString(provider.Name);
                    writer.WriteString(provider.GetArgumentString());
                }

                writer.Flush();
                serializedData = stream.ToArray();
            }

            return serializedData;
        }


    }
}
