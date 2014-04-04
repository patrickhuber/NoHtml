using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition.Hosting;

namespace NoHtml.Web.Tests.Unit
{
    /// <summary>
    /// Summary description for CompositionDependencyResolverTests
    /// </summary>
    [TestClass]
    public class CompositionDependencyResolverTests
    {
        public CompositionDependencyResolverTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        
        interface ICalculator
        {
            int Add(int first, int second);
        }

        class Calculator : ICalculator
        {
            public int Add(int first, int second)
            {
                return first + second;
            }
        }

        interface IAutomobile
        {
            void Start();
            int GetWheelCount();
        }

        class Car : IAutomobile
        {
            public void Start()
            {
                Console.Write("Put put put. Vrooom!");
            }

            public int GetWheelCount()
            {
                return 4;
            }
        }

        private CompositionContainer compositionContainer;
        private IDependencyResolver dependencyResolver;

        [TestInitialize()]
        public void Initialize_CompositionDependencyResolverTests() 
        {
            compositionContainer = new CompositionContainer();
            dependencyResolver = new CompositionDependencyResolver(compositionContainer);            
        }

        [TestMethod]
        public void Test_CompositionDependencyResolver_RegisterService_Registers_Instance()
        {
            dependencyResolver.Register<ICalculator>(new Calculator());
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test_CompositionDependencyResolver_RegisterService_Registers_Named_Instance()
        {            
            dependencyResolver.Register<ICalculator>(new Calculator(), "calculator");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test_CompositionDependencyResolver_GetServiceGeneric_Returns_Registered_Instance()
        {
            var expected = new Calculator();
            dependencyResolver.Register<ICalculator>(expected);
            var actual = dependencyResolver.GetService<ICalculator>();
            Assert.AreSame(actual, expected);
        }

        [TestMethod]
        public void Test_CompositionDependencyResolver_GetServiceGeneric_With_Name_Returns_Registered_Instance()
        {
            var expected = new Calculator();
            var notExpected = new Calculator();
            dependencyResolver.Register<ICalculator>(expected, "calculator");
            dependencyResolver.Register<ICalculator>(notExpected);
            var actual = dependencyResolver.GetService<ICalculator>("calculator");

            Assert.AreSame(actual, expected);
            Assert.AreNotSame(actual, notExpected);
        }

        [TestMethod]
        public void Test_CompositionDependencyResolver_GetService_Returns_Registered_Instance()
        {
            var expected = new Calculator();
            dependencyResolver.Register<ICalculator>(expected);
            var actual = dependencyResolver.GetService(typeof (ICalculator));
            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void Test_CompositionDependencyResolver_GetServices_Returns_All_Registered_Instances()
        {
            var defaultCalculator = new Calculator();
            var namedCalculator = new Calculator();
            var car = new Car();
            dependencyResolver.Register<ICalculator>(defaultCalculator);
            dependencyResolver.Register<ICalculator>(namedCalculator, "named");
            dependencyResolver.Register<IAutomobile>(car);

            // enumerate to save on computation power
            var services = dependencyResolver
                .GetServices(typeof (ICalculator))
                .ToArray();

            Assert.AreEqual(2, services.Length);

            bool isNamedCalculator = false;
            bool isDefaultCalculator = false;
            foreach (var service in services)
            {
                if (service == namedCalculator)
                    isNamedCalculator = true;
                if(service == defaultCalculator)
                    isDefaultCalculator = true;
            }
            Assert.IsTrue(isNamedCalculator && isDefaultCalculator);
        }
    }
}
