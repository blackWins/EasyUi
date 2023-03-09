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
            Items = new List<string>() { "����", "��ʼʹ��", "ɫ��˵��", "uni-sass ������ʽ", "uni-badge ���ֽǱ�", "uni-breadcrumb ���м", "uni-calendar ����", "uni-card ��Ƭ", "uni-collapse �۵����", "uni-combox ��Ͽ�", "uni-countdown ����ʱ", "uni-data-checkbox ����ѡ����", "uni-data-picker ����ѡ����", "uni-data-select ������", "uni-dateformat ���ڸ�ʽ��", "uni-datetime-picker ����ѡ����", "uni-drawer ����", "uni-easyinput ��ǿ�����", "uni-fab ������ť", "uni-fav �ղذ�ť", "uni-file-picker �ļ�ѡ���ϴ�" };
            */
        }

        public void OnGet()
        {
            Items = new List<TagsDto>();

            //Items = ObjectMapper.Map<List<Tags>, List<TagsDto>>(await _tagsRepository.GetListAsync());
        }
    }
}
