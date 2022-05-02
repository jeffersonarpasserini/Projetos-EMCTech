Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Namespace EMCLibrary.AcActive

   <ToolboxBitmap(GetType(DateTimePicker))> Public Class AcDataBox
      Inherits System.Windows.Forms.UserControl

      Public Enum eTabEnter
         TAB
         TABouENTER
      End Enum

      Public Enum eStyle
         Text
         Number
      End Enum

      Public Enum eAlign
         Left
         Right
         Center
      End Enum

      'definição de variáveis internas
      Private pTabEnter As eTabEnter = eTabEnter.TABouENTER
      Private pStyle As eStyle = eStyle.Text
      Private pMask As String = "0#/##/####"
      Private pText As String = ""
      Private pSelectText As Boolean = True
      Private pDateText As String = ""
      Private pDateValue As String = ""

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
      Friend WithEvents lblTexto As System.Windows.Forms.Label
      Friend WithEvents mnuTexto As System.Windows.Forms.ContextMenuStrip
      Friend WithEvents mnuCopiar As System.Windows.Forms.ToolStripMenuItem

      Private bInFocus As Boolean = False

      Public Shadows Event Enter(ByVal sender As Object, ByVal e As EventArgs)
      Public Shadows Event Leave(ByVal sender As Object, ByVal e As EventArgs)

      Public Shadows Event KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      Public Shadows Event KeyUP(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      Public Shadows Event KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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
      Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
      Friend WithEvents Label1 As System.Windows.Forms.Label

      'NOTE: The following procedure is required by the Windows Form Designer
      'It can be modified using the Windows Form Designer.  
      'Do not modify it using the code editor.
      Friend WithEvents Button1 As System.Windows.Forms.Button
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AcDataBox))
         Me.TextBox1 = New System.Windows.Forms.TextBox()
         Me.Label1 = New System.Windows.Forms.Label()
         Me.Button1 = New System.Windows.Forms.Button()
         Me.lblTexto = New System.Windows.Forms.Label()
         Me.mnuTexto = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me.mnuCopiar = New System.Windows.Forms.ToolStripMenuItem()
         Me.mnuTexto.SuspendLayout()
         Me.SuspendLayout()
         '
         'TextBox1
         '
         Me.TextBox1.AllowDrop = True
         Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
               Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.TextBox1.Location = New System.Drawing.Point(0, 18)
         Me.TextBox1.Name = "TextBox1"
         Me.TextBox1.Size = New System.Drawing.Size(84, 20)
         Me.TextBox1.TabIndex = 1
         Me.TextBox1.Text = "TextBox1"
         Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
         'Button1
         '
         Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
         Me.Button1.Location = New System.Drawing.Point(84, 18)
         Me.Button1.Name = "Button1"
         Me.Button1.Size = New System.Drawing.Size(20, 20)
         Me.Button1.TabIndex = 2
         Me.Button1.TabStop = False
         '
         'lblTexto
         '
         Me.lblTexto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.lblTexto.ContextMenuStrip = Me.mnuTexto
         Me.lblTexto.Location = New System.Drawing.Point(0, 18)
         Me.lblTexto.Name = "lblTexto"
         Me.lblTexto.Size = New System.Drawing.Size(84, 20)
         Me.lblTexto.TabIndex = 3
         Me.lblTexto.Text = "Label2"
         Me.lblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         Me.lblTexto.UseCompatibleTextRendering = True
         Me.lblTexto.Visible = False
         '
         'mnuTexto
         '
         Me.mnuTexto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCopiar})
         Me.mnuTexto.Name = "mnuTexto"
         Me.mnuTexto.Size = New System.Drawing.Size(110, 26)
         '
         'mnuCopiar
         '
         Me.mnuCopiar.Name = "mnuCopiar"
         Me.mnuCopiar.Size = New System.Drawing.Size(109, 22)
         Me.mnuCopiar.Text = "&Copiar"
         '
         'AcDataBox
         '
         Me.Controls.Add(Me.lblTexto)
         Me.Controls.Add(Me.Button1)
         Me.Controls.Add(Me.Label1)
         Me.Controls.Add(Me.TextBox1)
         Me.Name = "AcDataBox"
         Me.Size = New System.Drawing.Size(104, 40)
         Me.mnuTexto.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

#Region "Properties"

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

      'define o valor a ser gravado no Banco de Dados (formato DD-MM-YYYY)
      <DescriptionAttribute("Retorna a data no formado DD/MM/YYYY")> _
      Public ReadOnly Property DateText() As String
         Get
            Return pDateText
         End Get
      End Property

      'define o valor a ser gravado no Banco de Dados (formato DD-MMM-YYYY)
      <DescriptionAttribute("Retorna a data no formado DD-MMM-YYYY")> _
      Public ReadOnly Property DateValue() As String
         Get
            Return pDateValue
         End Get
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
            pIsEditable = Value
            Me.TabStop = Value
            Me.Button1.Enabled = Value
            If pIsEditable = False Then
               Me.TextBox1.Visible = False
               Me.lblTexto.Visible = True
            Else
               Me.TextBox1.Visible = True
               Me.lblTexto.Visible = False
            End If
         End Set
      End Property

      'define se o campo pode ser nulo
      <CategoryAttribute("Data"), DescriptionAttribute("Indica se o campo pode ser Nulo")> _
      Public Property IsNullable() As Boolean
         Get
            Return pIsNullable
         End Get
         Set(ByVal Value As Boolean)
            pIsNullable = Value
         End Set
      End Property

      'define se o campo faz parte da PrimaryKey da Tabela
      <CategoryAttribute("Data"), DescriptionAttribute("Indica se o campo faz parte da PrimaryKey da Tabela")> _
      Public Property IsPrimaryKey() As Boolean
         Get
            Return pIsPrimaryKey
         End Get
         Set(ByVal Value As Boolean)
            pIsPrimaryKey = Value
         End Set
      End Property

      'define se o campo é de preenchimento obrigatório
      <DescriptionAttribute("Indica se o campo é obrigatório")> _
      Public Property IsRequired() As Boolean
         Get
            Return pIsRequired
         End Get
         Set(ByVal Value As Boolean)
            pIsRequired = Value
         End Set
      End Property

      'define a cor do label (Backcolor)
      <CategoryAttribute("LabelProperties")> _
      Public Property LabelBackcolor() As Color
         Get
            Return Label1.BackColor
         End Get
         Set(ByVal Value As Color)
            Label1.BackColor = Value
         End Set
      End Property

      'define a fonte do label
      <CategoryAttribute("LabelProperties")> _
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
      <CategoryAttribute("LabelProperties")> _
      Public Property LabelForecolor() As Color
         Get
            Return Label1.ForeColor
         End Get
         Set(ByVal Value As Color)
            Label1.ForeColor = Value
         End Set
      End Property

      'define o label do TextBox
      <CategoryAttribute("LabelProperties")> _
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

      'define a máscara do texto
      Public ReadOnly Property Mask() As String
         Get
            Return pMask
         End Get
      End Property

      'define se seleciona o texto ao receber o foco
      <CategoryAttribute("TextProperties")> _
      Public Property SelectText() As Boolean
         Get
            Return pSelectText
         End Get
         Set(ByVal Value As Boolean)
            pSelectText = Value
         End Set
      End Property

      'define o estilo do TextBox
      <CategoryAttribute("TextProperties")> _
      Public Property Style() As eStyle
         Get
            Return pStyle
         End Get
         Set(ByVal Value As eStyle)
            pStyle = Value
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

      'define o texto
      <CategoryAttribute("TextProperties")> _
      Public Overrides Property Text() As String
         Get
            Return pText
         End Get
         Set(ByVal Value As String)
            pText = Value
            If bInFocus Then
               DoMask()
               Me.TextBox1.Text = pText
            Else
               DoMask()
            End If
         End Set
      End Property

      'define o alinhamento do texto
      <CategoryAttribute("TextProperties")> _
      Public Property TextAlign() As eAlign
         Get
            Return TextBox1.TextAlign
         End Get
         Set(ByVal Value As eAlign)
            TextBox1.TextAlign = Value
         End Set
      End Property

      'define a cor do text (Backcolor)
      <CategoryAttribute("TextProperties")> _
      Public Property TextBackcolor() As Color
         Get
            Return TextBox1.BackColor
         End Get
         Set(ByVal Value As Color)
            TextBox1.BackColor = Value
         End Set
      End Property

      'define a fonte do text
      <CategoryAttribute("TextProperties")> _
      Public Property TextFont() As Font
         Get
            Return TextBox1.Font
         End Get
         Set(ByVal Value As Font)
            TextBox1.Font = Value
            ControlSize()
         End Set
      End Property

      'define a cor do text (Forecolor)
      <CategoryAttribute("TextProperties")> _
      Public Property TextForecolor() As Color
         Get
            Return TextBox1.ForeColor
         End Get
         Set(ByVal Value As Color)
            TextBox1.ForeColor = Value
         End Set
      End Property

#End Region

#Region "Methods (Private)"

      Private Sub ControlSize()
         'se o controle tiver label
         If Me.Label1.Text.Length > 0 Then
            'mostrando o label e reposicionando o texto
            Me.Label1.Visible = True
            Me.Label1.Top = 2
            Me.TextBox1.Top = Me.Label1.Top + Me.Label1.Height + 3
            Me.Button1.Top = TextBox1.Top
            Me.lblTexto.Top = Me.TextBox1.Top
         Else 'se o controle nao tiver label
            'escondendo o label e reposicionando o texto
            Me.Label1.Visible = False
            Me.TextBox1.Top = 0
            Me.Button1.Top = Me.TextBox1.Top
            Me.lblTexto.Top = Me.TextBox1.Top
         End If
         Me.ControlResize(Me, New System.EventArgs)
      End Sub

      Private Sub ControlResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
         Me.Height = Me.TextBox1.Top + Me.TextBox1.Height + 2
      End Sub

      'seleciona todo o texto do controle (se necessário)
      Private Sub SubEnter(ByVal e As System.EventArgs)
         'se o campo não pode ser editado
         If Not pIsEditable = True Then
            'dispara o evento de entrada no componente
            RaiseEvent Enter(Me, e)
            'não seleciona o texto
            Me.TextBox1.SelectionLength = 0
            Me.TextBox1.SelectionStart = 0
            'simula um click no TAB para ir para o próximo objeto
            Try
               Windows.Forms.SendKeys.SendWait("{TAB}")
            Catch ex As Exception
            End Try
            Exit Sub
         End If
         '
         Me.TextBox1.Text = pText
         Me.TextBox1.SelectAll()
      End Sub

      'formata o texto (se necessário)
      Private Sub SubLeave(ByVal e As System.EventArgs)
         'se o campo não pode ser editado
         If Not pIsEditable = True Then
            'dispara o evento de entrada no componente
            RaiseEvent Enter(Me, e)
            'simula um click no TAB para ir para o próximo objeto
            Try
               Windows.Forms.SendKeys.SendWait("{TAB}")
            Catch ex As Exception
            End Try
            Exit Sub
         End If

         'se houver dados
         If Me.TextBox1.Text.Length > 0 Then
            'se digitado somente o dia (monta o mês e ano automaticamente)
            If Me.TextBox1.Text.Length < 3 Then
               Me.TextBox1.Text = Format(Val(Me.TextBox1.Text), "0#") & Format(Val(Date.Today.Month), "0#") & Format(Val(Date.Today.Year), "0###")
               'se digitado somente o dia e o mês (monta o ano automaticamente)
            ElseIf Me.TextBox1.Text.Length < 5 Then
               Me.TextBox1.Text = Format(Val(Me.TextBox1.Text), "0###") & Format(Val(Date.Today.Year), "0###")
               'se digitado dia, mês e ano com 2 dígitos finais (monta os primeiros 2 dígitos do ano)
            ElseIf Me.TextBox1.Text.Length < 7 Then
               Me.TextBox1.Text = Mid(Format(Val(Me.TextBox1.Text), "0#####"), 1, 4) & Mid(Format(Val(Date.Today.Year), "0###"), 1, 2) & Mid(Format(Val(Me.TextBox1.Text), "0#####"), 5, 2)
            End If
         End If

         Me.pText = TextBox1.Text
         'formatando o texto
         DoMask()

         'verificando se a data é válida
         If pText.Length > 0 AndAlso Not IsDate(Me.TextBox1.Text) AndAlso Not IsDate(Format(Me.TextBox1.Text, "dd/MM/yyyy")) Then
            MessageBox.Show(Me.Label1.Text & " inválida.", "Verificação de Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.Focus()
         End If
      End Sub

      'formatando o texto utilizando a máscara (propriedade Mask)
      Private Sub DoMask()
         'inicializa a propriedade de gravação no Banco de Dados
         pDateValue = ""
         'inicializa a propriedade de formatação
         pDateText = ""

         'se a data possui uma formatação
         If Not pMask Is Nothing Then
            'se houver máscara e o campo for numérico
            If pMask.Length > 0 AndAlso pText.Length > 0 Then
               Try
                  'formatando o texto
                  Me.TextBox1.Text = Format(Val(pText), pMask)
                  'montando a propriedade DateValue
                  If IsDate(cPublic.USdata(Me.TextBox1.Text)) Then
                     'salva a cultura atual na memória
                     Dim myCulture As New System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name)
                     'mudando a cultura para (Português - BR)
                     cPublic.SetCulture_ptBR()
                     'obtendo a data
                     Dim d As Date = CType(cPublic.USdata(Me.TextBox1.Text), Date)
                     'formatando a data como DD-MM-YYYY (Ex: 20-10-2002)
                     pDateText = CType(Format(d, "dd/MM/yyyy"), String)
                     'mudando a cultura para (English - US)
                     cPublic.SetCulture_enUS()
                     'formatando a data como DD-MMM-YYYY (Ex: 20-oct-2002)
                     pDateValue = CType(Format(d, "dd-MMM-yyyy"), String)
                     'mudando a cultura para (Português - BR)
                     System.Threading.Thread.CurrentThread.CurrentCulture = myCulture
                  End If
               Catch ex As Exception
                  pDateText = ""
                  pDateValue = ""
               End Try
               Exit Sub
            End If
         End If

         'atualizando o textbox
         Me.TextBox1.Text = pText
      End Sub

#End Region

#Region "Events"

      'se pressionada teclas especiais
      Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
         'se pressionado CTRL + D, retorna a data atual
         If e.Control AndAlso e.KeyValue = Keys.D Then
            Me.TextBox1.Text = Format(Date.Today.Day, "0#") & Format(Date.Today.Month, "0#") & Format(Date.Today.Year, "0###")
            'simula a saída do componente (para formatar os dados, se necessário)
            SubLeave(e)
            'volta o foco para o componente
            SubEnter(e)
         End If

         ''se pressionada uma tecla de função, simula a saída do componente (para formatar os dados, se necessário)
         'If e.KeyValue >= Keys.F1 And e.KeyValue <= Keys.F24 Then
         '   'simula a saída do componente (para formatar os dados, se necessário)
         '   SubLeave(e)
         '   'volta o foco para o componente
         '   SubEnter(e)
         'End If

         'se pressionada a tecla "-", subtrai um dia da data
         If e.KeyValue = Keys.Subtract Then
            'simula a saída do componente (para formatar os dados, se necessário)
            SubLeave(e)
            'se os dados digitados referem-se a uma data válida
            If IsDate(Me.TextBox1.Text) Then
               Me.TextBox1.Text = CType(Me.TextBox1.Text, Date).AddDays(-1)
               pText = Format(CType(Me.TextBox1.Text, Date).Day, "0#") & Format(CType(Me.TextBox1.Text, Date).Month, "0#") & Format(CType(Me.TextBox1.Text, Date).Year, "0###")
               'volta o foco para o componente
               SubEnter(e)
            End If
         End If

         'se pressionada a tecla "+", soma um dia da data
         If e.KeyValue = Keys.Add Then
            'simula a saída do componente (para formatar os dados, se necessário)
            SubLeave(e)
            'se os dados digitados referem-se a uma data válida
            If IsDate(Me.TextBox1.Text) Then
               Me.TextBox1.Text = CType(Me.TextBox1.Text, Date).AddDays(1)
               pText = Format(CType(Me.TextBox1.Text, Date).Day, "0#") & Format(CType(Me.TextBox1.Text, Date).Month, "0#") & Format(CType(Me.TextBox1.Text, Date).Year, "0###")
               'volta o foco para o componente
               SubEnter(e)
            End If
         End If

         RaiseEvent KeyDown(sender, e)
      End Sub

      Private Sub TextBox1_KeyUP(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
         RaiseEvent KeyUP(sender, e)
      End Sub

      'se pressionada a tecla ENTER
      Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
         Dim KeyAscii As Integer = Asc(e.KeyChar)

         'se pressionada a tecla ENTER
         If KeyAscii = Keys.Return Then
            'se a tecla ENTER avança para o próximo controle
            If pTabEnter = eTabEnter.TABouENTER Then
               Try
                  Windows.Forms.SendKeys.SendWait("{TAB}")
               Catch ex As Exception
               End Try
               'omite o beep
               e.Handled = True
               Exit Sub
            End If
         End If

         'aceita somente digitação de números
         Select Case KeyAscii
            Case 3 'Ctrl + C
            Case 48 To 57, 8  'dígitos de 0-9 e backspace não tem tratamento especial
            Case Else
               'não permite digitar outro caracter qualquer
               KeyAscii = 0
         End Select

         'se a tecla pressionada é inválida, omite-a
         If KeyAscii = 0 Then
            e.Handled = True
         Else
            e.Handled = False
         End If

         RaiseEvent KeyPress(sender, e)
      End Sub

      'seleciona o texto (se necessário) do início até a posição do cursor
      Private Sub TextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseDown
         If pSelectText = True Then
            'se não for o botão direito, seleciona o texto
            If Not e.Button = Windows.Forms.MouseButtons.Right Then
               'Dim i As Integer = TextBox1.SelectionStart
               Dim i As Integer = Me.TextBox1.Text.Length
               Me.TextBox1.SelectionStart = 0
               Me.TextBox1.SelectionLength = i
            End If
         End If
      End Sub

      'se pressionado o botão do calendário
      Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
         'simula a saída do campo para a formatação (se não estiver formatado)
         If Not IsDate(Me.TextBox1.Text) Then SubLeave(e)

         'criando o calendário
         Dim f As New frmCalendario(CType(IIf(IsDate(Me.TextBox1.Text), Me.TextBox1.Text, Date.Today), Date))
         'posicionando o calendário na tela
         If Me.Parent Is Me.ParentForm Then
            'se o controle pai é o próprio formulário pai
            f.Top = Me.Top + Me.ParentForm.Top + Me.Height + 64
            f.Left = Me.Left + Me.ParentForm.Left + 6
         Else
            'se o controle pai não é o formulário pai (está contido em 2 controles)
            f.Top = Me.Top + Me.ParentForm.Top + Me.Parent.Top + Me.Height + 64
            f.Left = Me.Left + Me.ParentForm.Left + Me.Parent.Left + 6
         End If

         'mostrando o calendário
         f.ShowDialog()

         'se foi selecionada uma data, atualiza o textbox
         If IsDate(f.DateValue) Then
            Me.TextBox1.Text = f.DateValue
            pText = Format(CType(Me.TextBox1.Text, Date).Day, "0#") & Format(CType(Me.TextBox1.Text, Date).Month, "0#") & Format(CType(Me.TextBox1.Text, Date).Year, "0###")
         End If

         'fecha o calendário
         f.Close()

         'simula a entrada no campo
         SubEnter(e)
         Me.TextBox1.Focus()
      End Sub

      'seleciona todo o texto do controle (se necessário)
      Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
         bInFocus = True

         'se o campo não pode ser editado
         If Not pIsEditable Then
            'dispara o evento de entrada no componente
            RaiseEvent Enter(Me, e)
            'não seleciona o texto
            Me.TextBox1.SelectionLength = 0
            Me.TextBox1.SelectionStart = 0
            'simula um click no TAB para ir para o próximo objeto
            Try
               Windows.Forms.SendKeys.SendWait("{TAB}")
            Catch ex As Exception
            End Try
            Exit Sub
         End If

         Me.TextBox1.Text = pText
         'seleciona todo o texto
         Me.TextBox1.SelectAll()
         'dispara o evento de entrada no componente
         RaiseEvent Enter(Me, e)
      End Sub

      'formata o texto (se necessário)
      Protected Overrides Sub OnLeave(ByVal e As EventArgs)
         bInFocus = False

         'se o campo não pode ser editado
         If Not pIsEditable Then
            'dispara o evento de entrada no componente
            RaiseEvent Enter(Me, e)
            'simula um click no TAB para ir para o próximo objeto
            Try
               Windows.Forms.SendKeys.SendWait("{TAB}")
            Catch ex As System.StackOverflowException
            End Try
            Exit Sub
         End If

         'se houver dados
         If Me.TextBox1.Text.Length > 0 Then
            'se digitado somente o dia (monta o mês e ano automaticamente)
            If Me.TextBox1.Text.Length < 3 Then
               Me.TextBox1.Text = Format(Val(Me.TextBox1.Text), "0#") & Format(Val(Date.Today.Month), "0#") & Format(Val(Date.Today.Year), "0###")
               'se digitado somente o dia e o mês (monta o ano automaticamente)
            ElseIf Me.TextBox1.Text.Length < 5 Then
               Me.TextBox1.Text = Format(Val(Me.TextBox1.Text), "0###") & Format(Val(Date.Today.Year), "0###")
               'se digitado dia, mês e ano com 2 dígitos finais (monta os primeiros 2 dígitos do ano)
            ElseIf Me.TextBox1.Text.Length < 7 Then
               Me.TextBox1.Text = Mid(Format(Val(Me.TextBox1.Text), "0#####"), 1, 4) & Mid(Format(Val(Date.Today.Year), "0###"), 1, 2) & Mid(Format(Val(Me.TextBox1.Text), "0#####"), 5, 2)
            End If
         End If
         pText = Me.TextBox1.Text
         'formatando o texto
         DoMask()
         'verificando se a data é válida
         If pText.Length > 0 AndAlso Not IsDate(Me.TextBox1.Text) AndAlso Not IsDate(Format(Me.TextBox1.Text, "dd/MM/yyyy")) Then
            MessageBox.Show(Me.Label1.Text & " inválida.", "Verificação de Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.Focus()
         End If
         'dispara o evento de saída do componente
         RaiseEvent Leave(Me, e)
      End Sub


      Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
         lblTexto.Text = TextBox1.Text
      End Sub

      Private Sub TextBox1_BackColorChanged(sender As Object, e As System.EventArgs) Handles TextBox1.BackColorChanged
         lblTexto.BackColor = TextBox1.BackColor
      End Sub

      Private Sub TextBox1_ForeColorChanged(sender As Object, e As System.EventArgs) Handles TextBox1.ForeColorChanged
         lblTexto.ForeColor = TextBox1.ForeColor
      End Sub

      Private Sub TextBox1_Resize(sender As Object, e As System.EventArgs) Handles TextBox1.Resize
         lblTexto.Top = TextBox1.Top
         lblTexto.Left = TextBox1.Left
         lblTexto.Width = TextBox1.Width
         lblTexto.Height = TextBox1.Height
      End Sub

      Private Sub TextBox1_FontChanged(sender As Object, e As System.EventArgs) Handles TextBox1.FontChanged
         lblTexto.Font = TextBox1.Font
      End Sub

      Private Sub TextBox1_ContextMenuStripChanged(sender As Object, e As System.EventArgs) Handles TextBox1.ContextMenuStripChanged
         lblTexto.ContextMenuStrip = TextBox1.ContextMenuStrip
      End Sub

      Private Sub TextBox1_SizeChanged(sender As Object, e As System.EventArgs) Handles TextBox1.SizeChanged
         lblTexto.Top = TextBox1.Top
         lblTexto.Left = TextBox1.Left
         lblTexto.Width = TextBox1.Width
         lblTexto.Height = TextBox1.Height
      End Sub

      Private Sub TextBox1_RightToLeftChanged(sender As Object, e As System.EventArgs) Handles TextBox1.RightToLeftChanged
         lblTexto.RightToLeft = TextBox1.RightToLeft
      End Sub

      Private Sub TextBox1_SystemColorsChanged(sender As Object, e As System.EventArgs) Handles TextBox1.SystemColorsChanged
         lblTexto.ForeColor = TextBox1.ForeColor
      End Sub

      Private Sub mnuCopiar_Click(sender As System.Object, e As System.EventArgs) Handles mnuCopiar.Click
         Clipboard.SetDataObject(lblTexto.Text, True)
      End Sub

#End Region

   End Class

End Namespace