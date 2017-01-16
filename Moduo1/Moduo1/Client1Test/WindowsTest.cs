using Client1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client1Test
{
    [TestFixture, RequiresSTA]
    public class WindowsTest
    {
        [Test]
        public void MainWindowConstructorTest()
        {
            Assert.DoesNotThrow(() => new MainWindow());
        }
       /* [Test]
        public void AdminWindowConstructorTest()
        {
            Assert.DoesNotThrow(() => new AdminWindow());
        }*/
        [Test]
        public void EployeeWindowConstructorTest()
        {
            Assert.DoesNotThrow(() => new EmployeeWindow());
        }
        [Test]
        public void ScrumMasterConstructorTest()
        {
            Assert.DoesNotThrow(() => new ScrumMasterWindow());
        }
        [Test]
        public void AddUsersConstructorTest()
        {
            Assert.DoesNotThrow(() => new AddUsers());
        }
        [Test]
        public void ProductOwnerConstructorTest()
        {
            Assert.DoesNotThrow(() => new ProductOwnerWindow());
        }

      /*  [Test]
        public void HumanResourceConstructorTest()
        {
            Assert.DoesNotThrow(() => new HumanResourceWindow());
        }*/
        [Test]
        public void ChangePassConstructorTest()
        {
            Assert.DoesNotThrow(() => new ChangePassWindow());
        }

    }
}
