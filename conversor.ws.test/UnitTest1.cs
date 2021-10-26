using JetBrains.dotMemoryUnit;
using JetBrains.dotMemoryUnit.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace conversor.ws.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DotMemoryUnitAttribute(FailIfRunWithoutSupport = false)]
        public void CheckObjectsTest() => dotMemory.Check(memory => Assert.IsTrue(memory
             .GetObjects(where => where.Generation.Is(Generation.LOH)).ObjectsCount > 5));
    }
}
