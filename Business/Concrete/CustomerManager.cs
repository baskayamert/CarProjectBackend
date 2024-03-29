﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);

            return new SuccessfulResult();
           
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);

            return new SuccessfulResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessfulDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessfulDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId));
        }

        public IDataResult<CustomerDto> GetCustomerByEmail(string email)
        {
            return new SuccessfulDataResult<CustomerDto>(_customerDal.GetCustomerByEmail(email));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);

            return new SuccessfulResult();
        }
    }
}
