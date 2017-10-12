using System;
using Xunit;
using WebApiCoreEdx.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreWebAPI.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1 + 1 == 2);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(1 , 0);
        }
    }

    public class ActorsControllerFunctionTest
{
    [Fact]
    public void GetActorByIdSmokeTest()
    {
        var controller = new FilmsController();
        var result = controller.GetFilm(101) as OkObjectResult;
        var actor = result.Value as Actor;
        Assert.Equal(actor.Actor_ID, 101);
        Assert.Equal(actor.First_Name, "SUSAN");
        Assert.Equal(actor.Last_Name, "DAVIS");
    }
}
}
