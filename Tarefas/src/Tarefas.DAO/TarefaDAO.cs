using Dapper;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Tarefas.DTO;
using System.Collections.Generic;

namespace Tarefas.DAO
{
    public class TarefaDAO : BaseDAO, ITarefaDAO
    {        
        public void Criar(TarefaDTO tarefa)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"INSERT INTO Tarefa
                    (Titulo, Descricao, Concluida) VALUES
                    (@Titulo, @Descricao, @Concluida);", tarefa
                );
            }
        }

        public List<TarefaDTO> Consultar()
        {
            using (var con = Connection)
            {
                con.Open();
                var result = con.Query<TarefaDTO>(
                    @"SELECT Id, Titulo, Descricao, Concluida FROM Tarefa"
                ).ToList();
                return result;
            }
        }

        public TarefaDTO Consultar(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                TarefaDTO result = con.Query<TarefaDTO>
                (
                    @"SELECT Id, Titulo, Descricao, Concluida FROM Tarefa
                    WHERE Id = @Id", new { id }
                ).First();
                return result;
            }
        }

        public void Atualizar(TarefaDTO tarefa)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"UPDATE Tarefa 
                    SET Titulo = @Titulo, Descricao = @Descricao, Concluida = @Concluida
                    WHERE Id = @Id;", tarefa
                );
            }
        }

        public void Excluir(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"DELETE FROM Tarefa
                    WHERE Id = @Id", new { id }
                );
            }
        }
    }
}