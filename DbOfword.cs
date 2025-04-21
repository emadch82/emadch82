using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public class DbOfword
    {
        LoginAndRegisterEntities db = new LoginAndRegisterEntities();

        private LoginRepository<Registertbl> _login;
        public LoginRepository<Registertbl> Login
        {
            get
            {
                if (_login == null)
                {
                    _login = new LoginRepository<Registertbl>(db);
                }
                return _login;
            }
        }
        public void Save()
        {
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
