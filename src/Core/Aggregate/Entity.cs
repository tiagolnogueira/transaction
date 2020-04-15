using System;

namespace Core.Aggregate
{
    public class Entity : IEquatable<Entity>
    {
        public Entity()
        {

        }

        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            return Equals(other);
        }

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id == null || other.Id == null)
                return false;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return a != b;
        }
    }
}
