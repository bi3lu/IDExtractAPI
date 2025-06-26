using Tesseract;

namespace Api.Services.OcrService;

public class OcrService(IWebHostEnvironment env) : IOcrService
{
    private readonly string _tesseractDataPath = Path.Combine(env.ContentRootPath, "Tessdata");

    public async Task<string> ExtractTextAsync(Stream imageStream)
    {
        using var engine = new TesseractEngine(_tesseractDataPath, "pol", EngineMode.Default);
        using var image = Pix.LoadFromMemory(ReadFully(imageStream));
        using var page = engine.Process(image);
        
        var text = page.GetText();
        Console.WriteLine("--- OCR OUTPUT ---");
        Console.WriteLine(text);
    
    return await Task.FromResult(text);
    }

    private static byte[] ReadFully(Stream input)
    {
        using var ms = new MemoryStream();
        input.CopyTo(ms);

        return ms.ToArray();
    }
}