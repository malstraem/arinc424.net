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
            {
                _ = builder.Append("\n    | ");

                var members = target.Members[i];

                var blank = members.FirstOrDefault(x => x.IsBlank);

                if (blank is not null)
                {
                    (string member, _) = blank;

                    _ = builder.Append($"(char.IsWhiteSpace({Constants.String}[{i}]) ? {member} : ");

                    members = members.Except([blank]).ToArray();
                }

                _ = builder.WriteOffset($"{Constants.String}[{i}]").WriteMembers(members, target.Unknown).Append("\n    }");

                if (blank is not null)
                    _ = builder.Append(')');
            }
        }
        return builder;
    }
}
