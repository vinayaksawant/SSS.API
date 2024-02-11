namespace SSS.API.Models.Domain
{
    public class Candidate
    {
        public Guid Id { get; set; }

        public Member MemberCandidate { get; set; }

        public ImageFile ProfileImages { get; set; }

        public string YearsOfExperience { get; set; }
       
        public bool IsVisible { get; set; }

        public Employer CurrentEmployer { get; set; }

        public ICollection<JobSkill> ExperienceJobSkills { get; set; }

        public ICollection<Document> Documents { get; set; }

        public ICollection<LinkHandle> LinkHandles { get; set; }

        public ICollection<ImageFile> ImageFiles { get; set; }
    }
}
