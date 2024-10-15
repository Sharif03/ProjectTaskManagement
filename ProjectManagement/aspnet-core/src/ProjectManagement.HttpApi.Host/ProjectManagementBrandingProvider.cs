using Microsoft.Extensions.Localization;
using ProjectManagement.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ProjectManagement;

[Dependency(ReplaceServices = true)]
public class ProjectManagementBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ProjectManagementResource> _localizer;

    public ProjectManagementBrandingProvider(IStringLocalizer<ProjectManagementResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
