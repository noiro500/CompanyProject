namespace CompanyProjectMessageService.Model
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string PersonName { get; set; } = null!;
        public string WhatsAppTelegramNumber { get; set; } = null!;
        public ulong MessageNumber { get; set; }
        public string? Email { get; set; }
        public string SubjectMessage { get; set; }=null!;
        public string Content { get; set; }=null!;
        public bool IsAnswered { get; set; }=false;
        public bool IsAdoptedPrivacyPolicy { get; set; }
    }
}
