﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(int userId)
        {
            return _userDal.Get(u => u.Id == userId);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
