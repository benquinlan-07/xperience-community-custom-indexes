using System;
using System.Data;
using CMS;
using CMS.DataEngine;
using CMS.Helpers;
using XperienceCommunity.CustomIndexes.Models;

[assembly: RegisterObjectType(typeof(CustomCustomIndexesItemInfo), CustomCustomIndexesItemInfo.OBJECT_TYPE)]

namespace XperienceCommunity.CustomIndexes.Models;

/// <summary>
/// Data container class for <see cref="CustomCustomIndexesItemInfo"/>.
/// </summary>
[Serializable]
public partial class CustomCustomIndexesItemInfo : AbstractInfo<CustomCustomIndexesItemInfo, IInfoProvider<CustomCustomIndexesItemInfo>>
{
    /// <summary>
    /// Object type.
    /// </summary>
    public const string OBJECT_TYPE = "xpcm.customextensiontemplateitem";
    public const string OBJECT_CLASS_NAME = "XPCM.CustomCustomIndexesItem";
    public const string OBJECT_CLASS_DISPLAYNAME = "CustomCustomIndexesItem";


    /// <summary>
    /// Type information.
    /// </summary>
    public static readonly ObjectTypeInfo TYPEINFO = new(typeof(IInfoProvider<CustomCustomIndexesItemInfo>), OBJECT_TYPE, OBJECT_CLASS_NAME, nameof(CustomCustomIndexesItemId), null, nameof(CustomCustomIndexesItemGuid), null, null, null, null, null)
    {
        TouchCacheDependencies = true,
        ContinuousIntegrationSettings =
        {
            Enabled = true,
        },
    };


    /// <summary>
    /// Custom extension template item ID.
    /// </summary>
    [DatabaseField]
    public virtual int CustomCustomIndexesItemId
    {
        get => ValidationHelper.GetInteger(GetValue(nameof(CustomCustomIndexesItemId)), 0);
        set => SetValue(nameof(CustomCustomIndexesItemId), value);
    }


    /// <summary>
    /// Custom extension template item GUID.
    /// </summary>
    [DatabaseField]
    public virtual Guid CustomCustomIndexesItemGuid
    {
        get => ValidationHelper.GetGuid(GetValue(nameof(CustomCustomIndexesItemGuid)), default);
        set => SetValue(nameof(CustomCustomIndexesItemGuid), value);
    }


    /// <summary>
    /// Custom extension template item placeholder value.
    /// </summary>
    [DatabaseField]
    public virtual string CustomCustomIndexesItemPlaceholder
    {
        get => ValidationHelper.GetString(GetValue(nameof(CustomCustomIndexesItemPlaceholder)), default);
        set => SetValue(nameof(CustomCustomIndexesItemPlaceholder), value);
    }


    /// <summary>
    /// Deletes the object using appropriate provider.
    /// </summary>
    protected override void DeleteObject()
    {
        Provider.Delete(this);
    }


    /// <summary>
    /// Updates the object using appropriate provider.
    /// </summary>
    protected override void SetObject()
    {
        Provider.Set(this);
    }


    /// <summary>
    /// Creates an empty instance of the <see cref="CustomCustomIndexesItemInfo"/> class.
    /// </summary>
    public CustomCustomIndexesItemInfo()
        : base(TYPEINFO)
    {
    }


    /// <summary>
    /// Creates a new instance of the <see cref="CustomCustomIndexesItemInfo"/> class from the given <see cref="DataRow"/>.
    /// </summary>
    /// <param name="dr">DataRow with the object data.</param>
    public CustomCustomIndexesItemInfo(DataRow dr)
        : base(TYPEINFO, dr)
    {
    }
}
