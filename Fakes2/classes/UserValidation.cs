using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakes2
{
    class UserValidation : IUserValidation //Class implements interface
    {
        public int validEntryRequest(int id)
        {
            return id;
        }
    }
}
