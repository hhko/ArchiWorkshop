﻿namespace ArchiWorkshop.Domains.Abstractions.DomainTypes;

public abstract class Entity<TEntityId>
    : IEquatable<Entity<TEntityId>>
    , IEntity
    where TEntityId : struct, IEntityId<TEntityId>
{
    protected Entity()
    {
    }

    protected Entity(TEntityId id)
    {
        Id = id;
    }

    public TEntityId Id { get; private init; }

    public bool Equals(Entity<TEntityId>? other)
    {
        if (other is null)
        {
            return false;
        }

        //if (other.GetType() != GetType())
        //{
        //    return false;
        //}

        return other.Id.Value == Id.Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Entity<TEntityId> otherEntity)
        {
            return false;
        }

        return otherEntity.Id.Value == Id.Value;
    }

    public static bool operator ==(Entity<TEntityId>? first, Entity<TEntityId>? second)
    {
        //return first is not null
        //    && second is not null
        //    && first.Equals(second);

        //if (first is null && second is null) 
        //{
        //    return true;
        //}

        if (first is null || second is null)
        {
            return false;
        }

        return first.Equals(second);
    }

    public static bool operator !=(Entity<TEntityId>? first, Entity<TEntityId>? second)
    {
        return !(first == second);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * 41;
    }
}
