using System;
using System.Reflection;

namespace W1040_Mvc_WebApi2_swgger.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}