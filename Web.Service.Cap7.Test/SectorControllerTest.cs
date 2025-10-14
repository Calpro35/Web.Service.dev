using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Web.Service.Cap7.Controllers;
using Web.Service.Cap7.Data.Context;
using Web.Service.Cap7.Models;
using Web.Service.Cap7.Requests;

namespace Web.Service.Cap7.Test
{
    public class SectorControllerTest
    {
        private readonly SectorController _sectorController;

        private readonly DbSet<Sector> _mockSet;

        private readonly Mock<IMediator> _mockMediator;

        public SectorControllerTest()
        {
            _mockMediator = new Mock<IMediator>();

            _mockSet = MockDbSet();

            _mockMediator
                .Setup(m => m.Send(It.IsAny<Sector>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(_mockSet);

            _sectorController = new SectorController(_mockMediator.Object);
        }


        [Fact]
        public void GetByIdAsync_ReturnsIActionResult_WhenGetByIdAsyncIsValid()
        {
            //Action
            var sector = GetSector();
            var token = GetCancellationToken();
            var result = _sectorController.GetByIdAsync(sector.UserId, token);

            //Assert
            var createdResult = Assert.IsType<Task<IActionResult>>(result);
            var model = Assert.IsAssignableFrom<Task<IActionResult>>(createdResult);

            Assert.NotNull(model);
        }

        [Fact]
        public void GetAllAsync_ReturnsIActionResult_WhenGetAllAsyncIsValid()
        {
            //Action
            var token = GetCancellationToken();
            var result = _sectorController.GetAllAsync(token);

            //Assert
            var createdResult = Assert.IsType<Task<IActionResult>>(result);
            var model = Assert.IsAssignableFrom<Task<IActionResult>>(createdResult);

            Assert.NotNull(model);
        }

        [Fact]
        public void CreateAsync_ReturnsIActionResult_WhenCreateAsyncIsValid()
        {
            //Action
            var request = new NewSectorRequest(Name: "RH", "", 1800.00);
            var token = GetCancellationToken();
            var result = _sectorController.CreateAsync(request, token);

            //Assert
            var createdResult = Assert.IsType<Task<IActionResult>>(result);
            var model = Assert.IsAssignableFrom<Task<IActionResult>>(createdResult);

            Assert.NotNull(model);
        }

        private Sector GetSector()
        {
            return new Sector(name: "Produção", description: "", consumptionLimit: 1500.0, userId:1);
        }

        private CancellationToken GetCancellationToken()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            return token;
        }

        private DbSet<Sector> MockDbSet()
        {
            var data = new List<Sector>
                {
                    new Sector(name: "Produção", description: "", consumptionLimit: 1500.0, userId:1),
                    new Sector(name: "Vendas", description: "", consumptionLimit: 2000.0, userId:2),
                }.AsQueryable();

            var mockSet = new Mock<DbSet<Sector>>();

            mockSet.As<IQueryable<Sector>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Sector>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Sector>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Sector>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet.Object;
        }
    }
}
