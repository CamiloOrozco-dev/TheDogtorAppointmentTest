using System.Globalization;

namespace TheDogtorAppointment.Domain
{
    public class Appointment
    {
        public string Name { get; }
        public EStatus Status { get; set; }

        public DateTime Datetime { get; }

        public static List<Appointment> Schedule { get; } = new List<Appointment>();

        public Appointment(Client client, string userdate)
        {
            try
            {
                Name = client.Name;
                Datetime = DateTime.ParseExact(userdate, "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Failed to create an appointment");
            }

            Status = EStatus.Scheduled;
        }



        public static Appointment Create(Client client, string dateTime)
        {
            var appointment = new Appointment(client, dateTime);

            if (CompareDates(appointment.Datetime) && Utility.ValidateCalendar(client, appointment.Datetime))
            
                throw new ArgumentException("The Schedule is already full for this day ");
            

            Schedule.Add(appointment);
            client.Calendar.Add(appointment);
            return appointment;
        }

        public static List<Appointment> ShowSchedule()
        {
            return Schedule;
        }

        public static bool CompareDates(DateTime newDate) //Validate that the appointment is not scheduled in the general calendar.
        {
            return Schedule.Any(appointment => appointment.Datetime.Date == newDate.Date);
        }
    }

    public enum EStatus
    {
        Scheduled = 0,
        Cancel = 1,
        OnProcess = 2
    }
}