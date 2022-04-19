using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSystem1.Models
{
    public class MemberProvider : IProvider<Member>
    {
        private NewsDbEntities2 db = new NewsDbEntities2();
        public int Delete(Member t)
        {
            if (t == null) return 0;
            var model = db.Member.ToList().FirstOrDefault(item => item.Id == t.Id);
            if (model == null) return 0;
            db.Member.Remove(model);
            int count = db.SaveChanges();
            return count;
        }

        public int insert(Member t)
        {
            if (t == null) return 0;
            db.Member.Add(t);
            int count = db.SaveChanges();
            return count;
        }

        public List<Member> Select()
        {
            return db.Member.ToList();
        }

        public int Update(Member t)
        {
            if (t == null) return 0;
            var model = db.Member.ToList().FirstOrDefault(item => item.Id == t.Id);
            if (model == null) return 0;
            model.Password = t.Password;
            int count = db.SaveChanges();
            return count;
        }
    }
}