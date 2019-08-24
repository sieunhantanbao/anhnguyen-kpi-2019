using SD2411.KPI2019.Module.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.BookLending.Model
{
    public class BooksBorrowedByUserResponseDto
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<BookLendingResponseDto> Books { get; set; }
    }
}
