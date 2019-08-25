using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.BookLending.Data
{
    public class BookLendingSeedData
    {
        public static IEnumerable<Model.BookLending> Data()
        {
            var bookLendings = new List<Model.BookLending>
            {
                new Model.BookLending
                {
                    Id = 1,
                    UserId = "69016cd7-609d-4539-a786-af8475f8c624",
                    BookId = 1,
                    BorrowDate = new DateTime(2019, 8, 20),
                    ReturnDate = null
                },
                new Model.BookLending
                {
                    Id = 2,
                    UserId = "69016cd7-609d-4539-a786-af8475f8c624",
                    BookId = 2,
                    BorrowDate = new DateTime(2019, 7, 20),
                    ReturnDate = null
                },
                new Model.BookLending
                {
                    Id = 3,
                    UserId = "69016cd7-609d-4539-a786-af8475f8c624",
                    BookId = 3,
                    BorrowDate = new DateTime(2019, 6, 20),
                    ReturnDate = new DateTime(2019, 7, 15)
                }
            };

            return bookLendings;
        }
    }
}
