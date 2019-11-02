using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SD2411.KPI2019.HostStandard.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_book_category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLUG = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_book_category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_book",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLUG = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    LANGUAGE = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    ISBN13 = table.Column<string>(nullable: true),
                    LENGTH = table.Column<int>(nullable: false),
                    WEIGHT = table.Column<string>(nullable: true),
                    DIMENSIONS = table.Column<string>(nullable: true),
                    IMAGE_URL = table.Column<string>(nullable: true),
                    PUBLISHED_DATE = table.Column<DateTime>(nullable: false),
                    AUTHOR = table.Column<string>(nullable: true),
                    IS_AVAILABLE_TO_LEND = table.Column<bool>(nullable: false),
                    BookCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_book", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOOK_CATEGORY",
                        column: x => x.BookCategoryId,
                        principalTable: "tbl_book_category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_book_lending",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLUG = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    BORROW_DATE = table.Column<DateTime>(nullable: false),
                    RETURN_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_book_lending", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_book_lending_tbl_book_BookId",
                        column: x => x.BookId,
                        principalTable: "tbl_book",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_book_lending_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tbl_book_category",
                columns: new[] { "ID", "DESCRIPTION", "NAME", "SLUG" },
                values: new object[,]
                {
                    { 1, "The Business Books and Investing Books section is perfect for the professional & student alike, looking to improve their prioritization, productivity and even their work-life balance. Learn the traits and failings of the world's great business leaders and how to create long-term financial success. When you shop business books and investing books with Thriftbooks.com you read more and spend less.", "Business", null },
                    { 2, "Take your little ones on a magical journey filled with wizards and talking animals, find the perfect craft or activity, and enlighten their minds with educational books.", "Kids", null },
                    { 3, "Our selection of Comic Books and Graphic Novels is perfect for the collector looking to discover a new story line or the booklover searching for a new medium of entertainment. From children’s favorites to best-selling graphic novels, popular classics, superheroes, hated villains, fantasy, action, humor, alternative, science fiction and more. When you shop comic books and graphic novels with Thriftbooks.com, you will read more and spend less.", "Comics & Graphic Novels", null },
                    { 4, "Our selection of Computer Books and Technology Books will provided guides for the novice nerd, tips and assistance for the student designer, or describe the story of a computer genius for technological inspiration. Other categories may include home computing, mobile computing, graphic design, networking, programming, computer science, business and culture and more. Discover the world of technology and computer science – all for a low price. When you shop used computer books and internet books with Thrfitbooks.com you read more and spend less.", "Computers & Technology", null },
                    { 5, "Whether you're gourmand, an expert in the kitchen or a first time cook our large selection of Cookery books for all styles of food and all levels of expertise will suit your tastes. Food Books and Wine Books will have something you're looking for. When you shop cookbooks, food books and wine books with Thriftbooks.com you eat more and spend less.", "Cookbooks, Food & Wine", null },
                    { 6, "Thriftbooks.com’s Reference Books section has titles for those looking to improve and develop an industry skill set, or students learning the tools of their trade. These resources aim to help individuals pull from their strengths and improve on their weaknesses through guides, manuals, maps and atlases, encyclopedias, collaborative journalism, rules of order, and more. Pinpoint the facts and learn the tools of your trade – all for a low price. When you shop reference books with Thriftbooks.com you read more and spend less.", "Education & Reference", null },
                    { 7, "In our History Books section you'll find used books on local history and histories of international events, histories by epoch and histories by continent. Whether history is a passionate interest, or your field of study, our low prices will open up any field to you whether you're interested in the last decade of the last millennium. When you ship history books at Thriftbooks.com you read more and spend less.", "History", null }
                });

            migrationBuilder.InsertData(
                table: "tbl_book",
                columns: new[] { "ID", "AUTHOR", "IS_AVAILABLE_TO_LEND", "BookCategoryId", "DESCRIPTION", "DIMENSIONS", "ISBN", "ISBN13", "IMAGE_URL", "LANGUAGE", "LENGTH", "NAME", "PUBLISHED_DATE", "SLUG", "WEIGHT" },
                values: new object[,]
                {
                    { 1, "Malcolm Gladwell", true, 1, "In this stunning new book, Malcolm Gladwell takes us on an intellectual journey through the world of outliers--the best and the brightest, the most famous and the most successful. He asks the question: what makes high-achievers different? His answer is that we pay too much attention to what successful people are like, and too little attention to where they are from: that is, their culture, their family, their generation, and the idiosyncratic experiences of their upbringing. Along the way he explains the secrets of software billionaires, what it takes to be a great soccer player, why Asians are good at math, and what made the Beatles the greatest rock band. Brilliant and entertaining, Outliers is a landmark work that will simultaneously delight and illuminate.", "8.3 x 1.1 x 5.5 (inches)", "0316017930", "9780316017930", "https://images-na.ssl-images-amazon.com/images/I/41LO6QRvIuL._SL300_.jpg", "English", 336, "Outliers: The Story of Success", new DateTime(2011, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "outliers-the-story-of-success", "0.75 lbs" },
                    { 2, "Yann Martel", true, 1, "No Synopsis Available.", "0.9 x 5.0 x 8.0 (inches)", "0156027321", "N/A", "https://images-na.ssl-images-amazon.com/images/I/51rxEvLljUL._SL300_.jpg", "English", 326, "Life of Pi", new DateTime(2003, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "life-of-pi", "0.87 lbs" },
                    { 3, "Ben Holden-Crowther and Napoleon Hill", true, 1, "Please note that this item is a roughcut (deckle edge) editionThink and Grow Rich has been called the Granddaddy of All Motivational Literature. It was the first book to boldly ask, What makes a winner? The man who asked and listened for the answer, Napoleon Hill, is now counted in the top ranks of the world's winners himself. The most famous of all teachers of success spent a fortune and the better part of a lifetime of effort to produce the Law of Success philosophy that forms the basis of his books and that is so powerfully summarized in this one. In the original Think and Grow Rich, published in 1937, Hill draws on stories of Andrew Carnegie, Thomas Edison, Henry Ford, and other millionaires of his generation to illustrate his principles. In the updated version, Arthur R. Pell, Ph.D., a nationally known author, lecturer, and consultant in human resources management and an expert in applying Hill's thought, deftly interweaves anecdotes of how contemporary millionaires and billionaires, such as Bill Gates, Mary Kay Ash, Dave Thomas, and Sir John Templeton, achieved their wealth. Outmoded or arcane terminology and examples are faithfully refreshed to preclude any stumbling blocks to a new generation of readers.", "7.1 x 0.8 x 5.0 (inches)", "1585424331", "9781585424337", "https://images-na.ssl-images-amazon.com/images/I/61y04z8SKEL._SL300_.jpg", "English", 320, "Think and Grow Rich: The Landmark Bestseller Now Revised and Updated for the 21st Century (Think and Grow Rich Series)", new DateTime(2005, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "think-and-grow-rich-the-landmark-bestseller-now-revised-and-updated-for-the-21st", "0.63 lbs." },
                    { 4, "George S. Clason", true, 1, "This is the complete, original 1926 edition of a classic. (A condensed, simplified retelling is also available under the title The Richest Man in Babylon: Six Laws of Wealth , ISBN 1490348557.) As a young man, I came across George Samuel Clason's classic book The Richest Man in Babylon , which offered commonsense financial advice told through ancient parables. I recommend it to everyone. --Tony Robbins, Money: Master the Game The ancient Babylonians were the first people to discover the universal laws of prosperity. In his classic bestseller, The Richest Man in Babylon, George S. Clason reveals their secrets for creating, growing, and preserving wealth. Through these entertaining tales of merchants, tradesmen, and herdsmen, you'll learn how to keep more out what you earn; get out of debt; put your money to work; attract good luck; choose wise investments; and safeguard a lasting fortune.Visit SuccessBooks.net for more of the greatest success guides ever written.", "0.3 x 6.0 x 9.0 (inches)", "1508524351", "9781508524359", "https://img.thriftbooks.com/api/images/l/685fe07eae86303190e84e64ca377eac1b8f5919.jpg", "English", 100, "The Richest Man in Babylon", new DateTime(2015, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the-richest-man-in-babylon", "0.40 lbs" },
                    { 5, "Stephen R. Covey", true, 1, "Millions of copies sold. New York Times Bestseller. Named the #1 Most Influential Business Book of the Twentieth Century. As the seminal work of Stephen R. Covey, The 7 Habits of Highly Effective People has influenced millions around the world to be their best selves at work and at home. It stands the test of time as one of the most important books of our time. --Indra Nooyi, CEO of PepsiCo One of the most inspiring and impactful books ever written, The 7 Habits of Highly Effective People has captivated readers for 25 years. It has transformed the lives of presidents and CEOs, educators and parents--in short, millions of people of all ages and occupations across the world. This twenty-fifth anniversary edition of Stephen Covey's cherished classic commemorates his timeless wisdom, and encourages us to live a life of great and enduring purpose.", "1.0 x 5.5 x 8.4 (inches)", "1451639619", "9781451639612", "https://img.thriftbooks.com/api/images/l/51e028cf7a5b685ff978e7e2f634fa924cfc5a25.jpg", "English", 432, "The 7 Habits of Highly Effective People : Powerful Lessons in Personal Change", new DateTime(2013, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the-7-habits-of-highly-effective-people-powerful-lessons-in-personal-change", "0.84 lbs" },
                    { 6, "Thomas J. Stanley and William D. Danko", true, 2, "Why aren't I as wealthy as I should be? Many people ask this question of themselves all the time. Often they are hard-working, well educated middle- to high-income people. Why, then, are so few affluent. For nearly two decades the answer has been found in the bestselling The Millionaire Next Door: The Surprising Secrets of America's Wealthy, reissued with a new foreword for the twenty-first century by Dr.Thomas J.Stanley.According to the authors, most people have it all wrong about how you become wealthy in America.Wealth in America is more often the result of hard work, diligent savings, and living below your means than it is about inheritance, advance degrees, and even intelligence.The Millionaire Next Door identifies seven common traits that show up again and again among those who have accumulated wealth.You will learn, for example, that millionaires bargain shop for used cars, pay a tiny fraction of their wealth in income tax, raise children who are often unaware of their family's wealth until they are adults, and, above all, reject the big-spending lifestyles most of us associate with rich people. In fact, you will learn that the flashy millionaires glamorized in the media represent only a tiny minority of America's rich.Most of the truly wealthy in this country don't live in Beverly Hills or on Park Avenue-they live next door.", "0.8 x 5.9 x 9.1 (inches)", "1589795474", "9781589795471", "https://img.thriftbooks.com/api/images/l/258268f1c457bfdc20dcc186f0f470062551877b.jpg", "English", 272, "The Millionaire Next Door : The Surprising Secrets of America's Wealthy", new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the-millionaire-next-door-the-surprising-secrets-of-americas-wealthy", "0.68 lbs." },
                    { 7, "John C. Maxwell", true, 2, "If you've never read The 21 Irrefutable Laws of Leadership , you've been missing out on one of the best-selling leadership books of all time. If you have read the original version, then you'll love this new expanded and updated one. Internationally recognized leadership expert, speaker, and author John C. Maxwell has taken this million-seller and made it even better: Every Law of Leadership has been sharpened and updated Seventeen new leadership stories are included Two new Laws of Leadership are introduced New evaluation tool will reveal your leadership strengths--and weaknesses New application exercises in every chapter will help you grow Why would Dr. Maxwell make changes to his best-selling book? A book is a conversation between the author and reader, says Maxwell. It's been ten years since I wrote The 21 Laws of Leadership . I've grown a lot since then. I've taught these laws in dozens of countries around the world. This new edition gives me the opportunity to share what I've learned.", "1.1 x 6.4 x 9.3 (inches)", "0785288376", "9780785288374", "https://img.thriftbooks.com/api/images/l/15f48f64ed3486632e3f6cda5fa64890a65ca9b9.jpg", "English", 336, "The 21 Irrefutable Laws of Leadership : Follow Them and People Will Follow You", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the-21-irrefutable-laws-of-leadership-follow-them-and-people-will-follow-you", "1.19 lbs." },
                    { 8, "Robert T. Kiyosaki", true, 2, "April 2017 marks 20 years since Robert Kiyosaki's Rich Dad Poor Dad first made waves in the Personal Finance arena. It has since become the #1 Personal Finance book of all time... translated into dozens of languages and sold around the world. Rich Dad Poor Dad is Robert's story of growing up with two dads -- his real father and the father of his best friend, his rich dad -- and the ways in which both men shaped his thoughts about money and investing. The book explodes the myth that you need to earn a high income to be rich and explains the difference between working for money and having your money work for you. 20 Years... 20/20 Hindsight In the 20th Anniversary Edition of this classic, Robert offers an update on what we've seen over the past 20 years related to money, investing, and the global economy. Sidebars throughout the book will take readers  fast forward  -- from 1997 to today -- as Robert assesses how the principles taught by his rich dad have stood the test of time. In many ways, the messages of Rich Dad Poor Dad , messages that were criticized and challenged two decades ago, are more meaningful, relevant and important today than they were 20 years ago. As always, readers can expect that Robert will be candid, insightful... and continue to rock more than a few boats in his retrospective. Will there be a few surprises? Count on it. Rich Dad Poor Dad ... - Explodes the myth that you need to earn a high income to become rich - Challenges the belief that your house is an asset - Shows parents why they can't rely on the school system to teach their kids about money - Defines once and for all an asset and a liability - Teaches you what to teach your kids about money for their future financial success", "1.1 x 4.3 x 7.5 (inches)", "1612680194", "9781612680194", "https://img.thriftbooks.com/api/images/l/7da997e4bfef47f6429c9d59556a4dd96af2d61e.jpg", "English", 336, "Rich Dad Poor Dad : What the Rich Teach Their Kids about Money That the Poor and Middle Class Do Not!", new DateTime(2017, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "rich-dad-poor-dad-what-the-rich-teach-their-kids-about-money-that-the-poor-and", "0.56 lbs." },
                    { 9, "Eric Carle", true, 2, "The time-honored classic The Very Hungry Caterpillar is now available in two bilingual formats, bringing together two languages for the ultimate reading and learning experience. With easily readable side-by-side English and Spanish text, it's perfect for children learning to speak either language. La oruga muy hambrienta es un libro lleno de colorido que habla de c?mo una oruga se transforma en una linda mariposa. Los ni?os se divierten al descrubrir los cambios tan asombrosos por los que pasa la oruga.", "7.1 x 0.7 x 5.0 (inches)", "0399256059", "9780399256059", "https://images-na.ssl-images-amazon.com/images/I/41OaVJC8efL._SL300_.jpg", "Spanish", 24, "La oruga muy hambrienta/The Very Hungry Caterpillar: bilingual board book [Spanish]", new DateTime(2011, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "la-oruga-muy-hambrienta-the-very-hungry-caterpillar-bilingual-board-book-spanis", "0.40 lbs." },
                    { 10, "Malcolm Gladwell and 麥爾坎·葛拉威爾", true, 2, "In his landmark bestseller The Tipping Point, Malcolm Gladwell redefined how we understand the world around us. Now, in Blink, he revolutionizes the way we understand the world within. Blink is a book about how we think without thinking, about choices that seem to be made in an instant-in the blink of an eye-that actually aren't as simple as they seem. Why are some people brilliant decision makers, while others are consistently inept? Why do some people follow their instincts and win, while others end up stumbling into error? How do our brains really work-in the office, in the classroom, in the kitchen, and in the bedroom? And why are the best decisions often those that are impossible to explain to others?In Blink we meet the psychologist who has learned to predict whether a marriage will last, based on a few minutes of observing a couple; the tennis coach who knows when a player will double-fault before the racket even makes contact with the ball; the antiquities experts who recognize a fake at a glance. Here, too, are great failures of blink: the election of Warren Harding; New Coke; and the shooting of Amadou Diallo by police. Blink reveals that great decision makers aren't those who process the most information or spend the most time deliberating, but those who have perfected the art of thin-slicing-filtering the very few factors that matter from an overwhelming number of variables.", "0.9 x 5.5 x 8.3 (inches)", "0316010669", "9780316010665", "https://img.thriftbooks.com/api/images/l/b67cd4ea2eb90f1b3553f5df371db4fe36935b03.jpg", "English", 320, "Blink : The Power of Thinking Without Thinking", new DateTime(2007, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "blink-the-power-of-thinking-without-thinking", "0.72 lbs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_book_BookCategoryId",
                table: "tbl_book",
                column: "BookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_book_SLUG",
                table: "tbl_book",
                column: "SLUG",
                unique: true,
                filter: "[SLUG] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_book_category_SLUG",
                table: "tbl_book_category",
                column: "SLUG",
                unique: true,
                filter: "[SLUG] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_book_lending_BookId",
                table: "tbl_book_lending",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_book_lending_UserId",
                table: "tbl_book_lending",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tbl_book_lending");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tbl_book");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tbl_book_category");
        }
    }
}
