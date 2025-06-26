namespace Api.DTOs;

public class UploadImageFileRequest
{
    public IFormFile Image { get; set; } = default!;
}