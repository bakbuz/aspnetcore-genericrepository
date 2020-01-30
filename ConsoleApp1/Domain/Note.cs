using ConsoleApp1.Common;
using System;

namespace ConsoleApp1.Domain
{
    public class Note : EntityBase
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
