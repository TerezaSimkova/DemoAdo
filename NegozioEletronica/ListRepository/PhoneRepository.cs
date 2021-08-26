using NegozioEletronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioEletronica.ListRepository
{
    class PhoneRepository : IPhoneRepository
    {
        List<Phone> phones = new List<Phone>()
        {
            new Phone(null,"Nokia","SX",85,16),
            new Phone(null,"Samsung","Gold",60,19),
            new Phone(null,"Huawei","XX",35,25),
        };

        public void Delete(Phone phone)
        {
            phones.Remove(phone);
        }

        public List<Phone> Fetch()
        {
            return phones;
        }

        public void Insert(Phone phone)
        {
            phones.Add(phone);
        }

        public void Update(Phone phone)
        {
            Insert(phone);
        }
    }
}
