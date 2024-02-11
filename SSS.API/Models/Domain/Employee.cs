namespace SSS.API.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; } 

        public Member MemberEmployee { get; set; }

        //public EmployeeSupervisor Supervisor { get; set; }

        //public EmployeeAssociate Associates { get; set; }

        public ICollection<Employer> PastEmployers { get; set; }

        public ICollection<JobSkill> ExperienceJobSkills { get; set; }

        public ICollection<Document> Documents { get; set; }

        public ICollection<LinkHandle> LinkHandles { get; set; }

        public ICollection<ImageFile> ImageFiles { get; set; }

    }
}
