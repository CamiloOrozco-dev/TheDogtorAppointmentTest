using System.Threading.Channels;
using TheDogtorAppointment.Domain;
using TheDogtorAppointment.Test.Helpers;

namespace TheDogtorAppointment.Test.Packages.Domain
{
    public class ClientTest
    {
     

        [Fact]
        public void When_an_appointment_is_created_it_must_be_saved_in_the_users_calendar()
        {
            Client client = new Client("Peter");
            Appointment appointment = Appointment.Create(client, "2023-12-06 02:23:34"); 
            Assert.NotEmpty(client.Calendar);
        }

       

        [Fact]
        public void CreateAppointment()
        {

            var appointment = AppointmentFactory.CreateAppoinment("Andrew", "2023-05-16 09:40:34");
            Assert.NotNull(appointment);
        }



        [Fact]

        public void The_user_can_cancel_an_appointment()
        {
            Client client = new Client("Mary");
            Appointment appointment = Appointment.Create(client, "2023-12-06 02:23:34");

            client.Cancel(appointment, client);

            Assert.Equal(EStatus.Cancel, appointment.Status);
            

        }

        [Fact]

        public void The_user_can_assign_an_appointment_for_different_days ()
        {
            Client client = new Client("Peter");
            Appointment appointment = Appointment.Create(client, "2023-12-06 02:23:34");
            Appointment appointment2 = Appointment.Create(client, "2023-12-07 02:27:00");

            Assert.Contains(appointment, client.Calendar);
            Assert.Contains(appointment2, client.Calendar);

        }
        [Fact]

        public void The_user_cannot_schedule_two_appointments_for_the_same_day()
        {
           
            Client client = new Client("Tom");
            Appointment.Create(client, "2023-12-06 02:23:34");

            Assert.Throws<ArgumentException>(() =>
            {
                Appointment.Create(client, "2023-12-06 08:45:00");
            });


        }
    }
}