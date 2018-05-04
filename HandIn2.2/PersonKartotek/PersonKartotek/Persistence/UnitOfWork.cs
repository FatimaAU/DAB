using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonKartotek.Core.Repositories;
using PersonKartotek.Persistence.Repositories;

namespace PersonKartotek.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KartotekContext _context;

        public UnitOfWork(KartotekContext context)
        {
            _context = context;
            AlternativeAddress = new AlternativeAddressRepository(_context);
            Address = new AddressRepository(_context);
            Contact = new ContactRepository(_context);
            Person = new PersonRepository(_context);
        }

        public IAlternativeAddressRepository AlternativeAddress { get; private set; }
        public IAddressRepository Address { get; private set; }
        public IContactRepository Contact { get; private set; }
        public IPersonRepository Person { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
