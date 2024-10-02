using ASP.Net.API.Memento.Controllers;
using AutoMapper;
using Castle.Core.Logging;
using Grpc.Net.Client.Balancer;
using Memento.Gpx.Domain;
using Memento.Gpx.Infrastructures.AutoMapper;
using Memento.Gpx.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net.Sockets;

namespace Test.ASP.Net.API.Memento
{
    public class MementoControllerUnitTest
    {
        [Fact]
        public void TestControllerGpxGetAll()
        {
            //Arrange
            //var controller = new GpxController();

            ////Act
            //var result = controller.GetAll();

            ////Assert

            //Assert.NotNull(result);
            //Assert.True(result.AsEnumerable().Any());
            //Assert.Contains("toto",result);
        }

        [Fact]
        public void TestControllerGpxAdd() {

            #region init
            var moqGpx = new Mock<DbSet<GpxType>>();
            var moqLogger = new Mock<ILogger<GpxController>>();
            var moqContext = new Mock<MementoDbContext>();
            var moqMapper = new Mock<Mapper>();
            moqContext.Setup(item => item.GpxTypes).Returns(moqGpx.Object);

            var controler = new GpxController(moqContext.Object, moqLogger.Object, moqMapper.Object);

            #endregion
            
            controler.Post();
            moqGpx.Verify(m => m.Add(It.IsAny<GpxType>()), Times.Once());
            moqContext.Verify(m => m.SaveChanges(), Times.Once());

        }
    }
}