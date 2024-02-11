namespace SSS.API.Models.Domain
{
    public class JobSkill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<JobSkill> JobSkills { get; set; }

    }
}
