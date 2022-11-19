using codenow_park.Dominio.Models;
using codenow_park.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace codenow_park.Tests
{
    [TestClass]
    public class VeiculoTest
    {
        ParkContext context;

        [TestMethod]
        public void TestMethod1()
        {
            var options = new DbContextOptionsBuilder<ParkContext>()
            .UseInMemoryDatabase(databaseName: "TestCenario1")
            .Options;
            context = new ParkContext(options);

            var veiculo = new Veiculo("FKA-0001", "Ford KA");
            context.Veiculos.Add(veiculo);

            veiculo = new Veiculo("GOL-0001", "Gol G5");
            context.Veiculos.Add(veiculo);
            
            veiculo = new Veiculo("CRL-0001", "Corola Super");
            context.Veiculos.Add(veiculo);
            
            veiculo = new Veiculo("PGT-0001", "Peugeot 208");
            context.Veiculos.Add(veiculo);

            context.SaveChanges();

            int cont = context.Veiculos.Count();

            Assert.AreEqual(4, cont);
        }
    }
}