using FreeShop.Business.Types;
using FreeShop.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShop.Business.Services
{
    public interface ICommentService
    {
        ServiceMessage AddComment(CommentDto comment);
        List<CommentDto> GetComments(int? productId = null);

        CommentDto GetCommentById(int id);

        void EditComment(CommentDto comment);

        void DeleteComment(int id);
    }
}
