using Contify.Domain.Entities;
using Contify.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contify.Domain.Services
{
    public class TesteService : ITesteService
    {
        public ObjetoTeste AtualizarObjeto(ObjetoTeste objeto)
        {
            objeto.Atualizar();

            return objeto;
        }
    }
}
