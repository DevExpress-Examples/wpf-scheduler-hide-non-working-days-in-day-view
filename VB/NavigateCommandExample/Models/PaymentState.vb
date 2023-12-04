Namespace SchedulerDragDropExample

    Public Class PaymentState

        Public Sub New(ByVal id As Integer, ByVal caption As String, ByVal color As String)
            Me.Id = id
            Me.Caption = caption
            Me.Color = color
        End Sub

        Public Property Id As Integer

        Public Property Caption As String

        Public Property Color As String
    End Class
End Namespace
