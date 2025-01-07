using System.ComponentModel;

namespace PersonalDiary.Application.Common
{
    public class PagedListQueryBase
    {
        public const int MaxPageSize = 100;
        [DefaultValue(1)]
        public int Page { get; set; }
        [DefaultValue(15)]
        public int PageSize { get; set; } = MaxPageSize;
    }

    public class TimefilterblePagedListQuery : PagedListQueryBase
    {
        [Description("созданные после с даты")]
        public DateTime? StartDate { get; set; }
        [Description("созданные ранее с даты")]
        public DateTime? EndDate { get; set; }
    }



}
