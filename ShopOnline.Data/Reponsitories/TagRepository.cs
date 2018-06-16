﻿using System.Collections.Generic;
using System.Linq;
using ShopOnline.Data.Inframestructure;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Reponsitories
{
    public interface ITagRepository : IRepository<Tag>
    {
        IEnumerable<Tag> GetTagByProductId(int productId);
    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Tag> GetTagByProductId(int productId)
        {
            IEnumerable<Tag> listTag = from t in DbContext.Tags
                                       join
                                       pt in DbContext.ProductTags
                                       on t.ID equals pt.TagID
                                       where pt.ProductID == productId
                                       orderby t.Name
                                       select t;
            return listTag;
        }
    }
}