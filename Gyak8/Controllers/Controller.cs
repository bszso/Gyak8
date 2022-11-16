﻿using Microsoft.AspNetCore.Mvc;
using Gyak8.JokeModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gyak8.Controllers
{
    [Route("api/jokes")]
    [ApiController]
    public class Controller : ControllerBase
    {
        // GET: api/jokes
        [HttpGet]
        public IActionResult Get()
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            return Ok(context.Jokes.ToList());
        }

        // GET api/jokes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            var keresettVicc = (from x in context.Jokes
                                where x.JokeSk == id
                                select x).FirstOrDefault();
            if (keresettVicc == null)
            {
                return NotFound($"Nincs #{id} azonosítóval vicc az adatbázisban");
            }
            else
            {
                return Ok(keresettVicc);
            }
        }

        // POST api/jokes
        [HttpPost]
        public void Post([FromBody] Joke újVicc)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            context.Jokes.Add(újVicc);
            context.SaveChanges();
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/jokes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            var törlenőVicc = (from x in context.Jokes
                               where x.JokeSk == id
                               select x).FirstOrDefault();
            context.Remove(törlenőVicc);
            context.SaveChanges();
        }


    }
}