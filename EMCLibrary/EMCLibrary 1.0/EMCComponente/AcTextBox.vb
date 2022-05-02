Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Namespace EMCLibrary.AcActive

   <ToolboxBitmap(GetType(TextBox))> Public Class AcTextBox
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

      Public Enum eCharacterCasing
         Normal
         Upper
         Lower
         Special
      End Enum


      'definição de variáveis internas
      Private pTabEnter As eTabEnter = eTabEnter.TABouENTER
      Private pStyle As eStyle = eStyle.Text
      Private pMask As String = ""
      Private pText As String = ""
      Private pSelectText As Boolean = True
      Private pCharacterCasing As eCharacterCasing = eCharacterCasing.Normal

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
      Private pAcceptKey39 As Boolean = False

      Private bTextChanged As Boolean = True
      Friend WithEvents lblTexto As System.Windows.Forms.Label
      Friend WithEvents mnuTexto As System.Windows.Forms.ContextMenuStrip
      Friend WithEvents mnuCopiar As System.Windows.Forms.ToolStripMenuItem
      Private bInFocus As Boolean = False

      Public Shadows Event Enter(ByVal sender As Object, ByVal e As EventArgs)
      Public Shadows Event TextChanged(ByVal sender As Object, ByVal e As EventArgs)
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
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container()
         Me.TextBox1 = New System.Windows.Forms.TextBox()
         Me.Label1 = New System.Windows.Forms.Label()
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
         '
         'Label1
         '
         Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.Label1.AutoSize = True
         Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.Label1.Location = New System.Drawing.Point(0, 2)
         Me.Label1.Name = "Label1"
         Me.Label1.Size = New System.Drawing.Size(33, 13)
         Me.Label1.TabIndex = 0
         Me.Label1.Text = "Label"
         '
         'lblTexto
         '
         Me.lblTexto.AutoEllipsis = True
         Me.lblTexto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.lblTexto.ContextMenuStrip = Me.mnuTexto
         Me.lblTexto.Location = New System.Drawing.Point(0, 18)
         Me.lblTexto.Name = "lblTexto"
         Me.lblTexto.Size = New System.Drawing.Size(84, 20)
         Me.lblTexto.TabIndex = 2
         Me.lblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         Me.lblTexto.UseCompatibleTextRendering = True
         Me.lblTexto.Visible = False
         '
         'mnuTexto
         '
         Me.mnuTexto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCopiar})
         Me.mnuTexto.Name = "mnuTexto"
         Me.mnuTexto.Size = New System.Drawing.Size(153, 48)
         '
         'mnuCopiar
         '
         Me.mnuCopiar.Name = "mnuCopiar"
         Me.mnuCopiar.Size = New System.Drawing.Size(152, 22)
         Me.mnuCopiar.Text = "&Copiar"
         '
         'AcTextBox
         '
         Me.Controls.Add(Me.lblTexto)
         Me.Controls.Add(Me.Label1)
         Me.Controls.Add(Me.TextBox1)
         Me.Name = "AcTextBox"
         Me.Size = New System.Drawing.Size(86, 40)
         Me.mnuTexto.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

#Region "Properties"

      Public Property CharacterCasing() As eCharacterCasing
         Get
            Return pCharacterCasing
         End Get
         Set(ByVal Value As eCharacterCasing)
            pCharacterCasing = Value
            'alterando a propriedade do TextBox
            Select Case pCharacterCasing
               Case eCharacterCasing.Special 'se especial, considera como normal
                  TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
                  'converte o texto do TextBox para o novo padrão
                  DoMask()
               Case Else                     'se outro valor, atualiza o TextBox
                  TextBox1.CharacterCasing = pCharacterCasing
            End Select
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

      'define se o campo pode ser Editado
      <DescriptionAttribute("Indica se o campo pode ser editado")> _
      Public Property IsEditable() As Boolean
         Get
            Return pIsEditable
         End Get
         Set(ByVal Value As Boolean)
            pIsEditable = Value
            If Value = True Then TextBackcolor = Color.FromName("Window")
            Me.TabStop = Value
            Me.TextBox1.Enabled = pIsEditable
            If pIsEditable = False Then
               Me.TextBox1.Visible = False
               Me.lblTexto.Visible = True
            Else
               Me.TextBox1.Visible = True
               Me.lblTexto.Visible = False
            End If
         End Set
      End Property

      'define se o campo pode ser Nulo
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
      Public Property Mask() As String
         Get
            Return pMask
         End Get
         Set(ByVal Value As String)
            pMask = Value
            'formatando o texto
            DoMask()
         End Set
      End Property

      'define o tamanho do texto
      Public Property MaxLength() As Integer
         Get
            Return TextBox1.MaxLength
         End Get
         Set(ByVal Value As Integer)
            TextBox1.MaxLength = Value
         End Set
      End Property

      'define se o texto será multiline ou não
      Public Property Multiline() As Boolean
         Get
            Return TextBox1.Multiline
         End Get
         Set(ByVal Value As Boolean)
            TextBox1.Multiline = Value
            LabelAlign()
            'se mudou o multiline para False
            If TextBox1.Multiline = False Then
               'remove a scrollbar
               TextBox1.ScrollBars = ScrollBars.None
               TextBox1.Font = New Font(TextBox1.Font.FontFamily, 8.25)
               TextBox1.Height = 20
            Else
               'insere a scrollbar
               TextBox1.ScrollBars = ScrollBars.Both
               TextBox1.Font = New Font(TextBox1.Font.FontFamily, 8.25)
               TextBox1.Height = 20
            End If
            'redefine o tamanho do controle
            ControlSize()
         End Set
      End Property

      'define o caracter que será mostrado se o campo for protegido
      Public Property PasswordChar() As String
         Get
            Return TextBox1.PasswordChar
         End Get
         Set(ByVal Value As String)
            TextBox1.PasswordChar = Value
         End Set
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
            If bInFocus = True Then
               'não formata o texto
               TextBox1.Text = pText
            Else
               'formatando o texto
               DoMask()
            End If
            'simula a mudança de conteúdo do campo
            RaiseEvent TextChanged(Me, New EventArgs)
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

      'define se aceita o (') Apostofro
      Public Property AcceptKey39() As Boolean
         Get
            Return pAcceptKey39
         End Get
         Set(ByVal value As Boolean)
            pAcceptKey39 = value
         End Set
      End Property

      ''' <summary>
      ''' Posicao do cursor dentro da text
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Property SelectionStart As Integer
         Get
            Return TextBox1.SelectionStart
         End Get
         Set(ByVal value As Integer)
            TextBox1.SelectionStart = value
         End Set
      End Property

#End Region

#Region "Methods (Private)"

      Private Sub ControlSize()
         'se o controle tiver label
         If Label1.Text.Length > 0 Then
            'mostrando o label e reposicionando o texto
            Label1.Visible = True
            Label1.Top = 2
            TextBox1.Top = Label1.Top + Label1.Height + 3
            Me.lblTexto.Top = Me.TextBox1.Top
         Else 'se o controle nao tiver label
            'escondendo o label e reposicionando o texto
            Label1.Visible = False
            TextBox1.Top = 0
            Me.lblTexto.Top = Me.TextBox1.Top
         End If
         ControlResize(Me, New System.EventArgs)
      End Sub

      Private Sub ControlResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
         Me.Height = TextBox1.Top + TextBox1.Height + 2
      End Sub

      'seleciona todo o texto do controle (se necessário)
      Private Sub SubEnter(ByVal e As System.EventArgs)
         'salva o conteudo do texto para que se caso não estiver editavle, posso retirar a mascara
         TextBox1.Text = pText
         'se o campo não pode ser editado
         If Not pIsEditable Then
            'dispara o evento de entrada no componente
            RaiseEvent Enter(Me, e)
            'não seleciona o texto
            TextBox1.SelectionLength = 0
            TextBox1.SelectionStart = 0
            'simula um click no TAB para ir para o próximo objeto
            Try
               Windows.Forms.SendKeys.SendWait("{TAB}")
            Catch ex As Exception
            End Try
            Exit Sub
         End If

         'seleciona todo o texto
         If pSelectText = True Then TextBox1.SelectAll()
      End Sub

      'formata o texto (se necessário)
      Private Sub SubLeave(ByVal e As System.EventArgs)
         pText = TextBox1.Text
         'formatando o texto
         DoMask()
      End Sub

      'formatando o texto utilizando a máscara (propriedade Mask)
      Private Sub DoMask()
         If Not pMask Is Nothing Then
            'se houver máscara e o campo for numérico
            If pMask.Length > 0 And pStyle = eStyle.Number Then
               'salva a cultura atual na memória
               Dim myCulture As New System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name)
               'mudando a cultura
               cPublic.SetCulture_ptBR()
               'não permite que o campo sem máscara seja atualizado com a máscara
               bTextChanged = False
               'se campo em branco, assume como 0
               pText = IIf(pText = "", 0, pText)
               'se primeiro dígito for "." ou ",", acrescenta "0" antes
               pText = IIf(Mid(pText, 1, 1) = "." Or Mid(pText, 1, 1) = ",", "0" & pText, pText)
               'substitui a "vírgula" pelo "ponto decimal"
               pText = Replace(pText, ",", ".")
               'formatando o texto
               TextBox1.Text = MyFormat(pText, pMask)
               'volta a variável de atualização para o valor default
               bTextChanged = True
               'restaura a cultura atual (salva anteriormente na memória)
               System.Threading.Thread.CurrentThread.CurrentCulture = myCulture
               Exit Sub
            End If
         End If

         'se texto for Special Casing
         If pCharacterCasing = eCharacterCasing.Special Then
            pText = SpecialName(pText)
         End If

         'atualizando o textbox
         TextBox1.Text = pText
      End Sub

      'converte maiusculo/minusculo, deixando as primeiras letras como maiusculo
      Private Function SpecialName(ByVal Texto As String) As String
         Dim Palavra As String
         Dim PosInicial As Integer
         Dim PosFinal As Integer

         Dim Resultado As String = ""

         'se o texto estiver em branco, não precisa converter
         If Texto.Trim.Length = 0 Then
            Return Texto
            Exit Function
         End If

         PosInicial = 1
         Texto = LCase(Texto) & " "

         'convertendo o texto
         Do Until InStr(PosInicial, Texto, " ") = 0
            PosFinal = InStr(PosInicial, Texto, " ")
            Palavra = Mid(Texto, PosInicial, PosFinal - PosInicial)
            PosInicial = PosFinal + 1
            If Palavra <> "de" And Palavra <> "da" And Palavra <> "do" And _
               Palavra <> "das" And Palavra <> "dos" And Palavra <> "a" And Palavra <> "e" Then
               Palavra = UCase(Palavra.Substring(0, 1)) & LCase(Palavra.Substring(1))
            End If
            Resultado = Resultado & " " & Palavra
         Loop

         Return Resultado.Trim
      End Function

      'formatando o campo de acordo com a Máscara
      Private Function MyFormat(ByVal MyString As String, ByVal MyMascara As String) As String
         Dim iStr As Integer = 0
         Dim iMsc As Integer = 0
         Dim nLen As Integer = 0
         Dim StrAux As String = ""

         Dim qDecStr As Integer = 0
         Dim qDecMsc As Integer = 0

         'substitui o ponto decimal por vírgula
         MyString = Replace(MyString, ".", ",")

         'calculando a qtde de casas decimais
         qDecStr = IIf(InStr(1, MyString, ",") > 0, (MyString.Length - InStr(1, MyString, ",")), 0)
         qDecMsc = IIf(InStr(1, MyMascara, ",") > 0, (MyMascara.Length - InStr(1, MyMascara, ",")), 0)

         iStr = 1
         'retirando a edição (máscara) do campo
         While iStr <= MyString.Length
            'alterado para mostrar valores negativos
            'If InStr(1, "0123456789,", Mid(MyString, iStr, 1)) > 0 Then
            If InStr(1, "0123456789,-", Mid(MyString, iStr, 1)) > 0 Then
               StrAux &= Mid(MyString, iStr, 1)
            End If
            iStr = iStr + 1
         End While

         'atualiza a string (sem a máscara)
         MyString = StrAux
         StrAux = ""

         'definindo o tamanho do campo
         If MyString.Length > MyMascara.Length Then
            nLen = MyString.Length
         Else
            nLen = MyMascara.Length
         End If

         'se campo com decimais, sincroniza as casas decimais
         If qDecStr > 0 Or qDecMsc > 0 Then
            If qDecStr < qDecMsc Then
               'se não digitou separador decimal
               If InStr(1, MyString, ",") = 0 Then
                  MyString &= ","
                  'acrescenta zeros a direita até completar a máscara
                  MyString = MyString.PadRight(MyString.Length + qDecMsc, "0")
               Else
                  'acrescenta zeros a direita até completar a máscara
                  MyString = MyString.PadRight(MyString.Length + (qDecMsc - qDecStr), "0")
               End If
            End If
         End If

         'se digitou mais casas decimais que o permitido, corta-as
         If qDecStr > qDecMsc Then
            MyString = Mid(MyString, 1, MyString.Length - (qDecStr - qDecMsc))
            'se a mascara não tiver casa decimal, retira a virgula
            If qDecMsc = 0 Then MyString = Mid(MyString, 1, MyString.Length - 1)
         End If

         iMsc = MyMascara.Length
         iStr = MyString.Length
         'montando os dígitos até o fim da máscara
         While iMsc > 0
            'se houver dados na string
            If iStr > 0 Then
               'se caracteres especiais, troca-os pelos dígitos da string
               If Mid(MyMascara, iMsc, 1) = "0" Or Mid(MyMascara, iMsc, 1) = "#" Or Mid(MyMascara, iMsc, 1) = "," Then
                  StrAux = Mid(MyString, iStr, 1) & StrAux
                  iStr = iStr - 1
                  iMsc = iMsc - 1
                  'se
               Else
                  'verifica se o o campo a ser inserido ´eo sinal de NEGATIVO
                  If Mid(MyString, iStr, 1) = "-" Then
                     StrAux = Mid(MyString, iStr, 1) & StrAux
                     iStr = iStr - 1
                     iMsc = iMsc - 1
                  Else
                     StrAux = Mid(MyMascara, iMsc, 1) & StrAux
                     iMsc = iMsc - 1
                  End If
               End If
               'se não houver dados na string, continua lendo a máscara
            Else
               Select Case Mid(MyMascara, iMsc, 1)
                  Case "0" : StrAux = "0" & StrAux
                  Case "#" : StrAux = StrAux
                  Case "," : StrAux = StrAux
                  Case "."
                     If iMsc > 1 Then
                        If Mid(MyMascara, iMsc - 1, 1) = "0" Then
                           StrAux = Mid(MyMascara, iMsc, 1) & StrAux
                        Else
                           StrAux = StrAux
                        End If
                     Else
                        StrAux = StrAux
                     End If
                  Case Else : StrAux = Mid(MyMascara, iMsc, 1) & StrAux
               End Select
               iMsc = iMsc - 1
            End If
         End While

         Return StrAux
      End Function

      Private Function CaracterValido() As Boolean
         Dim mskInteiro As Integer = 0
         Dim mskDecimal As Integer = 0

         'se houver máscara
         If pMask.Length > 0 Then
            'se houver separador decimal na máscara
            If InStr(pMask, ",") > 0 Then
               'número de caracteres inteiros permitidos
               mskInteiro = InStr(Replace(pMask, ".", ""), ",") - 1
               'número de caracteres decimais permitidos
               mskDecimal = pMask.Length - InStr(pMask, ",")
               'se não houver separador decimal na máscara
            Else
               mskInteiro = Me.MaxLength
               mskDecimal = 0
            End If
            'se não houver máscara
         Else
            mskInteiro = Me.MaxLength
            mskDecimal = 0
         End If

         'definindo a posição atual do separador decimal
         Dim sepPosicao As Integer = InStr(TextBox1.Text, ".")
         If InStr(TextBox1.Text, ",") > sepPosicao Then sepPosicao = InStr(TextBox1.Text, ",")

         Dim digInteiro As Integer = 0
         Dim digDecimal As Integer = 0

         'calculando o número de caracteres digitados até o momento
         If sepPosicao = 0 Then
            'se não foi digitado o separador decimal
            digInteiro = TextBox1.Text.Length
            digDecimal = 0
         Else
            'se foi digitado o separador decimal
            digInteiro = sepPosicao - 1
            digDecimal = TextBox1.Text.Length - sepPosicao
         End If

         'se já foi digitado o separador decimal
         If sepPosicao > 0 Then
            'se digitando a parte decimal
            If TextBox1.SelectionStart >= sepPosicao Then
               'se digitou mais caracteres decimais que a máscara permite
               If digDecimal >= mskDecimal Then
                  'se o texto não estiver todo selecionado, bloqueia digitação
                  If Not TextBox1.Text.Length = TextBox1.SelectionLength Then
                     Return False
                  End If
               End If
               'se digitando a parte inteira
            Else
               'se digitou mais caracteres inteiros que a máscara permite
               If digInteiro >= mskInteiro Then
                  'se o texto não estiver todo selecionado, bloqueia digitação
                  If Not TextBox1.Text.Length = TextBox1.SelectionLength Then
                     Return False
                  End If
               End If
            End If
         Else
            'se digitou mais caracteres inteiros que a máscara permite
            If digInteiro >= mskInteiro Then
               'se o texto não estiver todo selecionado, bloqueia digitação
               If Not TextBox1.Text.Length = TextBox1.SelectionLength Then
                  Return False
               End If
            End If
         End If

         Return True
      End Function

      Private Sub LabelAlign()
         Select Case TextBox1.TextAlign
            Case HorizontalAlignment.Center
               If Me.Multiline = True Then
                  lblTexto.TextAlign = ContentAlignment.TopCenter
               Else
                  lblTexto.TextAlign = ContentAlignment.MiddleCenter
               End If
            Case HorizontalAlignment.Left
               If Me.Multiline = True Then
                  lblTexto.TextAlign = ContentAlignment.TopLeft
               Else
                  lblTexto.TextAlign = ContentAlignment.MiddleLeft
               End If
            Case HorizontalAlignment.Right
               If Me.Multiline = True Then
                  lblTexto.TextAlign = ContentAlignment.TopRight
               Else
                  lblTexto.TextAlign = ContentAlignment.MiddleRight
               End If
            Case Else
               If Me.Multiline = True Then
                  lblTexto.TextAlign = ContentAlignment.TopLeft
               Else
                  lblTexto.TextAlign = ContentAlignment.MiddleLeft
               End If
         End Select
      End Sub

#End Region

#Region "Events"

      Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
         ''se pressionada uma tecla de função, simula a saída do componente (para formatar os dados, se necessário)
         'If e.KeyValue >= Keys.F1 And e.KeyValue <= Keys.F24 Then
         '   'simula como se tivesse saído do componente
         '   SubLeave(e)
         'End If

         'dispara o evento do componente
         RaiseEvent KeyDown(sender, e)

         ''se pressionada uma tecla de função, simula a saída do componente (para formatar os dados, se necessário)
         'If e.KeyValue >= Keys.F1 And e.KeyValue <= Keys.F24 Then
         '   'volta o foco para o componente
         '   SubEnter(e)
         'End If
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

         'se o estilo do texto é Number
         If pStyle = eStyle.Number Then
            Select Case KeyAscii
               Case 3 'Ctrl + C
               Case 8            'dígitos de 0-9 e backspace não tem tratamento especial
               Case 48 To 57
                  'verifica se o caracter digita é válido
                  If CaracterValido() = False Then KeyAscii = 0
               Case 45           'sinal de menos (possui tratamento especial)
                  'se já existe o sinal de menos não permite digitar outro
                  If InStr(TextBox1.Text, "-") <> 0 Then KeyAscii = 0
                  'somente aceita o sinal de menos como primeiro caracter do texto
                  If TextBox1.SelectionStart <> 0 Then KeyAscii = 0
               Case 44, 46       'ponto decimal ou vírgula
                  'se não há máscara ou se a máscara não permite casas decimais
                  If InStr(pMask, ",") = 0 Then KeyAscii = 0
                  'se já existe o ponto decimal não permite digitar outro
                  If InStr(TextBox1.Text, ",") <> 0 Or InStr(TextBox1.Text, ".") Then
                     'se o texto não estiver todo selecionado, bloqueia digitação
                     If Not TextBox1.Text.Length = TextBox1.SelectionLength Then KeyAscii = 0
                  End If
               Case Else
                  'não permite digitar outro caracter qualquer
                  KeyAscii = 0
            End Select
            'se o estilo do texto não é Number
         Else
            'se pressionada a tecla (') Apóstrofo
            If KeyAscii = 39 AndAlso pAcceptKey39 = False Then KeyAscii = 0
         End If

         'se a tecla pressionada é inválida, omite-a
         If KeyAscii = 0 Then
            e.Handled = True
         Else
            e.Handled = False
         End If

         'dispara o event KeyPress
         RaiseEvent KeyPress(sender, e)
      End Sub

      'seleciona o texto (se necessário) do início até a posição do cursor
      Private Sub TextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseDown
         If pSelectText = True Then
            'se não for o botão direito, seleciona o texto
            If Not e.Button = Windows.Forms.MouseButtons.Right Then
               TextBox1.SelectAll()
            End If
         End If
      End Sub

      Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
         'atualiza a propriedade do componente (se necessário)
         If bTextChanged = True Then
            pText = TextBox1.Text
            'dispara o evento de alteração na propriedade Text do componente
            RaiseEvent TextChanged(sender, e)
         End If
         lblTexto.Text = TextBox1.Text
      End Sub

      'seleciona todo o texto do controle (se necessário)
      Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
         bInFocus = True

         SubEnter(e)

         'dispara o evento de entrada no componente
         RaiseEvent Enter(Me, e)
      End Sub

      'formata o texto (se necessário)
      Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
         bInFocus = False

         SubLeave(e)

         'dispara o evento de saída do componente
         RaiseEvent Leave(Me, e)
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

      Private Sub TextBox1_TextAlignChanged(sender As Object, e As System.EventArgs) Handles TextBox1.TextAlignChanged
         LabelAlign()
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