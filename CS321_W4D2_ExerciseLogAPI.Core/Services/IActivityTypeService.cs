using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System.Collections.Generic;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IActivityTypeService
    {
     

     // create
     ActivityType Add(ActivityType todo);
        // read
        ActivityType Get(int id);
        // update
        ActivityType Update(ActivityType todo);
        // delete
        void Remove(ActivityType todo);
        // list
        IEnumerable<ActivityType> GetAll();
    }
}