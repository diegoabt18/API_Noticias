using API_Noticias.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Noticias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class newsController : ControllerBase
    {
        // GET: api/<newsController>
        [HttpGet]
        public string Get()
        {
            ImplementSqlDAO impleSQL = new ImplementSqlDAO();
            string json = JsonConvert.SerializeObject(impleSQL.findAll());
            

            return json ;
        }

        // GET api/<newsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<newsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<newsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<newsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
