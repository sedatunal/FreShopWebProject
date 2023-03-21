using FreeShop.Business.Services;
using FreeShop.Business.Types;
using FreeShop.Data.Dto;
using FreeShop.Data.Entities;
using FreeShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShop.Business.Managers
{
    public class CommentManager : ICommentService
    {
        private readonly IRepository<CommentEntity> _commentRepository;

        public CommentManager(IRepository<CommentEntity> commentRepository)
        {
            _commentRepository=commentRepository;
        }
        public ServiceMessage AddComment(CommentDto comment)
        {
            var hasComment = _commentRepository.GetAll(x => (x.CommentText).ToLower() == (comment.CommentText).ToLower()).ToList();

            var commentEntity = new CommentEntity()
            {
                Id = comment.Id,               
                CommentText=comment.CommentText,
                Rate = comment.Rate,
                ProductId = comment.ProductId,
                UserId = comment.UserId,
            };

            _commentRepository.Add(commentEntity);

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public void DeleteComment(int id)
        {
            _commentRepository.Delete(id);
        }

        public void EditComment(CommentDto comment)
        {
            var commentEntity = _commentRepository.GetById(comment.Id);

            commentEntity.CommentText = comment.CommentText;
            commentEntity.Rate = comment.Rate;
            commentEntity.ProductId = comment.ProductId;
            commentEntity.UserId = comment.UserId;
        
            if (comment.CommentText != null)
                commentEntity.CommentText = comment.CommentText;

            _commentRepository.Update(commentEntity);
        }

        public CommentDto GetCommentById(int id)
        {
            var commentEntity = _commentRepository.GetById(id);

            var commentDto = new CommentDto
            {
                Id = commentEntity.Id,
                CommentText = commentEntity.CommentText,
                Rate = commentEntity.Rate,
                ProductId = commentEntity.ProductId,
                UserId= commentEntity.UserId,
               
            };

            return commentDto;
        }

        public List<CommentDto> GetComments(int? productId = null)
        {
            var query = _commentRepository.GetAll();

            if (productId.HasValue)
                query = query.Where(x => x.ProductId == productId.Value);

            var commentEntities = query.OrderBy(x => x.Product.Name).ThenBy(x => x.ModifiedDate);


            var commentList = commentEntities.Select(x => new CommentDto
            {
                Id = x.Id,
                CommentText= x.CommentText,
                Rate= x.Rate,
                ProductId= x.ProductId, 
                UserId= x.UserId,
            }).ToList();

            return commentList;
        }
    }
}
