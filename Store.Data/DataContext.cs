using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Store.Core.Entities.Type;

namespace Store.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> BookList { get; set; }
        public DbSet<Saler> SalerList { get; set; }
        public DbSet<Branch> BranchList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=store_db");
        }

        //public DataContext()
        //{
        //    BookList = new List<Book>(){
        //    new Book(1,"Kids Speak","Chaim Walder",55.5,Type.Kids),
        //    new Book(2,"All for the Boss","Ruchama Shein",40,Type.Adult),
        //    new Book(3,"A Yidishe Kop","Gadi Polak",60,Type.Comix),
        //    new Book(4,"Harry Potter","J.K. Rowling",88,Type.Teen),
        //    new Book(5,"Shikupizky","Shifra Glik",35.9,Type.Comix)
        //    };

        //    SalerList = new List<Saler>(){
        //    new Saler(100,"Yair Levi",7582),
        //    new Saler(200,"Noam Cohen",6905.5),
        //    new Saler(300,"Avi Kaz",8000),
        //    new Saler(400,"Meir Noyman",7001)
        //    };

        //    BranchList = new List<Branch>(){
        //    new Branch(1,"Jerusalem","Bait Vagan",4),
        //    new Branch(2,"Bne Brak","Ezra",7),
        //    new Branch(3,"Ofakim","Ezel",1),
        //    new Branch(4,"Beytar","Grin Park",5)
        //    };
        //}
    }
}
