// <copyright file="StrongValueTypeAttribute.cs" company="Richard Russell">
// Copyright (c) Richard Russell. All rights reserved.
// Licensed under the MIT license.
// </copyright>

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
