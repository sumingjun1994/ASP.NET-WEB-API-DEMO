using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;
using  System.Web.Http.Cors;

namespace APIDemo.Controllers
{

    //[EnableCorsAttribute("*","*","*")] --添加跨域特性控制
    public class EmployeesController : ApiController
    {
        //[DisableCors] 禁止跨域访问
        public HttpResponseMessage Get(string gender = "ALL")
        {
            using (var entities = new EmployeeDBEntities())
            {
                switch (gender.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.ToList());
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees.Where(x =>x.Gender.ToLower().Equals("male")).ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees.Where(x => x.Gender.ToLower().Equals("female")).ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                            $"Gender Type {gender} is not match");
                }
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (var entities = new EmployeeDBEntities())
            {
                var employee = entities.Employees.FirstOrDefault(x => x.ID.Equals(id));

                if (employee != null)
                    return Request.CreateResponse(HttpStatusCode.OK, employee);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"id:{id} is not found");
            }
        }

        /*
         *FromBody And FromUri 
         */

        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                using (var dbEntities = new EmployeeDBEntities())
                {
                    dbEntities.Employees.Add(employee);
                    dbEntities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (var dbEntities = new EmployeeDBEntities())
                {
                    var item = dbEntities.Employees.FirstOrDefault(x => x.ID.Equals(id));

                    if (item == null)
                        return Request.CreateResponse(HttpStatusCode.NotFound, $"id:{id} not found to delete");

                    dbEntities.Employees.Remove(item);
                    dbEntities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, item);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody] Employee employee)
        {
            using (var dbEntities = new EmployeeDBEntities())
            {
                var entity = dbEntities.Employees.SingleOrDefault(x => x.ID.Equals(id));

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"id:{id} is not found");
                }

                entity.FirstName = employee.FirstName;
                entity.LastName = employee.LastName;
                entity.Gender = employee.Gender;
                entity.Salary = employee.Salary;
                dbEntities.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
        }
    }
}