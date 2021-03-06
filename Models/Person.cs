using System;
using System.Collections.Generic;
using api.Models.Default;

namespace api.Models{
    public class Person : External{
        public long idGender{get;set;}
        public Gender gender{get;set;}
        public string name{get;set;}
        public string name2{get;set;}
        public string surname{get;set;}
        public string surname2{get;set;}
        public DateTimeOffset birth{get;set;}
        public List<Group_Person> group_persons{get;set;}
    }
}