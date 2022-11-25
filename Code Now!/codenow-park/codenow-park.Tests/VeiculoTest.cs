using codenow_park.Dominio.Models;
using codenow_park.Infra.Context;
using codenow_park.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace codenow_park.Tests
{
    [TestClass]
    public class VeiculoTest
    {
        ParkContext context;

        [TestMethod]
        public void TestCenario1()
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

        [TestMethod]
        public void TestCenario1Repo()
        {
            var options = new DbContextOptionsBuilder<ParkContext>()
            .UseInMemoryDatabase(databaseName: "TestCenario2")
            .Options;
            context = new ParkContext(options);

            var repoVeic = new VeiculoRepo(context);

            var veiculo = new Veiculo("FKA-0001", "Ford KA");
            repoVeic.Inserir(veiculo);

            repoVeic.Inserir("GOL-0001", "Gol G5");
            repoVeic.Inserir("CRL-0001", "Corola Super");
            repoVeic.Inserir("PGT-0001", "Peugeot 208");
            
            int cont = repoVeic.Contar();

            Assert.AreEqual(4, cont);
        }
    }
}