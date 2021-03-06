﻿namespace Enginex.Domain.Entities
{
    public abstract class Entity
    {
        public virtual int Id { get; protected set; }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this != other)
            {
                return false;
            }

            if (Id == 0 || other.Id == 0)
            {
                return false;
            }

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (ToString() + Id).GetHashCode();
        }
    }
}
