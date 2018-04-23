Imports DevExpress.Mvvm.POCO

Namespace SchedulerDragDropExample
    Public Class PaymentState
        Public Shared Function Create() As PaymentState
            Return ViewModelSource.Create(Function() New PaymentState())
        End Function
        Public Shared Function Create(ByVal id As Integer, ByVal caption As String, ByVal color As String) As PaymentState
            Dim psi As PaymentState = PaymentState.Create()
            psi.Id = id
            psi.Caption = caption
            psi.Color = color
            Return psi
        End Function

        Protected Sub New()
        End Sub

        Public Overridable Property Id() As Integer
        Public Overridable Property Caption() As String
        Public Overridable Property Color() As String
    End Class
End Namespace