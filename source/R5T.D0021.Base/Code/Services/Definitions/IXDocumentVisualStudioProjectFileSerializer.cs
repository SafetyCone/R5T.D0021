using System;

using R5T.D0013;
using R5T.T0004;
using R5T.T0064;


namespace R5T.D0021
{
    [ServiceDefinitionMarker]
    public interface IXDocumentVisualStudioProjectFileSerializer : IFileSerializer<XDocumentVisualStudioProjectFile>, IServiceDefinition
    {
    }
}
