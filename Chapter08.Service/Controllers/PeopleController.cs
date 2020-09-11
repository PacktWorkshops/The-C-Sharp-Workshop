using Chapter08.Models;
using Chapter08.Service.Static;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter08.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : Controller
    {
        [HttpGet("{id}")]        
        public IActionResult Get(int id)
        {
            return Ok(JsonFiles.Load<Person>(id));
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            // to keep it simple, we're not paginating results
            var data = JsonFiles.LoadAll<Person>();

            return Ok(new Response<List<Person>>()
            {
                Count = data.Count(),
                Data = data.ToList()
            });
        }

        [HttpPost]
        public IActionResult Post(Person person)
        {
            JsonFiles.Save(person, person.Url);
            return Ok();
        }
    }
}
