using GerenciamentoTarefas.Application.DTOs;
using GerenciamentoTarefas.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTarefas.API.Controllers
{
    [ApiController]
    [Route("api/tarefas")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tarefas = await _tarefaService.ObterTodos();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tarefa = await _tarefaService.ObterPorId(id);

            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        [HttpPost("criar-tarefa")]
        public async Task<IActionResult> Post(TarefaDTO dto)
        {
            int tarefaId = await _tarefaService.Adicionar(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = tarefaId },
                dto
            );
        }

        [HttpPut("atualizar-tarefa/{id}")]
        public async Task<IActionResult> Put(int id, TarefaDTO dto)
        {
            //if (id != dto.Id)
            //    return BadRequest();
            
            await _tarefaService.Atualizar(dto);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tarefaService.Excluir(id);
            return NoContent();
        }
    }
}
