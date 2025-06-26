namespace Api.Models;

public class StudentIdCard
{
    public string UniversityName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateTime? IssueDate { get; set; }
    public string AlbumNumber { get; set; } = string.Empty;
    public string PeselNumber { get; set; } = string.Empty;
}