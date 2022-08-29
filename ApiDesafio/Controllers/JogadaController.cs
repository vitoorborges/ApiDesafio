using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadaController : ControllerBase
    {
        private readonly Jogada jogada = new Jogada();
        private readonly Jogador jogador = new Jogador();
        private readonly Jogadas jogadaRealizada = new Jogadas();

        //Lista todas as jogadas diponíveis
        [HttpGet("JogadasDisponiveis")]
        public IEnumerable<Jogada> jogadas()
        {
            return jogada.getJogadas();
        }


        //Insere jogada a partir do nome do jogador e descrição da jogada desejada
        [HttpGet("Inserir/{nomeJogador}/{descricaoJogada}")]
        public MensagemRetorno InsereJogadas(string nomeJogador, string descricaoJogada)
        {
            MensagemRetorno mensagemRetorno = new MensagemRetorno();
            var jogadores = jogador.GetJogadores();
            var jogadas = jogada.getJogadas();

            if (jogadores.Count() < 1)
            {
                mensagemRetorno.StatusCode = 400;
                mensagemRetorno.Mensagem = "Jogador inexistente";
                return mensagemRetorno;
            }

                int idJogador = jogadores.SingleOrDefault(r => r.Nome == nomeJogador).Id;
                int idJogada = jogadas.SingleOrDefault(r => r.Descricao == descricaoJogada).Id;

            if(jogadaRealizada.InsereJogada(idJogada, idJogador))
            {
                mensagemRetorno.StatusCode = 200;
                mensagemRetorno.Mensagem = "Jogada inserido com sucesso";
            }

            return mensagemRetorno;

        }

        //Remove uma jogada a partir do nome do jogador
        [HttpDelete("Remove/{nomeJogador}")]
        public MensagemRetorno RemoveJogada(string nomeJogador)
        {
            MensagemRetorno mensagemRetorno = new MensagemRetorno();
            var jogadasRealizadas = jogadaRealizada.GetJogadasrealizadas();
            var jogadores = jogador.GetJogadores();
            
            if(jogadasRealizadas.Count() < 1 || jogadores.Count() < 1)
            {
                mensagemRetorno.StatusCode = 400;
                mensagemRetorno.Mensagem = "Jogador inexistente ou não possui jogada";
                return mensagemRetorno;
            }


            var idJogadorRemove = jogadores.SingleOrDefault(r => r.Nome == nomeJogador).Id;
            if (jogadaRealizada.RemoveJogada(jogadasRealizadas.SingleOrDefault(r => r.IdJogador == idJogadorRemove).IdJogada))
            {
                mensagemRetorno.StatusCode = 200;
                mensagemRetorno.Mensagem = "Jogada removida com sucesso";
                return mensagemRetorno;
            }
            else
            {
                mensagemRetorno.StatusCode = 400;
                mensagemRetorno.Mensagem = "Jogador não possui jogada";
                return mensagemRetorno;
            }
        }
    }
}
