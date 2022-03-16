using Contify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contify.Domain.Interfaces
{
    public interface ITesteService
    {
        ObjetoTeste AtualizarObjeto(ObjetoTeste objeto); 
    }
}
