using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageBusWorkshop.Messages
{
    public class PersonNameChanged
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
