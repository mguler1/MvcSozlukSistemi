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
    public class WriterManager : IWriterService
    {
      private readonly  IWriterDal _writerdal;
        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }
        public Writer GetById(int id)
        {
            return _writerdal.Get(x => x.WriterId==id);
        }

        public List<Writer> GetList()
        {
            return _writerdal.List();
        }

        public void WriterAdd(Writer writer)
        {
            _writerdal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerdal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerdal.Update(writer);
        }
    }
}
