using System;
using System.IO;
using System.Threading.Tasks;

using R5T.D0010;
using R5T.T0004;


namespace R5T.D0021.Default
{
    public interface IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer
    {
        Task<XDocumentVisualStudioProjectFile> DeserializeAsync(Stream stream, IMessageSink messageSink);
        Task SerializeAsync(Stream stream, XDocumentVisualStudioProjectFile xElementVisualStudioProjectFile, IMessageSink messageSink);
    }
}
