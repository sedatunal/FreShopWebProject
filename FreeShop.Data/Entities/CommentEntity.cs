using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShop.Data.Entities
{
    public class CommentEntity : BaseEntity
    {
        public string CommentText { get; set; }
        public int Rate { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }

        public ProductEntity Product { get; set; }
        public UserEntity User { get; set; }
        //public string UserName { get; set; }
    }
    public class CommentEntityConfiguration : BaseConfiguration<CommentEntity>
    {
        public override void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.Property(x => x.CommentText).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Rate).IsRequired();
            builder.Property(x => x.UserId).IsRequired();



            base.Configure(builder);
        }
    }
}
