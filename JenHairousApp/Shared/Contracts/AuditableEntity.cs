using System;

namespace AtmosUserManager.Domain.Contracts
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public int          Id              { get; set; }
        public DateTime     CreatedOn       { get; set; }
        public DateTime?    LastModifiedOn  { get; set; }
    }
}