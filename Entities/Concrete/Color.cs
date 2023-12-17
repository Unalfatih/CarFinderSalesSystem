using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class Color : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime? CreatedDate { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}