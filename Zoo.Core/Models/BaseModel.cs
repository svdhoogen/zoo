using System;

namespace Zoo.Core.Models
{
    public abstract class BaseModel : IModel
    {
        public int Id { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}