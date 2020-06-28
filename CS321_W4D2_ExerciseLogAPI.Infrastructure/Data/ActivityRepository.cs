using CS321_W4D2_ExerciseLogAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository
    {
        private readonly AppDbContext _activityContext;

        public ActivityRepository(AppDbContext dbContext)
        {
            _activityContext = dbContext;
        }
        public Activity Add(Activity item)
        {
            _activityContext.Activities.Add(item);
            _activityContext.SaveChanges();
            return item;
        }

        public Activity Get(int id)
        {
            return _activityContext.Activities
                .Include(b => b.ActivityType)
                .Include(b => b.User)
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return (IEnumerable<Activity>)_activityContext.ActivityTypes
                .Include(b => b.ActivityType)
                .Include(b => b.User)
                .ToList();
        }



        public Activity Update(Activity updatedActivity)
        {
            // get the ToDo object in the current list with this id 
            var currentActivity = _activityContext.Activities.Find(updatedActivity.Id);

            // return null if todo to update isn't found
            if (currentActivity == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _activityContext.Entry(currentActivity)
                .CurrentValues
                .SetValues(updatedActivity);

            // update the todo and save
            _activityContext.Activities.Update(currentActivity);
            _activityContext.SaveChanges();
            return currentActivity;
        }

        public void Remove(Activity activity)
        {
            _activityContext.Activities.Remove(activity);
            _activityContext.SaveChanges();
        }

    }
}
