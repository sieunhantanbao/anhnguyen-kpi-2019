using SD2411.KPI2019.Infrastructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Books.Model
{
    public class BookCategory : EntityBase
    {
        public BookCategory()
        {
            Books = new HashSet<Book>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
