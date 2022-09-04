using Applications.Features.ProgrammingLanguages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageListModel: BasePageableModel
    {
        public IList<ProgrammingLanguageListDto> Items { get; set; }
    }
}
