using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Library
    {
         public int Id { get; set; }
         public string Title { get; set; }
         public string Author { get; set; }
         public List<string> Genre { get; set; }
         public string Description { get; set; }
         public object Citizenship { get; internal set; }
         public object BirthDay { get; internal set; }
    }
}
