using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SD2411.KPI2019.Module.Books.Model
{
    public class BookRequestDto
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Language is required")]
        public string Language { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "ISBN13 is required")]
        public string ISBN13 { get; set; }
        [Required(ErrorMessage = "Length is required")]
        public int Length { get; set; }
        [Required(ErrorMessage = "Weight is required")]
        public string Weight { get; set; }
        [Required(ErrorMessage = "Dimensions is required")]
        public string Dimensions { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        public bool Available2Lend { get; set; }
        [Required(ErrorMessage = "Category Id is required")]
        public int CatId { get; set; }
    }
}
