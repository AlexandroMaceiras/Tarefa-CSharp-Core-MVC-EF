using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Models;

namespace Tarefas.Services
{
    public class TempTarefaItemService //: ITarefaItemService
    {
        public Task<IEnumerable<TarefaItem>> GetItemAsync()
        {
            IEnumerable<TarefaItem> items = new[]
            {
                new TarefaItem
                {
                    Nome = "Ver essa merda",
                    EstaCompleta = false,
                    DataConclusao = DateTimeOffset.Now.AddDays(30)
                },
                new TarefaItem
                {
                    Nome = "Treinar porque esqueci tudo",
                    EstaCompleta = false,
                    DataConclusao = DateTimeOffset.Now.AddDays(60)

                }
            };


            return Task.FromResult(items);
        }
    }
}