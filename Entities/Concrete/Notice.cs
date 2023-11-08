using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{

    public partial class Notice : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CarId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Car Car { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
