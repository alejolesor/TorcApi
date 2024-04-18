using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorcTest.Infrastructure.models
{
    [Table("books")]
    public class Books
    {
        [Key]
        [Column("book_id")]
        public int Book_Id { get; set; }
        [Column("title")]
        public string Tittle { get; set; }
        [Column("first_name")]
        public string First_Name { get; set; }
        [Column("last_name")]
        public string Last_Name { get; set; }
        [Column("total_copies")]
        public int Total_Copies { get; set; }
        [Column("copies_in_use")]
        public int Copies_in_use { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("isbn")]
        public string Isbn { get; set; }
        [Column("category")]
        public string Category { get; set; }
    }
}
