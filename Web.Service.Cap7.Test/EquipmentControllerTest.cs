using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Web.Service.Cap7.Controllers;
using Web.Service.Cap7.Models;
using Web.Service.Cap7.Requests;

namespace Web.Service.Cap7.Test
{
    public class EquipmentControllerTest
    {
        private readonly EquipmentController _equipmentController;

        private readonly DbSet<Equipment> _mockSet;

        private readonly Mock<IMediator> _mockMediator;

        public EquipmentControllerTest()
        {
            _mockMediator = new Mock<IMediator>();

            _mockSet = MockDbSet();

            _mockMediator
                .Setup(m => m.Send(It.IsAny<Sector>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(_mockSet);

            _equipmentController = new EquipmentController(_mockMediator.Object);
        }

        [Fact]
        public void CreateAsync_ReturnsIActionResult_WhenCreateAsyncIsValid()
        {
            //Action
            var request = new NewEquipmentRequest(Name:"Cafeteira", ConsumptionPerHour: 20.0, MaxActiveHours: 8, LastActivedAt: DateTime.Now, SectorId: 1);
            var token = GetCancellationToken();
            var result = _equipmentController.CreateAsync(request, token);

            //Assert
            var createdResult = Assert.IsType<Task<IActionResult>>(result);
            var model = Assert.IsAssignableFrom<Task<IActionResult>>(createdResult);

            Assert.NotNull(model);
        }
        
        [Fact]
        public void ActivateAsync_ReturnsIActionResult_WhenActivateAsyncIsValid()
        {
            //Action
            var token = GetCancellationToken();
            var result = _equipmentController.ActivateAsync(1, token);

            //Assert
            var createdResult = Assert.IsType < Task<IActionResult>>(result);
            var model = Assert.IsAssignableFrom<Task<IActionResult>>(createdResult);

            Assert.NotNull(model);
        }

        private CancellationToken GetCancellationToken()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            return token;
        }

        private DbSet<Equipment> MockDbSet()
        {
            var data = new List<Equipment>
                {
                    new Equipment(name: "Servidor 1", consumptionPerHour: 80.0, maxActiveHours: 7, lastActivedAt:DateTime.Now, sectorId:1),
                    new Equipment(name: "Ar Condicionado", consumptionPerHour: 120.0, maxActiveHours: 5, lastActivedAt:DateTime.Now, sectorId:2)
                }.AsQueryable();

            var mockSet = new Mock<DbSet<Equipment>>();

            mockSet.As<IQueryable<Equipment>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Equipment>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Equipment>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Equipment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet.Object;
        }
    }
}