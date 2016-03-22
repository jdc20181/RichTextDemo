'Main form for our Notepad!

Public Class Main

Public Class Main
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
