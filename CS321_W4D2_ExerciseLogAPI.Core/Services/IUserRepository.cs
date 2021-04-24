using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IUserRepository
    {
        User Add(User user);
        User Get(int id);
        User Update(User user);
        void Remove(User user);
        IEnumerable<User> GetAll();
    }
}
