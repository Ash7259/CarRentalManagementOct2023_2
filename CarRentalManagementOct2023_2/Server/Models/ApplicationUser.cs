using CarRentalManagementOct2023_2.Client;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text;
using System.Threading.Channels;

namespace CarRentalManagementOct2023_2.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
