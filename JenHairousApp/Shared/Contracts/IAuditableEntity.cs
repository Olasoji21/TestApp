using System;

namespace AtmosUserManager.Domain.Contracts
{
    public interface IAuditableEntity
    {
        DateTime    CreatedOn       { get; set; }

        DateTime?   LastModifiedOn  { get; set; }
    }
}