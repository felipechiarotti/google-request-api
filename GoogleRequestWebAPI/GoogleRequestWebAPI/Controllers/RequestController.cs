using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleRequestWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
namespace GoogleRequestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        // GET: api/Request
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Request/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            Request request = new Request(id);
            string html = request.GetData();

            string json = "[";
            Website web;
            while ((web = request.GetWebsite(ref html)) != null)
            {
                json += Newtonsoft.Json.JsonConvert.SerializeObject(web) + ",";
            }
            json = json.Remove(json.Length-1);
            json += "]";
            return json;
        }

        // POST: api/Request
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Request/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
