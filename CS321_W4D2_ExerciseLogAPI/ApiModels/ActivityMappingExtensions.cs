using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public static class ActivityMappingExtenstions
    {

        public static ActivityModel ToApiModel(this Activity activity)
        {
            return new ActivityModel
            {
                Id = activity.Id,
                Date = activity.Date,
                ActivityTypeId = activity.ActivityTypeId,
                ActivityType = activity.ActivityType.Name,
                Duration = activity.Duration,
                Distance = activity.Distance,
                UserId = activity.UserId,
                User = activity.User.Name,
                Notes = activity.Notes,
            };
        }

        public static Activity ToDomainModel(this ActivityModel activityModel)
        {
            return new Activity
            {
                Id = activityModel.Id,
                Date = activityModel.Date,
                ActivityTypeId = activityModel.ActivityTypeId,
                Duration = activityModel.Duration,
                Distance = activityModel.Distance,
                UserId = activityModel.UserId,
                User = null,
                Notes = activityModel.Notes,
                // TODO: fill in property mappings
                // TODO: leave User and ActivityType null
            };
        }

        public static IEnumerable<ActivityModel> ToApiModels(this IEnumerable<Activity> activities)
        {
            return activities.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Activity> ToDomainModels(this IEnumerable<ActivityModel> activityModels)
        {
            return activityModels.Select(a => a.ToDomainModel());
        }
    }
}
