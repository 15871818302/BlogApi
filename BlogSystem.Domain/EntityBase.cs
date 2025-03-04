using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Common
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public override bool Equals(object? obj)
        {
            var entity = obj as EntityBase;
            if (entity == null)
            {
                return false;
            }
            return Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(EntityBase left, EntityBase right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }
            return left.Equals(right);
        }

        public static bool operator !=(EntityBase left, EntityBase right)
        {
            return !(left == right);
        }
    }
}