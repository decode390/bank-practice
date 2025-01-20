using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities;

public abstract class BaseEntity{
    [Column(TypeName = "datetime2")]
    [AllowNull]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime2")]
    [AllowNull]
    public DateTime? ModificationDate {get; set;}
}