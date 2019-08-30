Imports System.Data.OleDb
Imports System.IO
Public Class frmContactDetails
    Private Sub Save_Record()
        Dim con As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=|DataDirectory|\AddressBookDB.accdb")
        Dim cmd As New System.Data.OleDb.OleDbCommand("insert into tblAddressBook values('" + txtFirstName.Text + "','" + txtMidName.Text + "','" + txtLastName.Text + "','" + dtpDOB.Text + "','" + cmbgender.Text + "','" + txtHomeAdr.Text + "','" + txtDept.Text + "','" + txtTelNo.Text + "','" + txtMobNo.Text + "','" + txtEmail.Text + "','" + txtroom.Text + "','" + txtmatricno.Text + "','" + txtparentname.Text + "','" + txtparentno.Text + "','" + txtadvancepayment.Text + "','" + combohostelfee.Text + "',)", con)
        Try
            Dim rs As New DialogResult
            rs = MsgBox("Do u wana Save", MsgBoxStyle.YesNo)
            If Convert.ToBoolean(rs.ToString() = "Yes") Then
                con.Open()
                cmd.ExecuteNonQuery()
                MsgBox("suseccfllly")
                frmContactList.Show()
                Me.Hide()
                con.Close()
            Else
                MsgBox("not sucessfull")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try

       
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save_Record()
    End Sub
End Class

