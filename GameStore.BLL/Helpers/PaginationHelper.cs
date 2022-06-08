using GameStore.BLL.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.Helpers
{
    public static class PaginationHelper<T>
    {
        public static ItemPageDTO<T> CreatePage(int currentPage, int elementsOnPage, int totalItems, List<T> items)
        {
            ItemPageDTO<T> itemPageDTO = new ItemPageDTO<T>()
            {
                Items = items,
                PageInfo = new PageInfoDTO
                {
                    CurrentPageNumber = currentPage,
                    ElementsOnPage = elementsOnPage,
                    TotalItems = totalItems
                }
            };

            return itemPageDTO;

        }
    }
}
