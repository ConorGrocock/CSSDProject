using Xunit;

namespace UnitTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        bool result = true;

        Assert.True(result, "True can't be false");
    }
}