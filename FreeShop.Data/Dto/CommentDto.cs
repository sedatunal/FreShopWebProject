using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShop.Data.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int Rate { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }
        public string ProductName { get; set; }
        //public string UserName { get; set; }
        public UserDto User { get; set; }

    }
}
