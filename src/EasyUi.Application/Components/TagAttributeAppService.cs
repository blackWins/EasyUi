using System;
using System.Linq;
using System.Threading.Tasks;
using EasyUi.Permissions;
using EasyUi.Components.Dtos;
using Volo.Abp.Application.Services;

namespace EasyUi.Components;


public class TagAttributeAppService : CrudAppService<TagAttribute, TagAttributeDto, Guid, TagAttributeGetListInput, CreateUpdateTagAttributeDto, CreateUpdateTagAttributeDto>,
    ITagAttributeAppService
{
    protected override string GetPolicyName { get; set; } = EasyUiPermissions.TagAttribute.Default;
    protected override string GetListPolicyName { get; set; } = EasyUiPermissions.TagAttribute.Default;
    protected override string CreatePolicyName { get; set; } = EasyUiPermissions.TagAttribute.Create;
    protected override string UpdatePolicyName { get; set; } = EasyUiPermissions.TagAttribute.Update;
    protected override string DeletePolicyName { get; set; } = EasyUiPermissions.TagAttribute.Delete;

    private readonly ITagAttributeRepository _repository;

    public TagAttributeAppService(ITagAttributeRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<TagAttribute>> CreateFilteredQueryAsync(TagAttributeGetListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.TagId != null, x => x.TagId == input.TagId)
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(input.Type != null, x => x.Type == input.Type)
            .WhereIf(!input.DefaultValue.IsNullOrWhiteSpace(), x => x.DefaultValue.Contains(input.DefaultValue))
            .WhereIf(!input.Description.IsNullOrWhiteSpace(), x => x.Description.Contains(input.Description))
            ;
    }
}
