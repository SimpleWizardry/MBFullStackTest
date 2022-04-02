using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



//var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


namespace WebApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // ���������� ������
            using (WarehouseContext db = new WarehouseContext())
            {
                // ������� ��� ������� Warehouse
                Warehouse wh1 = new Warehouse { Name = "������ �����"};
                Warehouse wh2 = new Warehouse { Name = "������ �����"};
                Warehouse wh3 = new Warehouse { Name = "������ �����"};

                // ��������� �� � ��
                db.Warehouses.AddRange(wh1, wh2, wh3);
                db.SaveChanges();
            }
            // ��������� ������
            using (WarehouseContext db = new WarehouseContext())
            {
                // �������� ������� �� �� � ������� �� �������
                var warehouses = db.Warehouses.ToList();
                Console.WriteLine("Users list:");
                foreach (Warehouse u in warehouses)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
            }
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        using (var db = new WarehouseContext())
    //        {
    //            db.Warehouses.Add(new Warehouse { Name = "Another Blog " });
    //            db.SaveChanges();

    //            foreach (var blog in db.Warehouses)
    //            {
    //                Console.WriteLine(blog.Name);
    //            }
    //        }

    //        Console.WriteLine("Press any key to exit...");
    //        Console.ReadKey();
    //    }
    //}
}


//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
