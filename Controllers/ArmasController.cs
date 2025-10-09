using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly DataContext _context;

         public ArmasController(DataContext context)
        {
            _context = context;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Arma a = await _context.TB_ARMAS.FirstOrDefaultAsync(aBusca => aBusca.Id == id);
                return Ok (a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Arma> lista = await _context.TB_ARMAS.ToListAsync();
                return Ok(lista);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add(Arma novaArma)
        {
            try
            {
                if(novaArma.Dano > 1000)
                {
                    throw new Exception("Danos não podem ser maior que 1.000");
                }
                await _context.TB_ARMAS.AddAsync(novaArma);
                await _context.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Arma novaArma)
        {
            try
            {
                if(novaArma.Dano > 100)
                    throw new Exception("Danos não podem ser maior que 1.000");
                
                Personagem p = await _context.TB_PERSONAGENS
                    .FirstOrDefaultAsync(p => p.Id == novaArma.PersonagemId);

                if (p == null)
                    throw new Exception("Não existe personagem com o Id informado");

                _context.TB_ARMAS.Update(novaArma);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Arma aRemover = await  _context.TB_ARMAS.FirstOrDefaultAsync(a => a.Id == id);

                _context.TB_ARMAS.Remove(aRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
























