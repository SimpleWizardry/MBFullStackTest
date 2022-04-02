//namespace WebApplication1.Data
//{
//    public class ApplicatiobDbConext
//    {
//    }
//}
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
public class WarehouseContext : DbContext
{
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Nomenclature> Nomenclatures { get; set; }
    public DbSet<NomenclatureMoving> Movings { get; set; }

    //public WarehouseContext()
    //{
    //    Database.EnsureCreated();
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=127.0.0.1;User Id=postgres;Password=123;Port=5432;Database=warehousedb;");
    }
}

public class Warehouse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class Nomenclature
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class NomenclatureMoving
{
    public Guid Id { get; set; }
    public Guid Nomenclature { get; set; }
    public Guid SenderId { get; set; }
    public Guid DestinationId { get; set; }
    public double Count { get; set; }
    public DateTime Time { get; set; }
}
