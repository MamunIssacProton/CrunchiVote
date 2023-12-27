using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;

namespace CrunchiVote.Api;

internal static class ResponseCompression
{
    internal static IServiceCollection AddCompression(this IServiceCollection services)
    {
         services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
        });


         services.Configure<BrotliCompressionProviderOptions>(options =>
         {
             options.Level = CompressionLevel.SmallestSize;
         });
         services.Configure<GzipCompressionProviderOptions>(options =>
         {
             options.Level = CompressionLevel.SmallestSize;
         });
         
         return services;
    }
}