Imports System.Data.OleDb
Imports System.IO
Public Class frmContactList

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim frm As New frmContactDetails

        frm.ShowDialog()
        frm = Nothing
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmContactList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cboSearchBy.SelectedIndex = 0
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Search_Record()
    End Sub
    Private Sub Search_Record()
        Dim conn As New OleDbConnection
        Dim cmd As New OleDbCommand
        Dim da As New OleDbDataAdapter
        Dim dt As New DataTable
        Dim sSQL As String = String.Empty


        Try
            'get connection string declared in the Module1.vb and assing it to conn variable
            conn = New OleDbConnection(Get_Constring)
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            sSQL = "SELECT  Surname + ', ' + Firstname +', ' + Lastname as name,Class,Right,Wrong FROM SS1Mathematics"
            If Me.cboSearchBy.Text = "Name" Then
                sSQL = sSQL & " where Surname + ', ' + Firstname  like '%" & Me.txtSearch.Text & "%'"
            ElseIf Me.cboSearchBy.Text = "Class" Then
                sSQL = sSQL & " where Class =" & Me.txtSearch.Text
            End If
            cmd.CommandText = sSQL
            da.SelectCommand = cmd
            da.Fill(dt)

            Me.dtgResult.DataSource = dt
            If dt.Rows.Count = 0 Then
                MsgBox("No record found!")
            End If


        Catch ex As Exception
            MsgBox(ErrorToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dtgResult_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.dtgResult.RowCount > 0 Then
            Dim frm As New frmContactDetails

            frm.txtFirstName.Tag = Me.dtgResult.Item(0, Me.dtgResult.CurrentRow.Index).Value
            frm.ShowDialog()
            frm = Nothing
        End If
    End Sub

    Private Sub dtgResult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub cboSearchBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchBy.SelectedIndexChanged

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class
