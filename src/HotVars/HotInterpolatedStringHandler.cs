using System.Numerics;
using System.Runtime.CompilerServices;

namespace HotVars;

[InterpolatedStringHandler]
public struct HotInterpolatedStringHandler(int literalLength, int formattedCount)
{
    private HotString Builder { get; set; } = new HotString("");

    public void AppendLiteral(string s) => Builder = Builder + s;

    internal readonly HotString ToHotString() => Builder;

    public void AppendFormatted(HotString t)
    {
        Builder += t;
    }

    public void AppendFormatted(string t)
    {
        Builder += t;
    }

    public void AppendFormatted<T>(HotNumber<T> t)
        where T : INumber<T>
    {
        Builder += t;
    }
}
