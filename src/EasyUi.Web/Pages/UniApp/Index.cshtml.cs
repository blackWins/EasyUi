using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EasyUi.Components;
using EasyUi.Components.Dtos;
using System.Threading.Tasks;

namespace EasyUi.Web.Pages.UniApp
{
    public class IndexModel : EasyUiPageModel
    {
        private readonly ITagsRepository _tagsRepository;

        public List<TagsDto> Items { get; set; }

        public IndexModel(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }


        private async void SetItems()
        {
            /*
            Items = new List<string>() { "介绍", "开始使用", "色彩说明", "uni-sass 辅助样式", "uni-badge 数字角标", "uni-breadcrumb 面包屑", "uni-calendar 日历", "uni-card 卡片", "uni-collapse 折叠面板", "uni-combox 组合框", "uni-countdown 倒计时", "uni-data-checkbox 数据选择器", "uni-data-picker 级联选择器", "uni-data-select 下拉框", "uni-dateformat 日期格式化", "uni-datetime-picker 日期选择器", "uni-drawer 抽屉", "uni-easyinput 增强输入框", "uni-fab 悬浮按钮", "uni-fav 收藏按钮", "uni-file-picker 文件选择上传" };
            */
        }

        public void OnGet()
        {
            Items = new List<TagsDto>();

            //Items = ObjectMapper.Map<List<Tags>, List<TagsDto>>(await _tagsRepository.GetListAsync());
        }
    }
}
