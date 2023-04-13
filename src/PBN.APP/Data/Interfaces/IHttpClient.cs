using System.Diagnostics.CodeAnalysis;

namespace PBN.APP.Data.Interfaces
{
    internal interface IHttpClient
    {
        public Task<Y> GetAsync<Y>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri);

        public Task<Y> PostAsync<Y>([StringSyntax(StringSyntaxAttribute.Uri)] string requestUri, HttpContent content);

    }
}
