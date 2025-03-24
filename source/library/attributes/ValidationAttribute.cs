using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Arinc424.Attributes;

/**<summary>
Specifies the regex pattern to validate a value of the property according to the specification.
</summary>
<param name="pattern">Pattern to match.</param>*/
[AttributeUsage(AttributeTargets.Property)]
internal class ValidationAttribute([StringSyntax(StringSyntaxAttribute.Regex)] string pattern) : Attribute
{
    /// <summary>Pattern to validate.</summary>
    internal Regex Regex { get; } = new Regex(pattern, RegexOptions.Compiled);
}
