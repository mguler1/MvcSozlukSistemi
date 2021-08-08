using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void AdminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminAdd(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public Admin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
           return  _adminDal.List();
        }
    }
}
