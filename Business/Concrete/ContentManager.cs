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
    public class ContentManager : IContentService
    {
        IContentDal  _contentdal;
        public ContentManager(IContentDal contentDal)
        {
            _contentdal = contentDal;
        }
        public void ContentAdd(Content content)
        {
            _contentdal.Insert(content);
        }
        
        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Heading GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList()
        {
            return _contentdal.List();
        }

        public List<Content> GetListById(int id)
        {
            return _contentdal.List(x => x.HeadingId == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentdal.List(x => x.WriterId == id);
        }

        Content IContentService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
