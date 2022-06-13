using System.Collections.Generic;


namespace GameStore.BLL.DTO.Common
{
    public class ItemPageDTO<T>
    {
        public PageInfoDTO PageInfo { get; set; }

        public List<T> Items { get; set; }
    }
}
