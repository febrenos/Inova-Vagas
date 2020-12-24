using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using InovaWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InovaWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCursoController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private ITipoCursoRepository _tipoCursoRepository;

        /// <summary>
        /// 
        /// </summary>  
        public TipoCursoController()
        {
            _tipoCursoRepository = new TipoCursoRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoCursoRepository.ListarTodos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoTipoCurso"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TipoCurso novoTipoCurso)
        {
            try
            {
                _tipoCursoRepository.Cadastrar(novoTipoCurso);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoCursoAtualizado"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id ,TipoCurso tipoCursoAtualizado)
        {
            try
            {
                TipoCurso tipoCursoBuscado = _tipoCursoRepository.BuscarPorId(id);

                if (tipoCursoBuscado != null)
                {
                    _tipoCursoRepository.Atualizar(id, tipoCursoAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Nenhum tipo de curso encontrado.");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                TipoCurso tipoCursoBuscado = _tipoCursoRepository.BuscarPorId(id);

                if (tipoCursoBuscado != null)
                {
                    _tipoCursoRepository.Excluir(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum tipo de curso encontrado.");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
