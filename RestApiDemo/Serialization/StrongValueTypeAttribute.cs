using System;

namespace RestApiDemo.Serialization
{
    public sealed class StrongValueTypeAttribute : Attribute
    {
        public StrongValueTypeAttribute(Type valueType)
            : base()
        {
            ValueType = valueType;
        }

        public Type ValueType { get; }
    }
}
