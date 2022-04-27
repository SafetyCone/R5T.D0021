using System;
using System.IO;
using System.Threading.Tasks;

using R5T.D0010;
using R5T.D0017;
using R5T.D0022;
using R5T.T0004;
using R5T.T0064;


namespace R5T.D0021.Default
{
    [ServiceImplementationMarker]
    public class AsFilePathXDocumentVisualStudioProjectFileSerializer : IAsFilePathXDocumentVisualStudioProjectFileSerializer, IServiceImplementation
    {
        private IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer RelativePathsXDocumentVisualStudioProjectFileStreamSerializer { get; }
        private IFunctionalVisualStudioProjectFileSerializationModifier FunctionalVisualStudioProjectFileSerializationModifier { get; }
        private IMessageSink MessageSink { get; }
        private IVisualStudioProjectFileXDocumentPrettifier VisualStudioProjectFileXDocumentPrettifier { get; }


        public AsFilePathXDocumentVisualStudioProjectFileSerializer(
            IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer relativePathsXDocumentVisualStudioProjectFileStreamSerializer,
            IFunctionalVisualStudioProjectFileSerializationModifier functionalVisualStudioProjectFileSerializationModifier,
            IMessageSink messageSink,
            IVisualStudioProjectFileXDocumentPrettifier visualStudioProjectFileXDocumentPrettifier)
        {
            this.RelativePathsXDocumentVisualStudioProjectFileStreamSerializer = relativePathsXDocumentVisualStudioProjectFileStreamSerializer;
            this.FunctionalVisualStudioProjectFileSerializationModifier = functionalVisualStudioProjectFileSerializationModifier;
            this.MessageSink = messageSink;
            this.VisualStudioProjectFileXDocumentPrettifier = visualStudioProjectFileXDocumentPrettifier;
        }

        public async Task SerializeAsync(string actualfilePath, string asFilePath, XDocumentVisualStudioProjectFile xElementVisualStudioProjectFile, bool overwrite = true)
        {
            // Modify.
            var modifiedXElementVisualStudioProjectFile = await this.FunctionalVisualStudioProjectFileSerializationModifier.ModifySerializationAsync(xElementVisualStudioProjectFile, asFilePath, this.MessageSink);

            // Prettify.
            await this.VisualStudioProjectFileXDocumentPrettifier.Prettify(modifiedXElementVisualStudioProjectFile.VisualStudoProjectFileXDocument);

            // Serialize.
            using (var fileStream = FileStreamHelper.NewWrite(actualfilePath, overwrite))
            {
                await this.RelativePathsXDocumentVisualStudioProjectFileStreamSerializer.SerializeAsync(fileStream, modifiedXElementVisualStudioProjectFile, this.MessageSink);
            }
        }
    }
}
