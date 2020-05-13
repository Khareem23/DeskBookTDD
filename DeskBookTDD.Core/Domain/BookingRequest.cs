using System;

namespace DeskBookTDD.Core.Domain
{
    public class BookingRequest
    {
        
            public string FirstName { get; set; }
            public string LastName { get; set; }
        
            public string Email { get; set; }
        
            public DateTime Date { get; set; }
        
    }
}