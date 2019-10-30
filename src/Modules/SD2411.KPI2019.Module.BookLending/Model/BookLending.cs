using SD2411.KPI2019.Infrastructure.Model.Entity;
using SD2411.KPI2019.Module.Books.Model;
using SD2411.KPI2019.Module.Core.Model;
using SD2411.KPI2019.Module.Users.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SD2411.KPI2019.Module.BookLending.Model
{
    public class BookLending : EntityBase
    {
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int BookId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser AppUser { get; set; }
        public string UserId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
