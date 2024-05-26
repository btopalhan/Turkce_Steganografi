Option Strict Off

Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic

Module Module1
    Public Class TripleDESileSifreleme
        'Özel anahtar tanımlanıyor...
        Private anahtarAlfabe As String = "dabceijkfghlpqmtunozrsvx"
        Private IV_192() As Byte = {55, 103, 246, 79, 36, 99, 167, 3, 42, 5, 62, 83, 184, 7, 209, 13, 145, 23, 200, 58, 173, 10, 121, 222}
        Public Function StrToByteArray(ByVal str As String) As Byte()

            Dim encoding As New System.Text.ASCIIEncoding()
            If str.Length = 24 Then GoTo yap
            If str.Length > 24 Then
                str = str.Substring(0, 24)
            Else
                str = str + anahtarAlfabe.Substring(str.Length)
            End If
yap:        Return encoding.GetBytes(str)
        End Function

        Public Function Encrypt(ByVal value As String, ByVal key() As Byte) As String

            If value <> "" Then
                Dim cryptoProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()

                Dim ms As MemoryStream = New MemoryStream()
                Dim cs As CryptoStream = New CryptoStream(ms, cryptoProvider.CreateEncryptor(key, IV_192), CryptoStreamMode.Write)
                Dim sw As StreamWriter = New StreamWriter(cs)

                sw.Write(value)
                sw.Flush()
                cs.FlushFinalBlock()
                ms.Flush()


                Return Convert.ToBase64String(ms.GetBuffer(), 0, CInt(ms.Length))
            End If
        End Function



        Public Function Decrypt(ByVal value As String, ByVal key() As Byte) As String

            If value <> "" Then
                Dim cryptoProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()


                Dim buffer() As Byte = Convert.FromBase64String(value)
                Dim ms As MemoryStream = New MemoryStream(buffer)
                Dim cs As CryptoStream = _
                New CryptoStream(ms, cryptoProvider.CreateDecryptor(key, IV_192), CryptoStreamMode.Read)
                Dim sr As StreamReader = New StreamReader(cs)

                Return sr.ReadToEnd()
            End If
        End Function
    End Class

End Module
