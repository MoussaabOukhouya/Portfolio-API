namespace portfolio.models
{
    public class Skill
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