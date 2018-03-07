using System;

namespace UTRADE.DBAccess.Entities
{
    public abstract class Entity<TID>
    {
        public TId Id { get; set; }
    }
}