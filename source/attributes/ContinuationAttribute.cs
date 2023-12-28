namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies the index of <c>Continuation Record Number (CONT NR)</c> within an ARINC-424 string. Default is 22.
/// </summary>
/// <remarks>See paragraph 5.16.</remarks>
[AttributeUsage(AttributeTargets.Class)]
internal class ContinuationAttribute(int index = 22) : Attribute
{
    /// <summary>
    /// Index of the continuation number.
    /// </summary>
    /// <remarks>Default is 22.</remarks>
    internal int Index { get; } = index - 1;
}
