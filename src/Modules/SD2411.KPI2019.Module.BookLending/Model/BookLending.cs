using SD2411.KPI2019.Infrastructure.Model.Entity;
using System;

namespace SD2411.KPI2019.Module.BookLending.Model
{
    public class BookLending : EntityBase
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
