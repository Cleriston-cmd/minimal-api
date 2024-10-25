using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;
namespace Test.Domain.Entidades;

    [TestClass]
    public class VeiculoServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            var options = new DbContextOptionsBuilder<DbContexto>()
                .UseMySql(configuration.GetConnectionString("mysql"), ServerVersion.AutoDetect(configuration.GetConnectionString("mysql")))
                .Options;

            return new DbContexto(configuration);
        }

        [TestMethod]
        public void TestandoIncluirVeiculo()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");
            var veiculo = new Veiculo
            {
                Nome = "GOL",
                Marca = "VW",
                Ano = 2008
            };

            var veiculoServico = new VeiculoServico(context);

            // Act
            veiculoServico.Incluir(veiculo);

            // Assert
            Assert.AreEqual(1, veiculoServico.Todos(1).Count());
        }
        
        [TestMethod]
        public void TestandoBuscaPorId()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");
            var veiculo = new Veiculo
            {
                Nome = "GOL",
                Marca = "VW",
                Ano = 2008
            };

            var veiculoServico = new VeiculoServico(context);
            veiculoServico.Incluir(veiculo);
            
            // Act
            var veiculoDoBanco = veiculoServico.BuscaPorId(veiculo.Id);
            
            // Assert
            Assert.AreEqual(1, veiculoDoBanco?.Id);
        }
    }
