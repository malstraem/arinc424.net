using Arinc.Spec424.Attributes;

namespace Arinc.Spec424;

internal record ExternalLinkedInfo(ExternalAttribute externalLinkAttribute)
{
    public Range ExternalLinkRange { get; } = externalLinkAttribute.Range;
}
