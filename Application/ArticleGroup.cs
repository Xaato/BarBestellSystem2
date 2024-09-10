using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class ArticleGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Article>? Articles {get;set;}
    }
}