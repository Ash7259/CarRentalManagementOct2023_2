using CarRentalManagementOct2023_2.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalManagementOct2023_2.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Make> Makes { get; }
        IGenericRepository<Model> Models { get; }
        IGenericRepository<Vehicle> Vehicles { get; }
        IGenericRepository<Colour> Colours { get; }
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<Customer> Customers { get; }
    }
}