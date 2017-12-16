using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestApiDemo.Types;

namespace RestApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<TestId?> Get()
        {
            return new [] { (TestId?)1, (TestId?)2, (TestId?)null };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IEnumerable<TestId?> Post([FromBody]string value)
        {
            TestId? testId = JsonConvert.DeserializeObject<TestId?>(value);
            // Console.WriteLine($"Got test id: {testId}");
            return new TestId?[] { testId };
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
