using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.DataAccess
{
    using Contract;
    using Contract.Models;

    public class ArticleDao : MyBatisNetDao<int, Article>, IArticleDao
    {
        public Article GetById(int id)
        {
            return SqlMap.QueryForObject<Article>("GetArticleByArticleId", id);
        }

        public int Create(Article instance)
        {
            return (int)SqlMap.Insert("InsertArticle", instance);
        }

        public bool Update(Article instance)
        {
            return SqlMap.Update("UpdateArticleByArticleId", instance) > 0;
        }

        public bool Delete(int id)
        {
            return SqlMap.Delete("DeleteArticleByArticleId", id) > 0;
        }

        public IList<Article> GetAll(ExtPaging paging, out int total)
        {
            throw new NotImplementedException();
        }

        public IList<Article> GetAll(ExtPaging paging)
        {
            throw new NotImplementedException();
        }

        public IList<Article> GetAll()
        {
            return SqlMap.QueryForList<Article>("GetAllArticleList", null);
        }
    }
}