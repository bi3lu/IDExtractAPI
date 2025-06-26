using Tesseract;

namespace Api.Services.OcrService;

public class OcrService(IWebHostEnvironment env) : IOcrService
{
    private readonly string _tesseractDataPath = Path.Combine(env.ContentRootPath, "Tessdata");

    public Task<string> ExtractTextAsync(Stream imageStream)
    {
        using var engine = new TesseractEngine(_tesseractDataPath, "pol", EngineMode.Default);
        using var image = Pix.LoadFromMemory(ReadFully(imageStream));
        using var page = engine.Process(image);

        return Task.FromResult(page.GetText());
    }

    private static byte[] ReadFully(Stream input)
    {
        using var ms = new MemoryStream();
        input.CopyTo(ms);

        return ms.ToArray();
    }
}