using MarcasApi.Controllers;
using MarcasApi.Data;
using MarcasApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcasApi.Tests
{
    public class MarcasControllerTests
    {
        private AppDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + System.Guid.NewGuid())
                .Options;
            var ctx = new AppDbContext(options);
            ctx.MarcasAutos.AddRange(
                new MarcaAuto { Id = 1, Nombre = "Test1" },
                new MarcaAuto { Id = 2, Nombre = "Test2" });
            ctx.SaveChanges();
            return ctx;
        }

        [Fact]
        public async Task GetAll_ReturnsAll()
        {
            using var ctx = CreateInMemoryContext();
            var controller = new MarcasAutosController(ctx);
            var result = await controller.GetAll() as OkObjectResult;
            var list = Assert.IsType<List<MarcaAuto>>(result!.Value);
            Assert.Equal(2, list.Count);
        }
    }
}
