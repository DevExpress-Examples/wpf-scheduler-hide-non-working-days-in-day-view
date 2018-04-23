#Region "#usings"
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Xpf.Scheduling
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
#End Region ' #usings

Namespace SchedulerDragDropExample
    <POCOViewModel> _
    Public Class MainViewModel
        Private Const DayViewVisibleDaysCount As Integer = 7
        Public Overridable Property Appointments() As ObservableCollection(Of MedicalAppointment)
        Public Overridable Property Doctors() As ObservableCollection(Of Doctor)
        Public Overridable Property PaymentStates() As ObservableCollection(Of PaymentState)
        Public Overridable Property SchedulerStart() As Date

        Protected Sub New()
            Doctors = New ObservableCollection(Of Doctor)()
            Appointments = New ObservableCollection(Of MedicalAppointment)()
            PaymentStates = New ObservableCollection(Of PaymentState)()

            SchedulerStart = Date.Today.Date

            CreateDoctors()
            CreateAppointments()
            CreatePaymentStates()
        End Sub

        Private Sub CreateAppointments()
            Dim rand As New Random(Date.Now.Millisecond)
            Appointments.Add(MedicalAppointment.Create(startTime:= Date.Now.Date.AddHours(10), endTime:= Date.Now.Date.AddHours(11.5), doctorId:= 1, paymentStateId:= 1, location:= "101", patientName:= "Dave Murrel", note:= "Take care", firstVisit:= True))
            Appointments.Add(MedicalAppointment.Create(startTime:= Date.Now.Date.AddDays(2).AddHours(15), endTime:= Date.Now.Date.AddDays(2).AddHours(16.5), doctorId:= 1, paymentStateId:= 1, location:= "101", patientName:= "Mike Roller", note:= "Schedule next visit soon", firstVisit:= True))

            Appointments.Add(MedicalAppointment.Create(startTime:= Date.Now.Date.AddDays(1).AddHours(11), endTime:= Date.Now.Date.AddDays(1).AddHours(12), doctorId:= 2, paymentStateId:= 1, location:= "103", patientName:= "Bert Parkins", note:= String.Empty, firstVisit:= True))
            Appointments.Add(MedicalAppointment.Create(startTime:= Date.Now.Date.AddDays(2).AddHours(10), endTime:= Date.Now.Date.AddDays(2).AddHours(12), doctorId:= 2, paymentStateId:= 0, location:= "103", patientName:= "Carl Lucas", note:= String.Empty, firstVisit:= False))

            Appointments.Add(MedicalAppointment.Create(startTime:= Date.Now.Date.AddHours(12), endTime:= Date.Now.Date.AddHours(13.5), doctorId:= 3, paymentStateId:= 1, location:= "104", patientName:= "Brad Barnes", note:= "Tests are necessary", firstVisit:= False))
            Appointments.Add(MedicalAppointment.Create(startTime:= Date.Now.Date.AddDays(1).AddHours(14), endTime:= Date.Now.Date.AddDays(1).AddHours(15), doctorId:= 3, paymentStateId:= 1, location:= "104", patientName:= "Richard Fisher", note:= String.Empty, firstVisit:= True))
        End Sub

        Private Sub CreateDoctors()
            Doctors.Add(Doctor.Create(id:= 1, name:= "Stomatologist"))
            Doctors.Add(Doctor.Create(id:= 2, name:= "Ophthalmologist"))
            Doctors.Add(Doctor.Create(id:= 3, name:= "Surgeon"))
        End Sub

        Private Sub CreatePaymentStates()
            PaymentStates.Add(PaymentState.Create(id:= 0, caption:= "Unpaid", color:= "Tomato"))
            PaymentStates.Add(PaymentState.Create(id:= 1, caption:= "Paid", color:= "LightGreen"))
        End Sub

        #Region "#MyMove"
        Public Sub MyMoveLeft(ByVal scheduler As SchedulerControl)
            MyMove(False, scheduler)
        End Sub
        Public Sub MyMoveRight(ByVal scheduler As SchedulerControl)
            MyMove(True, scheduler)
        End Sub
        Public Sub MyMove(ByVal forward As Boolean, ByVal scheduler As SchedulerControl)
            If SchedulerStart.Date = scheduler.Start.Date Then
                Return
            End If
            FixVisibleDays(forward, scheduler)
            SchedulerStart = scheduler.Start
        End Sub
        Private Sub FixVisibleDays(ByVal forward As Boolean, ByVal scheduler As SchedulerControl)
            Dim myView As DayView = TryCast(scheduler.ActiveView, DayView)
            Dim startDate As Date = scheduler.Start
            If myView IsNot Nothing Then
                Dim selection As DateTimeRange = scheduler.SelectedInterval
                startDate = CorrectDate(startDate, forward)
                Dim visibleDays As List(Of Date) = GetDays(startDate)
                ' Specify DayView's visible days 
                myView.Days = visibleDays
                scheduler.SelectedInterval = AdjustSelection(forward, selection)
            End If
        End Sub
        #End Region ' #MyMove

        Public Sub MyGoToDate(ByVal scheduler As SchedulerControl)
            scheduler.ShowGotoDateWindow(Date.Today)
            FixVisibleDays(True, scheduler)
            SchedulerStart = scheduler.Start
        End Sub

        Public Sub MyGoToToday(ByVal scheduler As SchedulerControl)
            Dim startDate As Date = Date.Today
            scheduler.Start = startDate
            FixVisibleDays(True, scheduler)
            SchedulerStart = scheduler.Start
        End Sub
        #Region "#OnVisibleIntervalsChanged"
        Public Sub OnVisibleIntervalsChanged(ByVal scheduler As SchedulerControl, ByVal args As VisibleIntervalsChangedEventArgs)
            If Not NeedCorrection(args.VisibleDates.ToList()) Then
                Return
            End If
            FixVisibleDays(True, scheduler)
        End Sub
        #End Region ' #OnVisibleIntervalsChanged
        Private Function AdjustSelection(ByVal forward As Boolean, ByVal selection As DateTimeRange) As DateTimeRange
            Dim dtStart As Date
            Dim dtEnd As Date

            Dim diff As TimeSpan = selection.End - selection.Start
            dtStart = CorrectDate(selection.Start, forward)
            dtEnd = dtStart.Add(diff)
            Return New DateTimeRange(dtStart, dtEnd)
        End Function

        Public Sub MyNavigateBackward(ByVal scheduler As SchedulerControl)
            Dim myView As DayView = TryCast(scheduler.ActiveView, DayView)
            If myView IsNot Nothing Then
                scheduler.Start = scheduler.Start.AddDays(-DayViewVisibleDaysCount)
                myView.Days = GetDays(scheduler.Start)
            Else
                scheduler.ActiveView.NavigateBackward()
            End If
        End Sub
        #Region "#MyNavigateForward"
        Public Sub MyNavigateForward(ByVal scheduler As SchedulerControl)
            Dim myView As DayView = TryCast(scheduler.ActiveView, DayView)
            If myView IsNot Nothing Then
                scheduler.Start = scheduler.Start.AddDays(DayViewVisibleDaysCount)
                ' Calculate a list of days to display, excluding non-working days.
                myView.Days = GetDays(scheduler.Start)
            Else
                scheduler.ActiveView.NavigateForward()
            End If
        End Sub
        #End Region ' #MyNavigateForward
        Private Function CorrectDate(ByVal day As Date, ByVal forward As Boolean) As Date
            Dim direction As Integer
            Select Case day.DayOfWeek
                Case DayOfWeek.Saturday
                    direction = If(forward, 2, -1)
                    day = day.AddDays((direction))
                Case DayOfWeek.Sunday
                    direction = If(forward, 1, -2)
                    day = day.AddDays(direction)
            End Select
            Return day
        End Function

        Private Function NeedCorrection(ByVal days As List(Of Date)) As Boolean
            If days.Any(Function(day) (day.DayOfWeek = DayOfWeek.Saturday OrElse day.DayOfWeek = DayOfWeek.Sunday)) Then
                Return True
            End If
            Return False
        End Function
        Public Function GetDays(ByVal startDate As Date) As List(Of Date)
            Dim list = New List(Of Date)()
            Dim i As Integer = 0
            Do While list.Count < DayViewVisibleDaysCount
                Dim day = startDate.AddDays(i)
                If day.DayOfWeek <> DayOfWeek.Saturday AndAlso day.DayOfWeek <> DayOfWeek.Sunday Then
                    list.Add(day)
                End If
                i += 1
            Loop
            Return list
        End Function
    End Class
End Namespace

