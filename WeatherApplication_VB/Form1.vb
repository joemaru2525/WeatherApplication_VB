
Imports System
Imports System.IO
Imports System.Net
Imports System.Text


Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'ダウンロード元のURL
        Dim urlName As String = "https://weather.yahoo.co.jp/weather/jp/14/4610.html"
        'WebClientを作成
        Dim wc As New System.Net.WebClient()
        '文字コードを指定
        wc.Encoding = System.Text.Encoding.UTF8
        'データを文字列としてダウンロードする
        Dim source As String = wc.DownloadString(urlName)
        '後始末
        wc.Dispose()
        'ダウンロードしたデータを表示する
        Console.WriteLine(source)

        Dim wc2 As WebClient = New WebClient()
        Dim st As Stream = wc2.OpenRead("https://weather.yahoo.co.jp/weather/jp/14/4610.html")
        Dim enc As Encoding = Encoding.GetEncoding("utf-8")
        Dim sr As StreamReader = New StreamReader(st, enc)
        Dim html As String = sr.ReadToEnd()

        sr.Close()
        st.Close()

        'Console.WriteLine(html)

        'Dim weatherdate As String       '日付
        'Dim weather As String           '天気
        'Dim hightemp As String          '最高気温
        'Dim lowtemp As String           '最低気温
        'Dim precipitation As String     '降水確率

        Dim announce As Integer = InStr(source, "yjSt yjw_note_h2")  '発表日時
        Dim adate1 As Integer = announce + 18
        Dim adate2 As Integer = InStr(adate1, source, "</p>")
        Dim length1 As Integer = adate2 - adate1
        Dim happyo As String = source.Substring(adate1, length1 - 1)
        Label2.Text = happyo

        Dim weatherdate As Integer = InStr(adate2, source, "<p class")
        Dim wdate1 As Integer = weatherdate + 15
        Dim wdate2 As Integer = InStr(wdate1, source, "</p>")
        Dim length2 As Integer = wdate2 - wdate1
        Dim wdate As String = source.Substring(wdate1, length2 - 1)
        Label3.Text = wdate

        Dim weather As Integer = InStr(wdate2, source, "alt=")
        Dim weather1 As Integer = InStr(weather, source, ">")
        Dim weather2 As Integer = InStr(weather1, source, "</p>")
        Dim length3 As Integer = weather2 - weather1
        Dim wforcast As String = source.Substring(weather1, length3 - 1)
        Label4.Text = wforcast

        Dim hightemp As Integer = InStr(weather2, source, "<em>")
        Dim hightemp1 As Integer = hightemp + 3
        Dim hightemp2 As Integer = InStr(hightemp1, source, "</li>")
        Dim length4 As Integer = hightemp2 - hightemp1
        Dim hforcast As String = source.Substring(hightemp1, length4 - 1)
        Label5.Text = "最高気温：　" + hforcast.Replace("</em>", "")

        Dim lowtemp As Integer = InStr(hightemp2, source, "<em>")
        Dim lowtemp1 As Integer = lowtemp + 3
        Dim lowtemp2 As Integer = InStr(lowtemp1, source, "</li>")
        Dim length5 As Integer = lowtemp2 - lowtemp1
        Dim lforcast As String = source.Substring(lowtemp1, length5 - 1)
        Label6.Text = "最低気温：　" + lforcast.Replace("</em>", "")


        'lowtemp = InStr(announce, "low", source)
        'precipitation = InStr(announce, "precip", source)

        Console.WriteLine(lowtemp1)
        Console.WriteLine(lowtemp2)
        Console.WriteLine(length5)
        Console.WriteLine(lforcast)

    End Sub



End Class
