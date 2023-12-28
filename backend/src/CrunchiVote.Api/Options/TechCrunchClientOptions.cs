using System.ComponentModel.DataAnnotations;

namespace CrunchiVote.Api.Options;

public class TechCrunchClientOptions
{
    [Required]
    public string EndpointUrl { get; set; }
    
}