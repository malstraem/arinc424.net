namespace Arinc424.Attributes;

/**<summary>
Specifies that property holds continuation records.
</summary>*/
[AttributeUsage(AttributeTargets.Property)]
internal sealed class ContinueAttribute : Attribute;

/**<summary>
Specifies the index of <c>Continuation Record Number (CONT NR)</c>
within an <c>ARINC-424</c> string. Default is 22.
</summary>
<inheritdoc/>*/
[AttributeUsage(AttributeTargets.Class)]
internal sealed class ContinuousAttribute(int index = 22) : IndexAttribute(index);

/**<summary>
Specifies <c>Application Type</c> index and character
to define continuation record type. Default is 23 and 'A'.
</summary>
<remarks>See section 5.91.</remarks>*/
[AttributeUsage(AttributeTargets.Class)]
internal sealed class ContinuationAttribute(int index = 23, char application = 'A')
    : IndexAttribute(index)
{
    private readonly char application = application;

    internal bool IsMatch(string @string) => @string[Index] == application;
}
