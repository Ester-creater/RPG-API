using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models.Enuns;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensExercicioController : ControllerBase 
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=90, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=30, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=56, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=55, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=18, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=28, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var personagem = personagens.FirstOrDefault(p => p.Nome.ToLower() == nome.ToLower());
            
            if (personagem == null)
                return NotFound("Personagem não encontrado.");
            
            return Ok(personagem);
        }

        [HttpGet("GetClerigolMago")]
        public IActionResult GetClerigolMago()
        {
            var personagensFiltrados = personagens
                .Where(p => p.Classe != ClasseEnum.Cavaleiro)
                .OrderByDescending(p => p.PontosVida)
                .ToList();
            
            return Ok(personagensFiltrados);
        }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            var quantidade = personagens.Count;
            var somaInteligencia = personagens.Sum(p => p.Inteligencia);
            
            var estatisticas = new
            {
                QuantidadePersonagens = quantidade,
                SomaInteligencia = somaInteligencia
            };
            
            return Ok(estatisticas);
        }

        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao([FromBody] Personagem novoPersonagem)
        {
            if (novoPersonagem.Defesa < 10 || novoPersonagem.Inteligencia > 30)
                return BadRequest("Personagem inválido: Defesa deve ser >= 10 e Inteligência <= 30");
            
            novoPersonagem.Id = personagens.Max(p => p.Id) + 1;
            personagens.Add(novoPersonagem);
            
            return Ok(novoPersonagem);
        }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago([FromBody] Personagem novoPersonagem)
        {
            if (novoPersonagem.Classe == ClasseEnum.Mago && novoPersonagem.Inteligencia < 35)
                return BadRequest("Magos devem ter inteligência >= 35");
            
            novoPersonagem.Id = personagens.Max(p => p.Id) + 1;
            personagens.Add(novoPersonagem);
            
            return Ok(novoPersonagem);
        }

        [HttpGet("GetByClasse/{classeId}")]
        public IActionResult GetByClasse(int classeId)
        {
            if (!Enum.IsDefined(typeof(ClasseEnum), classeId))
                return BadRequest("Classe inválida");
            
            ClasseEnum classe = (ClasseEnum)classeId;
            
            var personagensClasse = personagens
                .Where(p => p.Classe == classe)
                .ToList();
            
            return Ok(personagensClasse);
        }
    }
}