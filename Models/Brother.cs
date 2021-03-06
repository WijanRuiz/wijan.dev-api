using api.Models.Default;

namespace api.Models{
    public class Brother:External{
        public long idPerson {get;set;}
        public Person person {get;set;}
    }
}