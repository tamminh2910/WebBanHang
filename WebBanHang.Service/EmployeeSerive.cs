using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Data.Repository;
using WebBanHang.Model.Entities;

namespace WebBanHang.Service
{
    public interface IEmployeeService
    {
        Employee Add(Employee employee);

        void Update(Employee employee);

        Employee Delete(int id);

        IEnumerable<Employee> GetAll();


        IEnumerable<Employee> GetAll(string keyword);

        Employee GetById(int id);

        void Save();
    }

    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeService;
        private IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this._employeeService = employeeRepository;
            this._unitOfWork = unitOfWork;
        }

        public Employee Add(Employee employee)
        {
            return _employeeService.Add(employee);
        }

        public Employee Delete(int id)
        {
            return _employeeService.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeService.GetAll();
        }

        public IEnumerable<Employee> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _employeeService.GetMulti(x => x.EmployeeName.Contains(keyword));
            }
            else return _employeeService.GetAll();
        }

       
        public Employee GetById(int id)
        {
            return _employeeService.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Employee employee)
        {
            _employeeService.Update(employee);
        }
    }
}
