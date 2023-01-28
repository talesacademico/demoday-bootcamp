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
            (Titulo, Descricao, Concluida, UsuarioId) VALUES
            (@Titulo, @Descricao, @Concluida, @UsuarioId);", tarefa
                );
            }
        }

         public TarefaDTO Consultar(int id, int usuarioId)
        {
            using (var con = Connection)
            {
                con.Open();
                TarefaDTO result = con.Query<TarefaDTO>
                (
                    @"SELECT Id, Titulo, Descricao, Concluida FROM Tarefa
                    WHERE Id = @Id", new { usuarioId}
                ).First();
                return result;
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

        public List<TarefaDTO> Consultar(int usuarioId)
        {
            using (var con = Connection)
            {
                con.Open();
                var result = con.Query<TarefaDTO>(
                    @"SELECT Id, Titulo, Descricao, Concluida, UsuarioId FROM Tarefa WHERE UsuarioId = @UsuarioId", new { usuarioId }
                ).ToList();
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
                    SET Titulo = @Titulo, Descricao = @Descricao, Concluida = @Concluida,
                    @UsuarioId;", tarefa
                );
            }
        }

        public void Excluir(int usuarioId)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"DELETE FROM Tarefa
                    WHERE UsuarioId = @UsuarioId", new {usuarioId}
                );
            }
        }



        
    }
}