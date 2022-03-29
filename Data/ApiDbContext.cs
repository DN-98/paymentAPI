using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PaymentAPI.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public virtual DbSet<PaymentItem> PaymentDetails {get; set;}
        public virtual DbSet<RefreshToken> RefreshTokens {get;set;}
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {
            
        }
    }
}
