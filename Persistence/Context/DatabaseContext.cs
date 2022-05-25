
using Application.Interfaces;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Person> People { get; set; } = null!;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


    }
}
