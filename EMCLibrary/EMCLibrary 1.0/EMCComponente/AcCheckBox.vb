Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Namespace EMCLibrary.AcActive

   <ToolboxBitmap(GetType(CheckBox))> Public Class AcCheckBox
      Inherits System.Windows.Forms.UserControl

      Public Enum eTabEnter
         TAB
         TABouENTER
      End Enum

      'definição de variáveis internas
      Private pTabEnter As eTabEnter = eTabEnter.TABouENTER

      Private pDataSource As String = ""
      Private pDataField As String = ""
      Private pDataFieldLog As String = ""
      Private pDataFieldNivel As String = ""

      Private pAutoErase As Boolean = True
      Private pAutoInsert As Boolean = True
      Private pAutoUpdate As Boolean = True
      Private pAutoSelect As Boolean = True

      Private pIsNullable As Boolean = True
      Private pIsPrimaryKey As Boolean = False
      Private pIsRequired As Boolean = False

      Private pValueChecked As String = "S"
      Private pValueUnchecked As String = "N"

      Public Shadows Event Enter(ByVal sender As Object, ByVal e As EventArgs)
      Public Shadows Event Leave(ByVal sender As Object, ByVal e As EventArgs)
      Public Shadows Event Click(ByVal sender As Object, ByVal e As EventArgs)

#Region " Windows Form Designer generated code "

      Public Sub New()
         MyBase.New()

         'This call is required by the Windows Form Designer.
         InitializeComponent()

         'Add any initialization after the InitializeComponent() call
      End Sub

      'UserControl1 overrides dispose to clean up the component list.
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not (components Is Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub

      'Required by the Windows Form Designer
      Private components As System.ComponentModel.IContainer
      Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

      'NOTE: The following procedure is required by the Windows Form Designer
      'It can be modified using the Windows Form Designer.  
      'Do not modify it using the code editor.
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.CheckBox1 = New System.Windows.Forms.CheckBox()
         Me.SuspendLayout()
         '
         'CheckBox1
         '
         Me.CheckBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                     Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.CheckBox1.Location = New System.Drawing.Point(0, 0)
         Me.CheckBox1.Name = "CheckBox1"
         Me.CheckBox1.Size = New System.Drawing.Size(138, 18)
         Me.CheckBox1.TabIndex = 0
         Me.CheckBox1.Text = "CheckBox1"
         '
         'AcCheckBox
         '
         Me.Controls.Add(Me.CheckBox1)
         Me.Name = "AcCheckBox"
         Me.Size = New System.Drawing.Size(140, 18)
         Me.ResumeLayout(False)

      End Sub

#End Region

#Region "Properties"

      'define se o campo está marcado ou não
      Public Property Checked() As Boolean
         Get
            Return CheckBox1.Checked
         End Get
         Set(ByVal Value As Boolean)
            CheckBox1.Checked = Value
            'simula um click no checkbox ao mudar o valor
            CheckBox1_Click(Me, New EventArgs)
         End Set
      End Property
      'define a que tabela o campo pertence
      <CategoryAttribute("Data"), DescriptionAttribute("Indica o nome da Tabela no Banco de Dados")> _
      Public Property DataSource() As String
         Get
            Return pDataSource
         End Get
         Set(ByVal Value As String)
            pDataSource = Value
         End Set
      End Property
      'define a que campo do Banco de Dados o objeto se refere
      <CategoryAttribute("Data"), DescriptionAttribute("Indica o nome da Coluna no Banco de Dados")> _
      Public Property DataField() As String
         Get
            Return pDataField
         End Get
         Set(ByVal Value As String)
            pDataField = Value
         End Set
      End Property
      'define uma descrição para o campo que será utilizada na montagem do Log
      <CategoryAttribute("Data"), DescriptionAttribute("Define uma descrição para o DataField que será utilizada na montagem do Log da Aplicação")> _
      Public Property DataFieldLog() As String
         Get
            Return pDataFieldLog
         End Get
         Set(ByVal Value As String)
            pDataFieldLog = Value
         End Set
      End Property
      'define o nível de importãncia do campo
      <CategoryAttribute("Data"), DescriptionAttribute("Define o nível de importância do DataField na Estrutura da Aplicação")> _
      Public Property DataFieldNivel() As String
         Get
            Return pDataFieldNivel
         End Get
         Set(ByVal Value As String)
            pDataFieldNivel = Value
         End Set
      End Property

      Public Property AutoErase() As Boolean
         Get
            Return pAutoErase
         End Get
         Set(ByVal Value As Boolean)
            pAutoErase = Value
         End Set
      End Property

      Public Property AutoInsert() As Boolean
         Get
            Return pAutoInsert
         End Get
         Set(ByVal Value As Boolean)
            pAutoInsert = Value
         End Set
      End Property

      Public Property AutoUpdate() As Boolean
         Get
            Return pAutoUpdate
         End Get
         Set(ByVal Value As Boolean)
            pAutoUpdate = Value
         End Set
      End Property

      Public Property AutoSelect() As Boolean
         Get
            Return pAutoSelect
         End Get
         Set(ByVal Value As Boolean)
            pAutoSelect = Value
         End Set
      End Property

      'define se o campo pode ser Nulo
      Public Property IsNullable() As Boolean
         Get
            Return pIsNullable
         End Get
         Set(ByVal Value As Boolean)
            pIsNullable = Value
         End Set
      End Property
      'define se o campo faz parte da PrimaryKey da Tabela
      Public Property IsPrimaryKey() As Boolean
         Get
            Return pIsPrimaryKey
         End Get
         Set(ByVal Value As Boolean)
            pIsPrimaryKey = Value
         End Set
      End Property
      'define se o campo é de preenchimento obrigatório
      Public Property IsRequired() As Boolean
         Get
            Return pIsRequired
         End Get
         Set(ByVal Value As Boolean)
            pIsRequired = Value
         End Set
      End Property

      'define o texto que aparecerá na Checkbox
      Public Property LabelText() As String
         Get
            Return CheckBox1.Text
         End Get
         Set(ByVal Value As String)
            CheckBox1.Text = Value
         End Set
      End Property

      'define se aceita a tecla ENTER como TAB
      Public Property TabEnter() As eTabEnter
         Get
            Return pTabEnter
         End Get
         Set(ByVal Value As eTabEnter)
            pTabEnter = Value
         End Set
      End Property

      ''define o tooltip do componente
      '<CategoryAttribute("TextProperties"), DescriptionAttribute("Determina a ajuda que deverá ser mostrada quando o mouse parar sobre o controle.")> _
      'Public Property ToolTip() As String
      '   Get
      '      Return Me.vToolTip.GetToolTip(Me.CheckBox1)
      '   End Get
      '   Set(ByVal Value As String)
      '      Me.vToolTip.SetToolTip(Me.CheckBox1, Value)
      '   End Set
      'End Property

      'define o valor quando marcado
      Public Property ValueChecked() As String
         Get
            Return pValueChecked
         End Get
         Set(ByVal Value As String)
            pValueChecked = Value
         End Set
      End Property

      'define o valor quando desmarcado
      Public Property ValueUnchecked() As String
         Get
            Return pValueUnchecked
         End Get
         Set(ByVal Value As String)
            pValueUnchecked = Value
         End Set
      End Property

#End Region

#Region "Methods"

      Private Sub ControlResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
         If Me.Height <> CheckBox1.Height Then
            Me.Height = CheckBox1.Height
         End If
      End Sub

#End Region

#Region "Events"

      'se pressionada a tecla ENTER
      Private Sub CheckBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckBox1.KeyDown
         If e.KeyCode = Keys.Return Then
            'se a tecla ENTER avança para o próximo controle
            If pTabEnter = eTabEnter.TABouENTER Then
               Windows.Forms.SendKeys.SendWait("{TAB}")
               Exit Sub
            End If
         End If
      End Sub

      Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
         'dispara o evento de entrada no componente
         RaiseEvent Enter(Me, e)
      End Sub

      Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
         'dispara o evento de saída do componente
         RaiseEvent Leave(Me, e)
      End Sub

      Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
         'dispara o evento de click no componente
         RaiseEvent Click(sender, e)
      End Sub

#End Region

   End Class

End Namespace