using System;
using DeskBookTDD.Core.Domain;

// ReSharper disable All

namespace DeskBookTDD.Core.Processor
{
    
    public class BookingProcessor
    {
        
        public BookingResult CreateBooking(BookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return new BookingResult
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date
            };
        }
    }
}