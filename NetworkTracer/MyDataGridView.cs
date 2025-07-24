using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace NetworkTracer
{
	public class MyDataGridView : DataGridView
	{

		private bool isSmallFont = true;
		public bool IsSmallFont
		{
			get => isSmallFont;
			set { UpdateViewDesign(); isSmallFont = value; }
		}

		public MyDataGridView()
		{
			AllowUserToDeleteRows = true;
			this.BackgroundColor = System.Drawing.Color.White;
			this.EditMode = DataGridViewEditMode.EditOnEnter;

			if (!this.IsInDesignMode())
			{
				UpdateViewDesign();

				// for CTRL F feature
				this.EditingControlShowing += (x, y) =>
				{
					if (y.Control.GetType().Name == "DataGridViewTextBoxEditingControl")
					{
						DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)y.Control;
						tb.KeyDown -= dataGridViewTextBox_KeyDown;
						tb.KeyDown += dataGridViewTextBox_KeyDown;

					}
				};

				//
				DataSourceChanged += (x, y) => { UpdateRowHeaderLabelCounts(); };
				RowsAdded += (x, y) => { UpdateRowHeaderLabelCounts(); };
				RowsRemoved += (x, y) => { UpdateRowHeaderLabelCounts(); };

				SetupContextMenu();

				TextFontResizer();
			}
		}

		public void UpdateRowHeaderLabelCounts()
		{
			int count = 0;
			foreach (DataGridViewRow row in Rows)
			{
				// donorview.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
				count++;
				row.HeaderCell.Value = count.ToString();
			}
			System.Diagnostics.Debug.WriteLine("Row Headers Updated till:" + count);
		}


		private void dataGridViewTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			//when i press enter,bellow code never run?
			if (e.KeyCode == Keys.Enter)
			{
				CellEnterKeyDown?.Invoke(sender, e);
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		public event EventHandler CellEnterKeyDown;

		private DataGridViewCellStyle tempdataGridViewRowCellStyle;
		private DataGridViewCellStyle tempdataGridViewColumnCellStyle;

		private void UpdateViewDesign()
		{
			//
			var columnHeaderCellStyle = new DataGridViewCellStyle
			{
				Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
				BackColor = System.Drawing.SystemColors.Highlight,
				Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				ForeColor = System.Drawing.SystemColors.WindowText,
				SelectionBackColor = System.Drawing.SystemColors.Highlight,
				SelectionForeColor = System.Drawing.SystemColors.HighlightText,
				WrapMode = System.Windows.Forms.DataGridViewTriState.True,
			};
			ColumnHeadersDefaultCellStyle = columnHeaderCellStyle;

			//
			var rowCellTemplate = new DataGridViewCellStyle
			{
				Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
				BackColor = System.Drawing.SystemColors.Control,
				Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				ForeColor = System.Drawing.SystemColors.WindowText,
				SelectionBackColor = System.Drawing.Color.DimGray,
				SelectionForeColor = System.Drawing.SystemColors.HighlightText,
				WrapMode = System.Windows.Forms.DataGridViewTriState.True,
			};
			RowsDefaultCellStyle = rowCellTemplate;
			DefaultCellStyle = rowCellTemplate;

		}


		private ToolStripMenuItem gridContext_ResetFont;
		private ContextMenuStrip gridContextStrip;
		void SetupContextMenu()
		{
			ToolStripMenuItem gridContext_Clear;
			ToolStripMenuItem gridContext_CopyAll;
			ToolStripMenuItem gridContext_copyAllWithHeaders;
			ToolStripMenuItem gridContext_Paste;
			ToolStripMenuItem gridContext_ImportTabDel;

			gridContext_ResetFont = new System.Windows.Forms.ToolStripMenuItem { Text = "Reset Font" }; ;

			gridContextStrip = new System.Windows.Forms.ContextMenuStrip();
			gridContext_Clear = new System.Windows.Forms.ToolStripMenuItem { Text = "Clear" };
			gridContext_CopyAll = new System.Windows.Forms.ToolStripMenuItem { Text = "Copy All" };
			gridContext_copyAllWithHeaders = new System.Windows.Forms.ToolStripMenuItem { Text = "Copy with Headers" };
			gridContext_ImportTabDel = new System.Windows.Forms.ToolStripMenuItem { Text = "Import By Txt" };
			gridContext_Paste = new System.Windows.Forms.ToolStripMenuItem { Text = "Paste" };
			gridContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			gridContext_Clear,
			gridContext_CopyAll,
			gridContext_copyAllWithHeaders,
			gridContext_Paste,
				gridContext_ImportTabDel,
				gridContext_ResetFont});

			gridContext_Clear.Click += (x, y) => { Rows.Clear(); NotifyCurrentCellDirty(true); NotifyCurrentCellDirty(false); };
			gridContext_CopyAll.Click += (x, y) =>
			{
				ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
				SelectAll();
				DataObject dataObj = GetClipboardContent();
				if (dataObj != null)
					Clipboard.SetDataObject(dataObj);
				SendKeys.Send("{TAB}");
			};
			gridContext_copyAllWithHeaders.Click += (x, y) =>
			{
				ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
				SelectAll();
				DataObject dataObj = GetClipboardContent();
				if (dataObj != null)
					Clipboard.SetDataObject(dataObj);
				SendKeys.Send("{TAB}");
			};

			gridContext_Paste.Click += (x, y) =>
			{
				PasteClipboard(true);
			};
			gridContext_ResetFont.Click += (x, y) =>
			{
				DataGridViewCellStyle columnHeaderCellStyle = new DataGridViewCellStyle
				{
					Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
					BackColor = System.Drawing.SystemColors.Highlight,
					Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
					ForeColor = System.Drawing.SystemColors.WindowText,
					SelectionBackColor = System.Drawing.SystemColors.Highlight,
					SelectionForeColor = System.Drawing.SystemColors.HighlightText,
					WrapMode = System.Windows.Forms.DataGridViewTriState.True,
				};
				ColumnHeadersDefaultCellStyle = columnHeaderCellStyle;
				////////////////
				DataGridViewCellStyle rowCellTemplate = new DataGridViewCellStyle
				{
					Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
					BackColor = System.Drawing.SystemColors.Control,
					Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
					ForeColor = System.Drawing.SystemColors.WindowText,
					SelectionBackColor = System.Drawing.Color.DimGray,
					SelectionForeColor = System.Drawing.SystemColors.HighlightText,
					WrapMode = System.Windows.Forms.DataGridViewTriState.True,
				};
				RowsDefaultCellStyle = rowCellTemplate;
				DefaultCellStyle = rowCellTemplate;

				foreach (DataGridViewRow dgvRow in Rows)
					dgvRow.DefaultCellStyle = DefaultCellStyle;
				foreach (DataGridViewColumn dgvCol in Columns)
					dgvCol.DefaultCellStyle = ColumnHeadersDefaultCellStyle;
				AutoResizeColumns();
				AutoResizeColumnHeadersHeight();
				AutoResizeRows();
				gridContext_ResetFont.Enabled = false;
			};
			gridContext_ImportTabDel.Click += (x, y) =>
			{
				ImportByTabDel();
			};
			TopLeftHeaderCell.ContextMenuStrip = gridContextStrip;
		}

		void PasteClipboard(bool isByClick = false)
		{

			string s = Clipboard.GetText();

			string[] lines = s.Split('\n');
			int iRow = 0, iCol = 0;
			if (isByClick) { iCol = 0; iRow = 0; }
			else
			{
				iRow = CurrentCell.RowIndex;
				iCol = CurrentCell.ColumnIndex;
			}
			Rows.Clear();
			foreach (string line in lines) { Rows.Add(); }

			//DataGridViewCell oCell;
			foreach (string line in lines)
			{
				if (line.Contains("\t"))
				{
					string[] sCells = line.Split('\t');

					foreach (var sCell in sCells)
					{
						for (int iCell = 0; iCell <= this.Columns.Count - 1; iCell++)
						{
							if (iCell <= sCells.Length)
								Rows[iRow].Cells[iCell].Value = sCells[iCell];
						}
					}

					//if (sCells.Length == this.Columns.Count)
					//for (int iCell = 0; iCell <= this.Columns.Count - 1; iCell++)
					//{
					//    if (iCell <= sCells.Length)
					//        Rows[iRow].Cells[iCell].Value = sCells[iCell];
					//}
				}
				else
				{
					Rows[iRow].Cells[0].Value = line;
				}
				iRow++;
			}

		}

		void TextFontResizer()
		{
			this.MouseWheel += (x, y) =>
			{

				float fontSize = this.DefaultCellStyle.Font.Size;
				float colHeaderfontSize = this.ColumnHeadersDefaultCellStyle.Font.Size;

				if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					if (y.Delta > 0)
					{
						DefaultCellStyle.Font = new System.Drawing.Font("Arial", fontSize + 1, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", colHeaderfontSize + 1, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
					}
					else
					{
						if (fontSize > 1)
						{
							DefaultCellStyle.Font = new System.Drawing.Font("Arial", fontSize - 1, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
							ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", colHeaderfontSize - 1, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
						}
					}
					foreach (DataGridViewRow dgvRow in Rows)
						dgvRow.DefaultCellStyle = this.DefaultCellStyle;
					foreach (DataGridViewColumn dgvCol in Columns)
						dgvCol.DefaultCellStyle = ColumnHeadersDefaultCellStyle;
					gridContext_ResetFont.Enabled = true;
					AutoResizeColumns();
					AutoResizeColumnHeadersHeight();
					AutoResizeRows();

				}
				//this.RowTemplate = new 
			};
		}

		void ImportByTabDel()
		{

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Text|*.txt|All|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				string s = File.ReadAllText(ofd.FileName);
				string[] lines = s.Split('\n');
				int iRow = 0;
				Rows.Clear();
				foreach (string line in lines) { if (line.Contains("\t")) Rows.Add(); }

				//DataGridViewCell oCell;
				foreach (string line in lines)
				{
					if (line.Contains("\t") && iRow < RowCount && line.Length > 0)
					{
						string[] sCells = line.Split('\t');
						//if (sCells.Length == this.Columns.Count)
						for (int iCell = 0; iCell <= this.Columns.Count - 1; iCell++)
						{
							if (iCell <= sCells.Length)
								Rows[iRow].Cells[iCell].Value = sCells[iCell];
						}
					}
					iRow++;
				}
			}

		}

	}
}
