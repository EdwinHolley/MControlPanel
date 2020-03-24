Public Class Form1

    Private Sub StartMCB_Click(sender As Object, e As EventArgs) Handles StartMCB.Click

        Start_BedrockServer()

    End Sub

    Private Sub Start_BedrockServer()

        ' need to get the process of the program and store it so that it can be stopped by the stop button
        Dim logfile As String = "I://Programs//MineCraftBedrock//LogFile.txt"
        Using Process As New Process
            ' This needs to be the current directory
            Process.StartInfo = New ProcessStartInfo("cmd.exe") With {
                .Arguments = "/c bedrock_server.exe 1>> """ + logfile + """ 2>>&1",
                .WorkingDirectory = "I:\Programs\MineCraftBedrock",
                .UseShellExecute = False,
                .CreateNoWindow = True
            }
            Process.Start()

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

    Public Function IsProcessRunning(ByVal name As String) As Boolean
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith(name) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub RebootMCB_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim path As String = "I:\Programs\MineCraftBedrock\bedrock_server.exe"

        TerminateProcess("bedrock_server.exe")

        If IsProcessRunning(path) = True Then

        Else

            Start_BedrockServer()

        End If

    End Sub
End Class
