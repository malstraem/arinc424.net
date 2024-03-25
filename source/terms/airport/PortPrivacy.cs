using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Public/Military Indicator (PUB/MIL)</c> character. See paragraph 5.177.
/// </summary>
/// <remarks><see cref="TransformAttribute">Transformed</see> by <see cref="PortPrivacyConverter"/>.</remarks>
[Flags]
public enum PortPrivacy : byte
{
    Unknown,
    Civil,
    Military,
    Private
}
