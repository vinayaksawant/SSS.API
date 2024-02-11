namespace SSS.API.Models.Domain
{
    public class EmployeeSupervisor
    {
        public Guid Id { get; set; }

        public Employee EmployeeSelf { get; set; }

        public Employee EmployeeSupervisorManager { get; set; }


    }
}
