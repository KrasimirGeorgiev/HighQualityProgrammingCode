namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using Moq;
    using System.Linq;

    /// <summary>
    /// Using Moq in homeowrk
    /// </summary>
    public class MoqCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        /// <summary>
        /// Refactored structure and added additional method mocks
        /// </summary>
        protected override void ArrangeCarsRepositoryMock()
        {
            /* Original code */

            var mockedCarsRepository = new Mock<ICarsRepository>();

            // .Add 
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>()))
                .Callback((Car car) => this.FakeCarCollection.Add(car)) // Additional Code
                .Verifiable();

            // .All
            mockedCarsRepository.Setup(r => r.All())
                .Returns(this.FakeCarCollection);

            // .Search 
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>()))
                .Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());

            // .GetById
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(this.FakeCarCollection.First());         

            /* Additional code */
            
            // .TotalCars
            mockedCarsRepository.Setup(r => r.TotalCars)
                .Returns(4);

            // .SortByMake
            mockedCarsRepository.Setup(r => r.SortedByMake())
                .Returns(this.FakeCarCollection.OrderBy(c => c.Make).ToList());

            // .SortByYear
            mockedCarsRepository.Setup(r => r.SortedByYear())
                .Returns(this.FakeCarCollection.OrderBy(c => c.Year).ToList());


            this.CarsData = mockedCarsRepository.Object;
        }
    }
}
