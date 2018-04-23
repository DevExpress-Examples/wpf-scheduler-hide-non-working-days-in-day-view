#region #usings
using DevExpress.Mvvm.POCO;
using System;
#endregion #usings

namespace SchedulerDragDropExample
{
    public class MedicalAppointment
    {
        public static MedicalAppointment Create()
        {
            return ViewModelSource.Create(() => new MedicalAppointment());
        }
        internal static MedicalAppointment Create(DateTime startTime, DateTime endTime, int doctorId, int paymentStateId, string location, string patientName, string note, bool firstVisit)
        {
            MedicalAppointment apt = MedicalAppointment.Create();
            apt.StartTime = startTime;
            apt.EndTime = endTime;
            apt.DoctorId = doctorId;
            apt.PaymentStateId = paymentStateId;
            apt.Note = note;
            apt.Location = location;
            apt.PatientName = patientName;
            apt.FirstVisit = firstVisit;
            return apt;
        }

        protected MedicalAppointment() { }
        public virtual int Id { get; set; }
        public virtual bool AllDay { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string PatientName { get; set; }
        public virtual string Note { get; set; }
        public virtual string Subject { get; set; }
        public virtual int PaymentStateId { get; set; }
        public virtual int IssueId { get; set; }
        public virtual int Type { get; set; }
        public virtual string Location { get; set; }
        public virtual string RecurrenceInfo { get; set; }
        public virtual string ReminderInfo { get; set; }
        public virtual int? DoctorId { get; set; }
        public virtual bool FirstVisit { get; set; }
    }
}

