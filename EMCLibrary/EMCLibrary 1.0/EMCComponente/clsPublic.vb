Imports System.Reflection
Imports System.Windows.Forms
Imports System.Web.UI
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Drawing
Imports System.Data
Imports System.Threading


Public Class cPublic

   Public Shared CultureLocal As New System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name)
   Public Shared CulturePrevious As System.Globalization.CultureInfo



   Public Shared Sub SetCulture_enUS()
      'salvando a cultura anterior
      CulturePrevious = New System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name)
      'setando a cultura para US-EN
      System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
   End Sub

   Public Shared Sub SetCulture_Local()
      'setando a cultura para a cultura local
      System.Threading.Thread.CurrentThread.CurrentCulture = CultureLocal
   End Sub

   Public Shared Sub SetCulture_ptBR()
      'setando a cultura para PT-BR
      System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("pt-BR")
   End Sub

   Public Shared Sub SetCulture_Previous()
      'setando a cultura para a cultura carregada anteriormente
      System.Threading.Thread.CurrentThread.CurrentCulture = CulturePrevious
   End Sub




   'formata a data para o padrão universal do banco de dados
   Public Shared Function USdata(ByVal pData As Date) As String
      'salva a cultura atual na memória
      Dim myCulture As New System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name)

      'mudando a cultura para (Inglês - Americano)
      System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

      'formatando a data (padrão americano)
      Dim sData As String = CType(Format(pData, "dd-MMM-yyyy"), String)

      'restaura a cultura atual (salva anteriormente na memória)
      System.Threading.Thread.CurrentThread.CurrentCulture = myCulture

      Return sData
   End Function
   Public Shared Function USdata(ByVal pData As String) As String
      'salva a cultura atual na memória
      Dim myCulture As New System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name)

      'setando a cultura para (Portugues)
      System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("pt-BR")

      'convertendo a data da
      Dim dData As Date = CDate(pData)

      'mudando a cultura para (Inglês - Americano)
      System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

      'formatando a data (padrão americano)
      Dim sData As String = CType(Format(dData, "dd-MMM-yyyy"), String)

      'restaura a cultura atual (salva anteriormente na memória)
      System.Threading.Thread.CurrentThread.CurrentCulture = myCulture

      Return sData
   End Function

   'formata o valor para o padrão Americano (utilizado pelos bancos de dados)
   Public Shared Function USvalor(ByVal pValor As String) As Double
      'se o valor possui ponto decimal
      If InStr(pValor, ",") > 0 Then
         'e o valor possui ponto milhar, retira os pontos (milhar) antes de converter
         pValor = Replace(pValor, ".", "")
      End If

      'formatando o valor (padrão americano) - "######0.00"
      Dim dValor As Double = Val(Replace(pValor, ",", "."))

      Return dValor
   End Function


End Class
