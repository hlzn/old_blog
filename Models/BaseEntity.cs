using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace hlzn1.DataModels;

public abstract class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Comment("Primary key of the entity")]
    public int Id { get; set; } = default!;
    
    [Comment("When the entity was created")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Comment("When the entity was last updated")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Column(TypeName = "timestamp with time zone")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}