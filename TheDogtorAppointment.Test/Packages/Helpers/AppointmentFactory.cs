using TheDogtorAppointment.Domain;

namespace TheDogtorAppointment.Test.Helpers
{
    public class AppointmentFactory
    {
        public static Appointment CreateAppoinment(string clientName, string dateTime)
        {
            var client = new Client(clientName);

            return Appointment.Create(client, dateTime);
        }
    }
}