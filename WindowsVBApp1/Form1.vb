Public Class MainForm

    ' ----------
    ' フォント選択ダイアログ表示
    ' ----------
    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click

        ' フォント選択ダイアログの返り値
        Dim ret As DialogResult

        Try
            Using Dialog As New FontDialog()
                With Dialog
                    .Font = MainTextBox.Font
                End With

                ret = Dialog.ShowDialog()

                If ret = DialogResult.OK Then
                    MainTextBox.Font = Dialog.Font
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    ' ----------
    ' ウィンドウを閉じる際の処理
    ' ----------
    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If MainTextBox.Text IsNot "" Then
            MsgBox("終了します。よろしいですか？")
        End If

    End Sub

    ' ----------
    ' RTL切り替え
    ' ----------
    Private Sub RTLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RTLToolStripMenuItem.Click
        If MainTextBox.RightToLeft = RightToLeft.No Then
            MainTextBox.RightToLeft = RightToLeft.Yes
            RTLToolStripMenuItem.Checked = True
        Else
            MainTextBox.RightToLeft = RightToLeft.No
            RTLToolStripMenuItem.Checked = False
        End If
    End Sub

    ' ----------
    ' フォームロード時
    ' ----------
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel_Line.Text = "行: " + MainTextBox.SelectionStart.ToString
    End Sub

    ' ----------
    ' 元に戻す（アンドゥ）
    ' ----------
    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        If MainTextBox.CanUndo = True Then
            MainTextBox.Undo()
        End If
    End Sub

    ' ----------
    ' やり直し（リドゥ）
    ' ----------
    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click

    End Sub

    ' ----------
    ' アプリケーション終了
    ' ----------
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    ' ----------
    ' 新規作成
    ' ----------
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        If MainTextBox.Text IsNot "" Then
            MsgBox("編集した内容は失われます。")
        End If
        MainTextBox.Text = ""
    End Sub
End Class
