namespace SSS.API.Models.Domain
{
    public class EmployeeAssociate
    {
        public Guid Id { get; set; }

        public Employee EmployeeSelf { get; set; }

        public ICollection<Employee> EmployeeJunior { get; set; }

    }
}
