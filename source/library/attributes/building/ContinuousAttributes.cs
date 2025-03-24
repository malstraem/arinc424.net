namespace Arinc424.Attributes;

/**<summary>
Specifies that property holds contunations records.
</summary>*/
[AttributeUsage(AttributeTargets.Property)]
internal class ContinueAttribute : Attribute;

/**<summary>
Specifies the index of <c>Continuation Record Number (CONT NR)</c> within an <c>ARINC-424</c> string. Default is 22.
</summary>
<remarks>See section 5.16.</remarks>*/
[AttributeUsage(AttributeTargets.Class)]
internal class ContinuousAttribute(int index = 22) : IndexAttribute(index);

/**<summary>
Specifies index and character <c>Application Type</c> to define continuation record type.
</summary>
<remarks>See section 5.91.</remarks>*/
[AttributeUsage(AttributeTargets.Class)]
internal class ContinuationAttribute(int index = 23, char application = 'A') : IndexAttribute(index)
{
    private readonly char application = application;

    internal bool IsMatch(string @string) => @string[Index] == application;
}
