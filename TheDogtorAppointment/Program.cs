using System;
using System.Globalization;
using TheDogtorAppointment.Domain;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Creating a client
            Client client = new Client("John");

            // Schedule an appointment
            Console.WriteLine("Scheduling an appointment...");
            Appointment appointment1 = Appointment.Create(client, "2023-12-10 14:30:00");
            Console.WriteLine("Appointment scheduled successfully.");

            // Trying to schedule another appointment on the same date --> failed
            Console.WriteLine("Trying to schedule another appointment on the same date...");
            Appointment appointment2 = Appointment.Create(client, "2023-12-10 15:00:00");

            // Cancel an appointment
            Console.WriteLine("Canceling the scheduled appointment...");
            client.Cancel(appointment1, client);
            Console.WriteLine("Appointment canceled.");

            // Show the client's calendar
            Console.WriteLine("Client's calendar:");
            var clientCalendar = client.ShowCalendar();
            foreach (var apt in clientCalendar)
            {
                Console.WriteLine($"Appointment for {apt.Datetime:yyyy-MM-dd HH:mm:ss}, Status: {apt.Status}");
            }

            // Show the general appointment schedule
            Console.WriteLine("General appointment schedule:");
            var generalSchedule = Appointment.ShowSchedule();
            foreach (var apt in generalSchedule)
            {
                Console.WriteLine($"Appointment for {apt.Datetime:yyyy-MM-dd HH:mm:ss}, Status: {apt.Status}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}