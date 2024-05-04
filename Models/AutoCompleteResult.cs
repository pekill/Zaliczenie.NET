using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaliczenie.Models
{
    public class AutoCompleteResult
    {
        public List<SearchItem> D { get; set; }
    }

    public class SearchItem
    {
        public ImageData I { get; set; }
        public string Id { get; set; }
        public string L { get; set; }
        public string Q { get; set; }
        public string QID { get; set; }
        public string Rank { get; set; }
        public string S { get; set; }
        public List<VideoData> V { get; set; }
        public int Y { get; set; }
        public string Yr { get; set; }
    }

    public class ImageData
    {
        public int Height { get; set; }
        public string ImageUrl { get; set; }
        public int Width { get; set; }
    }

    public class VideoData
    {
        public ImageData I { get; set; }
        public string Id { get; set; }
        public string L { get; set; }
        public string S { get; set; }
    }
}
