using System;
using DeskBookTDD.Core.DataInterface;
using DeskBookTDD.Core.Domain;
using DeskBookTDD.Core.Processor;
using Moq;
using Xunit;

// ReSharper disable All

namespace DeskBookTDD.Core.Tests.Processor
{
    public class BookingProcessorTests
    {
        private readonly BookingProcessor _processor;
        private readonly BookingRequest _request;
        private readonly Mock<IDeskBookingRepository> _deskBookingRepoMock;

        public BookingProcessorTests()
        {
          
            _request = new BookingRequest
            {
                FirstName = "Olayinka",
                LastName = "Khareem",
                Email = "kareem@gmail.com",
                Date = new DateTime(2020, 02, 25)
            };

            _deskBookingRepoMock = new Mock<IDeskBookingRepository>();
            _processor = new BookingProcessor(_deskBookingRepoMock.Object);
            
        }

       

        
        
        
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
            DeskBooking saveDeskBooking = null;
            
            _deskBookingRepoMock.Setup(x => x.Save(It.IsAny<DeskBooking>()))
                .Callback<DeskBooking>(deskBooking => { saveDeskBooking = deskBooking; });
            
               
            _processor.CreateBooking(_request);
            
            _deskBookingRepoMock.Verify(x=> x.Save(It.IsAny<DeskBooking>()),Times.Once);
            
            Assert.NotNull(saveDeskBooking);
            Assert.Equal(_request.FirstName, saveDeskBooking.FirstName);
            Assert.Equal(_request.LastName, saveDeskBooking.LastName);
            Assert.Equal(_request.Email, saveDeskBooking.Email);
            Assert.Equal(_request.Date, saveDeskBooking.Date);
         
            
        }

        [Fact]
        public void CreateBooking_ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.CreateBooking(null));
            Assert.Equal("request", exception.ParamName);
        }
    }
}