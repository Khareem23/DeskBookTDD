using System;
using DeskBookTDD.Core.Domain;
using DeskBookTDD.Core.Processor;
using Xunit;

// ReSharper disable All

namespace DeskBookTDD.Core.Tests.Processor
{
    public class BookingProcessorTests
    {
        public BookingProcessorTests()
        {
            _processor = new BookingProcessor();
            _request = new BookingRequest
            {
                FirstName = "Olayinka",
                LastName = "Khareem",
                Email = "kareem@gmail.com",
                Date = new DateTime(2020, 02, 25)
            };
        }

        private readonly BookingProcessor _processor;
        private readonly BookingRequest _request;

        [Fact]
        public void CreateBooking_ShouldReturnResultWithRequestValues()
        {
            // Arrange


            // Act
            BookingResult result = _processor.CreateBooking(_request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_request.FirstName, result.FirstName);
            Assert.Equal(_request.LastName, result.LastName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.Date, result.Date);
        }

        [Fact]
        public void CreateBooking_ShouldSaveBookingRequest()
        {
            _processor.CreateBooking(_request);
        }

        [Fact]
        public void CreateBooking_ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.CreateBooking(null));
            Assert.Equal("request", exception.ParamName);
        }
    }
}