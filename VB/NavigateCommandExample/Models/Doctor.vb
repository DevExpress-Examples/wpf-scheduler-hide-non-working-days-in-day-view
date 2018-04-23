#Region "#usings"
Imports DevExpress.Mvvm.POCO
Imports System
#End Region ' #usings

Namespace SchedulerDragDropExample
    Public Class Doctor
        Public Shared Function Create() As Doctor
            Return ViewModelSource.Create(Function() New Doctor())
        End Function
        Public Shared Function Create(ByVal id As Integer, ByVal name As String) As Doctor

            Dim doctor_Renamed As Doctor = SchedulerDragDropExample.Doctor.Create()
            doctor_Renamed.Id = id
            doctor_Renamed.Name = name
            Return doctor_Renamed
        End Function

        Protected Sub New()
        End Sub

        Public Overridable Property Id() As Integer
        Public Overridable Property Name() As String
    End Class
End Namespace

