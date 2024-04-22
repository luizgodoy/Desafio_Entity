using Desafio_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Infrastructure.Repository
{
    public class TipoContatoRepository : EFRepository<TipoContato>, ITipoContatoRepository
    {
        public TipoContatoRepository(PostgreContext context) : base(context)
        {

        }
    }
}