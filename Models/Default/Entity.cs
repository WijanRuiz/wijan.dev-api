using System;

namespace api.Models.Default{
    public class Entity{
        public long id {get;set;}
        public DateTimeOffset created {get;set;}
        public DateTimeOffset updated {get;set;}
    }
}