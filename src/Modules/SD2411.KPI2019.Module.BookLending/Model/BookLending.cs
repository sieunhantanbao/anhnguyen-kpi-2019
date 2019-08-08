using SD2411.KPI2019.Infrastructure.Model.Entity;
using SD2411.KPI2019.Module.Books.Model;
using SD2411.KPI2019.Module.Users.Model;
using System;

namespace SD2411.KPI2019.Module.BookLending.Model
{
    public class BookLending : EntityBase
    {
        public Book Book { get; set; }
        public UserAccount UserAccount { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
