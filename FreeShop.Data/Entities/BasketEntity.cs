using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShop.Data.Entities
{
    public class BasketEntity : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Piece { get; set; }

    }

    public class BasketEntityConfiguration : BaseConfiguration<BasketEntity>
    {
        public override void Configure(EntityTypeBuilder<BasketEntity> builder)
        {

            base.Configure(builder);
        }

    }
}
