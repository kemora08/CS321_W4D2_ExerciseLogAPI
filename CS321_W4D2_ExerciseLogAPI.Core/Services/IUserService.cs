using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System.Collections.Generic;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IUserService
    {
        // CRUDL - create (add), read (get), update, delete (remove), list

        // create
        User Add(User todo);
        // read
        User Get(int id);
        // update
        User Update(User todo);
        // delete
        void Remove(User todo);
        // list
        IEnumerable<User> GetAll();
    }
}