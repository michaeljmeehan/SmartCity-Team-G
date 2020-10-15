using IOTA.Database;
using IOTA.Database.Models;
using IOTA.Models;
using IOTA.Pages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTA.Database.Implements
{
    public class EFCoreLoginRepository : EfCoreRepository<Login, DatabaseContext>
    {
        private readonly DatabaseContext _context;

        public EFCoreLoginRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Login> GetLogin(SignIn model)
        {
            return _context.Login.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
        } 
    }
}
