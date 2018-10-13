using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class PlayerControllerTest {

    [Test]
    public void MyFirst_Test()
    {
        Assert.AreEqual(true, false);
    }

    [Test]
    public void MySecond_Test()
    {
        Assert.AreEqual(true, true);
    }

    [Test]
    public void setTestCount_Test()
    {
        // Arrange
        PlayerController playerController = new PlayerController();

        // Act
        string winText = playerController.SetCountText();

        // Assert
        Assert.AreEqual("You Win!", winText);

    }

}
