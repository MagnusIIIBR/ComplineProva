using ComplineProva.Domain;
using ComplineProva.Domain.Repository;
using ComplineProva.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ComplineProva.Web.Controllers
{
    [RoutePrefix("api/tarefas")]
    public class TarefaController : ApiController
    {
        private ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            this._tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var tarefas = _tarefaRepository.GetAll();
                List<TarefaVM> tarefasResponse = new List<TarefaVM>();

                foreach (var item in tarefas)
                {
                    tarefasResponse.Add(new TarefaVM()
                    {
                        Id = item.Id,
                        Titulo = item.Titulo,
                        Importante = item.Importante,
                        Prioridade = item.Prioridade
                    });
                }

                response = Request.CreateResponse(HttpStatusCode.OK, tarefasResponse);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            //var tsc = new HttpResponseMessage();
            //tsc.set.SetResult(response);
            //return tsc;

           return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public Task<HttpResponseMessage> Adicionar(TarefaVM model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _tarefaRepository.Add(new Tarefa(0, model.Titulo, model.Prioridade, model.Importante));
                _tarefaRepository.Save();
                response = Request.CreateResponse(HttpStatusCode.OK, "Registro inserido com sucesso!");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("{id}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody] TarefaVM model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _tarefaRepository.Edit(new Tarefa(model.Id, model.Titulo, model.Prioridade, model.Importante));
                _tarefaRepository.Save();
                response = Request.CreateResponse(HttpStatusCode.OK, "Registro atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _tarefaRepository.Delete(id);
                _tarefaRepository.Save();
                response = Request.CreateResponse(HttpStatusCode.OK, "Registro excluido com sucesso!");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            _tarefaRepository.Dispose();
        }
    }
}
