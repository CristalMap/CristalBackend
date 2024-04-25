namespace Cristal.Domain.DTOs
{
    public class EmailMessageDTO
    {
        public string? MailTo { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
