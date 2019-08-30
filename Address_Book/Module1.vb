Module Module1
    Public sConnstring As String

    Function Get_Constring()
        If Microsoft.VisualBasic.Right(Application.StartupPath, 1) = "\" Then
            sConnstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "AddressBookDB.accdb;Persist Security Info=False;"
        Else
            sConnstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\AddressBookDB.accdb;Persist Security Info=False;"
        End If
        Return sConnstring
    End Function
End Module
