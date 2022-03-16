using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contify.Domain.Entities
{
    public class ObjetoTeste
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }

        public ObjetoTeste() { }

        public ObjetoTeste(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void Atualizar()
        {
            Id = 15;
            Nome = $"{Nome} Atualizado";
        }
    }
}
