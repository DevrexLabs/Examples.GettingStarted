using System.Collections.Generic;
using System.Linq;
using OrigoDB.Core;

namespace OrigoDb.Examples.GettingStarted
{

    public class GetBookmarksPagedQuery : Query<BookmarkModel, IEnumerable<Bookmark>>
    {

        public readonly int PageIdx;
        public readonly int ItemsPerPage;

        public GetBookmarksPagedQuery(int pageIdx, int itemsPerPage)
        {
            PageIdx = pageIdx;
            ItemsPerPage = itemsPerPage;
        }

        protected override IEnumerable<Bookmark> Execute(BookmarkModel m)
        {
            return m.Bookmarks.Values
                .OrderBy(b => b.Added)
                .Skip(ItemsPerPage*PageIdx)
                .Take(ItemsPerPage)
                .ToArray();
        }
    }
}
