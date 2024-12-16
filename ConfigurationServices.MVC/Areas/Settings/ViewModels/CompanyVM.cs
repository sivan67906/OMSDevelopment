namespace ConfigurationServices.MVC.Areas.Settings.ViewModels
{
    public class CompanyVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RegnNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int EstablishedYear { get; set; }
        public string Website { get; set; } = string.Empty;
        public int BusinessTypeId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
