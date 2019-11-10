using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services {
    public class VehicleProvider : IVehicleProvider {
        private readonly IMemoryCache _cache;
        private readonly  static string Cachekey = "vehicles";
        private static readonly IDictionary<string, IEnumerable<VehicleDetails>> availabeVehicles =
            new Dictionary<string, IEnumerable<VehicleDetails>>
            {
                ["Audi"] = new List<VehicleDetails>
                {
                    new VehicleDetails("RS8", 4)
                },
                ["BMW"] = new List<VehicleDetails>
                {
                    new VehicleDetails("i8", 2)
                }
            };
        public VehicleProvider (IMemoryCache cache) 
        {
            _cache = cache;
        }
        public async Task<IEnumerable<VehicleDTO>> BrowseAsync() 
        {
            var vehicles = _cache.Get<IEnumerable<VehicleDTO>>(Cachekey);
            if (vehicles == null)
            {
                vehicles = await GetAllAsync();
                _cache.Set(Cachekey, vehicles);
            }
            return vehicles;
        }
        public async Task<IEnumerable<VehicleDTO>> GetAllAsync()         
            => await Task.FromResult(availabeVehicles.GroupBy(x => x.Key)
            .SelectMany(g => g.SelectMany(v => v.Value.Select(c => new VehicleDTO
            {
                Brand = v.Key,
                Name = c.Name,
                Seats = c.Seats
            }))));
        
        public async Task<VehicleDTO> GetAsync (string brand, string name) {
            if(!availabeVehicles.ContainsKey(brand))
            {
                throw new Exception($"Vehicle brand '{brand}' is not avaiable.");
            }
            var vehicles = availabeVehicles[brand];
            var vehicle = vehicles.SingleOrDefault(x => x.Name == name);
            if(vehicle == null)
            {
                throw new Exception($"Vehicle: '{name}' for brand: '{brand}' is not avaiable."); 
            }
            return await Task.FromResult(new VehicleDTO
            {
                Brand = brand,
                Name = vehicle.Name,
                Seats = vehicle.Seats
            });
        }
        private class VehicleDetails {
            public string Name { get; }
            public int Seats { get; }
            public VehicleDetails (string name, int seats) {
                Name = name;
                Seats = seats;
            }
        }
    }
}