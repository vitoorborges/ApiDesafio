using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesafio
{
    public class Jogadas
    {
        public int IdJogadaRealizada { get; set; }
        public int IdJogada { get; set; }
        public int IdJogador { get; set; }


        
        private static List<Jogadas> jogadas = new List<Jogadas>();

        
        public bool InsereJogada(int idJogada, int idJogador)
        {
            bool result;
            try
            {
                if(jogadas.ToArray().Length < 1)
                {
                    jogadas.Add(new Jogadas()
                    {
                        IdJogadaRealizada = 1,
                        IdJogada = idJogada,
                        IdJogador = idJogador
                    });
                }
                else
                {
                    jogadas.Add(new Jogadas()
                    {
                        IdJogadaRealizada = jogadas.Last().IdJogadaRealizada + 1,
                        IdJogada = idJogada,
                        IdJogador = idJogador
                    });

                }
                
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool RemoveJogada(int IdJogada)
        {
            bool result;
            try
            {
                jogadas.Remove(jogadas.SingleOrDefault(r => r.IdJogada == IdJogada));
                result = true;
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Jogadas> GetJogadasrealizadas()
        {
            return jogadas.ToList();
        }

        public void LimpaPalpites()
        {
            jogadas.Clear();
        }

    }
}
