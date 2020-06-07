using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_info.Models;
using Student_info.Web.Data;
using Student_info.Web.Models;

namespace Student_info.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly DbUserRepository ItemRepository;
        private readonly UsersDbContext _dbContext;


        public ItemController(DbUserRepository DbUsersRepository, UsersDbContext usersDbContext)
        {
            ItemRepository = DbUsersRepository;
            _dbContext = usersDbContext;
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return ItemRepository.GetAll().ToList();
        }
        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public Item Get(int id)
        {
            return ItemRepository.Get(id);
        }
        // POST: api/Students
        [HttpPost]
        public void Post([FromBody] Item item)
        {


            ItemRepository.Add(item);
        }
        // PUT: api/Students/5
        [HttpPut]
        public void Put([FromBody] Item value)
        {
            ItemRepository.Update(value);
           
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ItemRepository.Remove(id);

        }
    }
}
