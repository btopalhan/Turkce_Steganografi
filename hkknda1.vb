Public NotInheritable Class hkknda1
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub hkknda1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sfrhkk As TripleDESileSifreleme = New TripleDESileSifreleme()
        LabelProductName.Text = sfrhkk.Decrypt("0HIAtSWIKwURrUMv3EixnA==", sfrhkk.StrToByteArray(("SDFsdfkjhSDF")))
        LabelVersion.Text = sfrhkk.Decrypt("cX/50TK3DqBwVq28vMpQjohp2i2tgLNF", sfrhkk.StrToByteArray(("SDFsdfkjhSDF")))
        LabelCopyright.Text = sfrhkk.Decrypt("CbyozWIvAvVw6Khyisp+Iw+xpclQ3K5Ukse6KKqQAwqbb5Amw5d4TPO8FjGeSosA", sfrhkk.StrToByteArray(("SDFsdfkjhSDF")))
        LabelCompanyName.Text = sfrhkk.Decrypt("9sx6CDzJdAFO8aVtcuL+cmCfffEvzT9d", sfrhkk.StrToByteArray(("SDFsdfkjhSDF")))
        TextBoxDescription.Text = sfrhkk.Decrypt("xSwGLFnUQAy4DRceG9sa+pOLew38lVog+aoy/cHCx9G563wRNgQ/BDy6+NSR1x2zFIy5qLFfXz3gbTZ1zYKzPo/a1tDzXYV2bZ3dB/zFWWY52lGJGX18ssMaHhSysJ/uNTKR7qGeIBa1vGHeKuzxG4fqEDBTzrjP/i+WpbIUNlyp5D3WnlE6NO6xTM6eegZrzx7bqkLwXRU5m1I7JK52YpABSFhvXs16r2aBOcI9aF28Vtav6lV2Kbs1zN8Sg8eqbPIe3aqD/7W5SAQ5ocfNcLFeitZmlYacpUMrwDOfhWnkVxiaNuYjE21YBPu33sOWeSnRDQO/IPzM7A2qz4Du0wJveQXPE4HHwVPdPQ222ZWXYY9fe3JcYvWuVHoFdoYD59BbbLUz2963Yw61enGZeXehR3Is0GHj+klEZ/spZWZjF1H/9949crBV/td3KRNeKlM+ZYeyAwa1uXihDg7Hbr9DDHK0aE2C4Cv9nDin2ks8B6eUp4DrCVzSGqIfOukL7JLb0BH51z6n0BB0/mCWiptem9hfSRmyDxsa38wnaqS29OB0Iqx5Jg==", sfrhkk.StrToByteArray(("SDFsdfkjhSDF")))
    End Sub

    Private Sub TextBoxDescription_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDescription.TextChanged

    End Sub
End Class
