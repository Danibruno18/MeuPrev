using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeuPrev.Models;

namespace MeuPrev.Data
{
    public class MeuPrevContext : DbContext
    {
        public MeuPrevContext (DbContextOptions<MeuPrevContext> options)
            : base(options)
        {
        }

        public DbSet<MeuPrev.Models.Pessoa> Pessoa { get; set; } = default!;

        public DbSet<MeuPrev.Models.Funcionario>? Funcionario { get; set; }

        public DbSet<MeuPrev.Models.Cargo>? Cargo { get; set; }
    }
}
