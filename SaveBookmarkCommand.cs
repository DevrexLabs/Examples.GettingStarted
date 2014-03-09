using System;
using System.Linq;
using OrigoDB.Core;

namespace OrigoDb.Examples.GettingStarted
{
    [Serializable]
    public class SaveBookmarkCommand : Command<BookmarkModel>
    {
        public readonly string Url;
        public readonly string Title;
        public readonly DateTime Added;
        private readonly string[] Tags;

        public SaveBookmarkCommand(string url, string title, DateTime added, string[] tags)
        {
            Url = url;
            Title = title;
            Added = added;
            Tags = tags.ToArray();
        }

        /// <summary>
        /// Create a Bookmark object and add it to the model
        /// </summary>
        /// <param name="model">You have an exclusive lock on the model</param>
        protected override void Execute(BookmarkModel model)
        {
            var bookmark = new Bookmark(Url, Title);
            bookmark.Added = Added;
            foreach (string tag in Tags) bookmark.Tags.Add(tag);
            model.SaveBookmark(bookmark);
        }
    }
}
