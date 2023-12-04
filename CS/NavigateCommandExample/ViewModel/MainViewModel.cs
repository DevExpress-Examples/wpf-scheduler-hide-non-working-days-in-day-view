using DevExpress.Mvvm;
using DevExpress.Xpf.Scheduling;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchedulerDragDropExample {
    public class MainViewModel : ViewModelBase {
        const int DayViewVisibleDaysCount = 7;
        public ObservableCollection<MedicalAppointment> Appointments { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<PaymentState> PaymentStates { get; set; }
        public DateTime SchedulerStart { get; set; }

        public MainViewModel() {
            Doctors = new ObservableCollection<Doctor>();
            Appointments = new ObservableCollection<MedicalAppointment>();
            PaymentStates = new ObservableCollection<PaymentState>();

            SchedulerStart = DateTime.Today.Date;

            CreateDoctors();
            CreateAppointments();
            CreatePaymentStates();
        }

        private void CreateAppointments() {
            Random rand = new Random(DateTime.Now.Millisecond);
            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddHours(10), endTime: DateTime.Now.Date.AddHours(11.5), doctorId: 1, paymentStateId: 1, location: "101", patientName: "Dave Murrel", note: "Take care", firstVisit: true));
            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddDays(2).AddHours(15), endTime: DateTime.Now.Date.AddDays(2).AddHours(16.5), doctorId: 1, paymentStateId: 1, location: "101", patientName: "Mike Roller", note: "Schedule next visit soon", firstVisit: true));

            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddDays(1).AddHours(11), endTime: DateTime.Now.Date.AddDays(1).AddHours(12), doctorId: 2, paymentStateId: 1, location: "103", patientName: "Bert Parkins", note: string.Empty, firstVisit: true));
            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddDays(2).AddHours(10), endTime: DateTime.Now.Date.AddDays(2).AddHours(12), doctorId: 2, paymentStateId: 0, location: "103", patientName: "Carl Lucas", note: string.Empty, firstVisit: false));

            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddHours(12), endTime: DateTime.Now.Date.AddHours(13.5), doctorId: 3, paymentStateId: 1, location: "104", patientName: "Brad Barnes", note: "Tests are necessary", firstVisit: false));
            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddDays(1).AddHours(14), endTime: DateTime.Now.Date.AddDays(1).AddHours(15), doctorId: 3, paymentStateId: 1, location: "104", patientName: "Richard Fisher", note: string.Empty, firstVisit: true));
        }

        private void CreateDoctors() {
            Doctors.Add(new Doctor(id: 1, name: "Stomatologist"));
            Doctors.Add(new Doctor(id: 2, name: "Ophthalmologist"));
            Doctors.Add(new Doctor(id: 3, name: "Surgeon"));
        }

        private void CreatePaymentStates() {
            PaymentStates.Add(new PaymentState(id: 0, caption: "Unpaid", color: "Tomato"));
            PaymentStates.Add(new PaymentState(id: 1, caption: "Paid", color: "LightGreen"));
        }

        #region #MyMove
        public void MyMoveLeft(SchedulerControl scheduler) {
            MyMove(false, scheduler);
        }
        public void MyMoveRight(SchedulerControl scheduler) {
            MyMove(true, scheduler);
        }
        public void MyMove(bool forward, SchedulerControl scheduler) {
            if (SchedulerStart.Date == scheduler.Start.Date) return;
            FixVisibleDays(forward, scheduler);
            SchedulerStart = scheduler.Start;
        }
        private void FixVisibleDays(bool forward, SchedulerControl scheduler) {
            DayView myView = scheduler.ActiveView as DayView;
            DateTime startDate = scheduler.Start;
            if (myView != null) {
                DateTimeRange selection = scheduler.SelectedInterval;
                startDate = CorrectDate(startDate, forward);
                List<DateTime> visibleDays = GetDays(startDate);
                // Specify DayView's visible days 
                myView.Days = visibleDays;
                scheduler.SelectedInterval = AdjustSelection(forward, selection);
            }
        }
        #endregion #MyMove

        public void MyGoToDate(SchedulerControl scheduler) {
            scheduler.ShowGotoDateWindow(DateTime.Today);
            FixVisibleDays(true, scheduler);
            SchedulerStart = scheduler.Start;
        }

        public void MyGoToToday(SchedulerControl scheduler) {
            DateTime startDate = DateTime.Today;
            scheduler.Start = startDate;
            FixVisibleDays(true, scheduler);
            SchedulerStart = scheduler.Start;
        }
        #region #OnVisibleIntervalsChanged
        public void OnVisibleIntervalsChanged(SchedulerControl scheduler, VisibleIntervalsChangedEventArgs args) {
            if (!NeedCorrection(args.VisibleDates.ToList())) return;
            FixVisibleDays(true, scheduler);
        }
        #endregion #OnVisibleIntervalsChanged
        private DateTimeRange AdjustSelection(bool forward, DateTimeRange selection) {
            DateTime dtStart;
            DateTime dtEnd;

            TimeSpan diff = selection.End - selection.Start;
            dtStart = CorrectDate(selection.Start, forward);
            dtEnd = dtStart + diff;
            return new DateTimeRange(dtStart, dtEnd);
        }

        public void MyNavigateBackward(SchedulerControl scheduler) {
            DayView myView = scheduler.ActiveView as DayView;
            if (myView != null) {
                scheduler.Start = scheduler.Start.AddDays(-DayViewVisibleDaysCount);
                myView.Days = GetDays(scheduler.Start);
            } else
                scheduler.ActiveView.NavigateBackward();
        }
        #region #MyNavigateForward
        public void MyNavigateForward(SchedulerControl scheduler) {
            DayView myView = scheduler.ActiveView as DayView;
            if (myView != null) {
                scheduler.Start = scheduler.Start.AddDays(DayViewVisibleDaysCount);
                // Calculate a list of days to display, excluding non-working days.
                myView.Days = GetDays(scheduler.Start);
            } else
                scheduler.ActiveView.NavigateForward();
        }
        #endregion #MyNavigateForward
        private DateTime CorrectDate(DateTime day, bool forward) {
            int direction;
            switch (day.DayOfWeek) {
                case DayOfWeek.Saturday:
                    direction = forward ? 2 : -1;
                    day = day.AddDays((direction));
                break;
                case DayOfWeek.Sunday:
                    direction = forward ? 1 : -2;
                    day = day.AddDays(direction);
                break;
            }
            return day;
        }

        private bool NeedCorrection(List<DateTime> days) {
            if (days.Any(day => (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)))
                return true;
            return false;
        }
        public List<DateTime> GetDays(DateTime startDate) {
            var list = new List<DateTime>();
            int i = 0;
            while (list.Count < DayViewVisibleDaysCount) {
                var day = startDate.AddDays(i);
                if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                    list.Add(day);
                i++;
            }
            return list;
        }
        public void InitDays(SchedulerControl scheduler) {
            DayView myView = scheduler.ActiveView as DayView;
            if (myView != null) {
                myView.Days = GetDays(scheduler.Start);
            }
        }
    }
}
