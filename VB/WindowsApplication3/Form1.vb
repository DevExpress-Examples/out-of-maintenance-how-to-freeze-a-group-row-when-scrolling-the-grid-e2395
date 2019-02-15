Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Drawing
Imports DevExpress.Utils.Drawing


Namespace WindowsApplication3
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            InitData()
            gridView1.Columns(0).Group()
        End Sub
        Public Sub InitData()
            Dim dt = New DataTable()
            For i As Integer = 0 To 14
                dt.Columns.Add("col" & i)
            Next i
            For i As Integer = 0 To 9
                dt.Rows.Add(New Object() { i Mod 2 })
            Next i
            gridControl1.DataSource = dt
        End Sub
        Private Sub gridView1_CustomDrawGroupRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles gridView1.CustomDrawGroupRow
            Dim view As GridView = TryCast(sender, GridView)
            Dim viewInfo As GridViewInfo = TryCast(view.GetViewInfo(), GridViewInfo)
            If view.LeftCoord = 0 Then
                Return
            End If
            e.Appearance.FillRectangle(e.Cache, e.Bounds)
            DrawGroupRow(e, viewInfo)
            e.Handled = True
        End Sub
        Private Sub DrawGroupRow(ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs, ByVal viewInfo As GridViewInfo)
            Dim rowInfo As GridGroupRowInfo = TryCast(e.Info, GridGroupRowInfo)
            Dim painter As GridGroupRowPainter = TryCast(e.Painter, GridGroupRowPainter)
            rowInfo.ButtonBounds = GetButtonRectangle(rowInfo.ButtonBounds, viewInfo)
            painter.ElementsPainter.GroupRow.DrawObject(rowInfo)
        End Sub
        Private Function GetButtonRectangle(ByVal origRect As Rectangle, ByVal viewInfo As GridViewInfo) As Rectangle
            Dim buttonRect As Rectangle = origRect
            buttonRect.X = viewInfo.ClientBounds.X + viewInfo.ViewRects.IndicatorWidth + 5
            Return buttonRect
        End Function
    End Class
End Namespace
