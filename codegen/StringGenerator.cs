using System.Text;

using Microsoft.CodeAnalysis;

namespace Arinc424.Generators;

[Generator]
public class StringGenerator() : ConverterGenerator(Constants.StringAttribute)
{
    internal override StringBuilder WriteTarget(StringBuilder builder, Target target)
    {
        _ = base.WriteTarget(builder, target);

        if (target.IsFlags)
        {
            for (int i = 1; i < target.Members.Length; i++)
                _ = builder.Append("\n    | ").WriteOffset($"{Constants.String}[{i}]").WriteMembers(target.Members[i], target.Unknown).Append("\n    }");
        }
        return builder;
    }
}
