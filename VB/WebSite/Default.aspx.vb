#Region "Using"

Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections.Generic
Imports DevExpress.Web.ASPxGridView
#End Region

Partial Public Class Grid_Filter_OneColumnOnly_Default
	Inherits System.Web.UI.Page

	Private Expressions As Dictionary(Of GridViewDataColumn, String) = New Dictionary(Of GridViewDataColumn, String)()

	Private Function GetDataColumns() As IEnumerable(Of GridViewDataColumn)
		Dim result As List(Of GridViewDataColumn) = New List(Of GridViewDataColumn)()
		For Each column As GridViewColumn In ASPxGridView1.Columns
			Dim dataColumn As GridViewDataColumn = TryCast(column, GridViewDataColumn)
			If dataColumn IsNot Nothing Then
				result.Add(dataColumn)
			End If
		Next column
		Return result
	End Function

	Protected Sub ASPxGridView1_Load(ByVal sender As Object, ByVal e As EventArgs)
		For Each column As GridViewDataColumn In GetDataColumns()
			Expressions(column) = column.FilterExpression
		Next column
	End Sub
	Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
		Dim newFilterColumn As GridViewDataColumn = Nothing
		Dim columns As IEnumerable(Of GridViewDataColumn) = GetDataColumns()
		For Each column As GridViewDataColumn In columns
			If String.IsNullOrEmpty(Expressions(column)) AndAlso (Not String.IsNullOrEmpty(column.FilterExpression)) Then
				newFilterColumn = column
				Exit For
			End If
		Next column
		If newFilterColumn IsNot Nothing Then
			For Each column As GridViewDataColumn In columns
				If (Not Equals(column, newFilterColumn)) Then
					ASPxGridView1.AutoFilterByColumn(column, Nothing)
				End If
			Next column
		End If
	End Sub
End Class
