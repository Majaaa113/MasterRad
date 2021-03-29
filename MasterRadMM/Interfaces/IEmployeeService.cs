using MasterRadMM.ViewModels;

namespace MasterRadMM.Interfaces
{
    public interface IEmployeeService 
    {
        EmployeeViewModel Login(LoginViewModel login);
        EmployeeViewModel Register(RegisterViewModel register);
    }
}
