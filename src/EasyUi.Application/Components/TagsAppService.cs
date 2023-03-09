using System;
using System.Linq;
using System.Threading.Tasks;
using EasyUi.Permissions;
using EasyUi.Components.Dtos;
using Volo.Abp.Application.Services;

namespace EasyUi.Components;


public class TagsAppService : CrudAppService<Tags, TagsDto, Guid, TagsGetListInput, CreateUpdateTagsDto, CreateUpdateTagsDto>,
    ITagsAppService
{
    protected override string GetPolicyName { get; set; } = EasyUiPermissions.Tags.Default;
    protected override string GetListPolicyName { get; set; } = EasyUiPermissions.Tags.Default;
    protected override string CreatePolicyName { get; set; } = EasyUiPermissions.Tags.Create;
    protected override string UpdatePolicyName { get; set; } = EasyUiPermissions.Tags.Update;
    protected override string DeletePolicyName { get; set; } = EasyUiPermissions.Tags.Delete;

    private readonly ITagsRepository _repository;

    public TagsAppService(ITagsRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Tags>> CreateFilteredQueryAsync(TagsGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(!input.Code.IsNullOrWhiteSpace(), x => x.Code.Contains(input.Code))
            .WhereIf(input.IsEnable != null, x => x.IsEnable == input.IsEnable)
            //.WhereIf(input.Attribute != null, x => x.Attribute == input.Attribute)
            ;
    }
    public override Task<TagsDto> CreateAsync(CreateUpdateTagsDto input)
    {
        foreach (var item in input.Attribute)
        {
            item.Id = GuidGenerator.Create();
        }

        return base.CreateAsync(input);
    }

}
