using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class Notice :IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}