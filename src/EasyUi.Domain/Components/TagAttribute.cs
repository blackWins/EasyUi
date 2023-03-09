using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyUi.Components
{
    public class TagAttribute : FullAuditedEntity<Guid>
    {
        public Tags Tag { get; set; } //Navigation property
        public Guid TagId { get; set; }
        public string Name { get; set; }
        public EAttributeType Type { get; set; }
        public string DefaultValue { get; set; }
        public string Description { get; set; }

        protected TagAttribute()
        {
        }

        public TagAttribute(
            Guid id,
            Guid tagId,
            string name,
            EAttributeType type,
            string defaultValue,
            string description
        ) : base(id)
        {
            TagId = tagId;
            Name = name;
            Type = type;
            DefaultValue = defaultValue;
            Description = description;
        }
    }
}
