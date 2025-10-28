using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.DB;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorServiceTest
{
private DbContexto CriarContextoDeTeste()
{
    // Caminho relativo: Test -> (subir 4 níveis) -> Api
    var caminhoApi = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Api");

    var config = new ConfigurationBuilder()
        .SetBasePath(caminhoApi)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    return new DbContexto(config);
}


    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorService = new AdministradorService(context);

        // Act
        administradorService.Criar(adm);

        // Assert
        Assert.AreEqual(1, administradorService.Todos(1).Count());
    }

        [TestMethod]
    public void TestandoBuscarPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorService = new AdministradorService(context);

        // Act
        administradorService.Criar(adm);
        var admDoBanco = administradorService.BuscaPorId(adm.Id);

        // Assert
        Assert.AreEqual(1, admDoBanco?.Id);
    }
}