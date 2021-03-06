using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileSample.Core.Enums;
using MobileSample.Core.Models;
using MobileSample.Core.Repositories;

namespace MobileSample.Core.Services
{
    public interface IVehicleService : IBaseService<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetByIds(string[] ids);
        Task<IEnumerable<Vehicle>> GetByManufacturerId(string id);
        Task<IEnumerable<Vehicle>> GetByVehicleClass(EVehicleClass vehicleClass);
    }

    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> GetAll() => await Task.Run(_vehicleRepository.GetAll);

        public async Task<IEnumerable<Vehicle>> GetByCompanyId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await Task.Run(() => _vehicleRepository.GetByCompanyId(id));
        }

        public async Task<Vehicle> GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await Task.Run(() => _vehicleRepository.GetById(id));
        }

        public async Task<bool> Import(List<Vehicle> manufacturers)
        {
            if (manufacturers == null || manufacturers.Any(vehicle => !vehicle.ValidatePropertiesRequired()))
                return false;

            return await Task.Run(() => _vehicleRepository.Import(manufacturers));
        }

        public async Task<bool> Save(Vehicle vehicle)
        {
            if (!vehicle.ValidatePropertiesRequired())
                return false;

            return await Task.Run(() => _vehicleRepository.Save(vehicle));
        }

        public async Task<bool> Remove(Vehicle vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.Id))
                return false;

            vehicle.Removed = true;
            return await Task.Run(() => _vehicleRepository.Save(vehicle));
        }

        public async Task<IEnumerable<Vehicle>> GetByIds(string[] ids)
        {
            if (ids == null || !ids.Any())
                return null;

            return await Task.Run(() => _vehicleRepository.GetByIds(ids));
        }

        public async Task<IEnumerable<Vehicle>> GetByManufacturerId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await Task.Run(() => _vehicleRepository.GetByManufacturerId(id));
        }

        public async Task<IEnumerable<Vehicle>> GetByVehicleClass(EVehicleClass vehicleClass) =>
            await Task.Run(() => _vehicleRepository.GetByVehicleClass(vehicleClass));
    }
}