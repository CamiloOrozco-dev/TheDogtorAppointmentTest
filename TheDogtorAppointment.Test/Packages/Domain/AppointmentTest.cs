using TheDogtorAppointment.Domain;
using TheDogtorAppointment.Test.Helpers;

namespace TheDogtorAppointment.Test.Packages.Domain
{
    public class AppointmentTest
    {
      


        [Fact]

        public void The_dateformat_may_be_incorrectly_formatte()
        {
            Client client = new Client("Tom");
            Assert.Throws<ArgumentException>(() => new Appointment(client, "Not a dateTime"));
        }
        [Fact]

        public void When_creating_an_appointment_you_should_save_all_appointments_in_a_list()
        {
            var appointment = AppointmentFactory.CreateAppoinment("Camilo", "2023-10-31 02:23:34");

            Assert.NotNull(Appointment.ShowSchedule());
        }

       [Fact]
        public void Each_appointment_that_is_created_must_have_the_status_scheduled()
        {
            var appointment = AppointmentFactory.CreateAppoinment("Mathew", "2023-11-01 10:23:34");
        
            Assert.Equal(EStatus.Scheduled, appointment.Status);
        }
    }
}
