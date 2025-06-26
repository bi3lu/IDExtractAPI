using Tesseract;

namespace Api.Services.OcrService;

public class OcrService(IWebHostEnvironment env) : IOcrService
{
    private readonly string _tesseractDataPath = Path.Combine(env.ContentRootPath, "Tessdata");

    public Task<string> ExtractTextAsync(Stream imageStream)
    {
        throw new NotImplementedException();
    }

    private static byte[] ReadFully(Stream input)
    {
        using var ms = new MemoryStream();
        input.CopyTo(ms);

        return ms.ToArray();
    }
}