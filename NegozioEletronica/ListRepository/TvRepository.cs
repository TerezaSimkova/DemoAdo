using NegozioEletronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioEletronica.ListRepository
{
    class TvRepository : ITvRepository
    {
        List<Tv> tvs = new List<Tv>()
        {
            new Tv(null,"LG","Zero",68,65),
            new Tv(null,"Samsung","Q5",103,55),
            new Tv(null,"OLED","Qe5",15,30),
        };

        public void Delete(Tv tv)
        {
            tvs.Remove(tv);
        }

        public List<Tv> Fetch()
        {
            return tvs;
        }

        public void Insert(Tv tv)
        {
            tvs.Add(tv);
        }

        public void Update(Tv tv)
        {
            Insert(tv);
        }
    }
}
