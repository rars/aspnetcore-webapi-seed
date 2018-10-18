// <copyright file="RestApiDemoAutofacModule.cs" company="Richard Russell">
// Copyright (c) Richard Russell. All rights reserved.
// Licensed under the MIT license.
// </copyright>

using Autofac;
using Serilog;

namespace RestApiDemo.DI
{
    public class RestApiDemoAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c, p) => Log.Logger).SingleInstance();
        }
    }
}
