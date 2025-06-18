using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infraestructura.Persistencia
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet por cada entidad que quieres mapear a una tabla
        public DbSet<Client> Clients { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sex> Table18 { get; set; }
        public DbSet<Branch> Table10 { get; set; }
        public DbSet<Way_pay> Table5002 { get; set; }
        public DbSet<NMPoliza> Table13 { get; set; }
        public DbSet<NMPremium> Table95 { get; set; }
        public DbSet<Nacionality> Table5518 { get; set; }
        public DbSet<Poliza> Poliza { get; set; }
        public DbSet<ProductMaster> ProductMaster { get; set; }
        public DbSet<PolizaHistory> Poliza_History { get; set; }
        public DbSet<Premium> Premium { get; set; }
        public DbSet<Municipality> Municipality { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<TabLocat> Tab_Locat { get; set; }
        public DbSet<StatusPre> Table19 { get; set; }
        public DbSet<StatusPay> Table191 { get; set; }
        public DbSet<Address> Address { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo de tablas
            modelBuilder.Entity<Client>().ToTable("CLIENTS");
            modelBuilder.Entity<Usuario>().ToTable("USUARIOS");
            modelBuilder.Entity<Sex>().ToTable("TABLE18");
            modelBuilder.Entity<Branch>().ToTable("TABLE10");
            modelBuilder.Entity<Way_pay>().ToTable("TABLE5002");
            modelBuilder.Entity<NMPoliza>().ToTable("TABLE13");
            modelBuilder.Entity<NMPremium>().ToTable("TABLE95");
            modelBuilder.Entity<Nacionality>().ToTable("TABLE5518");
            modelBuilder.Entity<Poliza>().ToTable("POLIZA");
            modelBuilder.Entity<ProductMaster>().ToTable("PRODUCTMASTER");
            modelBuilder.Entity<PolizaHistory>().ToTable("POLIZA_HISTORY");
            modelBuilder.Entity<Premium>().ToTable("PREMIUM");
            modelBuilder.Entity<Municipality>().ToTable("MUNICIPALITY");
            modelBuilder.Entity<Province>().ToTable("PROVINCE");
            modelBuilder.Entity<TabLocat>().ToTable("TAB_LOCAT");
            modelBuilder.Entity<StatusPre>().ToTable("TABLE19");
            modelBuilder.Entity<StatusPay>().ToTable("TABLE191");
            modelBuilder.Entity<Address>().ToTable("ADDRESS").HasKey(a => new { a.NRecOwner, a.SKeyAddress, a.DeffecDate, a.SInfor });

            modelBuilder.Entity<Address>()
                .HasOne(a => a.TabLocat)
                .WithMany()
                .HasForeignKey(a => a.NLocal)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Municipality)
                .WithMany()
                .HasForeignKey(a => a.NMunicipality)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Province)
                .WithMany()
                .HasForeignKey(a => a.NProvince)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Poliza)
                .WithMany()
                .HasForeignKey(a => new { a.NBranch, a.NProduct, a.NPolicy })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Client)
                .WithMany()
                .HasForeignKey(a => a.SClient)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.NUserCode)
                .OnDelete(DeleteBehavior.Restrict);


            // Relaciones para Client
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasOne(c => c.Usuario)
                      .WithMany()
                      .HasForeignKey(c => c.NUserCode)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Sex)
                      .WithMany()
                      .HasForeignKey(c => c.SSexClien)
                      .HasPrincipalKey(s => s.SSexClien)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Nacionality)
                      .WithMany()
                      .HasForeignKey(c => c.NNationality)
                      .HasPrincipalKey(n => n.NNationality)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Relaciones para Poliza
            modelBuilder.Entity<Poliza>()
                .HasKey(p => new { p.NBranch, p.NProduct, p.NPolicy });

            modelBuilder.Entity<Poliza>()
                .HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.SClient);

            modelBuilder.Entity<Poliza>()
                .HasOne(p => p.WayPay)
                .WithMany()
                .HasForeignKey(p => p.NWayPay);

            modelBuilder.Entity<Poliza>()
                .HasOne(p => p.NullCode)
                .WithMany()
                .HasForeignKey(p => p.NNullCode);

            modelBuilder.Entity<Poliza>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.NUserCode);

            modelBuilder.Entity<Poliza>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => new { p.NBranch, p.NProduct });

            // Relaciones para ProductMaster
            modelBuilder.Entity<ProductMaster>()
                .HasKey(p => new { p.NBranch, p.NProduct });

            modelBuilder.Entity<ProductMaster>()
                .HasOne(p => p.Branch)
                .WithMany()
                .HasForeignKey(p => p.NBranch);

            modelBuilder.Entity<ProductMaster>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.NUserCode);

            // Relaciones para PolizaHistory
            modelBuilder.Entity<PolizaHistory>()
                .HasKey(p => new { p.NBranch, p.NProduct, p.NPolicy, p.NMovment });

            modelBuilder.Entity<PolizaHistory>()
                .HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.SClient);

            modelBuilder.Entity<PolizaHistory>()
                .HasOne(p => p.WayPay)
                .WithMany()
                .HasForeignKey(p => p.NWayPay);

            modelBuilder.Entity<PolizaHistory>()
                .HasOne(p => p.NullReason)
                .WithMany()
                .HasForeignKey(p => p.NNullCode);

            modelBuilder.Entity<PolizaHistory>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.NUserCode);

            modelBuilder.Entity<PolizaHistory>()
                .HasOne(p => p.Branch)
                .WithMany()
                .HasForeignKey(p => p.NBranch);

            modelBuilder.Entity<PolizaHistory>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => new { p.NBranch, p.NProduct });

            // Relaciones para Premium
            modelBuilder.Entity<Premium>()
                .HasKey(p => new { p.NBranch, p.NProduct, p.NPolicy, p.NReceipt });

            // Relación para Municipality -> Province
            modelBuilder.Entity<Municipality>()
                .HasKey(m => m.NMunicipality);

            modelBuilder.Entity<Municipality>()
                .HasOne(m => m.Province)
                .WithMany() // Sin relación inversa explícita
                .HasForeignKey(m => m.NProvince)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación para Province -> Usuario
            modelBuilder.Entity<Province>()
                .HasKey(p => p.NProvince);

            modelBuilder.Entity<Province>()
                .HasOne(p => p.Usuario)
                .WithMany() // Sin relación inversa explícita a menos que esté definida
                .HasForeignKey(p => p.NUserCode)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string DefaultConnection = "Data Source=localhost:1521/XEPDB1;User Id=adminProyecto;Password=adminProyecto;";
            optionsBuilder.UseOracle(DefaultConnection);
            base.OnConfiguring(optionsBuilder);
        }
    }
}