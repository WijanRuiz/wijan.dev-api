using System.Collections.Generic;
using api.Models.Default;

namespace api.Models{
    public class Role:DefaultType{
        public List<User_Role> user_roles{get;set;}
    }
}