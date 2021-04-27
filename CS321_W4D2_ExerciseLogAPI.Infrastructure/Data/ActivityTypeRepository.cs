using CS321_W4D2_ExerciseLogAPI.Core.Services;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System.Linq;
using System.Collections.Generic;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActivityType Add(ActivityType todo)
        {
            _dbContext.ActivityTypes.Add(todo);
            _dbContext.SaveChanges();

            return todo;
        }

        public ActivityType Get(int id)
        {
            return _dbContext.ActivityTypes.Find(id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return _dbContext.ActivityTypes.ToList();
        }

        public void Remove(ActivityType todo)
        {
            _dbContext.ActivityTypes.Remove(todo);
            _dbContext.SaveChanges();
        }

        public ActivityType Update(ActivityType todo)
        {
            var current = _dbContext.ActivityTypes.Find(todo.Id);

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
