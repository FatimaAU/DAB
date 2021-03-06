﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonKartotek.Core;
using PersonKartotek.Core.Domain;
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
            MainAddress = new MainAdressRepository(_context);
        }

        public IAlternativeAddressRepository AlternativeAddress { get; }
        public IAddressRepository Address { get; }
        public IContactRepository Contact { get; }
        public IPersonRepository Person { get; }
        public IMainAddressRepository MainAddress { get; }

        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Dublicated KEY Value -- Can't save changes");
                return 0;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
