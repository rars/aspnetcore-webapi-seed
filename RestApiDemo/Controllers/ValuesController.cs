// <copyright file="ValuesController.cs" company="Richard Russell">
// Copyright (c) Richard Russell. All rights reserved.
// Licensed under the MIT license.
// </copyright>

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestApiDemo.Types;

namespace RestApiDemo.Controllers
{
    /// <summary>
    /// Test controller.
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns>TestIds</returns>
        [HttpGet]
        public IEnumerable<TestId?> Get()
        {
            return new[] { (TestId?)1, (TestId?)2, (TestId?)null };
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id">Unused</param>
        /// <returns>Value</returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// POST api/values
        /// </summary>
        /// <param name="value">TestId</param>
        /// <returns>TestId passed in.</returns>
        [HttpPost]
        public IEnumerable<TestId?> Post([FromBody]string value)
        {
            TestId? testId = JsonConvert.DeserializeObject<TestId?>(value);

            // Console.WriteLine($"Got test id: {testId}");
            return new TestId?[] { testId };
        }

        /// <summary>
        /// PUT api/values/5
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="value">Value</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// DELETE api/values/5
        /// </summary>
        /// <param name="id">Id</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
