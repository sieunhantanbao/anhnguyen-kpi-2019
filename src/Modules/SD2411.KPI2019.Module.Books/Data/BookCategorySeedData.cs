using SD2411.KPI2019.Module.Books.Model;
using System.Collections.Generic;
using System.Linq;

namespace SD2411.KPI2019.Module.Books.Data
{
    public class BookCaterorySeedData
    {
        public static IEnumerable<BookCategory> Data()
        {
            var bookCats = new List<BookCategory>
            {
                new BookCategory
                {
                    Id = 1,
                    Name = "Business",
                    Description = "The Business Books and Investing Books section is perfect for the professional & student alike, looking to improve their prioritization, productivity and even their work-life balance. Learn the traits and failings of the world's great business leaders and how to create long-term financial success. When you shop business books and investing books with Thriftbooks.com you read more and spend less."
                },
                new BookCategory
                {
                    Id = 2,
                    Name = "Kids",
                    Description = "Take your little ones on a magical journey filled with wizards and talking animals, find the perfect craft or activity, and enlighten their minds with educational books."
                },
                new BookCategory
                {
                    Id = 3,
                    Name = "Comics & Graphic Novels",
                    Description = "Our selection of Comic Books and Graphic Novels is perfect for the collector looking to discover a new story line or the booklover searching for a new medium of entertainment. From children’s favorites to best-selling graphic novels, popular classics, superheroes, hated villains, fantasy, action, humor, alternative, science fiction and more. When you shop comic books and graphic novels with Thriftbooks.com, you will read more and spend less."
                },
                new BookCategory
                {
                    Id = 4,
                    Name = "Computers & Technology",
                    Description = "Our selection of Computer Books and Technology Books will provided guides for the novice nerd, tips and assistance for the student designer, or describe the story of a computer genius for technological inspiration. Other categories may include home computing, mobile computing, graphic design, networking, programming, computer science, business and culture and more. Discover the world of technology and computer science – all for a low price. When you shop used computer books and internet books with Thrfitbooks.com you read more and spend less."
                },
                new BookCategory
                {
                    Id = 5,
                    Name ="Cookbooks, Food & Wine",
                    Description ="Whether you're gourmand, an expert in the kitchen or a first time cook our large selection of Cookery books for all styles of food and all levels of expertise will suit your tastes. Food Books and Wine Books will have something you're looking for. When you shop cookbooks, food books and wine books with Thriftbooks.com you eat more and spend less."
                },
                new BookCategory
                {
                    Id = 6,
                    Name = "Education & Reference",
                    Description ="Thriftbooks.com’s Reference Books section has titles for those looking to improve and develop an industry skill set, or students learning the tools of their trade. These resources aim to help individuals pull from their strengths and improve on their weaknesses through guides, manuals, maps and atlases, encyclopedias, collaborative journalism, rules of order, and more. Pinpoint the facts and learn the tools of your trade – all for a low price. When you shop reference books with Thriftbooks.com you read more and spend less."
                },
                new BookCategory
                {
                    Id = 7,
                    Name ="History",
                    Description ="In our History Books section you'll find used books on local history and histories of international events, histories by epoch and histories by continent. Whether history is a passionate interest, or your field of study, our low prices will open up any field to you whether you're interested in the last decade of the last millennium. When you ship history books at Thriftbooks.com you read more and spend less."
                }
            };
            return bookCats;
        }
    }
}
