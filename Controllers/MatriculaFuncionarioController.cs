﻿using Controle_de_Transporte.Models;
using Controle_de_Transporte.Service;
using Controle_de_Transporte.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Controle_de_Transporte.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MatriculaFuncionarioController : ControllerBase
    {

        private readonly IMatriculaFuncionarioService _matriculaFuncionarioService;
        public MatriculaFuncionarioController(IMatriculaFuncionarioService matriculaFuncionarioService)
        {
            _matriculaFuncionarioService = matriculaFuncionarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var cargos = await _matriculaFuncionarioService.GetAllAsync();
                return Ok(cargos);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var cargo = await _matriculaFuncionarioService.GetByIdAsync(id);
                if (cargo == null)
                {
                    return NotFound();
                }
                return Ok(cargo);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }


        [HttpPost("{funcionarioId}")]
        public async Task<IActionResult> CreateAsync(int funcionarioId, [FromBody] MatriculaFuncionarioModel matriculaFuncionario)
        {
            try
            {
               
                var novaMatricula = await _matriculaFuncionarioService.AddAsync(matriculaFuncionario, funcionarioId);

               
                return CreatedAtAction(nameof(GetByIdAsync), new { id = novaMatricula.Id }, novaMatricula);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao criar a Matricula.");
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync(MatriculaFuncionarioModel matriculaFuncionario)
        {
            try
            {
                await _matriculaFuncionarioService.UpdateAsync(matriculaFuncionario);
                return Ok(matriculaFuncionario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _matriculaFuncionarioService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }
    }
}

