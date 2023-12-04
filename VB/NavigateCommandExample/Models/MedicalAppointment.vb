Namespace SchedulerDragDropExample

    Public Class MedicalAppointment

        Friend Sub New(ByVal startTime As Date, ByVal endTime As Date, ByVal doctorId As Integer, ByVal paymentStateId As Integer, ByVal location As String, ByVal patientName As String, ByVal note As String, ByVal firstVisit As Boolean)
            Me.StartTime = startTime
            Me.EndTime = endTime
            Me.DoctorId = doctorId
            Me.PaymentStateId = paymentStateId
            Me.Note = note
            Me.Location = location
            Me.PatientName = patientName
            Me.FirstVisit = firstVisit
        End Sub

        Public Property Id As Integer

        Public Property AllDay As Boolean

        Public Property StartTime As Date

        Public Property EndTime As Date

        Public Property PatientName As String

        Public Property Note As String

        Public Property Subject As String

        Public Property PaymentStateId As Integer

        Public Property IssueId As Integer

        Public Property Type As Integer

        Public Property Location As String

        Public Property RecurrenceInfo As String

        Public Property ReminderInfo As String

        Public Property DoctorId As Integer?

        Public Property FirstVisit As Boolean
    End Class
End Namespace
