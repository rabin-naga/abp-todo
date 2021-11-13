using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Todos
{
    [Dependency(ReplaceServices = true)]
    public class TodosBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Todos";
    }
}
