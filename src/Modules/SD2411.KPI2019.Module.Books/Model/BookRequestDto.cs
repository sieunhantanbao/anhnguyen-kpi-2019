using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Books.Model
{
    public class BookRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Available2Lend { get; set; }
        public int CatId { get; set; }
    }
}
