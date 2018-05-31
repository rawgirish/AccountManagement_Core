using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManagement_Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;


namespace AccountManagement_Core.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {

            return "Welcome to Contractor Connection's API !";
            
       }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            using (var context = new AM517Context())
            {
                var authorId = new SqlParameter("@Id", id);
                var books = context.TblAccountRep
                    .FromSql("EXEC getAccountRep @Id", authorId)
                    .ToList();

                return Json(books);

            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
