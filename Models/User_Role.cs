using System;

namespace api.Models{
    public class User_Role{
        public DateTimeOffset created{get;set;}
        public DateTimeOffset updated{get;set;}
        public long idRole{get;set;}
        public long idUser{get;set;}
        public Role role{get;set;}
        public User user{get;set;}
    }
}