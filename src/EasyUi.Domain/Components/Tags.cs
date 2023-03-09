using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyUi.Components
{
    public class Tags : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsEnable { get; set; }

        public ICollection<TagAttribute> Attribute { get; set; }

        protected Tags()
        {
        }

        public Tags(
            Guid id,
            string name,
            string code,
            bool isEnable
        ) : base(id)
        {
            Name = name;
            Code = code;
            IsEnable = isEnable;
            Attribute = new Collection<TagAttribute>();
        }
    }
}
