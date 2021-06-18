using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
namespace ModelEF.DAO
{
    public class ProductDAO
    {
        private TruongCongLinhContext db;
        public ProductDAO()
        {
            db = new TruongCongLinhContext();
        }
        public List<SanPham> ListAll()
        {
            return db.SanPhams.Where(x => x.Status == 1).OrderBy(x => x.Quanity).ThenByDescending(x => x.UniCost).ToList();           
        }
        public List<SanPham> ListWhere(int Id)
        {
            return db.SanPhams.Where(x => x.ID == Id).ToList();
        }
        public bool Insert(SanPham sp)
        {
            try {
                sp.Status = 1;
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }   
        }
    }
}
