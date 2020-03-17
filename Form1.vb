Public Class Form1

    Public Class Form1

    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' need to get the process of the program and store it so that it can be stopped by the stop button
        Dim output As String
        Dim tempfile As String = System.IO.Path.GetTempFileName
        Using Process As New Process
            ' This needs to be the current directory
            Process.StartInfo = New ProcessStartInfo("cmd.exe") With {
                .Arguments = "/c bedrock_server.exe 1> """ + tempfile + """ 2>&1",
                .WorkingDirectory = "I:\Programs\MineCraftBedrock",
                .UseShellExecute = False,
                .CreateNoWindow = True
            }
            Process.Start()
            ' This will not work as is will need for the server to exit unless we can get the process
            ' Process.WaitForExit()
            output = System.IO.File.ReadAllText(tempfile)
            System.IO.File.Delete(tempfile)
        End Using
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Open Log file, this will get all logs and errors
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Open whitelist.json and parse the file
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        ' Open permissions.json and parse the file
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        ' Read in json with filesystem
        ' This is apparently not a json file
        Dim json As String
        json = My.Computer.FileSystem.ReadAllText("I:\Programs\MineCraftBedrock\server.properties")
        MsgBox(json)

        Dim read = Newtonsoft.Json.Linq.JObject.Parse(json)
        TextBox3.Text = read.Item("server-name").ToString
        TextBox2.Text = read.Item("level-name").ToString
        TextBox18.Text = read.Item("level-seed").ToString
        NumericUpDown1.Value = read.Item("level-seed")
        NumericUpDown2.Value = read.Item("server-port")
        NumericUpDown3.Value = read.Item("server-portv6")
        NumericUpDown4.Value = read.Item("view-distance")
        NumericUpDown5.Value = read.Item("tick-distance")
        NumericUpDown6.Value = read.Item("player-idle-timeout")
        NumericUpDown7.Value = read.Item("max-threads")
        NumericUpDown8.Value = read.Item("compression-threshold")
        NumericUpDown9.Value = read.Item("player-movement-score-threshold")
        NumericUpDown10.Value = read.Item("player-movement-duration-threshold-in-ms")
        ComboBox1.SelectedIndex = read.Item("gamemode").ToString
        ComboBox2.SelectedIndex = read.Item("difficulty").ToString
        ComboBox3.SelectedIndex = read.Item("tick-distance").ToString
        ComboBox4.SelectedIndex = read.Item("default-player-permission-level").ToString
        CheckBox1.Checked = read.Item("allow-cheats")
        CheckBox2.Checked = read.Item("online-mode")
        CheckBox3.Checked = read.Item("white-list")
        CheckBox4.Checked = read.Item("texturepack-required")
        CheckBox5.Checked = read.Item("content-log-file-enabled")
        CheckBox6.Checked = read.Item("server-authoritative-movement")
        CheckBox7.Checked = read.Item("correct-player-movement")

    End Sub

    Private Function MsgBox() As String
        Throw New NotImplementedException()
    End Function
End Class
