using Api.DTOs;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/student-id-card")]
public class StudentIdCardController : ControllerBase
{
    [HttpPost("parse")]
    public IActionResult ParseStudentIdCard([FromForm] UploadImageFileRequest request)
    {
        if (request.Image == null || request.Image.Length == 0)
        {
            return BadRequest("Image file not uploaded.");
        }

        return Ok(new StudentIdCard()
        {
            UniversityName = "Simple University Warsaw",
            FullName = "Jan Kowalski",
            IssueDate = DateTime.Now,
            AlbumNumber = "123066",
            PeselNumber = "02350600312"
        });
    }
}