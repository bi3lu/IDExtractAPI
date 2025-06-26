namespace Api.Services.OcrService;

public interface IOcrService
{
    Task<string> ExtractTextAsync(Stream imageStream);
}