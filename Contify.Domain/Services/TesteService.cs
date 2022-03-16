using Contify.Domain.Entities;
using Contify.Domain.Interfaces;
using Contify.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contify.Domain.Services
{
    public class TesteService : ITesteService
    {
        public DomainResult<ObjetoTeste> AtualizarObjeto(ObjetoTeste objeto)
        {
            objeto.Atualizar();

            return new DomainResult<ObjetoTeste>(objeto);
        }
    }
}
