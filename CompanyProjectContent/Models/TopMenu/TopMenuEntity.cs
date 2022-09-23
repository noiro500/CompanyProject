namespace CompanyProjectContentService.Models.TopMenu
{
    public class TopMenuEntity
    {
        public Guid TopMenuEntityId { get; set; }
        public bool FirstLine { get; set; }
        public string AspAction { get; set; } = null!;
        public string AspController { get; set; }=null!;
        public string Icon { get; set; } = null!;
        public string IconColor { get; set; } = null!;
        public bool NavBar { get; set; }
        public bool NeedStar { get; set; }
        public string ScreenName { get; set; } = null!;
    }
}
