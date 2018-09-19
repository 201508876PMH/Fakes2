using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fakes2;
using NUnit.Framework;
using Fakes2.classes;
using NSubstitute;


namespace DoorControlTest
{
    [TestFixture]
    class Program
    {
        private DoorControl _uut;
        private IDoor _idoor;
        private IAlarm _alarm;
        private IEntryNot _entryNot;
        private IUserValidation _userValidation;

        [SetUp]
        public void SetUp()
        {
            /*
             * We dont create a mock of our DoorControl class, as it is the class from which we test from
             */
            //start by creating mocks of them
            _idoor = Substitute.For<IDoor>();
            _alarm = Substitute.For<IAlarm>();
            _entryNot = Substitute.For<IEntryNot>();
            _userValidation = Substitute.For<IUserValidation>();

            //Constructor injection
            _uut = new DoorControl(_userValidation, _alarm, _idoor, _entryNot);
            
        }

        [Test]
        public void runSelfTest_UserValidationFails()
        {
            _userValidation.validEntryRequest(1).Returns(0);
            Assert.Zero(_userValidation.validEntryRequest(0));
        }
    }
}
