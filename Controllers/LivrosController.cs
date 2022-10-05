using CebolinhaApi.Models;
using CebolinhaApi.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CebolinhaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        // GET: api/Livros
        [HttpGet]
        public IEnumerable<Livro> Get()
        {
            return RepositorioSimulado.Livros;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Livro livro = RepositorioSimulado.Livros.FirstOrDefault(l => l.Id == id);

            if (livro != null)
            {
                return Ok(livro);
            }
            else
            {
                return NotFound();
            }

            
        }

        [HttpPost]
        public ActionResult Post([FromBody] Livro livroObjeto)
        {
            Livro livro = RepositorioSimulado.Livros.FirstOrDefault(l => l.Id == livroObjeto.Id);

            if (livro != null)
            {
                return Conflict("Já existe um livro cadastrado com essas informações!");
            }
            else
            {
                RepositorioSimulado.Livros.Add(livroObjeto);
                return Ok();
            }

        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Livro livroObjeto)
        {
            Livro livro = RepositorioSimulado.Livros.FirstOrDefault(l => l.Id == livroObjeto.Id);

            if (livro != null)
            {
                livro.Titulo = livroObjeto.Titulo;
                livro.Autor = livroObjeto.Autor;
                return Ok("Registro atualizado com sucesso!");
            }
            else
            {
                return NotFound("Erro ao atualizar o livro. Dados informados não encontrados!");
            }
        }

        // DELETE 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Livro livro = RepositorioSimulado.Livros.FirstOrDefault(l => l.Id == id);

            if (livro != null)
            {
                RepositorioSimulado.Livros.Remove(livro);
                return Ok("Registro removido com sucesso!");
            }
            else
            {
                return NotFound("Erro ao remover o livro. Dados informados não encontrados!");
            }

        }
    }
}
