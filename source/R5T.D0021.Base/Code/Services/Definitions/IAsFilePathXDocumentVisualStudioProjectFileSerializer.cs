﻿using System;
using System.Threading.Tasks;

using R5T.T0004;


namespace R5T.D0021
{
    /// <summary>
    /// Allows serializing a <see cref="XDocumentVisualStudioProjectFile"/> to one path, while allowing the file to think it's being serialized to a different path (for determining any project-reference project file relative paths).
    /// </summary>
    public interface IAsFilePathXDocumentVisualStudioProjectFileSerializer
    {
        Task SerializeAsync(string actualfilePath, string asFilePath, XDocumentVisualStudioProjectFile xElementVisualStudioProjectFile, bool overwrite = true);
    }
}
