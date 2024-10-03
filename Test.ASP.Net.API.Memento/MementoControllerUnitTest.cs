using ASP.Net.API.Memento.Controllers;
using AutoMapper;
using Castle.Core.Logging;
using Grpc.Net.Client.Balancer;
using Memento.Gpx.Application.Repository;
using Memento.Gpx.Application.WorkOfUnit;
using Memento.Gpx.Domain;
using Memento.Gpx.Infrastructures.AutoMapper;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Interfaces.WorkOfUnit;
using Microsoft.AspNetCore.Mvc;
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
            var moqLogger = new Mock<ILogger<GpxController>>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            var moqWorkOfUnit = new Mock<IGpxTypeWorkOfUnit>();
            moqWorkOfUnit.Setup(item => item.GetInstance().GetAll()).Returns(
            [
                new GpxType() { Id = 1, Creator = "Loulou", Version = "1.1" },
                new GpxType() { Id = 2, Creator = "Loulou", Version = "1.1" }
            ]);

            var controller = new GpxController(moqLogger.Object, mapper, moqWorkOfUnit.Object);

            ////Act
            var result = controller.GetAll();

            ////Assert

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(List<GpxType>));
            
        }

        [Fact]
        public void TestControllerGpxAdd() {

            #region init
            var moqLogger = new Mock<ILogger<GpxController>>();
            var moqDbContext = new Mock<MementoDbContext>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            var moqWorkOfUnit = new Mock<IGpxTypeWorkOfUnit>();
            moqWorkOfUnit.Setup(item => item.GetInstance()
            .Add(new GpxType() { Version = "1.1", Creator = "Loulou" }));
            moqWorkOfUnit.Setup(item => item.Save()).Returns(1);

            var controler = new GpxController(moqLogger.Object, mapper, moqWorkOfUnit.Object);

            #endregion

            #region Act
            var result = controler.Post();
            #endregion

            #region Control
            Assert.NotNull(result);
            Assert.True(result is OkResult);
            
            #endregion
        }
    }
}