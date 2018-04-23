using System;
using System.Data;
using DevExpress.Web;
using DevExpress.Web.Data;

public partial class _Default : System.Web.UI.Page {
    private DataTable table;

    protected void Page_Init(object sender, EventArgs e) {
        InitializeDataTable();
        gv.DataSource = GetDataTable();
        gv.DataBind();
    }

    private DataTable GetDataTable() {
        if(Session["DataTable"] == null) {
            InitializeDataTable();
            Session["DataTable"] = table;
        }
        table = (DataTable)Session["DataTable"];
        return table;
    }

    private void InitializeDataTable() {
        table = new DataTable("Table");
        DataColumn column;

        column = new DataColumn();
        column.DataType = typeof(Int32);
        column.ColumnName = "ID";
        table.Columns.Add(column);

        table.PrimaryKey = new DataColumn[] { column };

        column = new DataColumn();
        column.DataType = typeof(String);
        column.ColumnName = "Item";
        table.Columns.Add(column);

        PopulateDataTable();
    }

    private void PopulateDataTable() {
        DataRow row;
        for(int i = 0; i < 2; i++) {
            row = table.NewRow();
            row["ID"] = i;
            row["Item"] = "Item " + i;
            table.Rows.Add(row);
        }
    }

    protected void gv_RowInserting(object sender, ASPxDataInsertingEventArgs e) {
        ASPxGridView gv = (ASPxGridView)sender;
        DataRow row = table.NewRow();
        row["ID"] = GetNewId();
        row["Item"] = e.NewValues[0];
        table.Rows.Add(row);
        Session["DataTable"] = table;
        gv.JSProperties["cpID"] = row["ID"];
        gv.JSProperties["cpText"] = row["Item"];
        gv.CancelEdit();
        e.Cancel = true;
    }

    private int GetNewId() {
        int id = 0;
        foreach(DataRow row in table.Rows) {
            int rowId = (int)row["ID"];
            if(rowId > id)
                id = rowId;
        }
        return ++id;
    }
}