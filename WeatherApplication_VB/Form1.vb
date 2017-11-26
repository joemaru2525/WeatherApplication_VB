
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

        Dim announce As Integer = InStr(source, "yjSt yjw_note_h2")     '発表日時
        Dim adate1 As Integer = announce + 18
        Dim adate2 As Integer = InStr(adate1, source, "</p>")
        Dim length1 As Integer = adate2 - adate1
        Dim happyo As String = source.Substring(adate1, length1 - 1)
        Label2.Text = happyo

        Dim weatherdate As Integer = InStr(adate2, source, "<p class")  '日付
        Dim wdate1 As Integer = weatherdate + 15
        Dim wdate2 As Integer = InStr(wdate1, source, "</p>")
        Dim length2 As Integer = wdate2 - wdate1
        Dim wdate As String = source.Substring(wdate1, length2 - 1)
        Label3.Text = wdate

        Dim weather As Integer = InStr(wdate2, source, "alt=")          '天気
        Dim weather1 As Integer = InStr(weather, source, ">")
        Dim weather2 As Integer = InStr(weather1, source, "</p>")
        Dim length3 As Integer = weather2 - weather1
        Dim wforcast As String = source.Substring(weather1, length3 - 1)
        Label4.Text = wforcast

        Dim hightemp As Integer = InStr(weather2, source, "<em>")       '最高気温
        Dim hightemp1 As Integer = hightemp + 3
        Dim hightemp2 As Integer = InStr(hightemp1, source, "</li>")
        Dim length4 As Integer = hightemp2 - hightemp1
        Dim hforcast As String = source.Substring(hightemp1, length4 - 1)
        Label5.Text = "最高気温：　" + hforcast.Replace("</em>", "")

        Dim lowtemp As Integer = InStr(hightemp2, source, "<em>")       '最低気温
        Dim lowtemp1 As Integer = lowtemp + 3
        Dim lowtemp2 As Integer = InStr(lowtemp1, source, "</li>")
        Dim length5 As Integer = lowtemp2 - lowtemp1 - 1
        Dim lforcast As String = source.Substring(lowtemp1, length5)
        Label6.Text = "最低気温：　" + lforcast.Replace("</em>", "")

        Dim pic As Integer = InStr(wdate2, source, "img src=")          '天気画像(75px x 41px)
        Dim pic1 As Integer = pic + 8
        Dim pic2 As Integer = InStr(pic1, source, "border=")
        Dim length6 As Integer = pic2 - pic1 - 3
        Dim picforcast As String = source.Substring(pic1, length6)
        PictureBox1.ImageLocation = picforcast

        Dim precip10 As Integer = InStr(lowtemp2, source, "降水")
        Dim precip11 As Integer = precip10 + 23
        Dim precip12 As Integer = InStr(precip11, source, "</td>")
        Dim length7 As Integer = precip12 - precip11 - 1
        Dim pforcast1 As String = source.Substring(precip11, length7)
        Label13.Text = pforcast1

        Dim precip20 As Integer = InStr(precip12, source, "<td>")
        Dim precip21 As Integer = precip20 + 3
        Dim precip22 As Integer = InStr(precip21, source, "</td>")
        Dim length8 As Integer = precip22 - precip21 - 1
        Dim pforcast2 As String = source.Substring(precip21, length8)
        Label14.Text = pforcast2

        Dim precip30 As Integer = InStr(precip22, source, "<td>")
        Dim precip31 As Integer = precip30 + 3
        Dim precip32 As Integer = InStr(precip31, source, "</td>")
        Dim length9 As Integer = precip32 - precip31 - 1
        Dim pforcast3 As String = source.Substring(precip31, length9)
        Label15.Text = pforcast3

        Dim precip40 As Integer = InStr(precip32, source, "<td>")
        Dim precip41 As Integer = precip40 + 3
        Dim precip42 As Integer = InStr(precip41, source, "</td>")
        Dim length10 As Integer = precip42 - precip41 - 1
        Dim pforcast4 As String = source.Substring(precip41, length10)
        Label16.Text = pforcast4


        Console.WriteLine(precip30)
        Console.WriteLine(precip31)
        Console.WriteLine(precip32)
        Console.WriteLine(length9)
        Console.WriteLine(pforcast3)

    End Sub



    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class
