using Api.DTOs;
using Api.Models;
using Api.Services.OcrService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/student-id-card")]
public class StudentIdCardController(IOcrService ocrService) : ControllerBase
{
    private readonly IOcrService _ocrService = ocrService;

    [HttpPost("parse")]
    public async Task<IActionResult> ParseStudentIdCard([FromForm] UploadImageFileRequest request)
    {
        if (request.Image == null || request.Image.Length == 0)
        {
            return BadRequest("Image file not uploaded.");
        }

        using var stream = request.Image.OpenReadStream();

        string ocrText = string.Empty;

        try
        {
            ocrText = await _ocrService.ExtractTextAsync(stream);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"OCR error: {ex.Message}");
        }

        // TODO: implement regex extraction...
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