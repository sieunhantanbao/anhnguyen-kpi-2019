using SD2411.KPI2019.Infrastructure.Helpers;
using SD2411.KPI2019.Module.Books.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Books.Data
{
    public class BookSeedData
    {
        public static IEnumerable<Book> Data()
        {

            var books = new List<Book>
            {
                // Caterogy 1
                new Book
                {
                    Id = 1,
                    Name = "Outliers: The Story of Success",
                    Slug = FriendlyUrlHelper.GetFriendlyTitle("Outliers: The Story of Success", true),
                    Language ="English",
                    ISBN = "0316017930",
                    ISBN13 = "9780316017930",
                    Length = 336,
                    Weight ="0.75 lbs",
                    Author ="Malcolm Gladwell",
                    Available2Lend = true,
                    Description = "In this stunning new book, Malcolm Gladwell takes us on an intellectual journey through the world of outliers--the best and the brightest, the most famous and the most successful. He asks the question: what makes high-achievers different? His answer is that we pay too much attention to what successful people are like, and too little attention to where they are from: that is, their culture, their family, their generation, and the idiosyncratic experiences of their upbringing. Along the way he explains the secrets of software billionaires, what it takes to be a great soccer player, why Asians are good at math, and what made the Beatles the greatest rock band. Brilliant and entertaining, Outliers is a landmark work that will simultaneously delight and illuminate.",
                    Dimensions ="8.3 x 1.1 x 5.5 (inches)",
                    ImageUrl ="https://images-na.ssl-images-amazon.com/images/I/41LO6QRvIuL._SL300_.jpg",
                    PublishedDate = new DateTime(2011, 6, 1),
                    BookCategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Name = "Life of Pi",
                    Slug = FriendlyUrlHelper.GetFriendlyTitle("Life of Pi", true),
                    Language ="English",
                    ISBN = "0156027321",
                    ISBN13 = "N/A",
                    Length = 326,
                    Weight ="0.87 lbs",
                    Author ="Yann Martel",
                    Available2Lend = true,
                    Description = "No Synopsis Available.",
                    Dimensions ="0.9 x 5.0 x 8.0 (inches)",
                    ImageUrl ="https://images-na.ssl-images-amazon.com/images/I/51rxEvLljUL._SL300_.jpg",
                    PublishedDate = new DateTime(2003,5,1),
                    BookCategoryId = 1
                },
                new Book
                {
                    Id = 3,
                    Name = "Think and Grow Rich: The Landmark Bestseller Now Revised and Updated for the 21st Century (Think and Grow Rich Series)",
                    Slug = FriendlyUrlHelper.GetFriendlyTitle("Think and Grow Rich: The Landmark Bestseller Now Revised and Updated for the 21st Century (Think and Grow Rich Series)", true),
                    Language ="English",
                    ISBN = "1585424331",
                    ISBN13 = "9781585424337",
                    Length = 320,
                    Weight ="0.63 lbs.",
                    Author = "Ben Holden-Crowther and Napoleon Hill",
                    Available2Lend = true,
                    Description = "Please note that this item is a roughcut (deckle edge) editionThink and Grow Rich has been called the Granddaddy of All Motivational Literature. It was the first book to boldly ask, What makes a winner? The man who asked and listened for the answer, Napoleon Hill, is now counted in the top ranks of the world's winners himself. The most famous of all teachers of success spent a fortune and the better part of a lifetime of effort to produce the Law of Success philosophy that forms the basis of his books and that is so powerfully summarized in this one. In the original Think and Grow Rich, published in 1937, Hill draws on stories of Andrew Carnegie, Thomas Edison, Henry Ford, and other millionaires of his generation to illustrate his principles. In the updated version, Arthur R. Pell, Ph.D., a nationally known author, lecturer, and consultant in human resources management and an expert in applying Hill's thought, deftly interweaves anecdotes of how contemporary millionaires and billionaires, such as Bill Gates, Mary Kay Ash, Dave Thomas, and Sir John Templeton, achieved their wealth. Outmoded or arcane terminology and examples are faithfully refreshed to preclude any stumbling blocks to a new generation of readers.",
                    Dimensions ="7.1 x 0.8 x 5.0 (inches)",
                    ImageUrl ="https://images-na.ssl-images-amazon.com/images/I/61y04z8SKEL._SL300_.jpg",
                    PublishedDate = new DateTime(2005,8,1),
                    BookCategoryId = 1
                },
                new Book
                {
                    Id = 4,
                    Name = "The Richest Man in Babylon",
                    Slug = FriendlyUrlHelper.GetFriendlyTitle("The Richest Man in Babylon", true),
                    Language ="English",
                    ISBN = "1508524351",
                    ISBN13 = "9781508524359",
                    Length = 100,
                    Weight ="0.40 lbs",
                    Author ="George S. Clason",
                    Available2Lend = true,
                    Description = "This is the complete, original 1926 edition of a classic. (A condensed, simplified retelling is also available under the title The Richest Man in Babylon: Six Laws of Wealth , ISBN 1490348557.) As a young man, I came across George Samuel Clason's classic book The Richest Man in Babylon , which offered commonsense financial advice told through ancient parables. I recommend it to everyone. --Tony Robbins, Money: Master the Game The ancient Babylonians were the first people to discover the universal laws of prosperity. In his classic bestseller, The Richest Man in Babylon, George S. Clason reveals their secrets for creating, growing, and preserving wealth. Through these entertaining tales of merchants, tradesmen, and herdsmen, you'll learn how to keep more out what you earn; get out of debt; put your money to work; attract good luck; choose wise investments; and safeguard a lasting fortune.Visit SuccessBooks.net for more of the greatest success guides ever written.",
                    Dimensions ="0.3 x 6.0 x 9.0 (inches)",
                    ImageUrl ="https://img.thriftbooks.com/api/images/l/685fe07eae86303190e84e64ca377eac1b8f5919.jpg",
                    PublishedDate = new DateTime(2015,2,1),
                    BookCategoryId = 1
                },
                new Book
                {
                    Id = 5,
                    Name = "The 7 Habits of Highly Effective People : Powerful Lessons in Personal Change",
                    Slug = FriendlyUrlHelper.GetFriendlyTitle("The 7 Habits of Highly Effective People : Powerful Lessons in Personal Change", true),
                    Language ="English",
                    ISBN = "1451639619",
                    ISBN13 = "9781451639612",
                    Length = 432,
                    Weight ="0.84 lbs",
                    Author ="Stephen R. Covey",
                    Available2Lend = true,
                    Description = "Millions of copies sold. New York Times Bestseller. Named the #1 Most Influential Business Book of the Twentieth Century. As the seminal work of Stephen R. Covey, The 7 Habits of Highly Effective People has influenced millions around the world to be their best selves at work and at home. It stands the test of time as one of the most important books of our time. --Indra Nooyi, CEO of PepsiCo One of the most inspiring and impactful books ever written, The 7 Habits of Highly Effective People has captivated readers for 25 years. It has transformed the lives of presidents and CEOs, educators and parents--in short, millions of people of all ages and occupations across the world. This twenty-fifth anniversary edition of Stephen Covey's cherished classic commemorates his timeless wisdom, and encourages us to live a life of great and enduring purpose.",
                    Dimensions ="1.0 x 5.5 x 8.4 (inches)",
                    ImageUrl ="https://img.thriftbooks.com/api/images/l/51e028cf7a5b685ff978e7e2f634fa924cfc5a25.jpg",
                    PublishedDate = new DateTime(2013,11,1),
                    BookCategoryId = 1
                },
                new Book
                {
                    Id = 6,
                    Name = "The Millionaire Next Door : The Surprising Secrets of America's Wealthy",
                    Slug = FriendlyUrlHelper.GetFriendlyTitle("The Millionaire Next Door : The Surprising Secrets of America's Wealthy", true),
                    Language ="English",
                    ISBN = "1589795474",
                    ISBN13 = "9781589795471",
                    Length = 272,
                    Weight ="0.68 lbs.",
                    Author ="Thomas J. Stanley and William D. Danko",
                    Available2Lend = true,
                    Description = "Why aren't I as wealthy as I should be? Many people ask this question of themselves all the time. Often they are hard-working, well educated middle- to high-income people. Why, then, are so few affluent. For nearly two decades the answer has been found in the bestselling The Millionaire Next Door: The Surprising Secrets of America's Wealthy, reissued with a new foreword for the twenty-first century by Dr.Thomas J.Stanley.According to the authors, most people have it all wrong about how you become wealthy in America.Wealth in America is more often the result of hard work, diligent savings, and living below your means than it is about inheritance, advance degrees, and even intelligence.The Millionaire Next Door identifies seven common traits that show up again and again among those who have accumulated wealth.You will learn, for example, that millionaires bargain shop for used cars, pay a tiny fraction of their wealth in income tax, raise children who are often unaware of their family's wealth until they are adults, and, above all, reject the big-spending lifestyles most of us associate with rich people. In fact, you will learn that the flashy millionaires glamorized in the media represent only a tiny minority of America's rich.Most of the truly wealthy in this country don't live in Beverly Hills or on Park Avenue-they live next door.",
                    Dimensions ="0.8 x 5.9 x 9.1 (inches)",
                    ImageUrl ="https://img.thriftbooks.com/api/images/l/258268f1c457bfdc20dcc186f0f470062551877b.jpg",
                    PublishedDate = new DateTime(2010,11,1),
                    BookCategoryId = 1
                },
                new Book
                {
                    Id = 7,
                    Name = "The 21 Irrefutable Laws of Leadership : Follow Them and People Will Follow You",
                    Slug = FriendlyUrlHelper.GetFriendlyTitle("The 21 Irrefutable Laws of Leadership : Follow Them and People Will Follow You", true),
                    Language ="English",
                    ISBN = "0785288376",
                    ISBN13 = "9780785288374",
                    Length = 336,
                    Weight ="1.19 lbs.",
                    Author ="John C. Maxwell",
                    Available2Lend = true,
                    Description = "If you've never read The 21 Irrefutable Laws of Leadership , you've been missing out on one of the best-selling leadership books of all time. If you have read the original version, then you'll love this new expanded and updated one. Internationally recognized leadership expert, speaker, and author John C. Maxwell has taken this million-seller and made it even better: Every Law of Leadership has been sharpened and updated Seventeen new leadership stories are included Two new Laws of Leadership are introduced New evaluation tool will reveal your leadership strengths--and weaknesses New application exercises in every chapter will help you grow Why would Dr. Maxwell make changes to his best-selling book? A book is a conversation between the author and reader, says Maxwell. It's been ten years since I wrote The 21 Laws of Leadership . I've grown a lot since then. I've taught these laws in dozens of countries around the world. This new edition gives me the opportunity to share what I've learned.",
                    Dimensions ="1.1 x 6.4 x 9.3 (inches)",
                    ImageUrl ="https://img.thriftbooks.com/api/images/l/15f48f64ed3486632e3f6cda5fa64890a65ca9b9.jpg",
                    PublishedDate = new DateTime(2007,9,1),
                    BookCategoryId = 1
                },
                new Book
                {
                    Id = 8,
                    Name = "Rich Dad Poor Dad : What the Rich Teach Their Kids about Money That the Poor and Middle Class Do Not!",
                    Slug = FriendlyUrlHelper.GetFriendlyTitle("Rich Dad Poor Dad : What the Rich Teach Their Kids about Money That the Poor and Middle Class Do Not!", true),
                    Language ="English",
                    ISBN = "1612680194",
                    ISBN13 = "9781612680194",
                    Length = 336,
                    Weight ="0.56 lbs.",
                    Author ="Robert T. Kiyosaki",
                    Available2Lend = true,
                    Description = "April 2017 marks 20 years since Robert Kiyosaki's Rich Dad Poor Dad first made waves in the Personal Finance arena. It has since become the #1 Personal Finance book of all time... translated into dozens of languages and sold around the world. Rich Dad Poor Dad is Robert's story of growing up with two dads -- his real father and the father of his best friend, his rich dad -- and the ways in which both men shaped his thoughts about money and investing. The book explodes the myth that you need to earn a high income to be rich and explains the difference between working for money and having your money work for you. 20 Years... 20/20 Hindsight In the 20th Anniversary Edition of this classic, Robert offers an update on what we've seen over the past 20 years related to money, investing, and the global economy. Sidebars throughout the book will take readers  fast forward  -- from 1997 to today -- as Robert assesses how the principles taught by his rich dad have stood the test of time. In many ways, the messages of Rich Dad Poor Dad , messages that were criticized and challenged two decades ago, are more meaningful, relevant and important today than they were 20 years ago. As always, readers can expect that Robert will be candid, insightful... and continue to rock more than a few boats in his retrospective. Will there be a few surprises? Count on it. Rich Dad Poor Dad ... - Explodes the myth that you need to earn a high income to become rich - Challenges the belief that your house is an asset - Shows parents why they can't rely on the school system to teach their kids about money - Defines once and for all an asset and a liability - Teaches you what to teach your kids about money for their future financial success",
                    Dimensions ="1.1 x 4.3 x 7.5 (inches)",
                    ImageUrl ="https://img.thriftbooks.com/api/images/l/7da997e4bfef47f6429c9d59556a4dd96af2d61e.jpg",
                    PublishedDate = new DateTime(2017,4,1),
                    BookCategoryId = 1
                },
                new Book
                {
                    Id = 9,
                    Name = "La oruga muy hambrienta/The Very Hungry Caterpillar: bilingual board book [Spanish]",
                    Slug = FriendlyUrlHelper.GetFriendlyTitle("La oruga muy hambrienta/The Very Hungry Caterpillar: bilingual board book [Spanish]", true),
                    Language ="Spanish",
                    ISBN = "0399256059",
                    ISBN13 = "9780399256059",
                    Length = 24,
                    Weight ="0.40 lbs.",
                    Author ="Eric Carle",
                    Available2Lend = true,
                    Description = "The time-honored classic The Very Hungry Caterpillar is now available in two bilingual formats, bringing together two languages for the ultimate reading and learning experience. With easily readable side-by-side English and Spanish text, it's perfect for children learning to speak either language. La oruga muy hambrienta es un libro lleno de colorido que habla de c?mo una oruga se transforma en una linda mariposa. Los ni?os se divierten al descrubrir los cambios tan asombrosos por los que pasa la oruga.",
                    Dimensions ="7.1 x 0.7 x 5.0 (inches)",
                    ImageUrl ="https://images-na.ssl-images-amazon.com/images/I/41OaVJC8efL._SL300_.jpg",
                    PublishedDate = new DateTime(2011,5,1),
                    BookCategoryId = 1
                },
                new Book
                {
                    Id = 10,
                    Name = "Blink : The Power of Thinking Without Thinking",
                    Slug = FriendlyUrlHelper.GetFriendlyTitle("Blink : The Power of Thinking Without Thinking", true),
                    Language ="English",
                    ISBN = "0316010669",
                    ISBN13 = "9780316010665",
                    Length = 320,
                    Weight ="0.72 lbs",
                    Author ="Malcolm Gladwell and 麥爾坎·葛拉威爾",
                    Available2Lend = true,
                    Description = "In his landmark bestseller The Tipping Point, Malcolm Gladwell redefined how we understand the world around us. Now, in Blink, he revolutionizes the way we understand the world within. Blink is a book about how we think without thinking, about choices that seem to be made in an instant-in the blink of an eye-that actually aren't as simple as they seem. Why are some people brilliant decision makers, while others are consistently inept? Why do some people follow their instincts and win, while others end up stumbling into error? How do our brains really work-in the office, in the classroom, in the kitchen, and in the bedroom? And why are the best decisions often those that are impossible to explain to others?In Blink we meet the psychologist who has learned to predict whether a marriage will last, based on a few minutes of observing a couple; the tennis coach who knows when a player will double-fault before the racket even makes contact with the ball; the antiquities experts who recognize a fake at a glance. Here, too, are great failures of blink: the election of Warren Harding; New Coke; and the shooting of Amadou Diallo by police. Blink reveals that great decision makers aren't those who process the most information or spend the most time deliberating, but those who have perfected the art of thin-slicing-filtering the very few factors that matter from an overwhelming number of variables.",
                    Dimensions ="0.9 x 5.5 x 8.3 (inches)",
                    ImageUrl ="https://img.thriftbooks.com/api/images/l/b67cd4ea2eb90f1b3553f5df371db4fe36935b03.jpg",
                    PublishedDate = new DateTime(2007,4,1),
                    BookCategoryId = 1
                },

                // Category 2

                //new Book
                //{
                //    Id = 4,
                //    Name = "",
                //    Language ="English",
                //    ISBN = "",
                //    ISBN13 = "",
                //    Length = 0,
                //    Weight ="",
                //    Author ="",
                //    Available2Lend = true,
                //    Description = "",
                //    Dimensions ="",
                //    ImageUrl ="",
                //    PublishedDate = new DateTime(1,1,1)
                //},
                //new Book
                //{
                //    Id = 4,
                //    Name = "",
                //    Language ="English",
                //    ISBN = "",
                //    ISBN13 = "",
                //    Length = 0,
                //    Weight ="",
                //    Author ="",
                //    Available2Lend = true,
                //    Description = "",
                //    Dimensions ="",
                //    ImageUrl ="",
                //    PublishedDate = new DateTime(1,1,1)
                //},
                //new Book
                //{
                //    Id = 4,
                //    Name = "",
                //    Language ="English",
                //    ISBN = "",
                //    ISBN13 = "",
                //    Length = 0,
                //    Weight ="",
                //    Author ="",
                //    Available2Lend = true,
                //    Description = "",
                //    Dimensions ="",
                //    ImageUrl ="",
                //    PublishedDate = new DateTime(1,1,1)
                //},
                //new Book
                //{
                //    Id = 4,
                //    Name = "",
                //    Language ="English",
                //    ISBN = "",
                //    ISBN13 = "",
                //    Length = 0,
                //    Weight ="",
                //    Author ="",
                //    Available2Lend = true,
                //    Description = "",
                //    Dimensions ="",
                //    ImageUrl ="",
                //    PublishedDate = new DateTime(1,1,1)
                //},new Book
                //{
                //    Id = 4,
                //    Name = "",
                //    Language ="English",
                //    ISBN = "",
                //    ISBN13 = "",
                //    Length = 0,
                //    Weight ="",
                //    Author ="",
                //    Available2Lend = true,
                //    Description = "",
                //    Dimensions ="",
                //    ImageUrl ="",
                //    PublishedDate = new DateTime(1,1,1)
                //},
                //new Book
                //{
                //    Id = 4,
                //    Name = "",
                //    Language ="English",
                //    ISBN = "",
                //    ISBN13 = "",
                //    Length = 0,
                //    Weight ="",
                //    Author ="",
                //    Available2Lend = true,
                //    Description = "",
                //    Dimensions ="",
                //    ImageUrl ="",
                //    PublishedDate = new DateTime(1,1,1)
                //},
            };

            return books;
        }
    }
}
