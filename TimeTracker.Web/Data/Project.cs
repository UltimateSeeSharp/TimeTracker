using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Web.Data;

public class Project
{
    [Key]
    public int Id { get; set; }

	[Required]
	[MaxLength(128)]
    public string Title { get; set; }

    [Required]
    [MaxLength(1024)]
    public string Description { get; set; }

    public ICollection<Entry> Entries { get; set; }
}