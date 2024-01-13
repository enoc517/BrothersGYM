using BrothersGYM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrothersGYM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public   DbSet<Actividad> Actividads { get; set; }

        public   DbSet<CategoriaMembresium> CategoriaMembresia { get; set; }

        public DbSet<CategoriaProducto> CategoriaProductos { get; set; }

        public DbSet<Clase> Clases { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<ClienteMembresium> ClienteMembresia { get; set; }

        public DbSet<ClienteSesione> ClienteSesiones { get; set; }

        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<DetallePedido> DetallePedidos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<FacturaPedido> FacturaPedidos { get; set; }

        public DbSet<HistorialPago> HistorialPagos { get; set; }

        public DbSet<Jornadum> Jornada { get; set; }

        public DbSet<Matricula> Matriculas { get; set; }

        public DbSet<PaquteSesione> PaquteSesiones { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Proveedor> Proveedors { get; set; }

        public DbSet<Puesto> Puestos { get; set; }

        public DbSet<Sala> Salas { get; set; }

        public DbSet<SesionesRayosUv> SesionesRayosUvs { get; set; }

        public DbSet<Ventum> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("name=DefaultConnection");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.HasKey(e => e.Idactividad);

                entity.ToTable("Actividad");

                entity.Property(e => e.Idactividad).HasColumnName("IDActividad");
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });


            modelBuilder.Entity<CategoriaMembresium>(entity =>
            {
                entity.HasKey(e => e.IdcategoriaMembresia);

                entity.Property(e => e.IdcategoriaMembresia).HasColumnName("IDCategoriaMembresia");
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.HasKey(e => e.IdcategoriaProducto);

                entity.ToTable("CategoriaProducto");

                entity.Property(e => e.IdcategoriaProducto).HasColumnName("IDCategoriaProducto");
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasKey(e => e.Idclase);

                entity.ToTable("Clase");

                entity.Property(e => e.Idclase).HasColumnName("IDClase");
                entity.Property(e => e.DiayHora).HasColumnType("smalldatetime");
                entity.Property(e => e.HoraFin).HasColumnType("smalldatetime");
                entity.Property(e => e.Idactividad).HasColumnName("IDActividad");
                entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");
                entity.Property(e => e.Idsala).HasColumnName("IDSala");

                entity.HasOne(d => d.IdactividadNavigation).WithMany(p => p.Clases)
                    .HasForeignKey(d => d.Idactividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clase_Actividad");

                entity.HasOne(d => d.IdempleadoNavigation).WithMany(p => p.Clases)
                    .HasForeignKey(d => d.Idempleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clase_Empleado");

                entity.HasOne(d => d.IdsalaNavigation).WithMany(p => p.Clases)
                    .HasForeignKey(d => d.Idsala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clase_Sala");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<ClienteMembresium>(entity =>
            {
                entity.HasKey(e => e.IdclienteMembresia);

                entity.Property(e => e.IdclienteMembresia).HasColumnName("IDClienteMembresia");
                entity.Property(e => e.FechaInicio).HasColumnType("smalldatetime");
                entity.Property(e => e.FechaRenovacion).HasColumnType("smalldatetime");
                entity.Property(e => e.IdcategoriaMembresia).HasColumnName("IDCategoriaMembresia");
                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.HasOne(d => d.IdcategoriaMembresiaNavigation).WithMany(p => p.ClienteMembresia)
                    .HasForeignKey(d => d.IdcategoriaMembresia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClienteMembresia_CategoriaMembresia");

                entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.ClienteMembresia)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClienteMembresia_Cliente");
            });

            modelBuilder.Entity<ClienteSesione>(entity =>
            {
                entity.HasKey(e => e.IdclienteSesiones);

                entity.Property(e => e.IdclienteSesiones).HasColumnName("IDClienteSesiones");
                entity.Property(e => e.FechaCita).HasColumnType("smalldatetime");
                entity.Property(e => e.Idsesiones).HasColumnName("IDSesiones");

                entity.HasOne(d => d.IdsesionesNavigation).WithMany(p => p.ClienteSesiones)
                    .HasForeignKey(d => d.Idsesiones)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClienteSesiones_SesionesRayosUv");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.Iddepartamento);

                entity.ToTable("Departamento");

                entity.Property(e => e.Iddepartamento).HasColumnName("IDDepartamento");
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IddetalleProducto).HasName("PK_DetalleProducto");

                entity.ToTable("DetallePedido");

                entity.Property(e => e.IddetalleProducto).HasColumnName("IDDetalleProducto");
                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Idpedido).HasColumnName("IDPedido");
                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
                entity.Property(e => e.PrecioUnidad).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdpedidoNavigation).WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.Idpedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleProducto_Pedido");

                entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleProducto_Producto");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Idempleado);

                entity.ToTable("Empleado");

                entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.CuentaBancaria)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.FechaContratacion).HasColumnType("smalldatetime");
                entity.Property(e => e.Idpuesto).HasColumnName("IDPuesto");
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.NumeroSeguroSocial)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.RetencionCcss)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("RetencionCCSS");
                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdpuestoNavigation).WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Idpuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Puesto");
            });

            modelBuilder.Entity<FacturaPedido>(entity =>
            {
                entity.HasKey(e => e.IdfacturaPedido);

                entity.ToTable("FacturaPedido");

                entity.Property(e => e.IdfacturaPedido).HasColumnName("IDFacturaPedido");
                entity.Property(e => e.FechaEmision).HasColumnType("datetime");
                entity.Property(e => e.Idpedido).HasColumnName("IDPedido");
                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
                entity.Property(e => e.Idproveedor).HasColumnName("IDProveedor");
                entity.Property(e => e.Iva)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("IVA");
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdpedidoNavigation).WithMany(p => p.FacturaPedidos)
                    .HasForeignKey(d => d.Idpedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaPedido_Pedido");

                entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.FacturaPedidos)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaPedido_Producto");

                entity.HasOne(d => d.IdproveedorNavigation).WithMany(p => p.FacturaPedidos)
                    .HasForeignKey(d => d.Idproveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaPedido_Proveedor");
            });

            modelBuilder.Entity<HistorialPago>(entity =>
            {
                entity.HasKey(e => e.IdhistorialPago);

                entity.ToTable("HistorialPago");

                entity.Property(e => e.IdhistorialPago).HasColumnName("IDHistorialPago");
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Idjornada).HasColumnName("IDJornada");

                entity.HasOne(d => d.IdjornadaNavigation).WithMany(p => p.HistorialPagos)
                    .HasForeignKey(d => d.Idjornada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistorialPago_Jornada");
            });

            modelBuilder.Entity<Jornadum>(entity =>
            {
                entity.HasKey(e => e.Idjornada);

                entity.Property(e => e.Idjornada).HasColumnName("IDJornada");
                entity.Property(e => e.DiaHoraEntrada).HasColumnType("smalldatetime");
                entity.Property(e => e.DiaHoraSalida).HasColumnType("smalldatetime");
                entity.Property(e => e.HorasTrabajadas).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");
                entity.Property(e => e.SalarioBruto).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdempleadoNavigation).WithMany(p => p.Jornada)
                    .HasForeignKey(d => d.Idempleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jornada_Empleado");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.Idmartricula);

                entity.ToTable("Matricula");

                entity.Property(e => e.Idmartricula).HasColumnName("IDMartricula");
                entity.Property(e => e.Idclase).HasColumnName("IDClase");
                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.HasOne(d => d.IdclaseNavigation).WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.Idclase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matricula_Clase");

                entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matricula_Cliente");
            });

            modelBuilder.Entity<PaquteSesione>(entity =>
            {
                entity.HasKey(e => e.PaqueteSesioensId);

                entity.Property(e => e.PaqueteSesioensId).ValueGeneratedNever();
                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Idpedido);

                entity.ToTable("Pedido");

                entity.Property(e => e.Idpedido).HasColumnName("IDPedido");
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");

                entity.HasOne(d => d.IdempleadoNavigation).WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idempleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Empleado");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto);

                entity.ToTable("Producto");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
                entity.Property(e => e.IdcategoriaProducto).HasColumnName("IDCategoriaProducto");
                entity.Property(e => e.Idproveedores).HasColumnName("IDProveedores");
                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.PrecioUnidad).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdcategoriaProductoNavigation).WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdcategoriaProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_CategoriaProducto");

                entity.HasOne(d => d.IdproveedoresNavigation).WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idproveedores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Proveedor");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Idproveedores);

                entity.ToTable("Proveedor");

                entity.Property(e => e.Idproveedores).HasColumnName("IDProveedores");
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.Idpuesto);

                entity.ToTable("Puesto");

                entity.Property(e => e.Idpuesto).HasColumnName("IDPuesto");
                entity.Property(e => e.Iddepartamento).HasColumnName("IDDepartamento");
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.PagHora).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IddepartamentoNavigation).WithMany(p => p.Puestos)
                    .HasForeignKey(d => d.Iddepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Puesto_Departamento");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.Idsala);

                entity.ToTable("Sala");

                entity.Property(e => e.Idsala).HasColumnName("IDSala");
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SesionesRayosUv>(entity =>
            {
                entity.HasKey(e => e.Idsesiones);

                entity.ToTable("SesionesRayosUv");

                entity.Property(e => e.Idsesiones).HasColumnName("IDSesiones");
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
                entity.Property(e => e.PaqueteSesionesId).HasColumnName("PaqueteSesionesID");

                entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.SesionesRayosUvs)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("FK_SesionesRayosUv_Cliente");

                entity.HasOne(d => d.PaqueteSesiones).WithMany(p => p.SesionesRayosUvs)
                    .HasForeignKey(d => d.PaqueteSesionesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SesionesRayosUv_PaquteSesiones");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.Idventa);

                entity.Property(e => e.Idventa).HasColumnName("IDVenta");
                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
                entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");
                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
                entity.Property(e => e.Pago).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Cliente");

                entity.HasOne(d => d.IdempleadoNavigation).WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idempleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Empleado");

                entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Producto");
            });

        }
    }
}
