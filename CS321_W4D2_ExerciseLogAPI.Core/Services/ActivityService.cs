using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class ActivityService : IActivityService
    {
        private IActivityRepository _activityRepo;

        public ActivityService(IActivityRepository activitytypeRepo)
        {
            _activityRepo = activitytypeRepo;
        }
        public Activity Add(Activity activity)
        {
            // TODO: implement add
            _activityRepo.Add(activity);
            return activity;
        }

        public Activity Get(int id)
        {
            // TODO: return the specified Activity using Find()
            return _activityRepo.Get(id);
        }

        public IEnumerable<Activity> GetAll()
        {
            // TODO: return all Activity using ToList()
            return _activityRepo.GetAll();
        }

       

        public Activity Update(Activity updatedActivity)
        {
            // update the todo and save
            var activity = _activityRepo.Update(updatedActivity);
            return activity;
        }

        public void Remove(Activity activity)
        {
            // TODO: remove the activty
            _activityRepo.Remove(activity);
        }

        Activity IActivityService.Add(Activity todo)
        {
            throw new NotImplementedException();
        }

        Activity IActivityService.Get(int id)
        {
            throw new NotImplementedException();
        }

        Activity IActivityService.Update(Activity todo)
        {
            throw new NotImplementedException();
        }

        void IActivityService.Remove(Activity todo)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Activity> IActivityService.GetAll()
        {
            throw new NotImplementedException();
        }

        object IActivityService.GetActivitiesForUser(object userId)
        {
            throw new NotImplementedException();
        }
    }
}
