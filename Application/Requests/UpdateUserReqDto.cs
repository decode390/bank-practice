
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Requests;

public class UpdateUserReqDto{
    /// <summary>
    ///  The new name of the user to update
    /// </summary>
    /// <example>New name</example>
    [Required]
    [MinLength(5)]
    public string Name { get; set; } = string.Empty;
}