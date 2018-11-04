using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDataAccess;

namespace APIDemo
{
    public class EmployeeSecurity
    {
        public static bool Login(string username,string password)
        {
            using (var entity=new EmployeeDBEntities())
            {
                return entity.Users.Any(User => User.Username.Equals(username,StringComparison.OrdinalIgnoreCase)
                &&User.Password.Equals(password));
            }
        }
    }
}