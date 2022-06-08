using System;

namespace GameStore.BLL.DTO.Common
{
    public class PageInfoDTO
    {
        public int CurrentPageNumber { get; set; }

        public int ElementsOnPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ElementsOnPage); }
        }

    }
}
