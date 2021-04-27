using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public User Add(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();

            return user; 
        }

        public User Get(int id)
        {
            return _appDbContext.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _appDbContext.Users.ToList();
        }

        public void Remove(User user)
        {
            _appDbContext.Users.Remove(user);
            _appDbContext.SaveChanges();
        }

        public User Update(User user)
        {
            var current = Get(user.Id);

            if (current == null)
                return null;

            _appDbContext.Entry(current)
                .CurrentValues
                .SetValues(user);
             
            _appDbContext.SaveChanges();

            return current;
        }
    }
}
