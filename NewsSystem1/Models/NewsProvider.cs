using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSystem1.Models
{
    public class NewsProvider : IProvider<News>
    {
        private NewsDbEntities2 db = new NewsDbEntities2();
        public int Delete(News t)
        {
            if (t == null) return 0;
            var model = db.News.ToList().FirstOrDefault(item => item.Id == t.Id);
            if (model == null) return 0;
            db.News.Remove(model);
            int count = db.SaveChanges();
            return count;
        }

        public int insert(News t)
        {
            if (t == null) return 0;
            db.News.Add(t);
            int count = db.SaveChanges();
            return count;
        }

        public List<News> Select()
        {
            return db.News.ToList();
        }

        public int Update(News t)
        {
            if (t == null) return 0;
            var model = db.News.ToList().FirstOrDefault(item => item.Id == t.Id);
            if (model == null) return 0;
            model.Title = t.Title;
            model.Text = t.Text;
            int count = db.SaveChanges();
            return count;
       
        }
    }
}