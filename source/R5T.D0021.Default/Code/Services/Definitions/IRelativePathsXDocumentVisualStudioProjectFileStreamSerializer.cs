using System;
using System.IO;
using System.Threading.Tasks;

using R5T.D0010;
using R5T.T0004;
using R5T.T0064;


namespace R5T.D0021.Default
{
    [ServiceDefinitionMarker]
    public interface IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer : IServiceDefinition
    {
        Task<XDocumentVisualStudioProjectFile> DeserializeAsync(Stream stream, IMessageSink messageSink);
        Task SerializeAsync(Stream stream, XDocumentVisualStudioProjectFile xElementVisualStudioProjectFile, IMessageSink messageSink);
    }
}
