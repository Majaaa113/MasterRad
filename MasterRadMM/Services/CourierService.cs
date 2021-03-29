using MasterRadMM.EntityFramework;
using MasterRadMM.Interfaces;
using MasterRadMM.Models;
using MasterRadMM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRadMM.Services
{
    public class CourierService : ICourierService
    {
        private readonly MasterRadDbContext _context;

        public CourierService(MasterRadDbContext context)
        {
            _context = context;
        }

        public int CreateCourier(CreateCourierViewModel createCourier)
        {
            var courier = Utilities.CopyEntityFields<CreateCourierViewModel, Courier>(createCourier);
            _context.Couriers.Add(courier);
            _context.SaveChanges();

            return courier.Id;
        }

        public CourierViewModel GetCourier(int id)
        {
            var courier = _context.Couriers.Find(id);
            return Utilities.CopyEntityFields<Courier, CourierViewModel>(courier);
        }

        public List<CourierViewModel> ListCouriers()
        {
            return _context.Couriers
                .Select(x => GetCourierViewModel(x))
                .ToList();
        }

        private static CourierViewModel GetCourierViewModel(Courier courier)
        {
            var viewModel = Utilities.CopyEntityFields<Courier, CourierViewModel>(courier);
            viewModel.FullName = $"{viewModel.Firstname} {viewModel.Lastname}";
            return viewModel;
        }
    }
}
