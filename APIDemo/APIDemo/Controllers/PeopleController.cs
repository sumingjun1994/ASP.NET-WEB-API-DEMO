using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIDemo.Models;

namespace APIDemo.Controllers
{
    public class PeopleController : ApiController
    {
        static List<Person> persons = new List<Person>()
        {
            new Person(){FirstName = "Tim",LastName = "Corey",Id = 1},
            new Person(){FirstName = "Sue",LastName = "Storm",Id = 2},
            new Person(){FirstName = "Bibo",LastName = "Baggins",Id = 3}
        };

        // GET: api/People
        public List<Person> Get()
        {
            return persons;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return persons.SingleOrDefault(a => a.Id.Equals(id));
        }

        // POST: api/People
        public void Post(Person val)
        {
            persons.Add(val);
        }

        // PUT: api/People/5
        public void Put(int id, Person value)
        {
            Person person = persons.FirstOrDefault(x => x.Id.Equals(id));
            if (person!=null)
            {
                person.FirstName = value.FirstName;
                person.LastName = value.LastName;
            }
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
            persons.RemoveAt(id);
        }
    }
}
