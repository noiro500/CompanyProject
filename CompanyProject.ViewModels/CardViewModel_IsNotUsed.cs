namespace CompanyProject.ViewModels
{
    public class CardViewModel_IsNotUsed
    {
        public string ScreenName { get; private set; }
        public string AspController { get; private set; }
        public string AspAction { get; private set; }
        public string Image { get; private set; }

        public CardViewModel_IsNotUsed(string screenName, string aspController, string aspAction, string image)
        {

            ScreenName = screenName;
            AspController = aspController;
            AspAction = aspAction;
            Image = image;
        }
    }
}
