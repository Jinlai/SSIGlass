using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.DataAccess
{
    using Contract;
    using Contract.Models;

    public class ArticleRuDao : MyBatisNetDao<int, ArticleRu>, IArticleRuDao
    {
        public ArticleRu GetById(int id)
        {
            return SqlMap.QueryForObject<ArticleRu>("GetArticleRuByArticleId", id);
        }

        public int Create(ArticleRu instance)
        {
            return (int)SqlMap.Insert("InsertArticleRu", instance);
        }

        public bool Update(ArticleRu instance)
        {
            return SqlMap.Update("UpdateArticleRuByArticleId", instance) > 0;
        }

        public bool Delete(int id)
        {
            return SqlMap.Delete("DeleteArticleRuByArticleId", id) > 0;
        }

        public IList<ArticleRu> GetAll(ExtPaging paging, out int total)
        {
            throw new NotImplementedException();
        }

        public IList<ArticleRu> GetAll(ExtPaging paging)
        {
            throw new NotImplementedException();
        }

        public IList<ArticleRu> GetAll()
        {
            return SqlMap.QueryForList<ArticleRu>("GetAllArticleRuList", null);
        }
    }
}