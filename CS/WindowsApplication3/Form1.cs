using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Drawing;
using DevExpress.Utils.Drawing;


namespace WindowsApplication3 {
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }
       

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.nwindDataSet.Employees);
        }

        private void gridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e) {
            GridView view = sender as GridView;
            GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
            if(view.LeftCoord == 0) return;
            e.Appearance.FillRectangle(e.Cache, e.Bounds);
            DrawGroupRow(e, viewInfo);
            e.Handled = true;
        }

        private void DrawGroupRow(DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e, GridViewInfo viewInfo) {
            GridGroupRowInfo rowInfo = e.Info as GridGroupRowInfo;
            GridGroupRowPainter painter = e.Painter as GridGroupRowPainter;
            rowInfo.ButtonBounds = GetButtonRectangle(rowInfo.ButtonBounds, viewInfo);
            painter.ElementsPainter.GroupRow.DrawObject(rowInfo);
        }

        private Rectangle GetButtonRectangle(Rectangle origRect, GridViewInfo viewInfo) {
            Rectangle buttonRect = origRect;
            buttonRect.X = viewInfo.ClientBounds.X + viewInfo.ViewRects.IndicatorWidth + 5;
            return buttonRect;
        }
    }
}
