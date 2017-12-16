using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace RestApiDemo.Serialization
{
    public class StrongValueTypeJsonConverter : JsonConverter
    {
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            Type valueType = value.GetType();
            StrongValueTypeAttribute valueTypeAttribute = GetStrongValueTypeAttribute(value.GetType());

            if (valueTypeAttribute.ValueType == typeof(int))
            {
                MethodInfo cast = valueType.GetMethod("op_Explicit", new Type[] { valueType });
                int intValue = (int)cast.Invoke(null, new object[] { value });
                writer.WriteValue(intValue);
            }
            else if (valueTypeAttribute.ValueType == typeof(long))
            {
                MethodInfo cast = valueType.GetMethod("op_Explicit", new Type[] { valueType });
                long longValue = (long)cast.Invoke(null, new object[] { value });
                writer.WriteValue(longValue);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            Type strongType;
            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                strongType = Nullable.GetUnderlyingType(objectType);
            }
            else
            {
                strongType = objectType;
            }

            StrongValueTypeAttribute valueTypeAttribute = GetStrongValueTypeAttribute(strongType);
            if (valueTypeAttribute.ValueType == typeof(int))
            {
                long? longValue = (long?)reader.Value;
                return CastToNullableStrongType(strongType, (int?)longValue);
            }
            else if (valueTypeAttribute.ValueType == typeof(long))
            {
                long? longValue = (long?)reader.Value;
                return CastToNullableStrongType(strongType, longValue);
            }
            throw new NotImplementedException();
        }
        
        public override bool CanConvert(
            Type objectType)
        {
            return GetStrongValueTypeAttribute(objectType) != null;
        }

        private static object CastToNullableStrongType<T>(
            Type strongType,
            T? primitiveValue) where T : struct
        {
            if (primitiveValue.HasValue)
            {
                return CastToStrongType(strongType, primitiveValue.Value);
            }
            else
            {
                return CreateNullStrongType(strongType);
            }
        }

        private static object CastToStrongType<T>(
            Type strongType,
            T primitiveValue)
        {
            MethodInfo cast = strongType.GetMethod("op_Explicit", new Type[] { typeof(T) });
            return cast.Invoke(null, new object[] { primitiveValue });
        }

        private static object CreateNullStrongType(
            Type strongType)
        {
            Type nullableType = typeof(Nullable<>).MakeGenericType(strongType);
            return Activator.CreateInstance(nullableType);
        }

        private static StrongValueTypeAttribute GetStrongValueTypeAttribute(
            Type objectType)
        {
            return objectType.GetCustomAttributes(true)
                .Where(x => x.GetType() == typeof(StrongValueTypeAttribute))
                .Cast<StrongValueTypeAttribute>()
                .FirstOrDefault();
        }
    }
}
