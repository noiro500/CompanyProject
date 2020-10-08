namespace CompanyProject.API.ViewModels
{
    public class TopMenuLineViewModel
    {
        private bool FirstLine { get; set; }
        public bool NavBar { get; private set; }
        public bool NeedStar { get; private set; }
        public string AspController { get; private set; }
        public string AspAction { get; private set; }
        public string Icon { get; private set; }
        public string IconColor { get; private set; }
        public string ScreenName { get; private set; }

        public TopMenuLineViewModel(bool firstLine,
            bool navBar, bool needStar,
            string aspController, string aspAction, string icon,
            string iconColor, string screenName)
        {
            FirstLine = firstLine;
            NavBar = navBar;
            NeedStar = needStar;
            AspController = aspController;
            AspAction = aspAction;
            Icon = icon;
            IconColor = iconColor;
            ScreenName = screenName;
        }
    }
}
