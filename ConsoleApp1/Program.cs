using ConsoleApp1.Domain;
using ConsoleApp1.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static readonly IRepository<Category> _categoryRepository;
        static readonly IRepository<Note> _noteRepository;

        static Program()
        {
            // configure services
            IServiceProvider serviceProvider = Startup.ConfigureServices();

            _categoryRepository = serviceProvider.GetService<IRepository<Category>>();
            _noteRepository = serviceProvider.GetService<IRepository<Note>>();
        }

        static void Main(string[] args)
        {
            // category
            _categoryRepository.Insert(new Category { Name = "kategori-" + DateTime.Now.ToShortTimeString() });

            IList<Category> categories = _categoryRepository.GetAll();
            foreach (var c in categories)
            {
                Console.WriteLine("{0}: {1}", c.Id, c.Name);
                //_categoryRepository.Delete(c);
            }

            Console.WriteLine("----------------------------------");

            // notes
            var note = new Note();
            note.Title = "Başlık-" + DateTime.Now.ToShortTimeString();
            note.Body = "Açıklama";
            note.CreatedAt = DateTime.UtcNow;

            _noteRepository.Insert(note);

            IList<Note> notes = _noteRepository.GetAll();
            foreach (var n in notes)
            {
                Console.WriteLine("{0}: {1}", n.Id, n.Title);
                //_noteRepository.Delete(n);
            }
        }
    }
}
