﻿using System;
using System.IO;
using System.Xml.Linq;
using System.Threading.Tasks;

using R5T.D0001;
using R5T.D0010;
using R5T.T0004;
using R5T.T0064;

using R5T.Magyar.Xml;


namespace R5T.D0021.Default
{
    [ServiceImplementationMarker]
    public class RelativePathsXDocumentVisualStudioProjectFileStreamSerializer : IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer, IServiceImplementation
    {
        private INowUtcProvider NowUtcProvider { get; }


        public RelativePathsXDocumentVisualStudioProjectFileStreamSerializer(
            INowUtcProvider nowUtcProvider)
        {
            this.NowUtcProvider = nowUtcProvider;
        }

        public Task<XDocumentVisualStudioProjectFile> DeserializeAsync(Stream stream, IMessageSink messageSink)
        {
            var xDocument = XDocument.Load(stream, LoadOptions.PreserveWhitespace); // Visual Studio project files have good whitespacing, so preserve.

            var visualStudioProjectFileXDocument = new VisualStudioProjectFileXDocument(xDocument);

            var xElementVisualStudioProjectFile = new XDocumentVisualStudioProjectFile(visualStudioProjectFileXDocument);

            return Task.FromResult(xElementVisualStudioProjectFile);
        }

        public Task SerializeAsync(Stream stream, XDocumentVisualStudioProjectFile xElementVisualStudioProjectFile, IMessageSink messageSink)
        {
            using (var xmlWriter = XmlWriterHelper.New(stream))
            {
                var projectXElement = xElementVisualStudioProjectFile.ProjectXElement;

                var xProjectXElement = projectXElement.Value;

                var xDocument = xProjectXElement.Document;

                xDocument.Save(xmlWriter); // No SaveAsync() in .NET Standard.
            }

            return Task.CompletedTask;
        }
    }
}

