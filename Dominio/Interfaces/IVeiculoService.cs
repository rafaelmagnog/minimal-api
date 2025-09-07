using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Dominio.Interfaces
{
    public interface IVeiculoService
    {
        List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null);
        Veiculo? BuscaPorId(int id);

        void Criar(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Deletar(Veiculo veiculo);
    }
}