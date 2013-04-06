using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventOrganizer.Web.Models
{
    public class SearchResult
    {
        public IList<SearchResultItem> Users { get; set; }
        public IList<SearchResultItem> Events { get; set; }
        public IList<SearchResultItem> Groups { get; set; }
    }
}