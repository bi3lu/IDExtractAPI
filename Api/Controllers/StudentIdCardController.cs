using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/extract-student-id-card")]
public class StudentIdCardController : ControllerBase
{
    [HttpGet]
    public IActionResult GetDummyStudentIdCardInfo()
    {
        var dummyStudentIdCardInfo = new StudentIdCard()
        {
            UniversityName = "Simple University Warsaw",
            FullName = "Jan Kowalski",
            IssueDate = DateTime.Now,
            AlbumNumber = "123066",
            PeselNumber = "02350600312"
        };

        return Ok(dummyStudentIdCardInfo);
    }
}