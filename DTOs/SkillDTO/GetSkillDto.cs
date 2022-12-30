using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portfolio.models;

namespace portfolio.DTOs.SkillDTO
{
    public class GetSkillDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int type { get; set; }
        public int level { get; set; }
        public Certificat certificat { get; set; }
    }
}