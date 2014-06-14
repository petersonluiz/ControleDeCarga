using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;

namespace ControleDeCarga.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Usuário")]
        public override string UserName
        {
            get
            {
                return base.UserName;
            }
            set
            {
                base.UserName = value;
            }
        }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove< System.Data.Entity.ModelConfiguration.Conventions.PluralizingEntitySetNameConvention>();
            base.OnModelCreating(modelBuilder);      
        }       

        public override int SaveChanges()
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();
            foreach(var model in this.ChangeTracker.Entries())
            {
                if (model.Entity is ModificationControlledModel)
                {
                    if (model.State == EntityState.Added)
                    {
                        ((ModificationControlledModel)model.Entity).OnCreate(userId);
                    }
                    else if (model.State == EntityState.Modified)
                    {
                        ((ModificationControlledModel)model.Entity).OnUpdate(userId);
                    }
                }
            }
            return base.SaveChanges();
        }
        
        public System.Data.Entity.DbSet<ControleDeCarga.Models.Veiculo> Veiculos { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.TipoVeiculo> TipoVeiculos { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Armador> Armadores { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.LocalDeEntrega> LocaisDeEntrega { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.UF> UFs { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.PortoSeco> PortosSecos { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.LocalDeDevolucao> LocaisDeDevolucao { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Carga> Cargas { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Especie> Especies { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Exportador> Exportadores { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Importador> Importadores { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Mercadoria> Mercadorias { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Navio> Navios { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Despachante> Despachantes { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Motorista> Motoristas { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Parceiro> Parceiros { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.StatusCarga> StatusCarga { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.HistoricoCarga> HistoricoCargas { get; set; }
        
        public System.Data.Entity.DbSet<ControleDeCarga.Models.Evento> Evento { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Filial> Filiais { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.CargaContainer> CargaContainers { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.CargaSimples> CargaSimples { get; set; }

        public System.Data.Entity.DbSet<ControleDeCarga.Models.Container> Containers { get; set; }

        public override IDbSet<ApplicationUser> Users
        {
            get
            {
                return base.Users;
            }
            set
            {
                base.Users = value;
            }
        }

    }
}