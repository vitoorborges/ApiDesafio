using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadorController : ControllerBase
    {

        private readonly Jogador jogador = new Jogador();

        //Lista todos os jogadores disponíveis
        [HttpGet("Mostrar")]
        public IEnumerable<Jogador> GetJogadores()
        {
            return jogador.GetJogadores();
        }

        //Adiciona um jogador a partir do nome inserido
        [HttpGet("Adicionar/{nome}")]
        public MensagemRetorno SetJogador(string nome)
        {
            MensagemRetorno mensagemRetorno = new MensagemRetorno();
            if (jogador.InsertJogador(nome))
            {
                mensagemRetorno.Mensagem = "Jogador cadastrado com sucesso";
                mensagemRetorno.StatusCode = 200;
            }

            return mensagemRetorno;
        }

        //Deleta o jogador a partir do nome inserido
        [HttpDelete("Remover/{nome}")]
        public MensagemRetorno DeletaJogador(string nome)
        {
            MensagemRetorno mensagemRetorno = new MensagemRetorno();
            if (jogador.DeleteJogador(nome))
            {
                mensagemRetorno.StatusCode = 200;
                mensagemRetorno.Mensagem = "Jogador removido com suceso";
            }
            else
            {
                mensagemRetorno.StatusCode = 400;
                mensagemRetorno.Mensagem = "Jogador não encontrado";
            }

            return mensagemRetorno;
        }
    }
}
