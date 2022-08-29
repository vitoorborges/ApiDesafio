using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesafio
{
    public class Jogada
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        private static readonly List<Jogada> palpites = new List<Jogada>()
        {
            new Jogada()
            {
                Id = 1,
                Descricao = "Pedra"
            },

            new Jogada()
            {
                Id = 2,
                Descricao = "Papel"
            },

             new Jogada()
            {
                Id = 3,
                Descricao = "Tesoura"
            },
        };

        public IEnumerable<Jogada> getJogadas()
        {
            return palpites.ToArray();
        }

    }
}
