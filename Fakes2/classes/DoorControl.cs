using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakes2.classes
{
    public class DoorControl
    {
        private IUserValidation _userValidation;
        private IAlarm _alarm;
        private IDoor _door;
        private IEntryNot _entryNot;
       

        public DoorControl(IUserValidation userValidation, IAlarm alarm, IDoor door, IEntryNot entryNot)
        {
            _userValidation = userValidation;
            _alarm = alarm;
            _door = door;
            _entryNot = entryNot;
        }

        void doorClosed()
        {
            Console.WriteLine("The door is closed");
        }

        void doorOpen()
        {
            Console.WriteLine("The door is open");
        }

        void requestEntry(int id)
        {
            if (_userValidation.validEntryRequest(id) == 1)
            {
                doorOpen();
            }
            else if(_userValidation.validEntryRequest(id) == 0)
            {
                doorClosed();
                _alarm.raiseAlarm();
            }
        }
    }

}
