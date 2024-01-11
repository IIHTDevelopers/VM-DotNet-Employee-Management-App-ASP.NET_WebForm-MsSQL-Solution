using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EmployeeManagementApp.DAL.Interfaces;
using EmployeeManagementApp.Model;

namespace EmployeeManagementApp.DAL.Services
{
    public class EmployeeService : Interfaces.IEmployeeService
    {
        private Interfaces.IEmployeeRepository _repository;

        public EmployeeService(Interfaces.IEmployeeRepository repository)
        {
            _repository = repository;
        }


        public string GetAll()
        {
            return _repository.GetAll();
        }

        public string Add()
        {
            return _repository.Add();
        }

        public string Update()
        {
            return _repository.Update();
        }

        public string Delete()
        {
            return _repository.Delete();
        }

        public EmployeeModel GetById(string id)
        {
            return _repository.GetById(id);
        }
    }
}