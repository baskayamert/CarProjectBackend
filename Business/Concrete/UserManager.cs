using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        

        public User GetByMail(string email)
        {
             
       
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<RoleDto> GetRoleByUserId(int userId)
        {
            return new SuccessfulDataResult<RoleDto>(_userDal.getRoleByUserId(userId));
        }

        public IDataResult<User> GetUserById(int userId)
        {
            return new SuccessfulDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessfulResult();
        }
    }
}
