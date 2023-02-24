namespace Mini_project.Models
{
    public interface EmployeeOperationsInterface
    {
        public int createNewEmployee(Employee emp);
        public List<Employee> readAllEmployee();
        public int updateEmployee(int id);
        public int deleteEmployee(int id);
        public Employee FindEmployee(int e);


    }
}
