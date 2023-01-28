using System;
using System.Collections.Generic;
using Tarefas.DAO;
using Tarefas.DTO;

namespace Tarefas.DAO
{
   /*  public interface ITarefaDAO
    {
        void Atualizar(TarefaDTO tarefa);
        List<TarefaDTO> Consultar();

        TarefaDTO Consultar(int id);
        void Criar(TarefaDTO tarefa);
        void Excluir(int id);
    }  */


 public interface ITarefaDAO
{   void Atualizar(TarefaDTO tarefa);
    List<TarefaDTO> Consultar();
    List<TarefaDTO> Consultar(int usuarioId);
    TarefaDTO Consultar(int id, int usuarioId);
    void Criar(TarefaDTO tarefa);
    void Excluir(int usuarioId);
}

}
