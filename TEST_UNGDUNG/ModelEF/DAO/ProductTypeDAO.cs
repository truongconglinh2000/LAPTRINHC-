using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
namespace ModelEF.DAO
{
   public  class ProductTypeDAO
    {
        private TruongCongLinhContext db;
        public ProductTypeDAO()
        {
            db = new TruongCongLinhContext();
        }
        public List<LoaiSP> ListAll()
        {
            return db.LoaiSPs.ToList();
        }
    }
}
