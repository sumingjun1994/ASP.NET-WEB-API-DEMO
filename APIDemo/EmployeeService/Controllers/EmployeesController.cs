using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    [Authorize]//添加授权访问
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (var entity=new EmployeeDBEntities())
            {
                return entity.Employees.ToList();
            }
        }
    }
}
