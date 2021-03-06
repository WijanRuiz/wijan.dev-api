using System;

namespace api.Models{
    public class Group_Person{
        public DateTimeOffset created{get;set;}
        public DateTimeOffset updated{get;set;}
        public long idGroup{get;set;}
        public long idPerson{get;set;}
        public Group group{get;set;}
        public Person person{get;set;}
    }
}