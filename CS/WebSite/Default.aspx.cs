#region Using
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using DevExpress.Web.ASPxGridView;
#endregion

public partial class Grid_Filter_OneColumnOnly_Default : System.Web.UI.Page {

	Dictionary<GridViewDataColumn, string> Expressions = new Dictionary<GridViewDataColumn, string>();

	IEnumerable<GridViewDataColumn> GetDataColumns() {
		List<GridViewDataColumn> result = new List<GridViewDataColumn>();
		foreach(GridViewColumn column in ASPxGridView1.Columns) {
			GridViewDataColumn dataColumn = column as GridViewDataColumn;
			if(dataColumn != null)
				result.Add(dataColumn);
		}
		return result;
	}

	protected void ASPxGridView1_Load(object sender, EventArgs e) {
		foreach(GridViewDataColumn column in GetDataColumns())
			Expressions[column] = column.FilterExpression;
	}
	protected void ASPxGridView1_DataBinding(object sender, EventArgs e) {
		GridViewDataColumn newFilterColumn = null;
		IEnumerable<GridViewDataColumn> columns = GetDataColumns();
		foreach(GridViewDataColumn column in columns) {
			if(string.IsNullOrEmpty(Expressions[column]) && !string.IsNullOrEmpty(column.FilterExpression)) {
				newFilterColumn = column;
				break;
			}
		}
		if(newFilterColumn != null) {
			foreach(GridViewDataColumn column in columns) {
				if(!Equals(column, newFilterColumn))
					ASPxGridView1.AutoFilterByColumn(column, null);
			}
		}
	}
}
