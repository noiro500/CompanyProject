namespace CompanyProject.API.ViewModels
{
    public class CardViewModel
    {
        public string ScreenName { get; set; }
        public string AspController { get; set; }
        public string AspAction { get; set; }
        public string Image { get; set; }

        public CardViewModel(string screenName, string aspController, string aspAction, string image)
        {

            ScreenName = screenName;
            AspController = aspController;
            AspAction = aspAction;
            Image = image;
        }
    }
}
