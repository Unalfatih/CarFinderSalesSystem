using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{

    public partial class Gear : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}