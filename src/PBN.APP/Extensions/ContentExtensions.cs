using System.Net.Http.Headers;
using System.Net.Mime;

namespace PBN.APP.Extensions;

public static class ContentExtensions
{
    public static ByteArrayContent ToByteArrayContent(this string me)
    {
        var buffer = System.Text.Encoding.UTF8.GetBytes(me);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);

        return byteContent;
    }
}