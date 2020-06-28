using CS321_W4D2_ExerciseLogAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityTypeRepository
    {
        private readonly AppDbContext _activitytypeContext;

        public ActivityTypeRepository(AppDbContext dbContext)
        {
            _activitytypeContext = dbContext;
        }
        public ActivityType Add(ActivityType item)
        {
            _activitytypeContext.ActivityTypes.Add(item);
            _activitytypeContext.SaveChanges();
            return item;
        }

        public ActivityType Get(int id)
        {
            return _activitytypeContext.ActivityTypes
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return (IEnumerable<ActivityType>)_activitytypeContext.ActivityTypes

                .ToList();
        }


        public ActivityType Update(ActivityType updatedActivityType)
        {
            // get the ToDo object in the current list with this id 
            var currentActivityType = _activitytypeContext.ActivityTypes.Find(updatedActivityType.Id);

            // return null if todo to update isn't found
            if (currentActivityType == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _activitytypeContext.Entry(currentActivityType)
                .CurrentValues
                .SetValues(updatedActivityType);

            // update the todo and save
            _activitytypeContext.ActivityTypes.Update(currentActivityType);
            _activitytypeContext.SaveChanges();
            return currentActivityType;
        }

        public void Remove(ActivityType activitytype)
        {
            _activitytypeContext.ActivityTypes.Remove(activitytype);
            _activitytypeContext.SaveChanges();
        }
    }
}
