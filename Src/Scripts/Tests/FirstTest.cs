using GdUnit4;
using static GdUnit4.Assertions;

namespace Game.Scripts.Tests;

[TestSuite]
public class FirstTest
{
    [TestCase]
    public void Test()
    {
        AssertThat(true).IsTrue();
        AssertThat(false).IsFalse();
    }
}