using System;

namespace SchedulerDragDropExample {
    public class MedicalAppointment {
        internal MedicalAppointment(DateTime startTime, DateTime endTime, int doctorId, int paymentStateId, string location, string patientName, string note, bool firstVisit) {
            StartTime = startTime;
            EndTime = endTime;
            DoctorId = doctorId;
            PaymentStateId = paymentStateId;
            Note = note;
            Location = location;
            PatientName = patientName;
            FirstVisit = firstVisit;
        }

        public int Id { get; set; }
        public bool AllDay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PatientName { get; set; }
        public string Note { get; set; }
        public string Subject { get; set; }
        public int PaymentStateId { get; set; }
        public int IssueId { get; set; }
        public int Type { get; set; }
        public string Location { get; set; }
        public string RecurrenceInfo { get; set; }
        public string ReminderInfo { get; set; }
        public int? DoctorId { get; set; }
        public bool FirstVisit { get; set; }
    }
}
