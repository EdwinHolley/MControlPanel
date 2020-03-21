Public Class Form1

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

    End Sub

    Private Sub StartMCB_Click(sender As Object, e As EventArgs) Handles StartMCB.Click

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
            ' This locks up the program
            Process.WaitForExit()
            output = System.IO.File.ReadAllText(tempfile)
            ' Write to log file
            Dim inputString As String = output
            My.Computer.FileSystem.WriteAllText("I://Programs//MineCraftBedrock//LogFile.txt", inputString, True)
            ' delete temporary file
            System.IO.File.Delete(tempfile)

        End Using

    End Sub

    Private Sub StopMCB_Click(sender As Object, e As EventArgs) Handles StopMCB.Click
        TerminateProcess("bedrock_server.exe")
    End Sub

    Private Sub TerminateProcess(app_exe As String)
        Dim Process As Object
        For Each Process In GetObject("winmgmts:").ExecQuery("Select Name from Win32_Process Where Name = '" & app_exe & "'")
            Process.Terminate
        Next
    End Sub
End Class
