using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {

        private readonly ILogger<Jogador> logger;

        private Jogadas palpiteJogador = new Jogadas();
        private readonly Jogador jogador = new Jogador();
         



        //Realiza o jogo fazendo um uma comparação a cada jogador e o próxmo, levando em consideração assim vantagem ao último jogador dado palpite em caso de mais de 2 jogadores
        [HttpGet("Jogar")]
        public MensagemRetorno Jogar()
        {

            MensagemRetorno mensagemRetorno = new MensagemRetorno();
            var palpiteJogadores = palpiteJogador.GetJogadasrealizadas();
            var jogadores = jogador.GetJogadores();
            int indexVencedor = 1;
            

            for (int i = 1; i < palpiteJogadores.ToArray().Length; i++)
            {
              
                if(palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == indexVencedor).IdJogada == 3 && palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == i+ 1).IdJogada == 1)
                {
                    indexVencedor = palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == i + 1).IdJogador;
                    mensagemRetorno.Mensagem = jogadores.SingleOrDefault(r => r.Id == indexVencedor).Nome + " Venceu";
                    

                }
                else if(palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == indexVencedor).IdJogada == 1 && palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == i + 1).IdJogada == 3)
                {
                    indexVencedor = palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == indexVencedor).IdJogador;
                    mensagemRetorno.Mensagem = jogadores.SingleOrDefault(r => r.Id == indexVencedor).Nome + " Venceu";
                    

                }
                else if (palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == indexVencedor).IdJogada == palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == i + 1).IdJogada)
                {
                    indexVencedor = i + 1;

                }
                else if(palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == indexVencedor).IdJogada > palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == i + 1).IdJogada)
                {
                    indexVencedor = palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == indexVencedor).IdJogador;
                    mensagemRetorno.Mensagem = jogadores.SingleOrDefault(r => r.Id == indexVencedor).Nome + " Venceu";
                    
                }
                else if (palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == indexVencedor).IdJogada < palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == i + 1).IdJogada)
                {
                    indexVencedor = palpiteJogadores.SingleOrDefault(r => r.IdJogadaRealizada == i + 1).IdJogador;
                    mensagemRetorno.Mensagem = jogadores.SingleOrDefault(r => r.Id == indexVencedor).Nome + " Venceu";
                    
                }

            }

            
            



            
            palpiteJogadores.Clear();
            palpiteJogador.LimpaPalpites();

            return mensagemRetorno;

        }


    }
    
}
