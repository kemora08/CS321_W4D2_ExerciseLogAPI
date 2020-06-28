using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System.Collections.Generic;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IActivityService
    {
        // CRUDL - create (add), read (get), update, delete (remove), list

        // create
        Activity Add(Activity todo);
        // read
        Activity Get(int id);
        // update
        Activity Update(Activity todo);
        // delete
        void Remove(Activity todo);
        // list
        IEnumerable<Activity> GetAll();
        object GetActivitiesForUser(object userId);
    }
}