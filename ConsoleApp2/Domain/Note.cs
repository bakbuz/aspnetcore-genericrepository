using ConsoleApp2.Common;
using System;

namespace ConsoleApp2.Domain
{
    public class Note : Entity<int>
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
