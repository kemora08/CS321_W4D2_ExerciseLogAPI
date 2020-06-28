using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private IActivityTypeRepository _activitytypeRepo;

        public ActivityTypeService(IActivityTypeRepository activitytypeRepo)
        {
            _activitytypeRepo = activitytypeRepo;
        }
        public ActivityType Add(ActivityType activitytype)
        {
            // TODO: implement add
            _activitytypeRepo.Add(activitytype);
            return activitytype;
        }

        public ActivityType Get(int id)
        {
            // TODO: return the specified ActivityType using Find()
            return _activitytypeRepo.Get(id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            // TODO: return all ActivityType using ToList()
            return _activitytypeRepo.GetAll();
        }


        public ActivityType Update(ActivityType updatedActivitytype)
        {
            // update the todo and save
            var activitytype = _activitytypeRepo.Update(updatedActivitytype);
            return activitytype;
        }

        public void Remove(ActivityType activitytype)
        {
            // TODO: remove the activitytype
            _activitytypeRepo.Remove(activitytype);
        }
    }
}
