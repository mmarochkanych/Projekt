using Student_info.Models;
using Student_info.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_info.Web.Models
{
    public class DbUserRepository
    {
        private readonly UsersDbContext _usersDbContext;

        public DbUserRepository(UsersDbContext userDbContext)
        {
            _usersDbContext = userDbContext;
        }

        public IEnumerable<Item> GetAll()
        {
            return _usersDbContext.Users.ToList();
        }

        public void Add(Item item)
        {
            _usersDbContext.Users.AddAsync(item);
            _usersDbContext.SaveChanges();
        }

        public Item Get(int id)
        {
            return _usersDbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var item = _usersDbContext.Users.FirstOrDefault(x => x.Id == id);
            _usersDbContext.Users.Remove(item);
            _usersDbContext.SaveChanges();
        }

        public void Update(Item item)
        {
            var itemupd = _usersDbContext.Users.FirstOrDefault(x => x.Id == item.Id);
            itemupd.FName = item.FName;
            itemupd.LName = item.LName;
            itemupd.Index = item.Index;
            itemupd.Email = item.Email;
            itemupd.Gender = item.Gender;
            itemupd.Email= item.Email;
            itemupd.Password = item.Password;
            itemupd.TelNumber = item.TelNumber;
            itemupd.ImgUrl = item.ImgUrl;
            _usersDbContext.Users.Update(itemupd);
            _usersDbContext.SaveChanges();
        }
    }
}
