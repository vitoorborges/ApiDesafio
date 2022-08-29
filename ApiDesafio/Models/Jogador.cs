using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesafio
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        private static List<Jogador> jogadores = new List<Jogador>();

        public IEnumerable<Jogador> GetJogadores()
        {
            return jogadores.ToArray();
        }

        public bool InsertJogador(string nome)
        {
            bool result;
            try
            {
                if (jogadores.ToArray().Length < 1)
                {
                    jogadores.Add(new Jogador()
                    {
                        Id = 1,
                        Nome = nome
                    }); ;
                }
                else
                {
                    jogadores.Add(new Jogador()
                    {
                        Id = jogadores.Last().Id + 1,
                        Nome = nome
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


        public bool DeleteJogador(string Nome)
        {
            bool result = false;
            try
            {
                foreach (var item in jogadores)
                {
                    if (item.Nome == Nome)
                    {
                        var JogadorRemovido = jogadores.SingleOrDefault(r => r.Nome == Nome);
                        jogadores.Remove(JogadorRemovido);
                        result = true;
                        return result;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;

        }

    }


}
