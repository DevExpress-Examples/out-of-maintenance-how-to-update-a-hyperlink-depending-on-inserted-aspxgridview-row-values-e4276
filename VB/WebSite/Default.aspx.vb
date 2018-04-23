Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.Data

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private table As DataTable

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		InitializeDataTable()
		gv.DataSource = GetDataTable()
		gv.DataBind()
	End Sub

	Private Function GetDataTable() As DataTable
		If Session("DataTable") Is Nothing Then
			InitializeDataTable()
			Session("DataTable") = table
		End If
		table = CType(Session("DataTable"), DataTable)
		Return table
	End Function

	Private Sub InitializeDataTable()
		table = New DataTable("Table")
		Dim column As DataColumn

		column = New DataColumn()
		column.DataType = GetType(Int32)
		column.ColumnName = "ID"
		table.Columns.Add(column)

		table.PrimaryKey = New DataColumn() { column }

		column = New DataColumn()
		column.DataType = GetType(String)
		column.ColumnName = "Item"
		table.Columns.Add(column)

		PopulateDataTable()
	End Sub

	Private Sub PopulateDataTable()
		Dim row As DataRow
		For i As Integer = 0 To 1
			row = table.NewRow()
			row("ID") = i
			row("Item") = "Item " & i
			table.Rows.Add(row)
		Next i
	End Sub

	Protected Sub gv_RowInserting(ByVal sender As Object, ByVal e As ASPxDataInsertingEventArgs)
		Dim gv As ASPxGridView = CType(sender, ASPxGridView)
		Dim row As DataRow = table.NewRow()
		row("ID") = GetNewId()
		row("Item") = e.NewValues(0)
		table.Rows.Add(row)
		Session("DataTable") = table
		gv.JSProperties("cpID") = row("ID")
		gv.JSProperties("cpText") = row("Item")
		gv.CancelEdit()
		e.Cancel = True
	End Sub

	Private Function GetNewId() As Integer
		Dim id As Integer = 0
		For Each row As DataRow In table.Rows
			Dim rowId As Integer = CInt(Fix(row("ID")))
			If rowId > id Then
				id = rowId
			End If
		Next row
        Return id + 1
	End Function
End Class