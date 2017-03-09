using System.Linq;

namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
             // : this(new JustMockCarsRepository())
             : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        /// <summary>
        /// Homework
        /// </summary>
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SortingShouldThrowArgumentExceptionIfInvokedWithAnythingButMakeOrModel()
        {
            var cars = (ICollection<Car>)this.GetModel(() => this.controller.Sort("1111"));
        }

        /// <summary>
        /// Homework
        /// </summary>
        [TestMethod]
        public void SortingByMakeShouldReturnCarsSortedByMake()
        {
            var cars = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(4, cars.Count);

            Car prevCar = cars.First();

            foreach (var c in cars)
            {
                Assert.IsTrue(string.Compare(c.Make, prevCar.Make, StringComparison.Ordinal) >= 0);
                prevCar = c;
            }
        }

        /// <summary>
        /// Homework
        /// </summary>
        [TestMethod]
        public void SortingByMakeShouldReturnCarsSortedByYear()
        {
            var cars = (ICollection<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(4, cars.Count);

            Car prevCar = cars.First();

            foreach (var c in cars)
            {
                Assert.IsTrue(c.Year >= prevCar.Year);
                prevCar = c;
            }
        }

        /// <summary>
        /// Homework
        /// </summary>
        [TestMethod]
        public void SearchingByAnyConditionWithContentShouldReturnResult()
        {
            var foundCars = (ICollection<Car>)this.GetModel(() => this.controller.Search("New Car"));

            foreach (var car in foundCars)
            {
                Assert.IsTrue(car.Make == "BMW");
            }
        }

        /// <summary>
        /// Homework
        /// </summary>
        [TestMethod]
        public void InvokingDetailsWithValidNumberShouldReturnCar()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(1));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        /// <summary>
        /// Homework 
        /// Adding this test fulfills 100% coverage for CarsController
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvokingDetailsWithNullOrEmptyStringShouldThrow()
        {
            var testMock = new Mock<ICarsRepository>();
            testMock.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(() => null);

            this.controller = new CarsController(testMock.Object);

            var model = (Car) this.GetModel(() => this.controller.Details(-1));
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
