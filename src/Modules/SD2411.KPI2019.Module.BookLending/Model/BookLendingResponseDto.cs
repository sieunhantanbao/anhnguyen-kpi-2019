using SD2411.KPI2019.Infrastructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.BookLending.Model
{
    public class BookLendingResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Available2Lend
        {
            get
            {
                return IsReturned;
            }
        }
        public string CategoryName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned
        {
            get
            {
                return ReturnDate!= null;
            }
        }
    }
}
