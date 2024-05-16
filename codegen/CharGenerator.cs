using Microsoft.CodeAnalysis;

namespace Arinc424.Generators;

[Generator]
public class CharGenerator() : ConverterGenerator(Constants.CharAttribute);
