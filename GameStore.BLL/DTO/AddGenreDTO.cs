using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.DTO
{
    public class AddGenreDTO
    {
        public string Name { get; set; }    

        public int? ParentGenreId { get; set; }
    }
}
