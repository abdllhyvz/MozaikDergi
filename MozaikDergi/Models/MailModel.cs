namespace MozaikDergi.Models
{
    public class MailModel
    {
        public string? Title { get; set; } = "Siteden Form Oluşturuldu";
        public string? Body { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Receiver { get; set; } = "info@mozaikdergi.com";
        public string? Password { get; set; } = "Mozaik_2023*";
    }
}
