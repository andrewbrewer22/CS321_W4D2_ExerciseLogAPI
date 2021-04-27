using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public Activity Add(Activity todo)
        {
            _dbContext.Activities.Add(todo);
            _dbContext.SaveChanges();

            return todo;
        }

        public Activity Get(int id)
        {
            return _dbContext.Activities.Find(id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _dbContext.Activities.ToList();
        }

        public void Remove(Activity todo)
        {
            _dbContext.Activities.Remove(todo);
            _dbContext.SaveChanges();
        }

        public Activity Update(Activity todo)
        {
            var current = _dbContext.Activities.Find(todo.Id);

            if (current == null)
                return null;

            _dbContext.Entry(current)
                .CurrentValues
                .SetValues(todo);

            _dbContext.SaveChanges();

            return current;
        }
    }
}
