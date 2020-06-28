using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public User Add(User user)
        {
            // TODO: implement add
            _userRepo.Add(user);
            return user;
        }

        public User Get(int id)
        {
            // TODO: return the specified User using Find()
            return _userRepo.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            // TODO: return all User using ToList()
            return _userRepo.GetAll();
        }

     

        public User Update(User updatedUser)
        {
            // update the todo and save
            var user = _userRepo.Update(updatedUser);
            return user;
        }

        public void Remove(User user)
        {
            // TODO: remove the user
            _userRepo.Remove(user);
        }
    }
}
