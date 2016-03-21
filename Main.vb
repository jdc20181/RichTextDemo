'You may need to use your own code however you wish!

Public Class Main

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

   

   Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
      If PrintDialog1.ShowDialog() = DialogResult.OK Then
         PrintDocument1.Print()
      End If
   End Sub
'Extras not needed
Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageSetup.Click.Click
      PageSetupDialog1.ShowDialog()
   End Sub
   
   Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
      PrintPreviewDialog1.ShowDialog()
   End Sub
