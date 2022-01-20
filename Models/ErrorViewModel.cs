using System;

namespace ASPProject4.Models
{
    // model class for checking the error
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
