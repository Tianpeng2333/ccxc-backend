﻿using Newtonsoft.Json;
using System;

namespace Ccxc.Core.Utils.ExtensionFunctions
{
    public class UnixTimestampConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long objectValue = (long)reader.Value;
            return UnixTimestamp.FromTimestamp(objectValue);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTime dt = (DateTime)value;
            writer.WriteValue(UnixTimestamp.GetTimestamp(dt));
        }
    }
}
