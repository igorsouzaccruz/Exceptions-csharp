using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions_csharp.Entities.Exceptions;

namespace Exceptions_csharp.Entities
{
    internal class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation() { }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkIn >= checkOut)
            {
                throw new DomainException("Check-out date must be after Check-in");
            }

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            if (checkIn < now || checkOut < now)
            {
                throw new DomainException("Reservation dates for update must be future dates");
            }
            if (checkIn >= checkOut)
            {
                throw new DomainException("Check-out date must be after Check-in");
            }
            CheckOut = checkOut;
            CheckIn = checkIn;
        }

        public override string ToString()
        {
            return "Room "
                + RoomNumber
                + ", checkIn: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", checkOut: "
                + CheckOut.ToString("dd/MM/yyyy")
                + ", Duration: "
                + Duration()
                + " nights ";
        }
    }
}
