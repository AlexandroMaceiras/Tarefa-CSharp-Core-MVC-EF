using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Models;

namespace Tarefas.Services
{
    public class TarefaItemService : ITarefaItemService
    {
        
        private readonly ApplicationDbContext _context; 
        public TarefaItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TarefaItem>> GetItemAsync(bool? criterio)
        {
            if(criterio != null)
            {
                var itens = await _context.Tarefas
                            .Where(t=>t.EstaCompleta == criterio)
                            .ToArrayAsync();
                return itens;
            }
            else
            {
                var itens = await _context.Tarefas
                            .ToArrayAsync();
                return itens;
            }
        }
        
         public async Task<bool> AdicionarItem(TarefaItem novoItem)
        {
            // TarefaItem novoItemOut = new TarefaItem();

            // novoItemOut.EstaCompleta    = false;
            // novoItemOut.Nome            = novoItem.Nome;
            // novoItemOut.DataConclusao   = novoItem.DataConclusao;

            // _context.Tarefas.Add(novoItemOut);
            
            _context.Tarefas.Add(novoItem);

            var resultado = await _context.SaveChangesAsync();

            return resultado == 1;
        }

        public async Task<bool> DeletarItem(int? id)
        {
            TarefaItem tarefa = _context.Tarefas.Find(id);
            _context.Tarefas.Remove(tarefa);
            var resultado = await _context.SaveChangesAsync();
            return resultado == 1;

        }

        public TarefaItem GetTarefaById(int? id)
        {
            return _context.Tarefas.Find(id);
        }

        public async Task Update(TarefaItem item)
        {
            if(item == null)
                throw new ArgumentException(nameof(item));

            _context.Tarefas.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}