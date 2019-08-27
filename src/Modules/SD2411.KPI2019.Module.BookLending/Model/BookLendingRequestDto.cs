using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.BookLending.Model
{
    public class BookLendingRequestDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
    }
}
