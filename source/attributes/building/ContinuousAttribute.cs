namespace Arinc424.Attributes;

/// <summary>
/// Specifies the index of <c>Continuation Record Number (CONT NR)</c> within an <c>ARINC-424</c> string. Default is 22.
/// </summary>
/// <remarks>See section 5.16.</remarks>
[AttributeUsage(AttributeTargets.Class)]
internal class ContinuousAttribute(int index = 22) : IndexAttribute(index);
