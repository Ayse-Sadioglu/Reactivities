using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }//you can genreate from both client and server side
        
        public string ?Title { get; set; }//you may put a question mark symbol(?) to indicate that the type is nullable

        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }

    }
}