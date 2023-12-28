namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies the section and subsection characters and indices to define the entity of the string.
/// </summary>
/// <param name="char">Section character.</param>
/// <param name="subsectionChar">Subsection character. Default is whitespace.</param>
/// <param name="index">Index of the section character.</param>
/// <param name="subsectionIndex">Index of the subsection character.</param>
/// <remarks>See paragraph 5.4 and 5.5.</remarks>
[AttributeUsage(AttributeTargets.Class)]
internal class RecordAttribute(char @char, char subsectionChar = (char)32, int index = 5, int subsectionIndex = 6) : Attribute
{
    /// <summary>
    /// Section character.
    /// </summary>
    internal char Char { get; } = @char;

    /// <summary>
    /// Index of the section character.
    /// </summary>
    internal int Index { get; } = index - 1;

    /// <summary>
    /// Subsection character.
    /// </summary>
    internal char SubsectionChar { get; } = subsectionChar;

    /// <summary>
    /// Index of the subsection character.
    /// </summary>
    internal int SubsectionIndex { get; } = subsectionIndex - 1;
}
