using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyUi.UniApp
{
    public class UniAppService : EasyUiAppService
    {
        public async Task<string> GetProperties(string name)
        {
            return "hi" + name;
        }

        public async Task<string> GetTageOutput(string name)
        {
            return $"<uni-badge text=\"1\">{name}</uni-badge>";
        }
    }
}
