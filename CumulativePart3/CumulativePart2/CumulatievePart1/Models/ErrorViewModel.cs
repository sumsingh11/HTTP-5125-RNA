// A model to represent error information.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CumulatievePart1.Models
{
    /// <summary>
    /// Represents an error view model .
    /// </summary>
    /// 
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
