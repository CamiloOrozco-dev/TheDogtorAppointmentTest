namespace TheDogtorAppointment.Domain
{
    public class Client
    {
        public string Name { get; }

        public List<Appointment> Calendar { get; } = new List<Appointment>();

        public Client(string name)
        {
            Name = name;
        }

        public List<Appointment> ShowCalendar() //This method would be better if I asked for a specific one.
        {
            return Calendar;
        }

        public void Cancel(Appointment appointment, Client client)
        {
            if (!Utility.ValidateCalendar(client, appointment.Datetime))

                throw new ArgumentException("Appointment not fount");

            appointment.Status = EStatus.Cancel;
        }
    }

    public static class Utility
    {
        public static bool ValidateCalendar(Client client, DateTime newDate) //Validate that the appointment in the client calendar.
        {
            return client.Calendar.Any(appointment => appointment.Datetime.Date == newDate.Date);
        }
    }
}