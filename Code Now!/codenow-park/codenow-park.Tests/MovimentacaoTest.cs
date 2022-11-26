using codenow_park.Dominio.Enums;
using codenow_park.Dominio.Models;
using codenow_park.Infra.Context;
using codenow_park.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace codenow_park.Tests
{
    [TestClass]
    public class MovimentacaoTest
    {
        [TestMethod]
        public void TestEstacionar2Veiculos()
        {
            ParkContext context = InicializarDados("Base01");
            VeiculoRepo repoVeic = new VeiculoRepo(context);
            EstacionamentoRepo repoEst = new EstacionamentoRepo(context);
            Estacionamento estacionamento = repoEst.ObterPorCnpj("01001001000101");

            MovimentacaoRepo operacao = new MovimentacaoRepo(context, estacionamento);

            Veiculo veiculo = repoVeic.ObterPorPlaca("FKA-0001");
            operacao.Estacionar(veiculo);
            veiculo = repoVeic.ObterPorPlaca("GOL-0001");
            operacao.Estacionar(veiculo);

            Assert.AreEqual(2, operacao.ObterOcupacaoAtual());
        }

        [TestMethod]
        public void TestRetirarVeiculos_ErroVeiculoNaoCalculado()
        {
            ParkContext context = InicializarDados("Base01");
            VeiculoRepo repoVeic = new VeiculoRepo(context);
            EstacionamentoRepo repoEst = new EstacionamentoRepo(context);
            Estacionamento estacionamento = repoEst.ObterPorCnpj("01001001000101");

            MovimentacaoRepo operacao = new MovimentacaoRepo(context, estacionamento);

            var veiculos = repoVeic.ObterTodos().Take(5).ToList();
            foreach (var veiculo in veiculos)
                operacao.Estacionar(veiculo);

            var vaga = estacionamento.Vagas.FirstOrDefault();
            var resp = operacao.Retirar(vaga);
            Assert.AreEqual(ERetirarStatus.Falha_PrecoNaoCalculado, resp);
        }
        
        [TestMethod]
        public void TestRetirarVeiculos_ErroVeiculoNaoPago()
        {
            ParkContext context = InicializarDados("Base01");
            VeiculoRepo repoVeic = new VeiculoRepo(context);
            EstacionamentoRepo repoEst = new EstacionamentoRepo(context);
            Estacionamento estacionamento = repoEst.ObterPorCnpj("01001001000101");

            MovimentacaoRepo operacao = new MovimentacaoRepo(context, estacionamento);

            var veiculos = repoVeic.ObterTodos().Take(5).ToList();
            foreach (var veiculo in veiculos)
                operacao.Estacionar(veiculo);

            var vaga = estacionamento.Vagas.FirstOrDefault();
            operacao.CalcularEstacionamento(vaga, vaga.Entrada.AddHours(2));
            var resp = operacao.Retirar(vaga);
            Assert.AreEqual(ERetirarStatus.Falha_PagamentoNaoEfetuado, resp);
        }
        
        
        [TestMethod]
        public void TestRetirarVeiculos_Sucesso()
        {
            ParkContext context = InicializarDados("Retirar03");
            VeiculoRepo repoVeic = new VeiculoRepo(context);
            EstacionamentoRepo repoEst = new EstacionamentoRepo(context);
            Estacionamento estacionamento = repoEst.ObterPorCnpj("01001001000101");

            MovimentacaoRepo operacao = new MovimentacaoRepo(context, estacionamento);

            var veiculos = repoVeic.ObterTodos().Take(5).ToList();
            foreach (var veiculo in veiculos)
                operacao.Estacionar(veiculo);

            var vaga = estacionamento.Vagas.FirstOrDefault();
            operacao.CalcularEstacionamento(vaga, vaga.Entrada.AddHours(2));
            operacao.PagarEstacionamento(vaga);
            var resp = operacao.Retirar(vaga);
            Assert.AreEqual(ERetirarStatus.Sucesso, resp);
        }
        
        [TestMethod]
        public void TestRetirarVeiculos_CalcularValor_Sucesso1()
        {
            ParkContext context = InicializarDados("Calcular01");
            VeiculoRepo repoVeic = new VeiculoRepo(context);
            EstacionamentoRepo repoEst = new EstacionamentoRepo(context);
            Estacionamento estacionamento = repoEst.ObterPorCnpj("01001001000101");

            MovimentacaoRepo operacao = new MovimentacaoRepo(context, estacionamento);

            var veiculos = repoVeic.ObterTodos().Take(5).ToList();
            foreach (var veiculo in veiculos)
                operacao.Estacionar(veiculo);

            var vaga = estacionamento.Vagas.FirstOrDefault();
            operacao.CalcularEstacionamento(vaga, vaga.Entrada.AddHours(7));
            double valor = vaga.ValorPagar;
            // Estacionamento ValorInicial=2 e ValorHora=1
            // Veiculo estacionado por 3 horas. 2 + (1*3) = 5
            Assert.AreEqual(9, valor);
        }
        
        [TestMethod]
        public void TestRetirarVeiculos_CalcularValor_Sucesso2()
        {
            ParkContext context = InicializarDados("Calcular02");
            VeiculoRepo repoVeic = new VeiculoRepo(context);
            EstacionamentoRepo repoEst = new EstacionamentoRepo(context);
            Estacionamento estacionamento = repoEst.ObterPorCnpj("01001001000101");

            MovimentacaoRepo operacao = new MovimentacaoRepo(context, estacionamento);

            var veiculos = repoVeic.ObterTodos().Take(5).ToList();
            foreach (var veiculo in veiculos)
                operacao.Estacionar(veiculo);

            var vaga = estacionamento.Vagas.FirstOrDefault();
            operacao.CalcularEstacionamento(vaga, vaga.Entrada.AddHours(3));
            double valor = vaga.ValorPagar;
            // Estacionamento ValorInicial=2 e ValorHora=1
            // Veiculo estacionado por 3 horas. 2 + (1*3) = 5
            Assert.AreEqual(5, valor);
        }
        
        [TestMethod]
        public void TestEstacionar6Veiculos_ErroAlemDaCapacidade()
        {
            ParkContext context = InicializarDados("Base01");
            VeiculoRepo repoVeic = new VeiculoRepo(context);
            EstacionamentoRepo repoEst = new EstacionamentoRepo(context);
            Estacionamento estacionamento = repoEst.ObterPorCnpj("01001001000101");

            MovimentacaoRepo operacao = new MovimentacaoRepo(context, estacionamento);

            EEstacionarStatus status = EEstacionarStatus.Sucesso;
            var veiculos = repoVeic.ObterTodos().ToList();
            foreach (var veiculo in veiculos)
                status = operacao.Estacionar(veiculo);

            Assert.AreEqual(EEstacionarStatus.Falha_EstacionamentoLotado, status);
        }

        
        [TestMethod]
        public void TestEstacionar6Veiculos_VagasOcupadas()
        {
            ParkContext context = InicializarDados("ObterVagas01");
            VeiculoRepo repoVeic = new VeiculoRepo(context);
            EstacionamentoRepo repoEst = new EstacionamentoRepo(context);
            Estacionamento estacionamento = repoEst.ObterPorCnpj("01001001000101");

            MovimentacaoRepo operacao = new MovimentacaoRepo(context, estacionamento);

            EEstacionarStatus status = EEstacionarStatus.Sucesso;
            var veiculos = repoVeic.ObterTodos().Take(3).ToList();
            foreach (var veiculo in veiculos)
                status = operacao.Estacionar(veiculo);

            Assert.AreEqual(3, operacao.ObterVagasOcupadas());
        }
        
        [TestMethod]
        public void TestEstacionar6Veiculos_VagasDisponiveis()
        {
            ParkContext context = InicializarDados("ObterVagas02");
            VeiculoRepo repoVeic = new VeiculoRepo(context);
            EstacionamentoRepo repoEst = new EstacionamentoRepo(context);
            Estacionamento estacionamento = repoEst.ObterPorCnpj("01001001000101");

            MovimentacaoRepo operacao = new MovimentacaoRepo(context, estacionamento);

            EEstacionarStatus status = EEstacionarStatus.Sucesso;
            var veiculos = repoVeic.ObterTodos().Take(3).ToList();
            foreach (var veiculo in veiculos)
                status = operacao.Estacionar(veiculo);

            Assert.AreEqual(2, operacao.ObterVagasDisponiveis());
        }




        private static ParkContext InicializarDados(string dbName)
        {
            ParkContext context = CriarConexao(dbName);
            var repoVeic = new VeiculoRepo(context);
            //DateTime d = repoVeic.DDD;
            repoVeic.Inserir("FKA-0001", "Ford KA");
            repoVeic.Inserir("GOL-0001", "Gol G5");
            repoVeic.Inserir("CRL-0001", "Corola Super");
            repoVeic.Inserir("PGT-0001", "Peugeot 208");
            repoVeic.Inserir("JRE-0001", "Jeep Renegade");
            repoVeic.Inserir("PAL-0001", "Pálio Copa");

            var estacionamento = new Estacionamento
            {
                Nome = "Estacionamento Teste",
                Cnpj = "01001001000101",
                PrecoInicial = 3,
                PrecoHora = 1,
                VagasTotais = 5
            };
            var repoEstac = new EstacionamentoRepo(context);
            repoEstac.Inserir(estacionamento);

            return context;
        }

        private static ParkContext CriarConexao(string dbName)
        {
            ParkContext context;
            var options = new DbContextOptionsBuilder<ParkContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;
            context = new ParkContext(options);
            return context;
        }
    }
}