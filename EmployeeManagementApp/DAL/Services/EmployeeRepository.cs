using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EmployeeManagementApp.DAL.Interfaces;

namespace EmployeeManagementApp.DAL.Services
{
    public class EmployeeRepository : Interfaces.IEmployeeRepository
    {
        private EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public Model.EmployeeModel GetById(string id)
        {
            return _context.EmployeeModels.FirstOrDefault(t => t.Id == int.Parse(id));
        }

        public string GetAll()
        {
            string qry = "select* from EmployeeModels";
            return qry;
        }

        public string Add()
        {
            string qry = "insert into EmployeeModels(Title, IsCompleted, DueDate)" +
                "values('";
            return qry;
        }

        public string Update()
        {
            var query = "update EmployeeModels set Title='";
            return query;
        }

        public string Delete()
        {
            var query = "delete from EmployeeModels where Id='";
            return query;
        }
    }
}