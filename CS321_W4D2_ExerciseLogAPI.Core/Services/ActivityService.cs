using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class ActivityService : IActivityService
    {
        private IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public Activity Add(Activity activity)
        {
            return _activityRepository.Add(activity);
        }

        public Activity Get(int id)
        {
            return _activityRepository.Get(id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _activityRepository.GetAll();
        }

        public Activity Update(Activity activity)
        {
            return _activityRepository.Update(activity);
        }

        public void Remove(Activity activity)
        {
            _activityRepository.Remove(activity);
        }
    }
}
