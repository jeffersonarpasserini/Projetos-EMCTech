Imports System.Windows.Forms

Public Class frmCalendario
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
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

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
   Friend WithEvents Button1 As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'MonthCalendar1
      '
      Me.MonthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.MonthCalendar1.Location = New System.Drawing.Point(0, 0)
      Me.MonthCalendar1.MaxSelectionCount = 1
      Me.MonthCalendar1.Name = "MonthCalendar1"
      Me.MonthCalendar1.TabIndex = 0
      '
      'Button1
      '
      Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Button1.BackColor = System.Drawing.Color.Navy
      Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Button1.ForeColor = System.Drawing.Color.White
      Me.Button1.Location = New System.Drawing.Point(0, 159)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(228, 20)
      Me.Button1.TabIndex = 1
      Me.Button1.Text = " [ESC]  Fechar "
      Me.Button1.UseVisualStyleBackColor = False
      '
      'frmCalendario
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.AutoSize = True
      Me.ClientSize = New System.Drawing.Size(226, 179)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.MonthCalendar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
      Me.Name = "frmCalendario"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.Text = "frmCalendario"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Public DateValue As Date = Date.Today

   Public Sub New(ByVal pDate As Date)
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'inicializa o calendário com a data recebida pelo parâmetro
      MonthCalendar1.SetDate(pDate)
   End Sub

#Region "Events"

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      OnDoubleClick(e)
   End Sub

   Private Sub MonthCalendar1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MonthCalendar1.DoubleClick
      OnDoubleClick(New System.EventArgs)
   End Sub

   Private Sub MonthCalendar1_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateSelected
      OnDoubleClick(e)
   End Sub

   Private Sub MonthCalendar1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MonthCalendar1.KeyDown
      'se pressionada a tecla ESC
      If e.KeyValue = Keys.Escape Then OnDoubleClick(e)
   End Sub

   Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)
      'retorna a data selecionada
      DateValue = MonthCalendar1.SelectionEnd
      'esconde o calendário
      Me.Hide()
   End Sub

   ''define a propriedade Height/Width do controle igual a do calendário
   'Private Sub ControlResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
   '   Me.Height = MonthCalendar1.Height + Button1.Height
   '   Me.Width = MonthCalendar1.Width
   'End Sub

#End Region

End Class
