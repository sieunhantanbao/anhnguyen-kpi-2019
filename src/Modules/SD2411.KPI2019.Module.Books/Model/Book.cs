using SD2411.KPI2019.Infrastructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SD2411.KPI2019.Module.Books.Model
{
    public class Book : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }
        public string ISBN13 { get; set; }
        public int Length { get; set; }
        public string Weight { get; set; }
        public string Dimensions { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Available2Lend { get; set; }

        [ForeignKey("BookCategoryId")]
        public BookCategory BookCategory { get; set; }
        public int BookCategoryId { get; set; }
    }
}
