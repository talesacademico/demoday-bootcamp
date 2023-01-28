using Dapper;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Tarefas.DTO;
using Tarefas.DAO;

namespace Tarefas.DAO
{
    public class DatabaseBootstrap : BaseDAO, IDatabaseBootstrap
    {        
        public DatabaseBootstrap()
        {
            
        }

        public void Setup()
        {
            if(!File.Exists(DataSourceFile))
            {
                using (var con = Connection)
                {   
                    con.Execute(
                        @"CREATE TABLE Tarefa
                        (
                            Id          integer primary key autoincrement,
                            Titulo      varchar(100) not null,
                            Descricao   varchar(100) not null,
                            Concluida   bool not null
                        )"
                    );

                    con.Execute(
                        @"CREATE TABLE Usuario
                        (
                            Id          integer primary key autoincrement,
                            Email       varchar(100) not null,
                            Senha       varchar(100) not null,
                            Nome        varchar(100) not null,
                            Ativo       bool not null
                        )"
                    );  

                    InsertDefaultData(con);
                }
            }
        }

        private void InsertDefaultData(SQLiteConnection con)
        {
            var usuario = new UsuarioDTO()
            {
                Email = "andre@gmail.com",
                Senha = "biscoito",
                Nome = "André Paulovich",
                Ativo = true
            };

            con.Execute(
                @"INSERT INTO Usuario
                (Email, Senha, Nome, Ativo) VALUES
                (@Email, @Senha, @Nome, @Ativo);", usuario
            );        
        }
    }
}