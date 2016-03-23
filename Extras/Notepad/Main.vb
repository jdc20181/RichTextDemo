'Main form for our Notepad!

Public Class Main

Public Class Main
Private Sub OpenFile()

        OpenFileDialog1.Title = "RTE - Open File"
        OpenFileDialog1.DefaultExt = "rtf"
        OpenFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName = "" Then Exit Sub

        Dim strExt As String
        strExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
        strExt = strExt.ToUpper()

        Select Case strExt
            Case ".RTF"
               RichTextBoxPrintCtrl1.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.RichText)
            Case Else
                Dim txtReader As System.IO.StreamReader
                txtReader = New System.IO.StreamReader(OpenFileDialog1.FileName)
             RichTextBoxPrintCtrl1.Text = txtReader.ReadToEnd
               RichTextBoxPrintCtrl1.Close()
             RichTextBoxPrintCtrl1 = Nothing
               RichTextBoxPrintCtrl1.SelectionStart = 0
          RichTextBoxPrintCtrl1.SelectionLength = 0
        End Select

        currentFile = OpenFileDialog1.FileName
        RichTextBoxPrintCtrl1.Modified = False
        Me.Text = "Editor: " & currentFile.ToString()

    End Sub
Public Sub Save()
 ' Create a SaveFileDialog to request a path and file name to save to.
        Dim saveFile1 As New SaveFileDialog()

        ' Initialize the SaveFileDialog to specify the RTF extension for the file. or you can use what ever file you wish to allow!
        saveFile1.DefaultExt = "*.rtf"
        saveFile1.Filter = "RTF Files|*.rtf"

        ' Determine if the user selected a file name from the saveFileDialog.
        If (saveFile1.ShowDialog() = System.Windows.Forms.DialogResult.OK) _
            And (saveFile1.FileName.Length) > 0 Then

            ' Save the contents of the RichTextBox into the file.
            RichTextBoxPrintCtrl1.SaveFile(saveFile1.FileName, _
                RichTextBoxStreamType.PlainText)
        End If
        End Sub
        Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        If  RichTextBoxPrintCtrl1.Modified Then

            Dim answer As Integer
            answer = MessageBox.Show("The current document has not been saved, would you like to continue without saving?", "Unsaved Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If answer = Windows.Forms.DialogResult.No Then
                Exit Sub

            Else
                OpenFile()
            End If
        Else
            OpenFile()

        End If
    End Sub
  Public Sub LoadUpEvents() 'This adds all the needed components!
  Dim R as new RichTextBoxPrintCtrl 
    Me.controls.add(R)
    R.dock = Dockstyle.fill
    Me.Text = "New Document"
  End Sub

 Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
LoadUpEvents() 'Now we add it so it will do these things at load time
End Sub
'Below is the code to print, the richtextbox class should do the formatting otherwise needed
 Private checkPrint As Integer

   Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
      checkPrint = 0
   End Sub

   Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
      ' Print the content of the RichTextBox. Store the last character printed.
      checkPrint = RichTextBoxPrintCtrl1.Print(checkPrint, RichTextBoxPrintCtrl1.TextLength, e)

      ' Look for more pages
      If checkPrint < RichTextBoxPrintCtrl1.TextLength Then
         e.HasMorePages = True
      Else
         e.HasMorePages = False
      End If
   End Sub

   

   Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click 'Prints the document immediately
      If PrintDialog1.ShowDialog() = DialogResult.OK Then
         PrintDocument1.Print()
      End If
   End Sub

Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageSetup.Click.Click 'Custom settings for page
      PageSetupDialog1.ShowDialog()
   End Sub
   
   Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click 'You can use the print preview dialog or create your own see the advanced tutorial for how to do this!
      PrintPreviewDialog1.ShowDialog()
   End Sub
   
   Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
   Save() 'We can use public subs easier than adding all the code for multiple buttons if you have this see setupguide for info
        End sub 
'Now we will add formatting options Bold,Italics,Custom Fonts, Align Center,Align Left, Align Right,Underlining

 Private Sub FontsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FontsToolStripMenuItem1.Click
        FontDialog1.ShowDialog()
    RichTextBoxPrintCtrl1.Font = FontDialog1.Font
    End Sub
    
    Private Sub BoldToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BoldToolStripMenuItem.Click 'Bold Text 
        If  RichTextBoxPrintCtrl1.SelectionFont.Bold = True Then
            If  RichTextBoxPrintCtrl1.SelectionFont.Italic = True Then
               RichTextBoxPrintCtrl1.SelectionFont = New Font(Me. RichTextBoxPrintCtrl1.SelectionFont, FontStyle.Regular + FontStyle.Italic)
            Else
             RichTextBoxPrintCtrl1.SelectionFont = New Font(Me. RichTextBoxPrintCtrl1.SelectionFont, FontStyle.Regular)
            End If

        ElseIf  RichTextBoxPrintCtrl1.SelectionFont.Bold = False Then 'Handles if we want it bold and italic
            If  RichTextBoxPrintCtrl1.SelectionFont.Italic = True Then
                RichTextBoxPrintCtrl1.SelectionFont = New Font(Me.textbox1.SelectionFont, FontStyle.Bold + FontStyle.Italic)
            Else
         RichTextBoxPrintCtrl1.SelectionFont = New Font(Me. RichTextBoxPrintCtrl1.SelectionFont, FontStyle.Bold)
            End If
        End If
       RichTextBoxPrintCtrl1.Focus()
    End Sub

    Private Sub ItalicsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItalicsToolStripMenuItem.Click
        If  RichTextBoxPrintCtrl1.SelectionFont.Italic = True Then
            If RichTextBoxPrintCtrl1.SelectionFont.Bold = True Then
                 RichTextBoxPrintCtrl1.SelectionFont = New Font(Me. RichTextBoxPrintCtrl1.SelectionFont, FontStyle.Regular + FontStyle.Bold)
            Else
                RichTextBoxPrintCtrl1.SelectionFont = New Font(Me. RichTextBoxPrintCtrl1.SelectionFont, FontStyle.Regular)
            End If

        ElseIf RichTextBoxPrintCtrl1.SelectionFont.Italic = False Then
            If  RichTextBoxPrintCtrl1.SelectionFont.Bold = True Then
                RichTextBoxPrintCtrl1.SelectionFont = New Font(Me. RichTextBoxPrintCtrl1.SelectionFont, FontStyle.Italic + FontStyle.Bold)
            Else
              RichTextBoxPrintCtrl1.SelectionFont = New Font(Me. RichTextBoxPrintCtrl1.SelectionFont, FontStyle.Italic)
            End If
        End If
    RichTextBoxPrintCtrl1.Focus()
    End Sub
    
  Private Sub UnderLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnderLineToolStripMenuItem.Click 

        If Not RichTextBoxPrintCtrl1.SelectionFont Is Nothing Then

            Dim currentFont As System.Drawing.Font = RichTextBoxPrintCtrl1.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle

            If RichTextBoxPrintCtrl1.SelectionFont.Underline = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Underline
            End If

         RichTextBoxPrintCtrl1.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        End If
    End Sub
    
    
    Private Sub LeftToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeftToolStripMenuItem.Click
        RichTextBoxPrintCtrl1.SelectionAlignment = HorizontalAlignment.Left
        LeftToolStripMenuItem.Checked = True
        CenterToolStripMenuItem.Checked = False
        RightToolStripMenuItem.Checked = False
    End Sub

    Private Sub CenterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CenterToolStripMenuItem.Click
        RichTextBoxPrintCtrl1.SelectionAlignment = HorizontalAlignment.Center
        LeftToolStripMenuItem.Checked = False
        CenterToolStripMenuItem.Checked = True
        RightToolStripMenuItem.Checked = False

    End Sub

    Private Sub RightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RightToolStripMenuItem.Click
        RichTextBoxPrintCtrl1.SelectionAlignment = HorizontalAlignment.Right
        LeftToolStripMenuItem.Checked = False
        CenterToolStripMenuItem.Checked = True
        RightToolStripMenuItem.Checked = False

    End Sub
    
    'Copy Paste Undo Redo Select all
     Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        'check if textbox can undo
        If RichTextBoxPrintCtrl1.CanUndo Then
            RichTextBoxPrintCtrl1.Undo()
        Else
        End If
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        'check if textbox can undo
        If RichTextBoxPrintCtrl1.CanRedo Then
            RichTextBoxPrintCtrl1.Redo()
        Else
        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        My.Computer.Clipboard.Clear()
        If RichTextBoxPrintCtrl1.SelectionLength > 0 Then
            My.Computer.Clipboard.SetText(RichTextBoxPrintCtrl1.SelectedText)

        End If
        RichTextBoxPrintCtrl1.SelectedText = ""
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        My.Computer.Clipboard.Clear()
        If RichTextBoxPrintCtrl1.SelectionLength > 0 Then
        Else
            My.Computer.Clipboard.SetText(RichTextBoxPrintCtrl1.SelectedText)
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        If My.Computer.Clipboard.ContainsText Then
            RichTextBoxPrintCtrl1.Paste()
        End If
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
      RichTextBoxPrintCtrl1.SelectAll()
    End Sub
