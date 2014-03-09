using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrigoDb.Examples.GettingStarted
{
    [Serializable]
    public class Bookmark
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime Added { get; set; }
        public HashSet<string> Tags { get; private set; }

        public Bookmark(string url, string title)
        {
            Url = url;
            Title = title;
            Tags = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
