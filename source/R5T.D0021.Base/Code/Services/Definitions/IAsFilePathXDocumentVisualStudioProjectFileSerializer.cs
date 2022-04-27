using System;
using System.Threading.Tasks;

using R5T.T0004;
using R5T.T0064;


namespace R5T.D0021
{
    /// <summary>
    /// Allows serializing a <see cref="XDocumentVisualStudioProjectFile"/> to one path, while allowing the file to think it's being serialized to a different path (for determining any project-reference project file relative paths).
    /// </summary>
    [ServiceDefinitionMarker]
    public interface IAsFilePathXDocumentVisualStudioProjectFileSerializer : IServiceDefinition
    {
        Task SerializeAsync(string actualfilePath, string asFilePath, XDocumentVisualStudioProjectFile xElementVisualStudioProjectFile, bool overwrite = true);
    }
}
