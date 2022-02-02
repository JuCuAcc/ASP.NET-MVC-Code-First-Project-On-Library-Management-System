namespace Code_First_Jashim.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    using Code_First_Jashim.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    internal sealed class Configuration : DbMigrationsConfiguration<Code_First_Jashim.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Code_First_Jashim.Models.ApplicationDbContext context)
        {



            var BookCategories = new List<BookCategories>
            {
                new BookCategories{Category="References" },
                new BookCategories{Category="Academic" },
                new BookCategories{Category="Novel" },
                new BookCategories{Category="Magazine" }

            };

            BookCategories.ForEach(ct => context.BookCategories.AddOrUpdate(x => x.Category, ct));
            context.SaveChanges();

            var StudentGroup = new List<StudentGroup>
            {
                new StudentGroup{GroupName="BBA"},
                new StudentGroup{GroupName="MBA"}

            };

            StudentGroup.ForEach(st => context.StudentGroups.AddOrUpdate(s => s.GroupName, st));
            context.SaveChanges();


            var Liberian = new List<Liberian>
            {
                new Liberian{LiberianName="Jamal" , Age=30, Email="abc@mail.com", Address="CTG"},
                new Liberian{LiberianName="Kamal", Age=30, Email="abc@mail.com", Address="CTG"}

            };

            Liberian.ForEach(lb => context.Liberians.AddOrUpdate(l => l.LiberianName, lb));
            context.SaveChanges();



            var Books = new List<Books>
            {
                //new Books{Title= "C#",              Author= "Jashim Uddin",     Description = "Basic",      CategoryID = 2,   AddedTime=new DateTime(2021, 11, 4), Availability=Available, ImagePath = "~/Images/default.png" },
                //new Books{Title= "Mathematics",     Author= "Jamal Uddin",      Description = "Basic",      CategoryID = 1,   AddedTime=new DateTime(2021, 11, 4), Availability=Available, ImagePath= "~/Images/default.png"  },
                //new Books{Title= "New World",       Author= "Robert Hertz",     Description = "Fiction",    CategoryID = 3,   AddedTime=new DateTime(2021, 11, 4), Availability=Available, ImagePath= "~/Images/default.png"  },
                //new Books{Title= "Current News",    Author= "Jishan Jahangir",  Description = "News",       CategoryID = 4,   AddedTime=new DateTime(2021, 11, 4), Availability=Available, ImagePath= "~/Images/default.png"  }
                
                new Books{Title= "C#",              Author= "Jashim Uddin",     Description = "Basic",      CategoryID = 2,   AddedTime=new DateTime(2021, 11, 4), ImagePath = "~/Images/default.png" },
                new Books{Title= "Mathematics",     Author= "Jamal Uddin",      Description = "Basic",      CategoryID = 1,   AddedTime=new DateTime(2021, 11, 4), ImagePath= "~/Images/default.png"  },
                new Books{Title= "New World",       Author= "Robert Hertz",     Description = "Fiction",    CategoryID = 3,   AddedTime=new DateTime(2021, 11, 4), ImagePath= "~/Images/default.png"  },
                new Books{Title= "Current News",    Author= "Jishan Jahangir",  Description = "News",       CategoryID = 4,   AddedTime=new DateTime(2021, 11, 4), ImagePath= "~/Images/default.png"  }


            };

            Books.ForEach(b => context.Books.AddOrUpdate(bk => bk.Title, b));
            context.SaveChanges();


            var Members = new List<Members>
            {
                new Members{MemberName= "Jashim", MemberStatus= "Student"},
                new Members{MemberName= "Jamal", MemberStatus= "Teacher"}

            };

            Members.ForEach(mb => context.Members.AddOrUpdate(m => m.MemberName, mb));
            context.SaveChanges();


            var BookIssue = new List<BookIssue>
            {
                new BookIssue{IssuedTime=new DateTime(2021, 11, 3)},
                new BookIssue{IssuedTime=new DateTime(2021, 11, 4)}

            };

            Members.ForEach(mb => context.Members.AddOrUpdate(m => m.MemberName, mb));
            context.SaveChanges();
        }
    }
}
