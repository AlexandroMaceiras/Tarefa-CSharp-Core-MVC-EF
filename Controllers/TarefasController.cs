using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarefas.Models;
using Tarefas.Services;

namespace Tarefas.Controllers
{
    public class TarefasController : Controller
    {
        ITarefaItemService _tarefaService;
        public TarefasController(ITarefaItemService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        TarefaViewModel _tarefaViewModel;

        //Lista de tarefas
        public async Task<IActionResult> Index(bool? criterio, TarefaViewModel tarefaViewModel)
        {
             _tarefaViewModel = tarefaViewModel;
            //TempTarefaItemService servico = new TempTarefaItemService();
            //var tarefas = servico.GetItemAsync();
            
            var tarefas = await _tarefaService.GetItemAsync(criterio); 

            //var model = new TarefaViewModel();
            var TarefaViewModel = _tarefaViewModel;
            {
                TarefaViewModel.TarefaItens = tarefas;
            }

            return View(TarefaViewModel);
        }

        [HttpGet]
        public IActionResult AdicionarItemTarefa()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AdicionarItemTarefa([Bind("Id, EstaCompleta, Nome, DataConclusao")] TarefaItem tarefa)
        {
            if(ModelState.IsValid)
            {
                await _tarefaService.AdicionarItem(tarefa);
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var tarefaItem = _tarefaService.GetTarefaById(id);
            if(tarefaItem == null)
            {
                return NotFound();
            }
            return View(tarefaItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Id,EstaCompleta,Nome,DataConclusao")] TarefaItem tarefaItem)
        {
            if(id != tarefaItem.Id)
                return NotFound();

            if(ModelState.IsValid)
            {
                try
                {
                    await _tarefaService.Update(tarefaItem);
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tarefaItem);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var tarefaItem = _tarefaService.GetTarefaById(id);

            if(tarefaItem == null)
            {
                return NotFound();
            }

            return View(tarefaItem);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _tarefaService.DeletarItem(id);

            return RedirectToAction(nameof(Index));
        }


    }
}