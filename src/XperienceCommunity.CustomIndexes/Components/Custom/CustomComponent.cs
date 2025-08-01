using System.Threading.Tasks;
using Kentico.Xperience.Admin.Base;

namespace XperienceCommunity.CustomIndexes.Components.Custom;

public class CustomComponent : ActionComponent<CustomComponentProperties, CustomComponentClientProperties>
{
    public override string ClientComponentName => "@xperiencecommunitycustomindexess/web-admin/Custom";

    protected override Task ConfigureClientProperties(CustomComponentClientProperties clientProperties)
    {
        return base.ConfigureClientProperties(clientProperties);
    }
}
