using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;
namespace ModelEF.DAO
{
    public class UserDao
    {
        private TruongCongLinhContext db;
        public UserDao()
        {
            db = new TruongCongLinhContext();
        }
        public int login(string user, string pass)
        {
            var rs = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user) 
                                && x.Password.Contains(pass) && x.Status=="Active");
            if(rs == null)
            {
                return 0;
            }
            else {
                return 1; }
        }
        public IEnumerable<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }
       
        public IEnumerable<UserAccount> ListWhereAll(string keysearch,int page,int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            { model = model.Where(x => x.UserName.Contains(keysearch)); }    
        
            return model.OrderBy(x=>x.UserName).ToPagedList(page, pagesize);
        }
        public bool Delete(int id)
        {
            try
            {
                var user =(UserAccount) db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
