Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data

Namespace EMCLibrary.AcActive
   <ToolboxBitmap(GetType(ComboBox))> Public Class AcComboBox
      Inherits System.Windows.Forms.UserControl

#Region "Enumerators"

      Public Enum eTabEnter
         TAB
         TABouENTER
      End Enum

      Public Enum eDropDownStyle
         Simple
         DropDown
         DropDownList
      End Enum

#End Region

#Region "Variables - Private"

      Private pTabEnter As eTabEnter = eTabEnter.TABouENTER
      Private pSelectText As Boolean = True

      Private pDataSource As String = ""
      Private pDataField As String = ""
      Private pDataFieldLog As String = ""
      Private pDataFieldNivel As String = ""

      Private pAutoErase As Boolean = True
      Private pAutoInsert As Boolean = True
      Private pAutoUpdate As Boolean = True
      Private pAutoSelect As Boolean = True

      Private pIsEditable As Boolean = True
      Private pIsNullable As Boolean = True
      Private pIsPrimaryKey As Boolean = False
      Private pIsRequired As Boolean = False

      Private inFocus As Boolean = False

      Private OldStyle As eDropDownStyle
      Private OldIndex As Integer = -1
      Private pStatusInativo As String = ""
      Private pStatusCancelado As String = ""

#End Region

#Region "Events - Definitions"

      Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

      Public Shadows Event Click(ByVal sender As Object, ByVal e As System.EventArgs)
      Public Shadows Event Enter(ByVal sender As Object, ByVal e As EventArgs)
      Public Shadows Event Leave(ByVal sender As Object, ByVal e As EventArgs)

      Public Shadows Event KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      Public Shadows Event KeyUP(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      Public Shadows Event KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

#End Region

#Region " Windows Form Designer generated code "

      Public Sub New()
         MyBase.New()

         'This call is required by the Windows Form Designer.
         InitializeComponent()

         'Add any initialization after the InitializeComponent() call
         ComboBox1.DisplayMember = "Text"
         ComboBox1.ValueMember = "Value"

         OldStyle = Me.DropDownStyle
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
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Public WithEvents ComboBox1 As System.Windows.Forms.ComboBox

      'NOTE: The following procedure is required by the Windows Form Designer
      'It can be modified using the Windows Form Designer.  
      'Do not modify it using the code editor.
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.Label1 = New System.Windows.Forms.Label()
         Me.ComboBox1 = New System.Windows.Forms.ComboBox()
         Me.SuspendLayout()
         '
         'Label1
         '
         Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.Label1.AutoSize = True
         Me.Label1.Location = New System.Drawing.Point(0, 2)
         Me.Label1.Name = "Label1"
         Me.Label1.Size = New System.Drawing.Size(33, 13)
         Me.Label1.TabIndex = 0
         Me.Label1.Text = "Label"
         '
         'ComboBox1
         '
         Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
         Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
         Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.ComboBox1.Location = New System.Drawing.Point(0, 18)
         Me.ComboBox1.Name = "ComboBox1"
         Me.ComboBox1.Size = New System.Drawing.Size(83, 21)
         Me.ComboBox1.TabIndex = 1
         '
         'AcComboBox
         '
         Me.Controls.Add(Me.Label1)
         Me.Controls.Add(Me.ComboBox1)
         Me.Name = "AcComboBox"
         Me.Size = New System.Drawing.Size(86, 40)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

#Region "Properties"

      'retorna a qtde de itens da combobox
      Public ReadOnly Property Count() As Integer
         Get
            Return ComboBox1.Items.Count
         End Get
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
      <CategoryAttribute("Data"), DescriptionAttribute("Define o Nível de importância do DataField na Estrutura da Aplicação")> _
      Public Property DataFieldNivel() As String
         Get
            Return pDataFieldNivel
         End Get
         Set(ByVal Value As String)
            pDataFieldNivel = Value
         End Set
      End Property

      'define o estilo da ComboBox
      Public Property DropDownStyle() As eDropDownStyle
         Get
            Return ComboBox1.DropDownStyle
         End Get
         Set(ByVal Value As eDropDownStyle)
            ComboBox1.DropDownStyle = Value
            'se combo for dropdownlist, não permite AutoComplete
            If ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList Then
               ComboBox1.AutoCompleteMode = Windows.Forms.AutoCompleteMode.None
               ComboBox1.AutoCompleteSource = Windows.Forms.AutoCompleteSource.None
            Else
               ComboBox1.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
               ComboBox1.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
            End If
            'salva o style da combobox
            OldStyle = ComboBox1.DropDownStyle
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

      'define se o campo pode ser Editado
      Public Property IsEditable() As Boolean
         Get
            Return pIsEditable
         End Get
         Set(ByVal Value As Boolean)
            'se deixou de ser editável, muda cor de fundo
            If pIsEditable = True And Value = False Then
               TextBackcolor = Color.FromName("InactiveBorder")
               'salva o style da combobox
               OldStyle = ComboBox1.DropDownStyle
               'muda a combobox para o style dropdown
               ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
               ComboBox1.AutoCompleteMode = Windows.Forms.AutoCompleteMode.None
               ComboBox1.AutoCompleteSource = Windows.Forms.AutoCompleteSource.None
               'se passou a ser editável, muda cor de fundo
            ElseIf pIsEditable = False And Value = True Then
               TextBackcolor = Color.FromName("Window")
               'volta a combobox para o style original
               Me.DropDownStyle = OldStyle
            End If
            pIsEditable = Value
            Me.TabStop = Value
         End Set
      End Property

      'define se o campo pode ser nulo
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

      'define a cor do label (Backcolor)
      Public Property LabelBackcolor() As Color
         Get
            Return Label1.BackColor
         End Get
         Set(ByVal Value As Color)
            Label1.BackColor = Value
         End Set
      End Property

      'define a fonte do label
      Public Property LabelFont() As Font
         Get
            Return Label1.Font
         End Get
         Set(ByVal Value As Font)
            Label1.Font = Value
            ControlSize()
         End Set
      End Property

      'define a cor do label (Forecolor)
      Public Property LabelForecolor() As Color
         Get
            Return Label1.ForeColor
         End Get
         Set(ByVal Value As Color)
            Label1.ForeColor = Value
         End Set
      End Property

      'define o label do TextBox
      Public Property LabelText() As String
         Get
            Return Label1.Text
         End Get
         Set(ByVal Value As String)
            Label1.Text = Value
            'redimensiona o controle
            ControlSize()
         End Set
      End Property

      'define se seleciona o texto ao receber o foco
      Public Property SelectText() As Boolean
         Get
            Return pSelectText
         End Get
         Set(ByVal Value As Boolean)
            pSelectText = Value
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

      'define a cor do text (Backcolor)
      Public Property TextBackcolor() As Color
         Get
            Return ComboBox1.BackColor
         End Get
         Set(ByVal Value As Color)
            ComboBox1.BackColor = Value
         End Set
      End Property

      'define a fonte do text
      Public Property TextFont() As Font
         Get
            Return ComboBox1.Font
         End Get
         Set(ByVal Value As Font)
            ComboBox1.Font = Value
            ControlSize()
         End Set
      End Property

      'define a cor do text (Forecolor)
      Public Property TextForecolor() As Color
         Get
            Return ComboBox1.ForeColor
         End Get
         Set(ByVal Value As Color)
            ComboBox1.ForeColor = Value
         End Set
      End Property

      Public ReadOnly Property AutoCompleteMode() As System.Windows.Forms.AutoCompleteMode
         Get
            Return ComboBox1.AutoCompleteMode
         End Get
      End Property

      Public ReadOnly Property AutoCompleteSource() As System.Windows.Forms.AutoCompleteSource
         Get
            Return ComboBox1.AutoCompleteSource
         End Get
      End Property

      Public Property FormattingEnabled() As Boolean
         Get
            Return ComboBox1.FormattingEnabled
         End Get
         Set(ByVal value As Boolean)
            ComboBox1.FormattingEnabled = value
         End Set
      End Property

      'define e retorna o texto do item selecionado
      Public Overrides Property Text() As String
         Get
            Return Me.SelectedText
         End Get
         Set(ByVal Value As String)
            Me.SelectedText = Value
         End Set
      End Property

      'retorna o valor do item selecionado
      Public Property Value() As String
         Get
            Return Me.SelectedValue
         End Get
         Set(ByVal Value As String)
            Me.SelectedValue = Value
         End Set
      End Property

      ''' <summary>
      ''' retorna o Status do item selecionado
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public ReadOnly Property Status() As String
         Get
            'se não houver item selecionado, retorna vazio
            If ComboBox1.SelectedItem Is Nothing Then Return ""
            'retorna o valor do item selecionado
            If TypeOf ComboBox1.SelectedItem Is cItem Then
               Dim L As cItem = ComboBox1.SelectedItem
               Return L.Status
            Else
               Return ""
            End If
         End Get
      End Property

      ''' <summary>
      ''' retorna o Valor Auxiliar 1
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public ReadOnly Property ValueAux1() As String
         Get
            'se não houver item selecionado, retorna vazio
            If ComboBox1.SelectedItem Is Nothing Then Return ""
            'retorna o valor aux do item selecionado
            If TypeOf ComboBox1.SelectedItem Is cItem Then
               Return CType(ComboBox1.SelectedItem, cItem).ValueAux1
            Else
               Return ""
            End If
         End Get
      End Property

      ''' <summary>
      ''' retorna o Valor Auxiliar 2
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public ReadOnly Property ValueAux2() As String
         Get
            'se não houver item selecionado, retorna vazio
            If ComboBox1.SelectedItem Is Nothing Then Return ""
            'retorna o valor aux do item selecionado
            If TypeOf ComboBox1.SelectedItem Is cItem Then
               Return CType(ComboBox1.SelectedItem, cItem).ValueAux2
            Else
               Return ""
            End If
         End Get
      End Property

      ''' <summary>
      ''' retorna o Valor Auxiliar 3
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public ReadOnly Property ValueAux3() As String
         Get
            'se não houver item selecionado, retorna vazio
            If ComboBox1.SelectedItem Is Nothing Then Return ""
            'retorna o valor aux do item selecionado
            If TypeOf ComboBox1.SelectedItem Is cItem Then
               Return CType(ComboBox1.SelectedItem, cItem).ValueAux3
            Else
               Return ""
            End If
         End Get
      End Property

      ''' <summary>
      ''' retorna o Valor Auxiliar 4
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public ReadOnly Property ValueAux4() As String
         Get
            'se não houver item selecionado, retorna vazio
            If ComboBox1.SelectedItem Is Nothing Then Return ""
            'retorna o valor aux do item selecionado
            If TypeOf ComboBox1.SelectedItem Is cItem Then
               Return CType(ComboBox1.SelectedItem, cItem).ValueAux4
            Else
               Return ""
            End If
         End Get
      End Property

      ''' <summary>
      ''' retorna o Valor Auxiliar 5
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public ReadOnly Property ValueAux5() As String
         Get
            'se não houver item selecionado, retorna vazio
            If ComboBox1.SelectedItem Is Nothing Then Return ""
            'retorna o valor aux do item selecionado
            If TypeOf ComboBox1.SelectedItem Is cItem Then
               Return CType(ComboBox1.SelectedItem, cItem).ValueAux5
            Else
               Return ""
            End If
         End Get
      End Property

      Public ReadOnly Property Items() As ComboBox.ObjectCollection
         Get
            Items = ComboBox1.Items
         End Get
      End Property

      'define qual item foi ou deverá ser selecionado
      Public Property SelectedIndex() As Integer
         Get
            Return ComboBox1.SelectedIndex
         End Get
         Set(ByVal Value As Integer)
            ComboBox1.SelectedIndex = Value
         End Set
      End Property

      Public Property SelectedText() As String
         Get
            'se não houver item selecionado, retorna vazio
            If ComboBox1.SelectedItem Is Nothing Then Return ""
            'retorna o texto do item selecionado
            Dim L As Object = ComboBox1.SelectedItem
            Return L.Text
         End Get
         Set(ByVal value As String)
            ComboBox1.SelectedIndex = ComboBox1.FindStringExact(value)
         End Set
      End Property

      Public Property SelectedValue() As String
         Get
            'se não houver item selecionado, retorna vazio
            If ComboBox1.SelectedItem Is Nothing Then Return ""
            'retorna o valor do item selecionado
            Dim L As Object = ComboBox1.SelectedItem
            Return L.Value
         End Get
         Set(ByVal value As String)
            'lendo os itens da combo
            For i As Integer = 0 To ComboBox1.Items.Count - 1
               'se o valor do mesmo for igual passado
               If ComboBox1.Items(i).Value = value Then
                  ComboBox1.SelectedIndex = i
                  Exit Property
               End If
            Next
            'se não localizou o valor
            ComboBox1.SelectedIndex = -1
         End Set
      End Property

      ''' <summary>
      ''' Status Inativo para a Combo
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Property StatusInativo As String
         Get
            Return pStatusInativo
         End Get
         Set(ByVal value As String)
            pStatusInativo = value
         End Set
      End Property

      ''' <summary>
      ''' Status Cancelado para a Combo
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Property StatusCancelado As String
         Get
            Return pStatusCancelado
         End Get
         Set(ByVal value As String)
            pStatusCancelado = value
         End Set
      End Property

      ''' <summary>
      ''' Retorna se o item selecionado esta Inativo
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public ReadOnly Property IsInativo As Boolean
         Get
            Return (Me.pStatusInativo.Length > 0 AndAlso Me.pStatusInativo = Me.Status)
         End Get
      End Property

      ''' <summary>
      ''' Retorna se o item selecionado esta cancelado
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public ReadOnly Property IsCancelado As Boolean
         Get
            Return (Me.pStatusCancelado.Length > 0 AndAlso Me.pStatusCancelado = Me.Status)
         End Get
      End Property

#End Region

#Region "Methods"

      'limpando a combobox
      Public Sub Clear()
         ComboBox1.Text = ""
         ComboBox1.Items.Clear()
      End Sub

      'adicionando um item a lista
      Public Sub Add(ByVal pText As String, ByVal pValue As String)
         Me.Add(New cItem(pText, pValue))
      End Sub
      Public Sub Add(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String)
         Me.Add(New cItem(pText, pValue, pStatus))
      End Sub
      Public Sub Add(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String, ByVal pValueAux1 As String)
         Me.Add(New cItem(pText, pValue, pStatus, pValueAux1))
      End Sub
      Public Sub Add(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String, ByVal pValueAux1 As String, ByVal pValueAux2 As String)
         Me.Add(New cItem(pText, pValue, pStatus, pValueAux1, pValueAux2))
      End Sub
      Public Sub Add(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String, ByVal pValueAux1 As String, ByVal pValueAux2 As String, ByVal pValueAux3 As String)
         Me.Add(New cItem(pText, pValue, pStatus, pValueAux1, pValueAux2, pValueAux3))
      End Sub
      Public Sub Add(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String, ByVal pValueAux1 As String, ByVal pValueAux2 As String, ByVal pValueAux3 As String, ByVal pValueAux4 As String)
         Me.Add(New cItem(pText, pValue, pStatus, pValueAux1, pValueAux2, pValueAux3, pValueAux4))
      End Sub
      Public Sub Add(ByVal pText As String, ByVal pValue As String, ByVal pStatus As String, ByVal pValueAux1 As String, ByVal pValueAux2 As String, ByVal pValueAux3 As String, ByVal pValueAux4 As String, ByVal pValueAux5 As String)
         Me.Add(New cItem(pText, pValue, pStatus, pValueAux1, pValueAux2, pValueAux3, pValueAux4, pValueAux5))
      End Sub

      Private Sub Add(ByVal pItem As cItem)
         ComboBox1.Items.Add(pItem)
      End Sub

      'vinculando a combobox a uma tabela
      Public Sub Binding(ByVal Table As DataTable, ByVal DisplayMember As String, ByVal ValueMember As String)
         'inicializa as informações da combobox
         Me.Clear()
         'carregando os dados da tabela na combobox
         For Each dr As DataRow In Table.Rows
            Me.Add(dr.Item(DisplayMember), dr.Item(ValueMember))
         Next
      End Sub

      Private Sub ControlSize()
         'se o controle tiver label
         If Label1.Text.Length > 0 Then
            'mostrando o label e reposicionando o texto
            Label1.Visible = True
            Label1.Top = 2
            ComboBox1.Top = Label1.Top + Label1.Height + 3
         Else 'se o controle nao tiver label
            'escondendo o label e reposicionando o texto
            Label1.Visible = False
            ComboBox1.Top = 0
         End If
         ControlResize(Me, New System.EventArgs)
      End Sub

      Private Sub ControlResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
         Me.Height = ComboBox1.Top + ComboBox1.Height + 1
      End Sub

#End Region

#Region "Events"

      'se disparado o evento Click
      Private Sub ComboBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Click
         'dispara o evento Click do componente
         RaiseEvent Click(sender, e)
      End Sub

      Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
         'se pressionada a tecla ENTER
         If e.KeyCode = Keys.Return Then
            'se a tecla ENTER avança para o próximo controle
            If pTabEnter = eTabEnter.TABouENTER Then
               Windows.Forms.SendKeys.SendWait("{TAB}")
               'omite o beep
               e.Handled = True
            End If
         End If
         If Me.IsEditable = False Then Exit Sub
         RaiseEvent KeyDown(sender, e)
      End Sub

      Private Sub ComboBox1_KeyUP(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyUp
         If Me.IsEditable = False Then Exit Sub
         RaiseEvent KeyUP(sender, e)
      End Sub

      'se pressionada a tecla ENTER
      Private Sub ComboBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
         If Me.IsEditable = False Then Exit Sub
         RaiseEvent KeyPress(sender, e)
      End Sub

      'seleciona o texto (se necessário) do início até a posição do cursor
      Private Sub ComboBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox1.MouseDown
         If Me.IsEditable = False Then Exit Sub

         If pSelectText = True Then
            Dim i As Integer = ComboBox1.SelectionStart
            ComboBox1.SelectionStart = 0
            ComboBox1.SelectionLength = i
         End If
      End Sub

      'se mudou o item selecionado
      Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
         'se mudou o item e não permite edição, não muda o item selecionado
         If inFocus = True And Me.IsEditable = False Then
            'se mudou o item, volta ao conteúdo original
            If Me.SelectedIndex <> OldIndex Then Me.SelectedIndex = OldIndex
         Else
            RaiseEvent SelectedIndexChanged(sender, e)
         End If
      End Sub

      'seleciona todo o texto do controle (se necessário)
      Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
         'grava o item selecionado ao receber o foco
         OldIndex = Me.SelectedIndex

         inFocus = True
         'seleciona o texto
         If pSelectText = True Then ComboBox1.SelectAll()

         'dispara o evento de entrada no componente
         RaiseEvent Enter(Me, e)
      End Sub

      Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
         inFocus = False

         'dispara o evento de saída do componente
         RaiseEvent Leave(Me, e)
      End Sub

#End Region


   End Class

End Namespace