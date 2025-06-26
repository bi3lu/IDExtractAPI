using Tesseract;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;

namespace Api.Services.OcrService;

public class OcrService(IWebHostEnvironment env) : IOcrService
{
    private readonly string _tesseractDataPath = Path.Combine(env.ContentRootPath, "Tessdata");

    public async Task<string> ExtractTextAsync(Stream imageStream)
    {
        using var preprocessedStream = PreprocessImage(imageStream);

        using var engine = new TesseractEngine(_tesseractDataPath, "pol", EngineMode.Default);
        using var image = Pix.LoadFromMemory(ReadFully(preprocessedStream));
        using var page = engine.Process(image);

        // Console.WriteLine("=== OCR TEST ===");
        // Console.WriteLine(page.GetText());

        return await Task.FromResult(page.GetText());
    }

    private static byte[] ReadFully(Stream input)
    {
        using var ms = new MemoryStream();
        input.CopyTo(ms);

        return ms.ToArray();
    }

    private static MemoryStream PreprocessImage(Stream originalStream)
    {
        originalStream.Position = 0;

        using var image = Image.Load(originalStream);

        // TODO: need to adapt these values...
        image.Mutate(x => x
            .Grayscale()
            .Contrast(1.5f)
            .AdaptiveThreshold());

        var ms = new MemoryStream();
        image.Save(ms, new PngEncoder());
        ms.Position = 0;
        
        return ms;
    }
}