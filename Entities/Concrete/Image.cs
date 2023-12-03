using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class Image :IEntity
    {
        public int Id { get; set; }

        public byte[]? Image1 { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; } = null!;
    }
}