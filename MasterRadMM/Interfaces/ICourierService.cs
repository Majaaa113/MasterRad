using MasterRadMM.ViewModels;
using System.Collections.Generic;

namespace MasterRadMM.Interfaces
{
    public interface ICourierService 
    {
        int CreateCourier(CreateCourierViewModel createCourier);
        CourierViewModel GetCourier(int id);
        List<CourierViewModel> ListCouriers();        
    }
}
