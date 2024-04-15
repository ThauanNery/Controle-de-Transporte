﻿using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;

namespace Controle_de_Transporte.Service
{
    public class TipodeTransporteService : ITipodeTransporteService
    {
        private readonly ITipodeTransporteRepository _repository;

        public TipodeTransporteService(ITipodeTransporteRepository repository)
        {
            _repository = repository;
        }

        public TipoDeTransporteModel GetById(int id)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var repositorio = _repository.GetById(id);
                if (repositorio != null)
                {
                    statusHttp = HttpStatusCode.OK;
                    
                }
                return repositorio;
            }
            catch (Exception ex)
            {

                string errorMessage = "Ocorreu um erro ao buscar o Tipo de Transporte por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public List<TipoDeTransporteModel> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar o Tipo de Transporte.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<TipoDeTransporteModel> AddAsync(TipoDeTransporteModel tpTransporte)
        {
            try
            {
               
                await _repository.createAsync(tpTransporte);
                return tpTransporte;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao adicionar o Tipo de Transporte.";
                throw new Exception(errorMessage, ex);
            }
        }

        public TipoDeTransporteModel Update(TipoDeTransporteModel instituicao)
        {
            try
            {
                    _repository.update(instituicao);
                    return instituicao;

            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualizar o Tipo de Transporte.";
                throw new Exception(errorMessage, ex);
            }
        }

        public TipoDeTransporteModel Delete(int id)
        {
            var statusHttp = HttpStatusCode.NoContent;
            try
            {
                _repository.deleteById(id);
                return null;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao apagar o Tipo de Transporte.";
                throw new Exception(errorMessage, ex);
            }
        }
             
    }
}