using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0001;
using R5T.D0010;
using R5T.D0017;
using R5T.D0022;

using R5T.Dacia;


namespace R5T.D0021.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="RelativePathsXDocumentVisualStudioProjectFileStreamSerializer"/> implementation of <see cref="IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddRelativePathsXDocumentVisualStudioProjectFileStreamSerializer(this IServiceCollection services,
            IServiceAction<INowUtcProvider> nowUtcProviderAction)
        {
            services
                .AddSingleton<IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer, RelativePathsXDocumentVisualStudioProjectFileStreamSerializer>()
                .Run(nowUtcProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="RelativePathsXDocumentVisualStudioProjectFileStreamSerializer"/> implementation of <see cref="IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer> AddRelativePathsXDocumentVisualStudioProjectFileStreamSerializerAction(this IServiceCollection services,
            IServiceAction<INowUtcProvider> nowUtcProviderAction)
        {
            var serviceAction = ServiceAction.New<IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer>(() => services.AddRelativePathsXDocumentVisualStudioProjectFileStreamSerializer(
                nowUtcProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="XDocumentVisualStudioProjectFileSerializer"/> implementation of <see cref="IXDocumentVisualStudioProjectFileSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddXDocumentVisualStudioProjectFileSerializer(this IServiceCollection services,
            IServiceAction<IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer> relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction,
            IServiceAction<IFunctionalVisualStudioProjectFileSerializationModifier> functionalVisualStudioProjectFileSerializationModifierAction,
            IServiceAction<IMessageSink> messageSinkAction,
            IServiceAction<IVisualStudioProjectFileXDocumentPrettifier> visualStudioProjectFileXDocumentPrettifierAction)
        {
            services
                .AddSingleton<IXDocumentVisualStudioProjectFileSerializer, XDocumentVisualStudioProjectFileSerializer>()
                .Run(relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction)
                .Run(functionalVisualStudioProjectFileSerializationModifierAction)
                .Run(messageSinkAction)
                .Run(visualStudioProjectFileXDocumentPrettifierAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="XDocumentVisualStudioProjectFileSerializer"/> implementation of <see cref="IXDocumentVisualStudioProjectFileSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IXDocumentVisualStudioProjectFileSerializer> AddXDocumentVisualStudioProjectFileSerializerAction(this IServiceCollection services,
            IServiceAction<IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer> relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction,
            IServiceAction<IFunctionalVisualStudioProjectFileSerializationModifier> functionalVisualStudioProjectFileSerializationModifierAction,
            IServiceAction<IMessageSink> messageSinkAction,
            IServiceAction<IVisualStudioProjectFileXDocumentPrettifier> visualStudioProjectFileXDocumentPrettifierAction)
        {
            var serviceAction = ServiceAction.New<IXDocumentVisualStudioProjectFileSerializer>(() => services.AddXDocumentVisualStudioProjectFileSerializerAction(
                relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction,
                functionalVisualStudioProjectFileSerializationModifierAction,
                messageSinkAction,
                visualStudioProjectFileXDocumentPrettifierAction));

            return serviceAction;
        }
    }
}
