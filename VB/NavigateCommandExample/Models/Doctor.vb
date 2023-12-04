#Region "#usings"
Imports DevExpress.Mvvm.POCO

#End Region  ' #usings
Namespace SchedulerDragDropExample

    Public Class Doctor

        Public Shared Function Create() As Doctor
            Return ViewModelSource.Create(Function() New Doctor())
        End Function

        Public Shared Function Create(ByVal id As Integer, ByVal name As String) As Doctor
            Dim doctor As Doctor = Create()
            doctor.Id = id
            doctor.Name = name
            Return doctor
        End Function

        Protected Sub New()
        End Sub

        Public Overridable Property Id As Integer

        Public Overridable Property Name As String
    End Class
End Namespace
