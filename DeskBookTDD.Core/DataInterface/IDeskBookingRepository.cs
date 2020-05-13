using DeskBookTDD.Core.Domain;

namespace DeskBookTDD.Core.DataInterface
{
    public interface IDeskBookingRepository
    {
        void Save(DeskBooking deskBooking);

    }
}