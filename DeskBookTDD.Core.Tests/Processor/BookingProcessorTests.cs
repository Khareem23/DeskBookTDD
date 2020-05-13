using System;
using DeskBookTDD.Core.Domain;
using DeskBookTDD.Core.Processor;
using Xunit;
// ReSharper disable All

namespace DeskBookTDD.Core.Tests.Processor
{
    public class BookingProcessorTests
    {
        private readonly BookingProcessor _processor;

        public BookingProcessorTests()
        {
             _processor = new BookingProcessor();
        }
        [Fact]
        public void   CreateBooking_ShouldReturnResultWithRequestValues()
        {
            // Arrange
            var request = new BookingRequest
            {
                FirstName = "Olayinka",
                LastName = "Khareem",
                Email = "kareem@gmail.com",
                Date = new DateTime(2020, 02, 25)
            };
            
            // Act
            BookingResult result = _processor.CreateBooking(request);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }

        [Fact]
        public  void CreateBooking_ShouldThrowExceptionIfRequestIsNull()
        {
            var exception =   Assert.Throws<ArgumentNullException>(()=> _processor.CreateBooking(null));
            Assert.Equal("request", exception.ParamName);
        }
    }
}