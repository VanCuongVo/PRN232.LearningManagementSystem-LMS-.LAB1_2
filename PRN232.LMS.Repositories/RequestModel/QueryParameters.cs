using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.LMS.Models.RequestModel
{
    public class QueryParameters
    {


        public string? Search { get; set; }

        public string? Sort { get; set; }

        private int _page = 1;
        private int _size = 10;

        public int Page
        {
            get => _page;
            set => _page = value > 0 ? value : 1;
        }

        public int Size
        {
            get => _size;
            set => _size = value > 0 ? value : 10;
        }

        public string? Fields { get; set; }

        public string? Expand { get; set; }
    }
}
