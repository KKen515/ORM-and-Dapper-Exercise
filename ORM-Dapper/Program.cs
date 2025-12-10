using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper;

//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);

departmentRepo.InsertDepartment("CSharp-63");

var departments = departmentRepo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine($"¨Name: {department.Name} | ID: {department.DepartmentID}");
}


var prodRepo = new ProductRepository(conn);

//prodRepo.CreateProduct("Banana", 5.00, 10, false, 25);
//prodRepo.UpdateProduct("Mario Kart 8", 60.00, 8, false, 500, 940);
prodRepo.DeleteProduct(940);


var products =  prodRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"ID: {product.ProductID} | Name: {product.Name} | Price: {product.Price} | CategoryID: {product.CategoryID} | Sale: {product.OnSale} | Stock: {product.StockLevel}");
}