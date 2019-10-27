using System;

namespace CinemaExplorer.Persisted.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
