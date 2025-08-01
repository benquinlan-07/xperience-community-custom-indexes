using CMS.DataEngine;
using CMS.FormEngine;
using CMS.Modules;
using XperienceCommunity.CustomIndexes.Models;

namespace XperienceCommunity.CustomIndexes;

internal class ExtensionModuleInstaller
{
    private readonly IInfoProvider<ResourceInfo> _resourceProvider;

    public ExtensionModuleInstaller(IInfoProvider<ResourceInfo> resourceProvider)
    {
        _resourceProvider = resourceProvider;
    }

    public void Install()
    {
        var resource = _resourceProvider.Get(Constants.ResourceName)
                       ?? new ResourceInfo();

        InitializeResource(resource);
        InstallCustomCustomIndexesItemInfo(resource);
    }

    public ResourceInfo InitializeResource(ResourceInfo resource)
    {
        resource.ResourceDisplayName = Constants.ResourceDisplayName;
        resource.ResourceName = Constants.ResourceName;
        resource.ResourceDescription = Constants.ResourceDescription;
        resource.ResourceIsInDevelopment = false;

        if (resource.HasChanged)
            _resourceProvider.Set(resource);

        return resource;
    }

    public void InstallCustomCustomIndexesItemInfo(ResourceInfo resource)
    {
        var info = DataClassInfoProvider.GetDataClassInfo(CustomCustomIndexesItemInfo.OBJECT_TYPE) ?? DataClassInfo.New(CustomCustomIndexesItemInfo.OBJECT_TYPE);

        info.ClassName = CustomCustomIndexesItemInfo.TYPEINFO.ObjectClassName;
        info.ClassTableName = CustomCustomIndexesItemInfo.TYPEINFO.ObjectClassName.Replace(".", "_");
        info.ClassDisplayName = CustomCustomIndexesItemInfo.OBJECT_CLASS_DISPLAYNAME;
        info.ClassType = ClassType.OTHER;
        info.ClassResourceID = resource.ResourceID;

        var formInfo = FormHelper.GetBasicFormDefinition(nameof(CustomCustomIndexesItemInfo.CustomCustomIndexesItemId));

        var formItem = new FormFieldInfo
        {
            Name = nameof(CustomCustomIndexesItemInfo.CustomCustomIndexesItemGuid),
            AllowEmpty = false,
            Visible = true,
            Precision = 0,
            DataType = "guid",
            Enabled = true,
        };
        formInfo.AddFormItem(formItem);

        formItem = new FormFieldInfo
        {
            Name = nameof(CustomCustomIndexesItemInfo.CustomCustomIndexesItemPlaceholder),
            AllowEmpty = true,
            Visible = true,
            Size = 500,
            DataType = "text"
        };
        formInfo.AddFormItem(formItem);

        SetFormDefinition(info, formInfo);

        if (info.HasChanged)
        {
            DataClassInfoProvider.SetDataClassInfo(info);
        }
    }

    /// <summary>
    /// Ensure that the form is upserted with any existing form
    /// </summary>
    /// <param name="info"></param>
    /// <param name="form"></param>
    private static void SetFormDefinition(DataClassInfo info, FormInfo form)
    {
        if (info.ClassID > 0)
        {
            var existingForm = new FormInfo(info.ClassFormDefinition);
            existingForm.CombineWithForm(form, new());
            info.ClassFormDefinition = existingForm.GetXmlDefinition();
        }
        else
        {
            info.ClassFormDefinition = form.GetXmlDefinition();
        }
    }
}
