#Region "#usings"
Imports DevExpress.Mvvm.POCO
Imports System
#End Region ' #usings

Namespace SchedulerDragDropExample
    Public Class MedicalAppointment
        Public Shared Function Create() As MedicalAppointment
            Return ViewModelSource.Create(Function() New MedicalAppointment())
        End Function
        Friend Shared Function Create(ByVal startTime As Date, ByVal endTime As Date, ByVal doctorId As Integer, ByVal paymentStateId As Integer, ByVal location As String, ByVal patientName As String, ByVal note As String, ByVal firstVisit As Boolean) As MedicalAppointment
            Dim apt As MedicalAppointment = MedicalAppointment.Create()
            apt.StartTime = startTime
            apt.EndTime = endTime
            apt.DoctorId = doctorId
            apt.PaymentStateId = paymentStateId
            apt.Note = note
            apt.Location = location
            apt.PatientName = patientName
            apt.FirstVisit = firstVisit
            Return apt
        End Function

        Protected Sub New()
        End Sub
        Public Overridable Property Id() As Integer
        Public Overridable Property AllDay() As Boolean
        Public Overridable Property StartTime() As Date
        Public Overridable Property EndTime() As Date
        Public Overridable Property PatientName() As String
        Public Overridable Property Note() As String
        Public Overridable Property Subject() As String
        Public Overridable Property PaymentStateId() As Integer
        Public Overridable Property IssueId() As Integer
        Public Overridable Property Type() As Integer
        Public Overridable Property Location() As String
        Public Overridable Property RecurrenceInfo() As String
        Public Overridable Property ReminderInfo() As String
        Public Overridable Property DoctorId() As Integer?
        Public Overridable Property FirstVisit() As Boolean
    End Class
End Namespace

