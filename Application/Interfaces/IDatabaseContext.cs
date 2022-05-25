using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<Person> People { get; set; }

        int SaveChanges();
    }
}
