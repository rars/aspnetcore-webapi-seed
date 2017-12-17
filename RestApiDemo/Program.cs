// <copyright file="Program.cs" company="Richard Russell">
// Copyright (c) Richard Russell. All rights reserved.
// Licensed under the MIT license.
// </copyright>

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace RestApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
