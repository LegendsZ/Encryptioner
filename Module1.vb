Module Module1
    Dim version As String = "v1.0.0.2"
    Dim line As String = "<=====================================================>"
    Dim shortline As String = "<-=-=-=-=-=->"
    Dim base As String = "Home --> "
    Dim prompt As String = base
    Dim colorset As ConsoleColor = ConsoleColor.White
    Sub Main()

        Console.Title = "Encryptioner | " & version
        Console.ForegroundColor = colorset

        Load()
        Console.Write(vbNewLine & prompt)

        Do
            Dim input As String = Console.ReadLine
            input = StrConv(input, vbLowerCase)

            If input = "encrypt" Or input = "1" Then
                Console.Write(vbNewLine & line)
                Console.Write(vbNewLine & prompt & "Encrypt: ")
                Encrypt(Console.ReadLine)

            ElseIf input = "decrypt" Or input = "2" Then
                Console.Write(vbNewLine & line)
                Console.Write(vbNewLine & prompt & "Decrypt: ")
                Decrypt(Console.ReadLine)

            ElseIf input = "cmds" Or input = "cmd" Or input = "command" Or input = "commands" Then
                Console.WriteLine(vbNewLine & line & vbNewLine & "Commands:" & vbNewLine & "1. Encrypt" & vbNewLine & "2. Decrypt" & vbNewLine & "3. clr/clear" & vbNewLine & "4. Setting(s)" & vbNewLine & line)
            ElseIf input = "clr" Or input = "clear" Or input = "3" Then
                Console.Clear()
                Load()
            ElseIf input = "settings" Or input = "setting" Then
                SettingsMode()
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(vbNewLine & "Command Not Found!")
                Console.ForegroundColor = colorset
            End If
            Console.Write(vbNewLine & prompt)
        Loop

    End Sub
    Private Sub SettingsMode()
        Console.Write(vbNewLine & line & vbNewLine & prompt & "Settings --> ")
        Do
            Dim inpSetting As String = Console.ReadLine
            inpSetting = StrConv(inpSetting, vbLowerCase)
            Select Case inpSetting
                Case "color"
                    Console.Write(vbNewLine & shortline & vbNewLine & "Colors: " & vbNewLine & "Blue" & vbNewLine & "White" & vbNewLine & "Yellow" & vbNewLine & shortline & vbNewLine)
                    Console.Write(vbNewLine & prompt & "Settings --> " & "Color --> ")
                    Dim colorInp As String
                    colorInp = StrConv(Console.ReadLine, vbLowerCase)
                    Select Case colorInp
                        Case "blue"
                            Console.ForegroundColor = ConsoleColor.Blue
                            colorset = ConsoleColor.Blue
                            Console.WriteLine(vbNewLine & "Successfully Changed Color!")
                        Case "white"
                            Console.ForegroundColor = ConsoleColor.White
                            colorset = ConsoleColor.White
                            Console.WriteLine(vbNewLine & "Successfully Changed Color!")
                        Case "yellow"
                            Console.ForegroundColor = ConsoleColor.Yellow
                            colorset = ConsoleColor.Yellow
                            Console.WriteLine(vbNewLine & "Successfully Changed Color!")
                        Case Else
                            Console.WriteLine(vbNewLine & "Error - color not identified")
                    End Select
                Case "cmd", "cmds", "commands", "command"
                    Console.Write(vbNewLine & shortline & vbNewLine & "Commands: " & vbNewLine & "1. Color" & vbNewLine & "2. exit" & vbNewLine & shortline & vbNewLine)
                Case "exit"
                    Console.WriteLine(line)
                    Exit Do
            End Select
            Console.Write(vbNewLine & prompt & "Settings --> ")
        Loop


    End Sub

    Private Sub PrintError(errorMsg As String)
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine(vbNewLine & line & vbNewLine & "Error --> " & vbNewLine & errorMsg & vbNewLine & line)
        Console.ForegroundColor = colorset
        Console.WriteLine(vbNewLine & "Press Any Key To Continue...")
        Console.ReadKey()

    End Sub
    Private Sub Load()
        Console.WriteLine("Welcome to Encryptioner by LegendsZ" & vbNewLine & vbNewLine & "Press Any Key To Continue...")
        Console.ReadKey()

        Console.Clear()
        Console.WriteLine("Welcome to Encryptioner by LegendsZ" & vbNewLine & vbNewLine & "Type cmds/cmd/command/commands for commands!")
    End Sub

    Private Sub Encrypt(input As String)
        Dim strOut As String = Nothing
        Dim characters() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " ", ".", ",", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}
        Dim strEncrypt() As String = {"azx", "qwe", "glo", "tew", "pge", "aqz", "yta", "jmb", "uqs", "hkd", "awp", "pwe", "jaz", "car", "spr", "sdu", "peg", "nyg", "psw", "xbf", "kmq", "emz", "jan", "dhu", "yxe", "uyt", " ", ".", ",", "583", "723", "597", "164", "394", "831", "963", "738", "173", "101"}

        input = StrConv(input, vbLowerCase)
        For i As Integer = 0 To input.Length - 1
            Try
                strOut &= strEncrypt(Array.IndexOf(characters, input.Substring(i, 1)))
            Catch ex As Exception
                PrintError(ex.ToString)
                Console.Clear()
                Load()
                Exit Sub
            End Try
        Next

        Console.WriteLine(vbNewLine & "Encrypted: " & strOut)
        Console.WriteLine(vbNewLine & "Do you wish to copy to clipboard? y (yes)/n (no)")
        Console.Write(vbNewLine & prompt & "Confirm: ")
        Dim ans As String = Nothing
        ans = StrConv(Console.ReadLine(), vbLowerCase)
        Do
            If ans = "y" Or ans = "yes" Then
                My.Computer.Clipboard.SetText(strOut)
                Console.WriteLine(vbNewLine & "Translation copied to clipboard!")
                Console.WriteLine(line)
                Exit Do
            ElseIf ans = "n" Or ans = "no" Then
                Console.WriteLine(line)
                Exit Do
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(vbNewLine & "Command Not Recoginized!" & vbNewLine)
                Console.ForegroundColor = colorset
                Console.Write(prompt & "Confirm: ")
                ans = StrConv(Console.ReadLine(), vbLowerCase)
            End If
        Loop
    End Sub

    Private Sub Decrypt(input As String)
        Dim strOut As String = Nothing
        Dim characters() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " ", ".", ",", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}
        Dim strEncrypt() As String = {"azx", "qwe", "glo", "tew", "pge", "aqz", "yta", "jmb", "uqs", "hkd", "awp", "pwe", "jaz", "car", "spr", "sdu", "peg", "nyg", "psw", "xbf", "kmq", "emz", "jan", "dhu", "yxe", "uyt", " ", ".", ",", "583", "723", "597", "164", "394", "831", "963", "738", "173", "101"}
        For i As Integer = 0 To input.Length - 1 Step 3
            If input.Substring(i, 1) = " " Then
                strOut &= " "
                i -= 2
                Continue For
            ElseIf input.Substring(i, 1) = "." Then
                strOut &= "."
                i -= 2
                Continue For
            ElseIf input.Substring(i, 1) = "," Then
                strOut &= ","
                i -= 2
                Continue For
            End If
            Try
                strOut &= characters(Array.IndexOf(strEncrypt, input.Substring(i, 3)))
            Catch ex As Exception
                PrintError(ex.ToString)
                Console.Clear()
                Load()
                Exit Sub
            End Try
        Next

        Console.WriteLine(vbNewLine & "Decrypted: " & strOut)

        Console.WriteLine(vbNewLine & "Do you wish to copy to clipboard? y (yes)/n (no)")
        Console.Write(vbNewLine & prompt & "Confirm: ")
        Dim ans As String = Nothing
        ans = StrConv(Console.ReadLine(), vbLowerCase)
        Do
            If ans = "y" Or ans = "yes" Then
                My.Computer.Clipboard.SetText(strOut)
                Console.WriteLine(vbNewLine & "Translation copied to clipboard!")
                Console.WriteLine(line)
                Exit Do
            ElseIf ans = "n" Or ans = "no" Then
                Console.WriteLine(line)
                Exit Do
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(vbNewLine & "Command Not Recoginized!" & vbNewLine)
                Console.ForegroundColor = colorset
                Console.Write(prompt & "Confirm: ")
                ans = StrConv(Console.ReadLine(), vbLowerCase)
            End If
        Loop

    End Sub

End Module
