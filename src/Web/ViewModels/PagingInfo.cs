using System;

namespace Enginex.Web.ViewModels
{
    public class PagingInfo
    {
        public int TotalCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalCount / ItemsPerPage);
    }
}
