using NegozioEletronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioEletronica.ListAdoRepository
{
    class PcAdoRepository : IPcRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=NegozioElettronica; Integrated Security=true;";

        const string _discriminator = "Pc";

        public void Delete(Pc pc)
        {
            throw new NotImplementedException();
        }

        public List<Pc> Fetch()
        {
            throw new NotImplementedException();
        }

        public void Insert(Pc pc)
        {
            throw new NotImplementedException();
        }

        public void Update(Pc pc)
        {
            throw new NotImplementedException();
        }
    }
}
