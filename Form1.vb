Public Class Form1


    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Al Muzdhar Computers\Documents\Jkuatlibrary.accdb")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            con.Open()
            If con.State = ConnectionState.Open Then
                MsgBox("Connected")
            Else
                MsgBox("Not Connected")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim i As Integer
            con.Open()
            sql = "INSERT INTO `Book Details` (BookCode,BookName,BookAuthor) values('" & txtBCode.Text & "','" & txtBName.Text & "','" & txtBAuthor.Text & "');"
            cmd.Connection = con
            cmd.CommandText = sql
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("New record has been inserted successfully!")
            Else
                MsgBox("No record has been inserted successfully")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        txtBAuthor.Text = ""
        txtBCode.Text = ""
        txtBName.Text = ""

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            con.Open()
            sql = "Select * from `Book Details`"
            cmd.Connection = con
            cmd.CommandText = sql
            da.SelectCommand = cmd
            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Me.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtBCode.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtBName.Text = DataGridView1.CurrentRow.Cells(2).Value
        txtBAuthor.Text = DataGridView1.CurrentRow.Cells(3).Value

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim i As Integer
            con.Open()
            sql = "UPDATE `Book Details` SET BookCode = '" & txtBCode.Text & "', BookName='" & txtBName.Text & "' , " & " BookAuthor='" & txtBAuthor.Text & "' WHERE ID=" & Val(Me.Text) & ""
            cmd.Connection = con
            cmd.CommandText = sql
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Record has been updated successfully!")
            Else
                MsgBox("No record has been UPDATED!!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        txtBCode.Text = ""
        txtBName.Text = ""
        txtBAuthor.Text = ""

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim i As Integer
            con.Open()
            sql = "Delete * from `Book Details' WHERE ID=" & Val(Me.Text) & ""
            cmd.Connection = con
            cmd.CommandText = sql
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Record has been deleted successfully!")
            Else
                MsgBox("No record has been deleted!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class
