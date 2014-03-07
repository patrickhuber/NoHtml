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
        public void Test_CompositionDependencyResolver_GetService_Returns_Registered_Instance()
        {
            var expected = new Calculator();
            dependencyResolver.Register<ICalculator>(expected);
            var actual = dependencyResolver.GetService<ICalculator>();
            Assert.AreSame(actual, expected);
        }
    }
}
