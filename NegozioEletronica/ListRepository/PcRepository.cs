using NegozioEletronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioEletronica.ListRepository
{
    class PcRepository : IPcRepository
    {
        List<Pc> pcs = new List<Pc>()
        {
            new Pc(null,"Lenovo","CoreI5",24,EnumOP.Linux,true),
            new Pc(null,"Dell","I6",29,EnumOP.Windows,false),       
            new Pc(null,"Apple","Light",36,EnumOP.Mac,true),       
        };

        public void Delete(Pc pc)
        {
            pcs.Remove(pc);
        }

        public List<Pc> Fetch()
        {
            return pcs;
        }

        public void Insert(Pc pc)
        {
            pcs.Add(pc);
        }

        public void Update(Pc pc)
        {
            Insert(pc);
        }
    }
}
