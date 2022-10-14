using System;

namespace OA.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}