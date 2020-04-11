using System.ComponentModel;

namespace Bashi.Core.Tests.Enums
{
    public enum TestColour
    {
        [Description("#FF0000")] Red,
        [Description("#00FF00")] Green,
        [Description("#0000FF")] Blue,
        Yellow
    }
}
