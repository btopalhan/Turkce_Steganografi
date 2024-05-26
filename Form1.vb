Option Explicit On
Imports System
Imports System.IO
Public Class Form1
    Dim alfabe, bir As String
    Dim dz() As String
    Dim f, ta As Integer
    Dim ss As Integer = 0
    Dim ad As String
    Function BinToDec(ByVal BinValue As String) As Byte ' ikilikten 10luk sisteme cevirir
        Dim lngValue As Byte
        Dim x As Long
        Dim k As Long
        k = Len(BinValue)
        For x = k To 1 Step -1
            If Mid$(BinValue, x, 1) = "1" Then
                If k - x > 30 Then
                    lngValue = lngValue Or -2147483648.0#
                Else
                    lngValue = lngValue + 2 ^ (k - x)
                End If
            End If
        Next x
        BinToDec = lngValue
    End Function
    Public Function dec_bin(ByVal taban As Integer, ByVal sayi As Integer) As String ' onluktan iklik sisteme cevirir
        Do
            If sayi <> 0 Then
                dec_bin &= (sayi Mod taban).ToString
                sayi = sayi \ taban
            Else
                Return StrReverse(dec_bin)
            End If
        Loop
    End Function
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Form2.Hide()
        'alfabe tanımlıyoruz.
        alfabe = "®│ßø""’‘}|{zyxwvüutşsrqpöonmlkjiıhğgfedçcba`_^]\[ZYXWVÜUTŞSRQPÖONMLKJİIHĞGFEDÇCBA@?>=<;:9876543210/.-,+*)('&%$#!¶" + (Chr(13) + Chr(10)) + (Chr(32)) + "│"
        ReDim dz(alfabe.Length)
        For f = 0 To alfabe.Length - 1 'ikiliğe çevrilen sayıları 6 karaktere tamalıyoruz.
            bir = dec_bin(2, f)
            If bir.Length < 7 Then
                For ta = 1 To 7 - bir.Length
                    bir = "0" + bir
                Next
            End If
            dz(f) = bir
        Next f
        RichTextBox1.Text = "Lütfen Bir Metin Dosyası Açın Yada Yazı Yazın..."
        RichTextBox1.Select(0, RichTextBox1.Text.Length)
        SplashScreen1.Show()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ss = ss + 1
        OpenFileDialog1.Filter = "TXT DOSYALAR (*.txt)|*.txt|RTF DOSYALAR (*.rtf)|*.rtf"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
        If Not File.Exists(OpenFileDialog1.FileName) Then
            RichTextBox1.Text = OpenFileDialog1.FileName + " Dosyası Bulunamadı"
            Return
        End If
        Using sr As StreamReader = New StreamReader(OpenFileDialog1.FileName, System.Text.Encoding.GetEncoding(1254))
            RichTextBox1.Text = sr.ReadToEnd
            sr.Close()
        End Using
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        On Error Resume Next
        OpenFileDialog1.Filter = "JPEG RESİMLER (*.jpg)|*.jpg|BITMAP RESİMLER (*.bmp)|*.bmp|GIF RESİMLER (*.gif)|*.gif"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
        If Not File.Exists(OpenFileDialog1.FileName) Then
            RichTextBox1.Text = OpenFileDialog1.FileName + " Dosyası Bulunamadı"
            Return
        End If
        Dim resim As New Bitmap(OpenFileDialog1.FileName)
        PictureBox1.Image.Dispose()
        PictureBox1.Image = resim
        ad = OpenFileDialog1.FileName
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ss = 5
        On Error GoTo son
        'gelen veriyi şifreleyip gömme işlemine yarayan metod
        Dim keyal As String
tekrarkeyal:
        MsgBox("* Birazdan Gireceğiniz Veri, Veri Şifreleme İçin Anahtar olarak Kullanılacaktır." & (Chr(13) & Chr(10)) & "* Lütfen Girdiğiniz Anahtarı Büyük/Küçük Uyumlu Olarak Bir Yere Kaydedin." & (Chr(13) & Chr(10)) & "* Bu Anahtar Size Tekrar Sorulacaktır. Eğer Doğru Bir Şekilde Giremezseniz Gömülü Tüm Veriyi Kaydedeceksiniz.", MsgBoxStyle.Information, "Lütfen Dikkat")
        keyal = ""
        keyal = InputBox("Lütfen Anantar Veriyi Giriniz (Büyük/Küçük Harf Uyumuna Dikkat)", "Anahtar Veri giriş Ekranı", , , )
        If keyal = "" Then
            MsgBox("Geçersiz Uzunlukta Anahtar.", MsgBoxStyle.Critical, "Lütfen Dikkat")
            GoTo tekrarkeyal
        End If
        Dim sifrele As TripleDESileSifreleme = New TripleDESileSifreleme()
        Dim stegoverigirisi As String
        stegoverigirisi = ""
        Dim metin As String
        stegoverigirisi = sifrele.Encrypt(RichTextBox1.Text, sifrele.StrToByteArray(keyal))
        metin = stegoverigirisi
        metin = metin + "ø"
        Dim resim As New Bitmap(PictureBox1.Image)
        Dim renk, rnk As Color
        Dim ch As Char
        Dim r, g, b, koduz, yenir, yenig, yenib, okunan As String
        Dim i, en, boy, deger, son As Integer

        r = "" : g = "" : b = "" : koduz = "" : yenir = "" : yenig = "" : yenib = ""
        i = 0
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = metin.Length
        ProgressBar1.Value = 1
        ProgressBar1.Step = 1
        If resim.Width < resim.Height Then son = resim.Width - 1 Else son = resim.Height - 1
        For en = 0 To son
            For boy = 0 To son

                ch = metin(i)
                deger = alfabe.IndexOf(ch)
                okunan = dz(deger)
                renk = resim.GetPixel(en, boy)
                r = dec_bin(2, renk.R)
                g = dec_bin(2, renk.G)
                b = dec_bin(2, renk.B)
                If r.Length < 7 Then
                    For ta = 1 To 7 - r.Length
                        r = "0" + r
                    Next
                End If
                If g.Length < 7 Then
                    For ta = 1 To 7 - g.Length
                        g = "0" + g
                    Next
                End If
                If b.Length < 7 Then
                    For ta = 1 To 7 - b.Length
                        b = "0" + b
                    Next
                End If
                yenir = r.Substring(0, r.Length - 3) + okunan.Substring(0, 3)
                yenig = g.Substring(0, g.Length - 2) + okunan.Substring(3, 2)
                yenib = b.Substring(0, b.Length - 2) + okunan.Substring(5, 2)
                rnk = Color.FromArgb(255, BinToDec(yenir), BinToDec(yenig), BinToDec(yenib))
                resim.SetPixel(en, boy, rnk)
                i = i + 1
                If i = metin.Length Then GoTo devam
                ProgressBar1.PerformStep()
            Next boy
        Next en
devam:
        ad = ad.Insert(ad.Length - 4, "_1")
        resim.Save(ad)
        Dim yuzde As Double = ((i * 100) / (resim.Width * resim.Height))
        MsgBox("* Şifreleme Ve Kayıt Tamamlandı." & (Chr(13) & Chr(10)) & (Chr(13) & Chr(10)) & "Saklanan Karakter Sayısı :" + (i - 1).ToString + (Chr(13) + Chr(10)) + "Resim Boyutu:" + resim.Width.ToString + "X" + resim.Height.ToString + "," + (resim.Width * resim.Height).ToString + " Piksel " + (Chr(13) + Chr(10)) + (Chr(13) + Chr(10)) + "Saklama Yüzdesi :%" + yuzde.ToString, , "Bilgi")
        ProgressBar1.Value = 1
        Form2.PictureBox1.Image = New Bitmap(ad)
        Form2.Text = ad & "<--- Yazının Gömüldüğü Resim"
        Form2.Show()
son:    If Err.Description <> "" Then MsgBox(Err.Description + vbCrLf + "Kaynak : " + Err.Source, MsgBoxStyle.Critical, "Dikkat")

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ss = 3
        On Error GoTo son
        'verilen resmin içinden veriyi alıp şifresini çözen metod
        Dim keyalokumada As String
tekrarkeyal:
        MsgBox("* Birazdan Gireceğiniz Veri, Şifreli Veri Okuma İçin Anahtar olarak Kullanılacaktır." & (Chr(13) & Chr(10)) & "* Lütfen Girdiğiniz Anahtarı Büyük/Küçük Uyumlu Olarak Bir Yere Kaydedin." & (Chr(13) & Chr(10)) & "* Eğer Doğru Bir Şekilde Giremezseniz Gömülü Tüm Veriyi Kaydedeceksiniz.", MsgBoxStyle.Information, "Lütfen Dikkat")
        keyalokumada = ""
        keyalokumada = InputBox("Lütfen Anantar Veriyi Giriniz (Büyük/Küçük Harf Uyumuna Dikkat)", "Anahtar Veri giriş Ekranı", , , )
        If keyalokumada = "" Then
            MsgBox("Geçersiz Uzunlukta Anahtar.", MsgBoxStyle.Critical, "Lütfen Dikkat")
            GoTo tekrarkeyal
        End If
        Dim resim As New Bitmap(PictureBox1.Image)
        Dim renk As Color
        Dim ch As Char
        Dim r, g, b, koduz, yenikel, okunan As String
        Dim i, deger, son, en, boy As Integer
        If resim.Width < resim.Height Then son = resim.Width Else son = resim.Height
        renk = resim.GetPixel(0, 0)
        r = dec_bin(2, renk.R)
        g = dec_bin(2, renk.G)
        b = dec_bin(2, renk.B)
        If r.Length < 7 Then
            For ta = 1 To 7 - r.Length
                r = "0" + r
            Next
        End If
        If g.Length < 7 Then
            For ta = 1 To 7 - g.Length
                g = "0" + g
            Next
        End If
        If b.Length < 7 Then
            For ta = 1 To 7 - b.Length
                b = "0" + b
            Next
        End If
        yenikel = r.Substring(r.Length - 3, 3) + g.Substring(g.Length - 2, 2) + b.Substring(b.Length - 2, 2)
        okunan = ""
        okunan = okunan + alfabe.Chars(BinToDec(yenikel)).ToString
        en = 0 : boy = 1
        While (alfabe.Chars(BinToDec(yenikel)).ToString <> "ø")
            renk = resim.GetPixel(en, boy)
            r = dec_bin(2, renk.R)
            g = dec_bin(2, renk.G)
            b = dec_bin(2, renk.B)
            If r.Length < 7 Then
                For ta = 1 To 7 - r.Length
                    r = "0" + r
                Next
            End If
            If g.Length < 7 Then
                For ta = 1 To 7 - g.Length
                    g = "0" + g
                Next
            End If
            If b.Length < 7 Then
                For ta = 1 To 7 - b.Length
                    b = "0" + b
                Next
            End If
            yenikel = r.Substring(r.Length - 3, 3) + g.Substring(g.Length - 2, 2) + b.Substring(b.Length - 2, 2)
            okunan += alfabe.Chars(BinToDec(yenikel)).ToString
            i = i + 1
            boy = boy + 1
            If boy = son Then
                en = en + 1
                boy = 0
            End If

        End While

        Dim sifreoku As TripleDESileSifreleme = New TripleDESileSifreleme()
        Dim stegoveriokunan As String
        stegoveriokunan = okunan.Substring(0, Len(okunan) - 1)
        RichTextBox1.Text = sifreoku.Decrypt(stegoveriokunan, sifreoku.StrToByteArray(keyalokumada))
son:    If Err.Description <> "" Then MsgBox(Err.Description + vbCrLf + "Kaynak : " + Err.Source, MsgBoxStyle.Critical, "Dikkat")
    End Sub

    Private Sub RichTextBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RichTextBox1.MouseClick
        If ss = 0 Then RichTextBox1.Text = ""
        ss = ss + 1
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        SplashScreen1.Hide()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        hkknda1.Show()
    End Sub
End Class
