using System;
using System.Collections.Generic;
using System.Linq;
using OrigoDB.Core;

namespace OrigoDb.Examples.GettingStarted
{

    /// <summary>
    /// A very simple domain model root class.
    /// </summary>
    [Serializable]
    public class BookmarkModel : Model
    {

        public Dictionary<string,Bookmark> Bookmarks { get; set; }

        public BookmarkModel()
        {
            Bookmarks = new Dictionary<string, Bookmark>();
        }

        public void SaveBookmark(Bookmark bookmark)
        {
            Bookmarks[bookmark.Url] = bookmark;
        }

        public IEnumerable<Bookmark> GetBookmarksByTag(string tag)
        {
            return Bookmarks.Values.Where(b => b.Tags.Contains(tag)).ToArray();
        }
    }
}
