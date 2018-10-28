using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;

public class NewTestScript {

    [Test]
    public void NewTestScriptSimplePasses() {
        // Arrange
        var weaponStub = Substitute.For<IWeapon>();
        weaponStub.Fire().Returns(2);

        // Act
        int fire = weaponStub.Fire();

        // Assert
        Assert.AreEqual(2, fire);
        weaponStub.Received().Fire();


    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}

public interface IWeapon
{
    int Fire();
}


