using System;

namespace UTRADE.DBAccess.Entities
{
    public abstract class Entity<TID>
    {
        public TID Id { get; set; }
    }
}