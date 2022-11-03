using System.Collections.Generic;
using System.Linq;
using API_Folhas.Models;
using Microsoft.AspNetCore.Mvc;
using API_FOlhas.IteratorFuncionario;

namespace API_Folhas.Controllers
{
    [ApiController]
    [Route("api/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private readonly DataContext _context;

        //Injeção de dependência - balta.io
        public FuncionarioController(DataContext context) =>
            _context = context;

        private static List<Funcionario> funcionarios = new List<Funcionario>();

        // GET: /api/funcionario/listar
        [Route("listar")]
        [HttpGet]
        public IActionResult Listar() =>
            Ok(_context.Funcionarios.ToList());

        //GET: /api/funcionario/contar
        [Route("contar")]
        [HttpGet]
        public IActionResult Contar()
        {
            var lista_funcionarios = _context.Funcionarios.ToList();
            ConcreteCollection colecao = new ConcreteCollection(lista_funcionarios);

            Iterator iterator = colecao.CreateIterator();

            return Ok(colecao.Count);
        }

        //GET: /api/funcionario/encontrar/1
        [Route("encontrar/{id}")]
        [HttpGet]
        public IActionResult Encontrar([FromRoute] int id)
        {
            var lista_funcionarios = _context.Funcionarios.ToList();

            Funcionario funcionario_encontrado = null;
            
            //cria uma coleção e vincula ela com a lista de funcionários
            ConcreteCollection colecao = new ConcreteCollection(lista_funcionarios);

            //cria o iterator
            Iterator iterator = colecao.CreateIterator();

            for(Funcionario funcionario = iterator.First(); !iterator.IsDone; funcionario = iterator.Next())
            {
                if(funcionario.FuncionarioId == id)
                {
                    funcionario_encontrado = funcionario;
                }
            }

            if(funcionario_encontrado == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(funcionario_encontrado);
            }
        }

        // POST: /api/funcionario/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return Created("", funcionario);
        }

        // GET: /api/funcionario/buscar/123
        [Route("buscar/{cpf}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] string cpf)
        {
            //Expressão lambda
            Funcionario funcionario =
                _context.Funcionarios.FirstOrDefault
            (
                f => f.Cpf.Equals(cpf)
            );
            //IF ternário
            return funcionario != null ? Ok(funcionario) : NotFound();
        }

        // DELETE: /api/funcionario/deletar/1
        [Route("deletar/{id}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] int id)
        {
            Funcionario funcionario =
                _context.Funcionarios.Find(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
                _context.SaveChanges();
                return Ok(funcionario);
            }
            return NotFound();
        }

        // PATCH: /api/funcionario/alterar
        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }
    }
}


// if (funcionario != null)
// {
//     return Ok(funcionario);
// }
// return NotFound();
// foreach (Funcionario f in funcionarios)
// {
//     if(f.Cpf.Equals(cpf))
//     {
//         return Ok(f);
//     }
// }
// foreach(Funcionario f in _context.Funcionarios.ToList()){

// }