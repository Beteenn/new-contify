using Contify.Application.DTO;
using Contify.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contify.Application.Interfaces
{
    public interface ITesteAppService
    {
        ObjetoTesteViewModel Teste(ObjetoTesteDto objetoDto);
    }
}
