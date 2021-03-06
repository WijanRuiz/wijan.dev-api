using System.Collections.Generic;
using api.Models.Default;

namespace api.Models{
    public class User : External{
        public long idPerson{get;set;}
        public Person person{get;set;}
        public string email{get;set;}
        public string username{get;set;}
        public string pass{get;set;}
        public List<User_Role> user_roles{get;set;}
    }
}