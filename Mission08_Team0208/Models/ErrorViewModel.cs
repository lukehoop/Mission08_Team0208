namespace Mission08_Team0208.Models
{
    public class ErrorViewModel
    {
        // Error view to display erro information
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
