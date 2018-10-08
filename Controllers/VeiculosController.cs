using System.Collections.Generic;
using APISistemaVeicularNet.Models;
using APISistemaVeicularNet.Repositorio;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace APISistemaVeicularNet.Controllers
{
    
    [Route("api/[Controller]")]
    public class VeiculosController : Controller
    {
        private readonly IVeiculosRepositorio _veiculosRepositorio;
        public VeiculosController(IVeiculosRepositorio veiculosRepo)
        {
            _veiculosRepositorio = veiculosRepo;
        }

        [HttpGet]
        public IEnumerable<Veiculos> GetAll()
        {
            return _veiculosRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetVeiculos")]
        public IActionResult GetById(long id)
        {
            var veiculos = _veiculosRepositorio.Find(id);
            if (veiculos == null)
            {
                return NotFound();
            }
            return new ObjectResult(veiculos);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Veiculos veiculos)
        {
            if (veiculos == null)
            {
                return BadRequest();
            }
            else
            {
                _veiculosRepositorio.Add(veiculos);
                return CreatedAtRoute("GetVeiculos", new Veiculos { id = veiculos.id }, veiculos);
            }

        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Veiculos veiculos)
        {
            if (veiculos == null || veiculos.id != id)
            {
                return BadRequest();
            }
            else
            {
                var _veiculos = _veiculosRepositorio.Find(id);
                if (_veiculos == null)
                {
                    return NotFound();
                }
                else
                {
                    _veiculos.nome = veiculos.nome;
                    _veiculos.placa = veiculos.placa;
                    _veiculos.modelo = veiculos.modelo;
                    _veiculos.url = veiculos.url;

                    _veiculosRepositorio.Update(_veiculos);
                    return new NoContentResult();
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var _veiculos = _veiculosRepositorio.Find(id);
            if (_veiculos == null)
            {
                return NotFound();
            }else{
                _veiculosRepositorio.Remove(id);
                return new NoContentResult();
            }
        }
    }
}
