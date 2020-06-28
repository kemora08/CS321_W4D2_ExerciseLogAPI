using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _userContext;

        public UserRepository(AppDbContext dbContext)
        {
            _userContext = dbContext;
        }
        public User Add(User item)
        {
            _userContext.Users.Add(item);
            _userContext.SaveChanges();
            return item;
        }

        public User Get(int id)
        {
            return _userContext.Users
                .Include(b => b.Activities)
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users
                .Include(b => b.Activities)
                .ToList();
        }

    

        public User Update(User updatedUser)
        {
            // get the ToDo object in the current list with this id 
            var currentUser = _userContext.Users.Find(updatedUser.Id);

            // return null if todo to update isn't found
            if (currentUser == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _userContext.Entry(currentUser)
                .CurrentValues
                .SetValues(updatedUser);

            // update the todo and save
            _userContext.Users.Update(currentUser);
            _userContext.SaveChanges();
            return currentUser;
        }

        public void Remove(User user)
        {
            _userContext.Users.Remove(user);
            _userContext.SaveChanges();
        }

        User IUserRepository.Add(User todo)
        {
            throw new NotImplementedException();
        }

        User IUserRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUserRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        void IUserRepository.Remove(User todo)
        {
            throw new NotImplementedException();
        }

        User IUserRepository.Update(User todo)
        {
            throw new NotImplementedException();
        }
    }
}
