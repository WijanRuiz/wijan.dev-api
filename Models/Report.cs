using api.Models.Default;

namespace api.Models{
    public class Report:External{
        public long idBrother{get;set;}
        public Brother brother{get;set;}
        public long idMonth{get;set;}
        public Month month{get;set;}
        public long time{get;set;}
        public short placements{get;set;}
        public short videos{get;set;}
        public short visits{get;set;}
        public short studies{get;set;}
    }
}