using System.Collections.Generic;
using api.Models.Default;

namespace api.Models{
    public class Group : DefaultType{ 
        public long idGroupType{get;set;}
        public GroupType groupType{get;set;}
        public List<Group_Person> group_persons{get;set;}
    }
}