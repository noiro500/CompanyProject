namespace CompanyProject.API.Infrastructure.Dto
{
    namespace CompanyProject.ViewModels
    {
        public class ErrorViewModel
        {
            public string RequestId { get; set; }

            public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        }
    }
}
