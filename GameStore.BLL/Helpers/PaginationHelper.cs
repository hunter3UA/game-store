using GameStore.BLL.DTO.Common;
using System.Collections.Generic;

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

        public static int CheckCurrentPage(int currentPage, int elementsOnPage,int totalItemss)
        {
            PageInfoDTO pageInfo = new PageInfoDTO { CurrentPageNumber = currentPage, ElementsOnPage = elementsOnPage, TotalItems = totalItemss };

            currentPage = currentPage > pageInfo.TotalPages || currentPage <= 0 ? 1 : currentPage;

            return currentPage;
        }
    }
}
