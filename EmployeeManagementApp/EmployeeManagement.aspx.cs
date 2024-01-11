using EmployeeManagementApp.DAL;
using EmployeeManagementApp.Model;
using System;
using System.Web.UI;

namespace EmployeeManagementApp
{
    public partial class EmployeeManagement : Page
    {
        private readonly datalayer _dataLayer;
        private readonly EmployeeManagementApp.DAL.Interfaces.IEmployeeService _employeeService;

        public EmployeeManagement()
        {
            _dataLayer = new datalayer();
            _employeeService = new DAL.Services.EmployeeService(new DAL.Services.EmployeeRepository(new EmployeeManagementApp.DAL.EmployeeDbContext()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            var employees = _employeeService.GetAll();
            _dataLayer.fillgridView(employees, gv);
        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = gv.SelectedRow.Cells[1].Text;
            // Retrieve the employee details and populate the form
            var employee = _employeeService.GetById(id);
            if (employee != null)
            {
                txtFirstName.Text = employee.FirstName;
                txtLastName.Text = employee.LastName;
                txtDateOfBirth.Text = employee.DateOfBirth.ToString("yyyy-MM-dd");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var newEmployee = new EmployeeModel
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DateOfBirth = DateTime.Parse(txtDateOfBirth.Text)
            };

            _employeeService.Add();
            BindGridView();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = gv.SelectedRow.Cells[1].Text.ToString();
            var existingEmployee = _employeeService.GetById(id);

            if (existingEmployee != null)
            {
                existingEmployee.LastName = txtLastName.Text;
                existingEmployee.FirstName = txtFirstName.Text;
                existingEmployee.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text);

                _employeeService.Update();
                BindGridView();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = gv.SelectedRow.Cells[1].Text.ToString();
            _employeeService.Delete();
            BindGridView();
        }
    }
}
