Public Class cItem

   Private _Text As String
   Private _Value As String
   Private _Status As String

   Private _ValueAux1 As String
   Private _ValueAux2 As String
   Private _ValueAux3 As String
   Private _ValueAux4 As String
   Private _ValueAux5 As String

   Public Sub New(ByVal pText As String, ByVal pValue As String)
      Me.Text = pText
      Me.Value = pValue
   End Sub

   Public Sub New(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String)
      Me.Text = pText
      Me.Value = pValue
      Me.Status = pStatus
   End Sub

   Public Sub New(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String, ByVal pValueAux1 As String)
      Me.Text = pText
      Me.Value = pValue
      Me.Status = pStatus
      Me.ValueAux1 = pValueAux1
   End Sub

   Public Sub New(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String, ByVal pValueAux1 As String, ByVal pValueAux2 As String)
      Me.Text = pText
      Me.Value = pValue
      Me.Status = pStatus
      Me.ValueAux1 = pValueAux1
      Me.ValueAux2 = pValueAux2
   End Sub

   Public Sub New(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String, ByVal pValueAux1 As String, ByVal pValueAux2 As String, ByVal pValueAux3 As String)
      Me.Text = pText
      Me.Value = pValue
      Me.Status = pStatus
      Me.ValueAux1 = pValueAux1
      Me.ValueAux2 = pValueAux2
      Me.ValueAux3 = pValueAux3
   End Sub

   Public Sub New(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String, ByVal pValueAux1 As String, ByVal pValueAux2 As String, ByVal pValueAux3 As String, ByVal pValueAux4 As String)
      Me.Text = pText
      Me.Value = pValue
      Me.Status = pStatus
      Me.ValueAux1 = pValueAux1
      Me.ValueAux2 = pValueAux2
      Me.ValueAux3 = pValueAux3
      Me.ValueAux4 = pValueAux4
   End Sub

   Public Sub New(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String, ByVal pValueAux1 As String, ByVal pValueAux2 As String, ByVal pValueAux3 As String, ByVal pValueAux4 As String, ByVal pValueAux5 As String)
      Me.Text = pText
      Me.Value = pValue
      Me.Status = pStatus
      Me.ValueAux1 = pValueAux1
      Me.ValueAux2 = pValueAux2
      Me.ValueAux3 = pValueAux3
      Me.ValueAux4 = pValueAux4
      Me.ValueAux5 = pValueAux5
   End Sub

#Region "Properties"

   Public Property Text() As String
      Get
         Return _Text
      End Get
      Set(ByVal Value As String)
         _Text = Value
      End Set
   End Property

   Public Property Value() As String
      Get
         Return _Value
      End Get
      Set(ByVal Value As String)
         _Value = Value
      End Set
   End Property

   Public Property Status() As String
      Get
         Return _Status
      End Get
      Set(ByVal Value As String)
         _Status = Value
      End Set
   End Property

   Public Property ValueAux1() As String
      Get
         Return _ValueAux1
      End Get
      Set(ByVal Value As String)
         _ValueAux1 = Value
      End Set
   End Property

   Public Property ValueAux2() As String
      Get
         Return _ValueAux2
      End Get
      Set(ByVal Value As String)
         _ValueAux2 = Value
      End Set
   End Property

   Public Property ValueAux3() As String
      Get
         Return _ValueAux3
      End Get
      Set(ByVal Value As String)
         _ValueAux3 = Value
      End Set
   End Property

   Public Property ValueAux4() As String
      Get
         Return _ValueAux4
      End Get
      Set(ByVal Value As String)
         _ValueAux4 = Value
      End Set
   End Property

   Public Property ValueAux5() As String
      Get
         Return _ValueAux5
      End Get
      Set(ByVal Value As String)
         _ValueAux5 = Value
      End Set
   End Property

#End Region

End Class
