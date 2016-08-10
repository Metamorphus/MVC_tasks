using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week8_2.Models
{
    public class PagesListModel
    {
        public List<Page> pages;
        public int CurPage { get; set; }
        public int MaxPage { get; set; }
    }
}
