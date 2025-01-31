using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class VeiculoTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            // Arrange
            var veiculo = new Veiculo();

            // Act
            veiculo.Id = 1;
            veiculo.Nome = "GOL";
            veiculo.Marca = "VW";
            veiculo.Ano = 2008;

            // Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("GOL", veiculo.Nome);
            Assert.AreEqual("VW", veiculo.Marca);
            Assert.AreEqual(2008, veiculo.Ano);
        }
    }
}

