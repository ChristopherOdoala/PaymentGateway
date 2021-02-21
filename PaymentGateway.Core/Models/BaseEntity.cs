using PaymentGateway.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Models
{
    public class BaseEntity
    {
        public interface IEntity
        {
            Guid Id { get; set; }
        }

        public interface IDateAudit
        {
            DateTime CreatedOn { get; set; }
            DateTime? ModifiedOn { get; set; }
        }

        public interface ISoftDelete
        {
            bool IsDeleted { get; set; }
            DateTime? DeletedOn { get; set; }
        }

        public interface IActorAudit
        {
            Guid? CreatedBy { get; set; }
            Guid? ModifiedBy { get; set; }
        }

        public interface IAudit : IDateAudit, IActorAudit
        {
        }

        public abstract class Entity : IEntity
        {
            public virtual Guid Id { get; set; }
        }

        public abstract class AuditedEntity : Entity, IAudit
        {
            public AuditedEntity()
            {
                Id = SequentialGuidGenerator.Instance.Create();
                CreatedOn = DateTime.Now;
            }

            public DateTime CreatedOn { get; set; }
            public DateTime? ModifiedOn { get; set; }

            public Guid? CreatedBy { get; set; }
            public Guid? ModifiedBy { get; set; }
        }
    }
}
