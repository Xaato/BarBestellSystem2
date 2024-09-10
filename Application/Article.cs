using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ArticleGroupId { get; set; }
        public ArticleGroup ArticleGroup { get; set; }
    }
}