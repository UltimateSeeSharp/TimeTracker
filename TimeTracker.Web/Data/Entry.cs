using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks.Dataflow;

namespace TimeTracker.Web.Data;

public class Entry
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? EmployeeId { get; set; }
    public ApplicationUser Employee { get; set; }

    [Required]
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
	public TimeOnly Start { get; set; }

	[Required]
	public TimeOnly End { get; set; }

	[Required]
	public DateOnly Date { get; set; }

    public double HoursWorked => Math.Round((End - Start).TotalHours, 2);
}