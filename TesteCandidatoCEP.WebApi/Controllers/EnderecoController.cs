using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TesteCandidatoCEP.Business.Interfaces;
using TesteCandidatoCEP.DTO;

namespace TesteCandidatoCEP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoBusiness enderecoBusi;

        public EnderecoController(IEnderecoBusiness enderecoBusi)
        {
            this.enderecoBusi = enderecoBusi;
        }


        /// <summary>
        /// Retorna uma localidade.
        /// </summary>
        /// <param name="cep">ID do registro</param>
        /// <returns>EnderecoDTO</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await this.enderecoBusi.FindByIdAsync(id, true);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Falha para recuperar o CEP do banco de dados" });
            }
        }

        /// <summary>
        /// Retorna uma localidade do banco de dados.
        /// </summary>
        /// <param name="cep">número do CEP</param>
        /// <returns>EnderecoDTO</returns>
        [HttpGet("cep/{cep}")]
        public async Task<IActionResult> GetCep(string cep)
        {
            try
            {
                var result = await this.enderecoBusi.GetCepAsync(cep, true);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Falha para recuperar o CEP do banco de dados" });
            }
        }

        /// <summary>
        /// Retorna uma localiade consultando o serviço ViaCEP na internet.
        /// Para mais detalhes da consulta verificar o metodo 'GetCepByWebAsync' em 'TesteCandidatoCEP.Business.Classes' 
        /// </summary>
        /// <param name="cep">número do CEP</param>
        /// <returns>EnderecoDTO</returns>
        [HttpGet("cep/{cep}/web")]
        public async Task<IActionResult> GetCepByWeb(string cep)
        {
            try
            {
                var result = await this.enderecoBusi.GetCepByWebAsync(cep);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Falha para recuperar o CEP da internet: {ex.Message}" });
            }
        }

        /// <summary>
        /// Retorna a lista de localidades.
        /// </summary>
        /// <param name="uf">Sigla UF</param>
        /// <returns>EnderecoDTO</returns>
        [HttpGet("uf/{uf}")]
        public async Task<IActionResult> GetCepsByUf(string uf)
        {
            try
            {
                var result = await this.enderecoBusi.GetCepsByUFAsync(uf, true);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Falha para recuperar a lista de localidades do CEP" });
            }
        }


        /// <summary>
        /// Grava uma localidade no banco de dados.
        /// </summary>
        /// <param name="model">modelo EnderecoDTO</param>
        /// <returns>EnderecoDTO</returns>
        [HttpPost]
        public async Task<IActionResult> Post(EnderecoDTO model)
        {
            try
            {
                var result = await this.enderecoBusi.Create(model);

                if (result != null)
                    return Created($"/endereco/{result.Id}", result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Falha para salvar a localidade" });
            }

            return BadRequest(new { Message = "Falha na requisição para salvar o endereço " });
        }


        /// <summary>
        /// Atualiza uma localidade no banco de dados.
        /// </summary>
        /// <param name="id">ID do registro</param>
        /// <param name="model">modelo EnderecoDTO</param>
        /// <returns>EnderecoDTO</returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, EnderecoDTO model)
        {
            try
            {
                var existe = await this.enderecoBusi.Exists(id);

                if (!existe)
                    return NotFound(new { Message = "localidade não encontrada" });

                var result = await this.enderecoBusi.Update(model);

                if (result != null)
                    return Accepted($"/endereco/{result.Id}", result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Falha para alterar q localidade" });
            }

            return BadRequest(new { Message = "Falha na requisição para alterar a localidade" });
        }

    }
}
