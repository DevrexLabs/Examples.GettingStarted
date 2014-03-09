using OrigoDB.Core;
using System;

namespace OrigoDb.Examples.GettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {

            // Start your engines!
            // uses current working directory
            Engine<BookmarkModel> engine = Engine.LoadOrCreate<BookmarkModel>();


            //create and execute some commands
            var cmd = new SaveBookmarkCommand(
                "http://google.com/",
                "Google",
                DateTime.Now,
                new []{"rich", "ugly", "evil"});

            engine.Execute(cmd);

            cmd = new SaveBookmarkCommand(
                "http://microsoft.com",
                "Microsoft",
                DateTime.Now,
                new[]{"rich", "good"}
                );

            engine.Execute(cmd);

            cmd = new SaveBookmarkCommand(
                "http://oracle.com",
                "Oracle",
                DateTime.Now,
                new[] { "rich", "bad", "evil" }
                );

            engine.Execute(cmd);


            //Execute an ad-hoc lambda query
            Console.WriteLine("Result of db => db.GetBookmarksByTag(\"evil\")");
            var bookmarks = engine.Execute((BookmarkModel db) => db.GetBookmarksByTag("evil"));
            foreach (var bookmark in bookmarks)
            {
                Console.WriteLine(bookmark.Title);
                Console.WriteLine(bookmark.Url);
            }

            Console.WriteLine("---");
            //Execute a strongly typed query
            Console.WriteLine("Result of GetBookmarksPagedQuery(0,2)");
            var query = new GetBookmarksPagedQuery(0, 2);
            var page = engine.Execute(query);
            foreach (var bookmark in page)
            {
                Console.WriteLine(bookmark.Title);
                Console.WriteLine(bookmark.Url);
            }

            Console.WriteLine("hit return to terminate");
            Console.ReadLine();
        }
    }
}
