using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.DTOs.SocialMediaDTO
{
    public class UpdateSocialMediaDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string link { get; set; }
    }
}