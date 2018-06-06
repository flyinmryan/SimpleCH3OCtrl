using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dry.Framework.Helpers;
using Dry.Framework.Attributes;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Dry.Framework.EventArguments;
using Dry.Framework.Exceptions;
using Dry.Framework;
using BurnerControl;

namespace SIGIntranetShell
{
    [System.Drawing.ToolboxBitmapAttribute(typeof(System.Windows.Forms.ListView))]
    [System.ComponentModel.DefaultEvent("ActionRowDoubleClick")]
    public class ucDataLView : System.Windows.Forms.UserControl
    {
		private clsListView xLV = new clsListView();
		private clsListView.clsColumnHeaderExtender[] mColumnHeaders;
		//New Events:
		public event ActionRowClickEventHandler ActionRowClick;
		public delegate void ActionRowClickEventHandler(object sender, dlvSelectionChangedEventArgs e);
		public event ActionRowAddErrorEventHandler ActionRowAddError;
		public delegate void ActionRowAddErrorEventHandler(object sender, InternalErrorEventArgs e);
		public event ActionRowDoubleClickEventHandler ActionRowDoubleClick;
		public delegate void ActionRowDoubleClickEventHandler(object sender, dlvSelectionChangedEventArgs e);
		public event ActionRowLocationChangedEventHandler ActionRowLocationChanged;
		public delegate void ActionRowLocationChangedEventHandler(object sender, System.EventArgs e);
		public event ActionKeyDownEventHandler ActionKeyDown;
		public delegate void ActionKeyDownEventHandler(object sender, System.Windows.Forms.KeyEventArgs e);
		public event ActionKeyUpEventHandler ActionKeyUp;
		public delegate void ActionKeyUpEventHandler(object sender, System.Windows.Forms.KeyEventArgs e);
		public event ActionKeyPressEventHandler ActionKeyPress;
		public delegate void ActionKeyPressEventHandler(object sender, System.Windows.Forms.KeyPressEventArgs e);
		public event ActionCASF11PressEventHandler ActionCASF11Press;
		public delegate void ActionCASF11PressEventHandler(object sender, dlvSelectionChangedEventArgs e);
		public event ActionMouseClickEventHandler ActionMouseClick;
		public delegate void ActionMouseClickEventHandler(object sender, System.Windows.Forms.MouseEventArgs e);
		public event ActionMouseDoubleClickEventHandler ActionMouseDoubleClick;
		public delegate void ActionMouseDoubleClickEventHandler(object sender, System.Windows.Forms.MouseEventArgs e);
		public event ActionMouseDownEventHandler ActionMouseDown;
		public delegate void ActionMouseDownEventHandler(object sender, System.Windows.Forms.MouseEventArgs e);
		public event ActionMouseMoveEventHandler ActionMouseMove;
		public delegate void ActionMouseMoveEventHandler(object sender, System.Windows.Forms.MouseEventArgs e);
		public event ActionMouseUpEventHandler ActionMouseUp;
		public delegate void ActionMouseUpEventHandler(object sender, System.Windows.Forms.MouseEventArgs e);
		public event ActionMouseWheelEventHandler ActionMouseWheel;
		public delegate void ActionMouseWheelEventHandler(object sender, System.Windows.Forms.MouseEventArgs e);
		public event ActionColumnReorderedEventHandler ActionColumnReordered;
		public delegate void ActionColumnReorderedEventHandler(object sender, System.Windows.Forms.ColumnReorderedEventArgs e);
		public event ActionColumnWidthChangedEventHandler ActionColumnWidthChanged;
		public delegate void ActionColumnWidthChangedEventHandler(object sender, System.Windows.Forms.ColumnWidthChangedEventArgs e);
		public event ActionItemCheckedEventHandler ActionItemChecked;
		public delegate void ActionItemCheckedEventHandler(object sender, System.Windows.Forms.ItemCheckedEventArgs e);
		public event ActionItemSelectionChangedEventHandler ActionItemSelectionChanged;
		public delegate void ActionItemSelectionChangedEventHandler(object sender, System.Windows.Forms.ListViewItemSelectionChangedEventArgs e);
		public event ActionSelectedIndexChangedEventHandler ActionSelectedIndexChanged;
		public delegate void ActionSelectedIndexChangedEventHandler(object sender, System.EventArgs e);
		public event ActionRefreshClickEventHandler ActionRefreshClick;
		public delegate void ActionRefreshClickEventHandler(object sender, EventArgs e);
		public event ActionPrintPreviewClickEventHandler ActionPrintPreviewClick;
		public delegate void ActionPrintPreviewClickEventHandler(object sender, HandleableEventArgs e);
		public event ActionItemAddButtonClickEventHandler ActionItemAddButtonClick;
		public delegate void ActionItemAddButtonClickEventHandler(object sender, dlvSelectionChangedEventArgs e);
		public event ActionItemRemoveButtonClickEventHandler ActionItemRemoveButtonClick;
		public delegate void ActionItemRemoveButtonClickEventHandler(object sender, dlvSelectionChangedEventArgs e);

		private object mDataHoldingObject;
		private Button btnRefresh;
		private Button btnHTMLPreview;
		private Button btnAddItem;
		private Button btnItemRemove;
		internal System.Windows.Forms.ToolTip tip;


		#region " Windows Form Designer generated code "

		public ucDataLView() : base()
		{
			GotFocus += ucDataLView_GotFocus;

			//This call is required by the Windows Form Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call

		}

		//UserControl1 overrides dispose to clean up the component list.
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if ((components != null)) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		//Required by the Windows Form Designer

		private System.ComponentModel.IContainer components;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		internal System.Windows.Forms.GroupBox grpHolder;
		private System.Windows.Forms.ListView lvwA;

		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.grpHolder = new System.Windows.Forms.GroupBox();
            this.btnItemRemove = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnHTMLPreview = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lvwA = new System.Windows.Forms.ListView();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.grpHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpHolder
            // 
            this.grpHolder.Controls.Add(this.btnItemRemove);
            this.grpHolder.Controls.Add(this.btnAddItem);
            this.grpHolder.Controls.Add(this.btnHTMLPreview);
            this.grpHolder.Controls.Add(this.btnRefresh);
            this.grpHolder.Controls.Add(this.lvwA);
            this.grpHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHolder.Location = new System.Drawing.Point(0, 0);
            this.grpHolder.Name = "grpHolder";
            this.grpHolder.Padding = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.grpHolder.Size = new System.Drawing.Size(314, 216);
            this.grpHolder.TabIndex = 0;
            this.grpHolder.TabStop = false;
            this.grpHolder.Text = "Results:";
            // 
            // btnItemRemove
            // 
            this.btnItemRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemRemove.Image = global::BurnerControl.Properties.Resources.Minus;
            this.btnItemRemove.Location = new System.Drawing.Point(132, 11);
            this.btnItemRemove.Name = "btnItemRemove";
            this.btnItemRemove.Size = new System.Drawing.Size(40, 35);
            this.btnItemRemove.TabIndex = 8;
            this.tip.SetToolTip(this.btnItemRemove, "Remove selected record");
            this.btnItemRemove.Visible = false;
            this.btnItemRemove.Click += new System.EventHandler(this.btnItemRemove_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Image = global::BurnerControl.Properties.Resources.Plus;
            this.btnAddItem.Location = new System.Drawing.Point(178, 11);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(40, 35);
            this.btnAddItem.TabIndex = 8;
            this.tip.SetToolTip(this.btnAddItem, "Add new record");
            this.btnAddItem.Visible = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnHTMLPreview
            // 
            this.btnHTMLPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHTMLPreview.Image = global::BurnerControl.Properties.Resources.Print;
            this.btnHTMLPreview.Location = new System.Drawing.Point(224, 11);
            this.btnHTMLPreview.Name = "btnHTMLPreview";
            this.btnHTMLPreview.Size = new System.Drawing.Size(40, 35);
            this.btnHTMLPreview.TabIndex = 7;
            this.tip.SetToolTip(this.btnHTMLPreview, "View a print preview in IE");
            this.btnHTMLPreview.Visible = false;
            this.btnHTMLPreview.Click += new System.EventHandler(this.btnHTMLPreview_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::BurnerControl.Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(270, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(40, 35);
            this.btnRefresh.TabIndex = 6;
            this.tip.SetToolTip(this.btnRefresh, "Refresh the data in the List");
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lvwA
            // 
            this.lvwA.AllowColumnReorder = true;
            this.lvwA.AutoArrange = false;
            this.lvwA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwA.FullRowSelect = true;
            this.lvwA.GridLines = true;
            this.lvwA.HideSelection = false;
            this.lvwA.Location = new System.Drawing.Point(3, 48);
            this.lvwA.MultiSelect = false;
            this.lvwA.Name = "lvwA";
            this.lvwA.ShowItemToolTips = true;
            this.lvwA.Size = new System.Drawing.Size(308, 165);
            this.lvwA.TabIndex = 0;
            this.lvwA.UseCompatibleStateImageBehavior = false;
            this.lvwA.View = System.Windows.Forms.View.Details;
            this.lvwA.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwA_ColumnClick);
            this.lvwA.ColumnReordered += new System.Windows.Forms.ColumnReorderedEventHandler(this.lvwA_ColumnReordered);
            this.lvwA.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvwA_ColumnWidthChanged);
            this.lvwA.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwA_ItemChecked);
            this.lvwA.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwA_ItemSelectionChanged);
            this.lvwA.SelectedIndexChanged += new System.EventHandler(this.lvwA_SelectedIndexChanged);
            this.lvwA.LocationChanged += new System.EventHandler(this.lvwA_LocationChanged);
            this.lvwA.Click += new System.EventHandler(this.lvwA_Click);
            this.lvwA.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwA_DragDrop);
            this.lvwA.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwA_DragEnter);
            this.lvwA.DragOver += new System.Windows.Forms.DragEventHandler(this.lvwA_DragOver);
            this.lvwA.DragLeave += new System.EventHandler(this.lvwA_DragLeave);
            this.lvwA.DoubleClick += new System.EventHandler(this.lvwA_DoubleClick);
            this.lvwA.Enter += new System.EventHandler(this.ucDataLView_GotFocus);
            this.lvwA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwA_KeyDown);
            this.lvwA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwA_KeyPress);
            this.lvwA.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwA_KeyUp);
            this.lvwA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvwA_MouseClick);
            this.lvwA.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwA_MouseDoubleClick);
            this.lvwA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvwA_MouseDown);
            this.lvwA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvwA_MouseMove);
            this.lvwA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwA_MouseUp);
            // 
            // tip
            // 
            this.tip.IsBalloon = true;
            this.tip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // ucDataLView
            // 
            this.Controls.Add(this.grpHolder);
            this.Name = "ucDataLView";
            this.Size = new System.Drawing.Size(314, 216);
            this.grpHolder.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		public enum GridLoadType
		{
			GridDataUnknown = 0,
			GridDataSet = 1,
			GridDataTable = 2,
			GridDataView = 3,
			GridDataRowArray = 4,
			GridDryViewable = 5
		}

		#region "    Public Properties    "



        [System.ComponentModel.Browsable(false)]
        public GridLoadType GridDataType
        {
            get
            {
                try
                {
                    if (mDataHoldingObject is DataSet)         {return GridLoadType.GridDataSet;}
                    else if (mDataHoldingObject is DataTable)  {return GridLoadType.GridDataTable;}
                    else if (mDataHoldingObject is DataView)   {return GridLoadType.GridDataView;}
                    else if (mDataHoldingObject is DataRow[])  {return GridLoadType.GridDataRowArray;}
                    else{return GridLoadType.GridDataUnknown;}
                } catch {return GridLoadType.GridDataUnknown;}
            }
        }

		#region "    Group By Testing    "
		///////////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////////

		//, ByVal soSort As SortOrder)
		public void GroupByColumn(int intColumnIndex)
		{
			//<STAThread()> _
			//Dim groupTables() As Hashtable
			bool isRunningXPOrLater = OSFeature.Feature.IsPresent(OSFeature.Themes);

			lvwA.Groups.Clear();
			if (intColumnIndex < 0) {
				lvwA.ShowGroups = false;
				Invalidate();
				return;
			} else {
				lvwA.ShowGroups = true;
				// Retrieve the hash table corresponding to the column.
				System.Collections.Hashtable groups = CreateGroupsTable(intColumnIndex);
				//CType(groupTables(intColumnIndex), Hashtable)
				if (groups.Count < 1)
					return;
				ListViewGroup[] groupsArray = new ListViewGroup[groups.Count];
				groups.Values.CopyTo(groupsArray, 0);

				// Sort the groups and add them to myListView.
				//If lvwA.Sorting <> SortOrder.None Then Array.Sort(groupsArray, New ListViewGroupSorter(lvwA.Sorting))
				Array.Sort(groupsArray, new ListViewGroupSorter(lvwA.Sorting));
				lvwA.Groups.AddRange(groupsArray);

				if (lvwA.Items.Count < 1)
					return;

				// Iterate through the items in myListView, assigning each 
				// one to the appropriate group.
				for (int i = 0; i <= lvwA.Items.Count - 1; i++) {
					// Retrieve the subitem text corresponding to the column.
					string subItemText = lvwA.Items[i].SubItems[intColumnIndex].Text;

					// For the Title column, use only the first letter.
					if (intColumnIndex == 0) {
						subItemText = subItemText.Substring(0, 1);
					}

					// Assign the item to the matching group.
					lvwA.Items[i].Group = (ListViewGroup)groups[subItemText];
				}
				//lvwA.Sorting = soSort
				Invalidate();
			}


		}

		// Creates a Hashtable object with one entry for each unique
		// subitem value (or initial letter for the parent item)
		// in the specified column.
		private System.Collections.Hashtable CreateGroupsTable(int column)
		{
			// Create a Hashtable object.
			System.Collections.Hashtable groups = new System.Collections.Hashtable();

			// Iterate through the items in myListView.
            if (lvwA.Items.Count < 1) { return groups; }
            if (lvwA.Items[0].SubItems.Count <= column) { return groups; }

            foreach (ListViewItem item in lvwA.Items)
            {
				// Retrieve the text value for the column.
				string subItemText = item.SubItems[column].Text;

				// Use the initial letter instead if it is the first column.
				if (column == 0) {
					subItemText = subItemText.Substring(0, 1);
				}

				// If the groups table does not already contain a group
				// for the subItemText value, add a new group using the 
				// subItemText value for the group header and Hashtable key.
				if (!groups.Contains(subItemText)) {
					groups.Add(subItemText, new ListViewGroup(subItemText, HorizontalAlignment.Left));
				}
			}

			// Return the Hashtable object.
			return groups;
		}
		//CreateGroupsTable


		// Sorts ListViewGroup objects by header value.
        private class ListViewGroupSorter : IComparer<ListViewGroup>
		{


			private SortOrder order;
			// Stores the sort order.
			public ListViewGroupSorter(SortOrder theOrder)
			{
				order = theOrder;
			} //New

			// Compares the groups by header value, using the saved sort
			// order to return the correct value.
            public int Compare(ListViewGroup x, ListViewGroup y)
			{
				int result = string.Compare(((ListViewGroup)x).Header, ((ListViewGroup)y).Header);
				if (order == SortOrder.Ascending) {
					return result;
				} else {
					return -result;
				}
			}  //Compare
		}  //ListViewGroupSorter 

		///////////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////////
		#endregion

		[System.ComponentModel.Browsable(false)]
		public DataTable GridDT {
			get {
                if (GridDataType == GridLoadType.GridDataTable) { return (DataTable)mDataHoldingObject; }
                else { return null; }
			}
			set { LoadView(value, "", 2000); }
		}

		public object GridDataObject()
		{
			return mDataHoldingObject;
		}

		/// <summary>
		/// Gets the First Rox index from the column specified that contains the data specified
		/// </summary>
		/// <param name="strColumnName">Name of column to search</param>
		/// <param name="strData">Data to search for</param>
		public int RowDataIndex(string strColumnName, string strData)
		{
			int intColumnIndex = ColumnFieldIndex(strColumnName);
			int intRowIndex = 0;
			if (intColumnIndex >= 0 && lvwA.Items.Count > 0) {
				for (intRowIndex = 0; intRowIndex <= lvwA.Items.Count - 1; intRowIndex++) {
					if (lvwA.Items[intRowIndex].SubItems[intColumnIndex].Text == strData) {
						return intRowIndex;
					}
				}
			}
            return -1;
		}

		/// <summary>
		/// Gets the First Rox index from the First column (assumed to be a number) that contains the data specified
		/// </summary>
		/// <param name="intPrimaryKey">Key to search for</param>
        public int RowDataIndex(int intPrimaryKey)
        {
            int intRowIndex = 0;
            if (lvwA.Items.Count > 0)
            {
                for (intRowIndex = 0; intRowIndex <= lvwA.Items.Count - 1; intRowIndex++)
                {
                    if (Strings.SafeInteger(lvwA.Items[intRowIndex].SubItems[0].Text) == intPrimaryKey)
                    {
                        return intRowIndex;
                    }
                }
            }
            return -1;
        }

		public void ColumnRemove(int intIndex)
		{
			if (intIndex < 0)
				return;
			if ((lvwA.Columns.Count - 1) < intIndex)
				return;
			lvwA.Columns.RemoveAt(intIndex);
		}

		/// <summary>
		/// Gets the Text in the column specified of the Row by indexed position
		/// </summary>
		/// <param name="intRowIndex">Index of the Row</param>
		/// <param name="strColumnName">Name of the column</param>
		public string ItemTextByColumnName(int intRowIndex, string strColumnName)
		{
			int intColumnIndex = ColumnFieldIndex(strColumnName);
			if (intColumnIndex >= 0 && intRowIndex >= 0 && lvwA.Items.Count > 0) {
				return lvwA.Items[intRowIndex].SubItems[intColumnIndex].Text;
			} else {
				return "";
			}
		}

		/// <summary>
		/// Gets the Selected row's text for the given column
		/// </summary>
		/// <param name="strColumnName">Name of the column</param>
		public string SelectedTextByColumn(string strColumnName)
		{
			int intColumnIndex = ColumnFieldIndex(strColumnName);
			if (intColumnIndex >= 0 && SelectedItems.Count > 0) {
				return SelectedItems[0].SubItems[intColumnIndex].Text;
			}
			return "";
			//Dim intEligibilityID As Integer = .ColumnFieldIndex("intEligibilityID")
			//If intEligibilityID >= 0 Then dlvEligibility.ColumnWidth(intEligibilityID) = 0 ' Eligibility ID
		}

		/// <summary>
		/// Gets or sets the Column Display order
		/// </summary>
		/// <param name="strNewOrder">If ommitted returns the current state, otherwise changes the state and returns the new state.  index,position|index,position| ex. "1,1|2,3|3,2|"</param>
		public string ColumnDisplayOrderPipe(string strNewOrder = null)
		{
			try {
				string strOut = "";
                int ColCnt = lvwA.Columns.Count;
				if (string.IsNullOrWhiteSpace(strNewOrder) == false) 
                {
					//Change it
					string[] aryPipe = Strings.ArrayRemoveEmpty(strNewOrder.Split('|'));
                    if (Strings.ArraySafeCount(aryPipe) > 0)
                    {
						foreach (string strIndex in aryPipe) {
                            string[] aryIndexs = Strings.ArrayRemoveEmpty(strIndex.Split(','));
                            if (Strings.ArraySafeCount(aryIndexs) == 2)
                            {
                                int intIndex = Strings.SafeInteger(aryIndexs[0]);
                                int intDisplayIndex = Strings.SafeInteger(aryIndexs[1]);
								if ((intIndex > 0 & intIndex < ColCnt) & (intDisplayIndex > 0 & intDisplayIndex < ColCnt)) {
									lvwA.Columns[intIndex].DisplayIndex = intDisplayIndex;
								}
							}
						}
						lvwA.Invalidate();
						lvwA.Refresh();
					}
				}
				for (int i = lvwA.Columns.Count - 1; i >= 1; i += -1) {
					strOut += lvwA.Columns[i].Index.ToString() + "," + lvwA.Columns[i].DisplayIndex.ToString() + "|";
				}
				return strOut;
			} catch {
				return "";
			}
		}

		/// <summary>If buttons are hidden Skoot the visible button over</summary>
		private void UpdateButtonPlacement()
		{
            //          136=90+46|90=44+46    44
            //          |--------|--------|---------|
            //|-------------------------------------| 314
            //   /----\  /----\  /-|--\   /----\    |
            //   |    |  |    |  | 35 |-6-|-40-|-4- |
            //   \----/  \----/  \-|--/   \----/ 
            //    \132    \178    \224     \270
			System.Drawing.Point[] aryPoints = new System.Drawing.Point[4];
			int intShowIndex = 0;

            aryPoints[0] = new System.Drawing.Point(this.Width - 44, 11);  
            aryPoints[1] = new System.Drawing.Point(this.Width - 90, 11);  
            aryPoints[2] = new System.Drawing.Point(this.Width - 136, 11); 
			aryPoints[3] = new System.Drawing.Point(this.Width - 182, 11);
            if (ShowRefreshButton) { btnHTMLPreview.Location = aryPoints[intShowIndex]; intShowIndex += 1; }
            if (ShowPrintPreviewButton == true) { btnHTMLPreview.Location = aryPoints[intShowIndex]; intShowIndex += 1; }
            if (ShowItemAddButton) { btnAddItem.Location = aryPoints[intShowIndex]; intShowIndex += 1; }
            if (ShowItemRemoveButton) { btnItemRemove.Location = aryPoints[intShowIndex]; }
		}

		[System.ComponentModel.Description("Shows or Hide a Small Add Button that will fire the ActionItemAddButtonClick Event")]
		public bool ShowItemAddButton {
			get { return btnAddItem.Visible; }
			set {
				btnAddItem.Visible = value;
				UpdateButtonPlacement();
				this.Invalidate();
			}
		}

		[System.ComponentModel.Description("Shows or Hide a Small Refresh Button that will fire the ActionItemRemoveButtonClick Event")]
		public bool ShowItemRemoveButton {
			get { return btnItemRemove.Visible; }
			set {
				btnItemRemove.Visible = value;
				UpdateButtonPlacement();
				this.Invalidate();
			}
		}

		[System.ComponentModel.Description("Shows or Hide a Small Refresh Button that will fire the ActionRefreshClick Event")]
		public bool ShowRefreshButton {
			get { return btnRefresh.Visible; }
			set {
				btnRefresh.Visible = value;
				UpdateButtonPlacement();
				this.Invalidate();
			}
		}

		/// <summary>
		/// Shows or Hide a Small Print Preview Button that will fire the ActionPrintPreviewClick Event (Set Cancel = True to prevent the HTML Export and Launch.)
		/// </summary>
		[System.ComponentModel.Description("Shows or Hide a Small Print Preview Button that will fire the ActionPrintPreviewClick Event (Set Cancel = True to prevent the HTML Export and Launch.)")]
		public bool ShowPrintPreviewButton {
			get { return btnHTMLPreview.Visible; }
			set {
				btnHTMLPreview.Visible = value;
				UpdateButtonPlacement();
				this.Invalidate();
			}
		}

		#region "     Tool Tip Title     "

		#region "    Comments    "
		/// <summary>
		/// Gets or sets Tool Tip Title
		/// </summary>
		#endregion
		[System.ComponentModel.Description("Tool Tip Title")]
		public string ToolTipTitle {
			[System.Diagnostics.DebuggerStepThrough()]
			get { return tip.ToolTipTitle; }
			[System.Diagnostics.DebuggerStepThrough()]
			set { tip.ToolTipTitle = value; }
		}
		#endregion

		#region "     Tool Tip Refresh     "

		/// <summary>
		/// Gets or sets Tool Tip Refresh
		/// </summary>
		[System.ComponentModel.Description("Tool Tip Refresh")]
		public string ToolTipRefresh {
			[System.Diagnostics.DebuggerStepThrough()]
			get { return tip.GetToolTip(btnRefresh); }
			[System.Diagnostics.DebuggerStepThrough()]
			set { tip.SetToolTip(this.btnRefresh, value); }
		}
		#endregion

		#region "     Tool Tip Preview     "

		/// <summary>
		/// Gets or sets Tool Tip Preview
		/// </summary>
		[System.ComponentModel.Description("Tool Tip for Preview button")]
		public string ToolTipPreview {
			[System.Diagnostics.DebuggerStepThrough()]
			get { return tip.GetToolTip(btnHTMLPreview); }
			[System.Diagnostics.DebuggerStepThrough()]
			set { tip.SetToolTip(this.btnHTMLPreview, value); }
		}
		#endregion

		#region "     Tool Tip Add     "

		/// <summary>
		/// Gets or sets Tool Tip Add
		/// </summary>
		[System.ComponentModel.Description("Tool Tip for Add button")]
		public string ToolTipAdd {
			[System.Diagnostics.DebuggerStepThrough()]
			get { return tip.GetToolTip(btnAddItem); }
			[System.Diagnostics.DebuggerStepThrough()]
			set { tip.SetToolTip(this.btnAddItem, value); }
		}
		#endregion

		#region "     Tool Tip Remove     "

		/// <summary>
		/// Gets or sets Tool Tip Remove
		/// </summary>
		[System.ComponentModel.Description("Tool Tip for Remove button")]
		public string ToolTipRemove {
			[System.Diagnostics.DebuggerStepThrough()]
			get { return tip.GetToolTip(btnItemRemove); }
			[System.Diagnostics.DebuggerStepThrough()]
			set { tip.SetToolTip(this.btnItemRemove, value); }
		}
		#endregion



		//    <System.ComponentModel.Browsable(False)> _
		public bool ColumnHeadersVisible {
			get {
				if (lvwA.View == View.Details) {
					return true;
				} else {
					return false;
				}
			}
			set {
				if (value) {
					lvwA.View = View.Details;
				} else {
					lvwA.View = View.List;
				}
				this.Invalidate();
			}
		}

		[System.ComponentModel.Browsable(false)]
		public int ItemCount {
			get { return lvwA.Items.Count; }
		}

		[System.ComponentModel.Browsable(false)]
		public int ColumnCount {
			get { return lvwA.Columns.Count; }
		}

		[System.ComponentModel.Browsable(false)]
		public List<int> ColumnWidth {
			get {
                List<int> x = new List<int>();
				for(int i =0; i < lvwA.Columns.Count ;i++)
                {
                    x.Add(lvwA.Columns[i].Width);
                }
				return x;
				
			}
			set {
                if (value == null) { return; }
                int i = 0;
                foreach (int x in value)
                { try { lvwA.Columns[i].Width = x; i++; } catch { } }
				Invalidate();
			}
		}

        [System.ComponentModel.Browsable(false)]
        public List<string> ColumnNames
        {
            get
            {
                List<string> x = new List<string>();
                for (int i = 0; i < lvwA.Columns.Count; i++)
                    {x.Add(lvwA.Columns[i].Text);}
                return x;
            }
            set
            {
                if (value == null) { return; }
                int i = 0;
                foreach (string s in value)
                    { try { lvwA.Columns[i].Text = s; i++; } catch { } }
                Invalidate();
            }
        }

        [System.ComponentModel.Browsable(false)]
        public int ColumnFieldIndex(string strField)
        {
            if (mColumnHeaders == null) { return -1; }
            for (int i = mColumnHeaders.GetLowerBound(0); i <= mColumnHeaders.GetUpperBound(0); i++)
            {
                if (mColumnHeaders[i] != null)
                {
                    if (mColumnHeaders[i].strField.ToUpper() == strField.ToUpper()) { return i - 1; }
                }
            }
            return -1;
        }

        [System.ComponentModel.Browsable(false)]
        public int ColumnCaptionIndex(string strCaption)
        {
            for (int i = mColumnHeaders.GetLowerBound(0); i <= mColumnHeaders.GetUpperBound(0); i++)
            {
                if (mColumnHeaders[i] != null && mColumnHeaders[i].strValue == strCaption) { return i - 1; }
            }
            return -1;
        }

        //[System.ComponentModel.Browsable(false)]
        //public clsListView.clsColumnHeaderExtender ColumnHeaders {
        //    get { return mColumnHeaders(i); }
        //    set {
        //        mColumnHeaders(i) = value;
        //        this.Invalidate();
        //    }
        //}

		//'<System.ComponentModel.Browsable(False)> _
        public bool ListShowItemToolTips
        {
            get { return lvwA.ShowItemToolTips; }
            set
            {
                lvwA.ShowItemToolTips = value;
                this.Invalidate();
            }
        }

        //[System.ComponentModel.Browsable(false)]
        //public System.Windows.Forms.HorizontalAlignment ColumnAlignments {
        //    get {
        //        if (lvwA.Columns.Count <= i && (lvwA.Columns[i] != null)) {
        //            return lvwA.Columns[i].TextAlign;
        //        } else {
        //            return HorizontalAlignment.Left;
        //        }
        //    }
        //    set {
        //        try {
        //            if (lvwA.Columns.Count <= i && (lvwA.Columns(i) != null)) {
        //                lvwA.Columns(i).TextAlign = value;
        //            } else {
        //            }
        //            Invalidate();
        //        } catch (Exception ex) {
        //        }
        //    }
        //}

		/// <summary>
		/// Developer Method. returns a Sample call you your dlv instance with the current widths set
		/// </summary>
		/// <returns></returns>
		public string GetWidthString()
		{
			string strOut = ".SetWidths(new int[] {";
            List<int> cw = ColumnWidth;
            cw.ForEach(i => strOut += (i.ToString() + ", "));
            strOut = strOut.Remove(strOut.Length - 2);
			strOut += "});";
			return strOut;
		}

		/// <summary>Returns an Array of the Column Widths</summary>
		public int[] GetWidths()
		{
            return ColumnWidth.ToArray();
		}

		/// <summary>
		/// Changes the Column width of columns to the values in an integer array
		/// </summary>
		/// <param name="ariWidths">integer array to set the column widths to</param>
		[System.ComponentModel.Description("Changes the Column width of columns to the values in an integer array")]
		public void SetWidths(int[] ariWidths)
		{
			int intCols = 0;
			if ((ColumnCount) > ariWidths.Length) {
				intCols = ariWidths.Length - 1;
			} else {
				intCols = ColumnCount - 1;
			}
			for (int i = 0; i <= intCols; i++) {
                lvwA.Columns[i].Width = ariWidths[i];
			}
			Invalidate();
		}

		/// <summary>
		/// Changes the Column width of all columns
		/// </summary>
		/// <param name="intSetAllTo">Integer to set the width of all columns to</param>
		/// <remarks></remarks>
		[System.ComponentModel.Description("Changes the Column width of all columns")]
		public void SetWidths(int intSetAllTo)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			for (int i = 0; i <= ColumnCount - 1; i++) {
				ColumnWidth[i] = intSetAllTo;
			}
			Invalidate();
		}

		/// <summary>
		/// Group Box Caption.  If blank group box turns invisible.
		/// </summary>
		[System.ComponentModel.Description("Group Box Caption.  If blank group box turns invisible.")]
		public string CaptionGrid {
			get { return grpHolder.Text; }
			set {
				grpHolder.Text = value;
				if (grpHolder.Text.Length == 0) {
					lvwA.Dock = System.Windows.Forms.DockStyle.None;
					lvwA.Location = new System.Drawing.Point(0, 0);
					lvwA.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height);
					lvwA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
				} else {
					lvwA.Dock = System.Windows.Forms.DockStyle.Fill;
				}
				Invalidate();
			}
		}

		[System.ComponentModel.Description("Gets or sets a value indicating whether grid lines appear between the rows and columns containing the items and subitems in the control.")]
		public bool GridLines {
			get { return lvwA.GridLines; }
			set {
				lvwA.GridLines = value;
				Invalidate();
			}
		}

		[System.ComponentModel.Description("Gets or sets a value indicating whether multiple items can be selected.")]
		public bool MultiSelect {
			get { return lvwA.MultiSelect; }
			set {
				lvwA.MultiSelect = value;
				Invalidate();
			}
		}

		[System.ComponentModel.Description("Gets or sets a value indicating whether the user can drag column headers to reorder columns in the control.")]
		public bool AllowColumnReorder {
			get { return lvwA.AllowColumnReorder; }
			set {
				lvwA.AllowColumnReorder = value;
				Invalidate();
			}
		}


		private bool mynAllowColumnSorting = true;
		[System.ComponentModel.Description("Allow User to click the column headers to sort")]
		public bool AllowColumnSorting {
			get { return mynAllowColumnSorting; }
			set { mynAllowColumnSorting = value; }
		}

		public bool HideSelection {
			get { return lvwA.HideSelection; }
			set { lvwA.HideSelection = value; }
		}

		public bool HoverSelection {
			get { return lvwA.HoverSelection; }
			set { lvwA.HoverSelection = value; }
		}

		[System.ComponentModel.Browsable(false)]
		public System.Windows.Forms.ListViewItem FocusedItem {
			get { return lvwA.FocusedItem; }
		}

		public new System.Windows.Forms.BorderStyle BorderStyle {
			get { return lvwA.BorderStyle; }
			set {
				lvwA.BorderStyle = value;
				Invalidate();
			}
		}

		public System.Windows.Forms.FlatStyle BorderFlatStyle {
			//NEW 07
			get { return grpHolder.FlatStyle; }
			set {
				grpHolder.FlatStyle = value;
				Invalidate();
			}
		}

		public bool CheckBoxes {
			get { return lvwA.CheckBoxes; }
			set {
				lvwA.CheckBoxes = value;
				Invalidate();
			}
		}

		[System.ComponentModel.Browsable(false)]
		public System.Windows.Forms.ListView.CheckedIndexCollection CheckedIndices {
			get { return lvwA.CheckedIndices; }
		}

		[System.ComponentModel.Browsable(false)]
		public System.Windows.Forms.ListView.CheckedListViewItemCollection CheckedItems {
			get { return lvwA.CheckedItems; }
		}

		[System.ComponentModel.Browsable(false)]
		public System.Windows.Forms.ListView.SelectedIndexCollection SelectedIndices {
			get { return lvwA.SelectedIndices; }
		}

		[System.ComponentModel.Browsable(false)]
		public int SelectedItemCount {
			get { return lvwA.SelectedItems.Count; }
		}

		[System.ComponentModel.Browsable(false)]
		public System.Windows.Forms.ListView.SelectedListViewItemCollection SelectedItems {
			get { return lvwA.SelectedItems; }
		}

		[System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public System.Windows.Forms.ListView.ListViewItemCollection Items {
			get { return lvwA.Items; }
		}

		/// <summary>
		/// If the First Selected Item has a number in the First column it will be returned otherwise -1 will
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks>
		/// It is standard practice to always put the Primary Key Autonumber column in the Zero SubItem Location.
		/// </remarks>
		[System.ComponentModel.Browsable(false)]
		public int SelectedItemPrimaryKey {
			get {
				if (lvwA.SelectedItems.Count > 0) {
					int intOut = Strings.SafeInteger(lvwA.SelectedItems[0].Text.Trim());
					return intOut;
				} else {
					return -1;
				}
			}
		}

		/// <summary>
		/// Assumes the First Column has the Data's Primary Key Autonumbers.  Gets or Sets an Array of the Selected keys.
		/// </summary>
		/// <remarks>
		/// It is standard practice to always put the Primary Key Autonumber column in the Zero SubItem Location.
		/// </remarks>
		[System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public List<int> SelectedItemPrimaryKeys {
			get {
                try
                {
                    if (lvwA.SelectedItems.Count > 0)
                    {
                        List<int> aryInts = new List<int>();
                        foreach (ListViewItem ItmX in lvwA.SelectedItems)
                        {
                            int intTmp = Strings.SafeInteger(ItmX.SubItems[0].Text.Trim());
                            if (intTmp > 0) { aryInts.Add(intTmp); }
                        }
                        return aryInts;
                    }
                    else { return null; }
                }
                catch { return null; }
			}
			set {
				try {
					ItemsUnSelectAll();
					for (int i = 0; i <= lvwA.Items.Count - 1; i++) {
						int intTmp = Strings.SafeInteger(lvwA.Items[i].SubItems[0].Text.Trim());
						if (value.Contains(intTmp)) {
							lvwA.Items[i].Selected = true;
							lvwA.Items[i].EnsureVisible();
						}
					}
				} catch {}
			}
		}

		/// <summary>
		/// Change color of an item based on the first col val
		/// </summary>
		/// <param name="FirstColumnValue">will compared with the First Column text. the first match will be colored if found</param>
		/// <param name="ynBold">If True the Text will be Bolded</param>
		/// <param name="clrForeColor">If Not Drawing.Color.Empty then the Fore Color will be changed</param>
		/// <param name="clrBackColor">If Not Drawing.Color.Empty then the Back Color will be changed</param>
        public void ItemColorize(string FirstColumnValue, bool ynBold, System.Drawing.Color clrForeColor, System.Drawing.Color clrBackColor)
        {
            for (int j = 0; j <= lvwA.Items.Count - 1; j++)
            {
                if (lvwA.Items[j] != null && (lvwA.Items[j].SubItems[0].Text) == FirstColumnValue)
                {
                    for (int i = 0; i <= lvwA.Items[j].SubItems.Count - 1; i++)
                    {
                        if (lvwA.Items[j].SubItems[i] != null)
                        {
                            if (clrForeColor != System.Drawing.Color.Empty) { lvwA.Items[j].SubItems[i].ForeColor = clrForeColor; }
                            if (clrBackColor != System.Drawing.Color.Empty) { lvwA.Items[j].SubItems[i].BackColor = clrBackColor; }
                            if (ynBold) { lvwA.Items[j].SubItems[i].Font = new System.Drawing.Font(lvwA.Items[j].SubItems[i].Font, System.Drawing.FontStyle.Bold); }
                        }
                    }
                    return;  // We found the Item
                }
            }
        }

		/// <summary>
		/// Allows you to change The Item Text and all Sub Item Text to the Specified Fore and Back Color's and optionally Bold the Text
		/// </summary>
		/// <param name="intIndex">The Row Index</param>
		/// <param name="ynBold">If True the Text will be Bolded</param>
		/// <param name="clrForeColor">If Not Drawing.Color.Empty then the Fore Color will be changed</param>
		/// <param name="clrBackColor">If Not Drawing.Color.Empty then the Back Color will be changed</param>
		/// <remarks></remarks>
        public void ItemColorize(int intIndex, bool ynBold, System.Drawing.Color clrForeColor, System.Drawing.Color clrBackColor)
        {
            if (lvwA.Items.Count == 0) { return; }
            if (lvwA.Items[intIndex] != null)
            {
                for (int i = 0; i <= lvwA.Items[intIndex].SubItems.Count - 1; i++)
                {
                    if (lvwA.Items[intIndex].SubItems[i] != null)
                    {
                        if (clrForeColor != System.Drawing.Color.Empty) { lvwA.Items[intIndex].SubItems[i].ForeColor = clrForeColor; }
                        if (clrBackColor != System.Drawing.Color.Empty) { lvwA.Items[intIndex].SubItems[i].BackColor = clrBackColor; }
                        if (ynBold) { lvwA.Items[intIndex].SubItems[i].Font = new System.Drawing.Font(lvwA.Items[intIndex].SubItems[i].Font, System.Drawing.FontStyle.Bold); }
                    }
                }
            }
        }

		public void SelectFirstItem()
		{
			try {
				if (lvwA.Items.Count > 0) {
					lvwA.Items[0].Selected = true;
					lvwA.Items[0].EnsureVisible();
				}
			} catch {
			}
		}

		public void SelectLastItem()
		{
			try {
				if (lvwA.Items.Count > 0) {
					lvwA.Items[lvwA.Items.Count - 1].Selected = true;
					lvwA.Items[lvwA.Items.Count - 1].EnsureVisible();
				}
			} catch {
			}
		}

        public void SelectIfLocate(int intColumn, string strValue)
        {
            foreach (ListViewItem ItmX in lvwA.Items)
            {
                if (ItmX.SubItems[intColumn].Text.ToLower() == strValue.ToLower())
                {
                    ItmX.Selected = true;
                    ItmX.EnsureVisible();
                    return;
                }
                else
                {
                    ItmX.Selected = false;
                }
            }
        }

		public void SelectAllIfLocate(int intColumn, List<string> ListOfValues)
		{
            foreach (ListViewItem ItmX in lvwA.Items)
            {
                if (ListOfValues.Contains(ItmX.SubItems[intColumn].Text, StringComparer.OrdinalIgnoreCase))
                {
                    ItmX.Selected = true;
                    ItmX.EnsureVisible();
                }
                else
                {
                    ItmX.Selected = false;
                }
            }
		}


		public void EnsureVisible(int index)
		{
			lvwA.EnsureVisible(index);
		}

		public bool LabelEdit {
			get { return lvwA.LabelEdit; }
			set { lvwA.LabelEdit = value; }
		}

		public bool Scrollable {
			get { return lvwA.Scrollable; }
			set { lvwA.Scrollable = value; }
		}

		public System.Windows.Forms.ImageList SmallImageList {
			get { return lvwA.SmallImageList; }
			set { lvwA.SmallImageList = value; }
		}

		[System.ComponentModel.Browsable(false)]
		public System.Windows.Forms.ListViewItem TopItem {
			get { return lvwA.TopItem; }
		}

		public System.Windows.Forms.ContextMenu ListViewContextMenu {
			get { return lvwA.ContextMenu; }
			set { lvwA.ContextMenu = value; }
		}

		public System.Drawing.Color ListBackColor {
			get { return lvwA.BackColor; }
			set { lvwA.BackColor = value; }
		}

		public System.Drawing.Color ListForeColor {
			get { return lvwA.ForeColor; }
			set { lvwA.ForeColor = value; }
		}

		public System.Drawing.Color GroupBackColor {
			get { return grpHolder.BackColor; }
			set {
				grpHolder.BackColor = value;
				this.BackColor = value;
			}
		}

		[System.ComponentModel.Browsable(false)]
		public ListView zUnderlyingObject {
			get { return lvwA; }
		}

		/// <summary>
		/// Gets a String Array of the Selected Texts for the Column you specify
		/// </summary>
		/// <param name="intColumnNumber">Zero Based Index of the Column</param>
		/// <value></value>
		/// <returns>Returns a String Array of selected values. To remove empty values use: Strings.ArrayRemoveEmpty(dlvSample.ItemsSelectedArray)</returns>
		/// <remarks></remarks>
        [System.ComponentModel.Browsable(false)]
        public List<string> ItemsSelectedList(int intColumnNumber)
        {
            try
            {
                List<string> glOut = new List<string>();
                if (lvwA.SelectedItems.Count == 0) { return glOut; }
                for (int i = 0; i <= lvwA.SelectedItems.Count - 1; i++)
                {
                    glOut.Add(lvwA.SelectedItems[i].SubItems[intColumnNumber].Text);
                }
                return glOut;
            }
            catch
            {
                return new List<string>();
            }

        }

		#endregion

		#region "    Select All Remove Selected etc...    "

		/// <summary>Remove all selected items from the list view</summary>
        public void ItemsRemoveAllSelected()
        {
            xLV.RemoveAllSelected(lvwA, true);
        }

		/// <summary>Remove all non selected items from the list view</summary>
        public void ItemsRemoveAllNotSelected()
        {
            xLV.RemoveAllSelected(lvwA, false);
        }

		/// <summary>Select all items</summary>
        public void ItemsSelectAll()
        {
            xLV.SelectAllItems(lvwA);
        }

		/// <summary>Move all selected items up one</summary>
        public void ItemsSelectedMoveUp()
        {
            xLV.MoveListViewItems(lvwA, true);
        }

		/// <summary>Move all selected items down one</summary>
        public void ItemsSelectedMoveDn()
        {
            xLV.MoveListViewItems(lvwA, false);
        }

		/// <summary>Select None</summary>
        public void ItemsUnSelectAll()
        {
            xLV.SelectNone(lvwA);
        }

		/// <summary>Invert the selection of all items</summary>
		public void ItemsSelectedInvert()
		{
			xLV.SelectionInvert(lvwA);
		}

		#endregion

		#region "    DATA LOADING METHODS    "

		/// <summary>Clear all objects and listview</summary>
		public void Clear()
		{
			mDataHoldingObject = null;
			lvwA.ListViewItemSorter = null;
			lvwA.Sorting = SortOrder.None;
			lvwA.Items.Clear();
		}

		/// <summary>Loads the ListView from Columns and ListItems</summary>
		/// <param name="lvccColumns">Columns</param>
		/// <param name="lvicItems">Items</param>
		public void LoadView(ref ListView.ColumnHeaderCollection lvccColumns, ref ListView.ListViewItemCollection lvicItems)
		{
			Clear();

			if ((lvccColumns != null)) {
				if (lvwA.Columns.Count != lvccColumns.Count) {
					lvwA.Columns.Clear();
					for (int i = 0; i <= lvccColumns.Count - 1; i++) {
						lvwA.Columns.Add(lvccColumns[i]);
					}
				}
			}
			if ((lvicItems != null)) {
				lvwA.Items.AddRange(lvicItems);
			}
		}



		///<summary> Loads the ListView From the contents of a DataSet</summary> 
		///<example> 
		///<code>
		///dsWork = xDB.RetrieveDS("Select * FROM street")
		///object.LoadView(dsWork)
		///</code>
		///</example> 
		///<param name="dsLoad">System.Data.DataSet object containing the records you wish to display</param> 
		///<param name="intTableNumber">optional Long Object, Defaults to 0.  Defines which table to load</param> 
		///<param name="strNullText">optional String object, Defaults to "Null".  Database Null Values are replaced with this value</param> 
		public void LoadView(System.Data.DataSet dsLoad, int intTableNumber = 0, string strNullText = "", long lngMaxDisplayCount = 1000000)
		{
			try {
				mDataHoldingObject = dsLoad;
				if ((dsLoad.Tables[intTableNumber] != null)) {
					LoadView(dsLoad.Tables[intTableNumber], strNullText, lngMaxDisplayCount);
				}
			} catch (Exception ex) {
				Debug.WriteLine(ex);
				throw;
			}
		}

		///<summary> 
		///Loads the ListView From the contents of a DataTable
		///</summary> 
		///<example> 
		///<code>
		///Dim dtWork as System.Data.DataTable
		///dtWork = xDB.RetrieveDT("Select * FROM street")
		///object.LoadView(dtWork)
		///</code>
		///</example> 
		///<param name="dtLoad">System.Data.DataTable object containing the records you wish to display</param> 
		///<param name="strNullText">optional String object, Defaults to "Null" Database Null Values are replaced with this value</param> 
		public void LoadView(System.Data.DataTable dtLoad, string strNullText = "", long lngMaxDisplayCount = 1000000)
		{
			try {
				if ((dtLoad != null)) {
					mDataHoldingObject = dtLoad;
					LoadView(dtLoad.Select(), strNullText, lngMaxDisplayCount);
				}
			} catch (Exception ex) {
				Debug.WriteLine(ex);
				throw;
			}
		}

		/// <summary>
		/// Returns True if the Columns in the ListView are the same as the Data Table
		/// </summary>
		/// <param name="dtCols">A DataTable with Columns to compare to</param>
		/// <returns>True if the Columns Match</returns>
		private bool ColumnsCompare(DataTable dtCols)
		{
			var _with3 = lvwA;
			if (mColumnHeaders == null || dtCols == null) {
				return false;
			}
			if ((mColumnHeaders.Length == lvwA.Columns.Count) & mColumnHeaders.Length == (dtCols.Columns.Count + 1)) {
				for (int i = 0; i <= dtCols.Columns.Count - 1; i++) {
					if (mColumnHeaders[i + 1].strField != dtCols.Columns[i].ColumnName) {
						return false;
					}
				}
			} else {
				return false;
			}
			return true;
		}

		public void LoadColumns(DataTable dtCols)
		{
			int o = 0;
            lvwA.SuspendLayout();
            lvwA.Columns.Clear();
			mColumnHeaders = new clsListView.clsColumnHeaderExtender[2];
			mColumnHeaders = new clsListView.clsColumnHeaderExtender[dtCols.Columns.Count + 2];
            lvwA.FullRowSelect = true;
			foreach (DataColumn dCol in dtCols.Columns) {
				o = o + 1;
				mColumnHeaders[o] = new clsListView.clsColumnHeaderExtender(dCol);
				if (mColumnHeaders[o].strValue.Trim().Length > 0) {
                    lvwA.Columns.Add(mColumnHeaders[o].strValue, xLV.ColumnHeaderWidthFromDataColumn(dCol), HorizontalAlignment.Left);
				}
			}

            lvwA.Refresh();
		}

		///<summary>                                                                                                 
		///Loads the ListView From the contents of a DataRow Array                                                   
		///</summary>                                                                                                
		///<example>                                                                                                 
		///<code>                                                                                                    
		///                                                                                                          
		///     Dim dsWork As System.Data.DataSet                   ' Create a DataSet                               
		///     Dim rwWork() As System.Data.DataRow                 ' Create an Array of Rows                        
		///     dsWork = xDB.RetrieveDS("SELECT * FROM code")       ' Load the DataSet                               
		///     rwWork = dsWork.Tables(0).Select("type = 'AX'", "") ' Fill the rows from a Filter of the DataSet     
		///     object.LoadView(rwWork)                                                                              
		///                                                                                                          
		///</code>                                                                                                   
		///</example>                                                                                                
		///<param name="drLoad">System.Data.DataRow object containing the records you wish to display</param>        
		///<param name="strNullText">optional String object, Defaults to "Null" Database Null Values are replaced with this value</param> 
		public void LoadView(System.Data.DataRow[] drLoad, string strNullText = "", long lngMaxDisplayCount = 1000000)
		{
			//string strE = "";
			string strT = "";
			int i = 0;
			int o = 0;
			System.Drawing.Color clrX = default(System.Drawing.Color);
			System.Windows.Forms.ListViewItem Itmx = default(System.Windows.Forms.ListViewItem);
			//Dim ColX As System.Windows.Forms.ColumnHeader
			//Dim dCol As System.Data.DataColumn
			InternalErrorEventArgs dx = default(InternalErrorEventArgs);
			System.Windows.Forms.SortOrder pSort = lvwA.Sorting;
			System.Collections.IComparer pComparer = lvwA.ListViewItemSorter;
			lvwA.ListViewItemSorter = null;

			lvwA.Sorting = SortOrder.None;

			try {
				this.Cursor = Cursors.WaitCursor;
				//Dim cHead As clsColumnHeaderExtender
				if (mDataHoldingObject == null) {
					mDataHoldingObject = drLoad;
				}
				lvwA.View = View.Details;
                try
                {
                    if (drLoad.Length == 0)
                    {
                        lvwA.Items.Clear();
                        return;
                    }
                }
                catch (System.IndexOutOfRangeException ex) { return; }
                catch (Exception ex) { throw; }
                if (drLoad[0] == null) { return; }

				if (drLoad[0].Table == null) {return;} 
                else {
					if (ColumnsCompare(drLoad[0].Table)) {
						lvwA.Items.Clear();
					} else {
						lvwA.Clear();
						LoadColumns(drLoad[0].Table);
					}
				}

				if (drLoad.Length > 0) {
					o = 0;
                    lvwA.Refresh();
					System.Windows.Forms.Application.DoEvents();
                    lvwA.SuspendLayout();

                    foreach (DataRow dRow in drLoad)
                    {
						try {
							Itmx = new System.Windows.Forms.ListViewItem();

							if (dRow.ItemArray[0] == DBNull.Value) {
								strT = strNullText;
							} else {
								strT = Convert.ToString(dRow.ItemArray[0]);
							}
                            Itmx = lvwA.Items.Add(strT);

							if (strT == strNullText)
								Itmx.ForeColor = System.Drawing.Color.DimGray;
							for (i = dRow.ItemArray.GetLowerBound(0) + 1; i <= dRow.ItemArray.GetUpperBound(0); i++) {
								if (dRow.ItemArray[i]==DBNull.Value) {
									strT = strNullText;
									clrX = System.Drawing.Color.DimGray;
								} else {
									try {
										strT = "";
										clrX = System.Drawing.Color.White;
										strT = Convert.ToString(dRow.ItemArray[i]);
									} catch {
									}
								}
								Itmx.SubItems.Add(strT).ForeColor = clrX;
							}

						} catch (Exception ex) {
							dx = new InternalErrorEventArgs("Adding a Row to the ListView.", ex);
							dx.CancelOperation = false;
							dx.IsCancelable = true;
                            if (ActionRowAddError != null) { ActionRowAddError(this, dx); }
                            if (dx.CancelOperation) { return; }
						}
					}
				}
				// drLoad.Length

			} catch (Exception ex) {
				Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! DataListViewControlError");
				Debug.WriteLine(strT);
				Debug.WriteLine(ex);
				Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + o);
				throw;
			} finally {
				lvwA.ResumeLayout();
				this.Cursor = Cursors.Default;
				if (pSort != SortOrder.None) {
					lvwA.Sorting = pSort;
					lvwA.ListViewItemSorter = pComparer;
					lvwA.Sort();
				}
				this.Invalidate();
			}

		}

		#endregion

		#region "    Helper Methods    "

		/// <summary>Exports the ListView Contents to an Html file in the users temp folder and returns the File Name it created</summary>
		/// <param name="strTitle">Main Title</param>
		/// <param name="strSubTitle">Sub Title</param>
		/// <returns>The Fullpath and filename to the newly created HTM File</returns>
		public string ActionPrintToHtml(string strTitle, string strSubTitle, string strIMG = "", string strAdditionalHeader = "", string strAdditionalFooter = "")
		{
            DataTable dt = GridDT;
            if (dt == null) { return null; }
            dt.Namespace = CaptionGrid;
            dt.TableName = Strings.DateLongString(DateTime.Now);
            Dry.Framework.Options.HTMLOutputOptions Opt = new Dry.Framework.Options.HTMLOutputOptions() { H1Title = strTitle, H6Title = strSubTitle, ImageLogo = strIMG, AdditionalHeader = strAdditionalHeader, AdditionalFooter = strAdditionalFooter };
            string strTempFile = Files.TemporaryFileCreateAndReturnFileName(".html");
            Files.ExportHTMLWithStyle(dt, strTempFile, null);
            Files.OpenFileWithItsAssociation(strTempFile);
            return strTempFile;
		}

		/// <summary>Retrieves the item at the specified location</summary>
		public System.Windows.Forms.ListViewItem GetItemAt(int x, int y)
		{
			return lvwA.GetItemAt(x, y);
		}


		#endregion

		#region "    User interaction Event Propagation    "

		/// <summary>Invalidate and refresh the list view control</summary>
		public void InvokeViewRefresh()
		{
			lvwA.Invalidate();
			lvwA.Refresh();
		}

		/// <summary>Invoke a row double click</summary>
		public void InvokeRowDoubleClick()
		{
			lvwA_DoubleClick(null, null);
		}

		/// <summary>Invoke a row click</summary>
		public void InvokeRowClick()
		{
			lvwA_Click(null, null);
		}

		/// <summary>Perform a sort operation</summary>
		/// <param name="intColumn">Column index to sort</param>
		/// <param name="SortMethod">Sort method</param>
		/// <param name="eSortOrder">Sort Order</param>
		public void SortManual(int intColumn, clsListView.colType SortMethod, System.Windows.Forms.SortOrder eSortOrder)
		{
			//lvwA.ListViewItemSorter = (System.Collections.IComparer)(IComparer<clsListView.clsLvwSorter>)new clsListView.clsLvwSorter(intColumn, SortMethod, eSortOrder);
            lvwA.ListViewItemSorter = (System.Collections.IComparer)new clsListView.clsLvwSorter(intColumn, SortMethod, eSortOrder);
        }

        private void lvwA_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            try
            {
                if (KeyMod.CTL) { GroupByColumn(e.Column); } /* Group by Clicked Column */
                else if (KeyMod.SHT) { GroupByColumn(-1); }  /* Turn Off Grouping */

                clsListView.colType eSortType = clsListView.colType.ColumnSortText;
                eSortType = mColumnHeaders[e.Column + 1].SortType;
                if (lvwA.Sorting == SortOrder.Ascending) { lvwA.Sorting = SortOrder.Descending; }
                else { lvwA.Sorting = SortOrder.Ascending; }
                lvwA.ListViewItemSorter = (System.Collections.IComparer)new clsListView.clsLvwSorter(e.Column, eSortType, lvwA.Sorting);
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

		private void lvwA_DoubleClick(object sender, System.EventArgs e)
		{
			//DRYID201003030142P
			try {
				if (lvwA.SelectedItems.Count > 0) {
					if (ActionRowDoubleClick != null) {
						ActionRowDoubleClick(this, new dlvSelectionChangedEventArgs(lvwA.SelectedIndices[0], lvwA.SelectedItems[0]));
					}
				}
			} catch {
			}
		}

		private void lvwA_Click(object sender, System.EventArgs e)
		{
			//DRYID201003030142P
			try {
				if (lvwA.SelectedItems.Count > 0) {
					if (ActionRowClick != null) {
						ActionRowClick(this, new dlvSelectionChangedEventArgs(lvwA.SelectedIndices[0], lvwA.SelectedItems[0]));
					}
				}
			} catch {
			}
		}

		private void ucDataLView_GotFocus(object sender, System.EventArgs e)
		{
			try {
				lvwA.Focus();
			} catch {
			}
		}

		private void lvwA_LocationChanged(object sender, System.EventArgs e)
		{
			if (ActionRowLocationChanged != null) {
				ActionRowLocationChanged(this, e);
			}
		}

		private void lvwA_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//DRYID201003030142P
			try {
				if (e.KeyCode == Keys.Enter) {
					if (lvwA.SelectedItems.Count > 0) {
						//Pressing Enter Key on a record same as Double Clicking on record
						if (ActionRowDoubleClick != null) {
							ActionRowDoubleClick(this, new dlvSelectionChangedEventArgs(lvwA.SelectedIndices[0], lvwA.SelectedItems[0]));
						}
					}
				}
				if (ActionKeyDown != null) {
					ActionKeyDown(this, e);
				}
			} catch {
			}
		}

		private void lvwA_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (ActionKeyPress != null) {
				ActionKeyPress(this, e);
			}
		}

        private void lvwA_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string CRLF = Environment.NewLine;
            if (ActionKeyUp != null) { ActionKeyUp(this, e); }

            if (e.Handled == false)
            {
                if (e.KeyCode == Keys.F12)
                {
                    if (KeyMod.CTL && KeyMod.ALT && KeyMod.SHT)
                    {
                        InvokePrintPreviewButton();
                    }
                }
                else if (e.KeyCode == Keys.F11)
                {
                    if (KeyMod.CTL && KeyMod.ALT && KeyMod.SHT)
                    {
                        if (lvwA.SelectedItems.Count >= 1)
                        {
                            dlvSelectionChangedEventArgs That = new dlvSelectionChangedEventArgs(lvwA.SelectedIndices[0], lvwA.SelectedItems[0]);
                            if (ActionCASF11Press != null) { ActionCASF11Press(this, That); }
                        }
                    }
                }
                else if (e.KeyCode == Keys.W)
                {
                    if (KeyMod.CTL && KeyMod.ALT && KeyMod.SHT)
                    {
                        string strColumnNames = "Item Count: " + ItemCount + Environment.NewLine;
                        try
                        {
                            if (GridDT != null)
                            {
                                foreach (DataColumn dc in GridDT.Columns)
                                {
                                    strColumnNames += "Column " + dc.Ordinal.ToString().PadLeft(3) + " " + dc.ColumnName.PadRight(40) + " (" + dc.DataType.ToString() + ")" + Environment.NewLine;
                                }
                            }
                        }
                        catch { }
                        string msg = GetWidthString() + CRLF + CRLF + @".ColumnDisplayOrderPipe(""" + ColumnDisplayOrderPipe() + @""")" + CRLF + CRLF + "Item Count: " + ItemCount + CRLF + CRLF + "Selected Count: " + SelectedItemCount + CRLF + CRLF + "Column Count: " + ColumnCount + CRLF + strColumnNames;
                        Program.DisplayABigString(msg, this, "Data List View Column Information");
                    }
                }
                else if (e.KeyCode == Keys.D)
                {
                    if (KeyMod.CTL && KeyMod.ALT && KeyMod.SHT)
                    {
                        string strColumnNames = "Item Count: " + ItemCount + Environment.NewLine;
                        try
                        {
                            if (GridDT != null)
                            {
                                string msg = Dry.Framework.DAL.Database.devReturnDTString(GridDT, 5000);
                                Program.DisplayABigString(msg, this, "Data List View Table Information");
                            }
                        }
                        catch { }
                    }
                }
                if (e.KeyCode == Keys.OemMinus && KeyMod.CTL && !KeyMod.ALT && !KeyMod.SHT) { InvokeAutoColumnSizeFit(); }
            }
        }

		/// <summary>Resizes the width of the columns as indicated by the resize style.</summary>
		/// <param name="o">Auto Resize Style</param>
		public void InvokeAutoColumnSize(System.Windows.Forms.ColumnHeaderAutoResizeStyle o)
		{
			//mynAutoSizingColumns = True
			lvwA.AutoResizeColumns(o);
			this.Refresh();
		}
        
        /// <summary>Resizes the width of the columns as indicated by the resize style.</summary>
        /// <param name="o">Auto Resize Style</param>
        public void InvokeAutoColumnSizeFit()
        {
            int intCount = lvwA.Columns.Count;
            int intWidith = lvwA.Width;
            int intColWid = (intWidith / intCount);
            foreach (ColumnHeader col in lvwA.Columns) { col.Width = intColWid; }
            this.Refresh();
        }

		//Private mynAutoSizingColumns As Boolean = False
		//Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
		//    Const WM_PAINT As Integer = &HF
		//    If mynAutoSizingColumns Then
		//        Select Case m.Msg
		//            Case WM_PAINT
		//                If lvwA.Columns.Count > 0 Then
		//                    SetWidths(-2)
		//                    lvwA.Invalidate()
		//                    mynAutoSizingColumns = False
		//                End If
		//        End Select
		//    End If
		//    MyBase.WndProc(m)
		//End Sub

		private void lvwA_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (ActionMouseClick != null) {ActionMouseClick(this, e);}
		}

		private void lvwA_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (ActionMouseDoubleClick != null) {
				ActionMouseDoubleClick(this, e);
			}
		}

		private void lvwA_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (ActionMouseDown != null) {
				ActionMouseDown(this, e);
			}
		}

		private void lvwA_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (ActionMouseUp != null) {
				ActionMouseUp(this, e);
			}
		}

		private void lvwA_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (ActionMouseWheel != null) {
				ActionMouseWheel(this, e);
			}
		}

		private void lvwA_ColumnReordered(object sender, System.Windows.Forms.ColumnReorderedEventArgs e)
		{
			if (ActionColumnReordered != null) {
				ActionColumnReordered(this, e);
			}
		}

		private void lvwA_ColumnWidthChanged(object sender, System.Windows.Forms.ColumnWidthChangedEventArgs e)
		{
			if (ActionColumnWidthChanged != null) {
				ActionColumnWidthChanged(this, e);
			}
		}

		private void lvwA_ItemChecked(object sender, System.Windows.Forms.ItemCheckedEventArgs e)
		{
			if (ActionItemChecked != null) {
				ActionItemChecked(this, e);
			}
		}

		private void lvwA_ItemSelectionChanged(object sender, System.Windows.Forms.ListViewItemSelectionChangedEventArgs e)
		{
			if (ActionItemSelectionChanged != null) {
				ActionItemSelectionChanged(this, e);
			}
		}

		private void lvwA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ActionSelectedIndexChanged != null) {
				ActionSelectedIndexChanged(this, e);
			}
		}

		#endregion

		#region "    List View Drag Drop Passthrough    "

		//Using the Drag n Drop:
		//
		//Set Destination Control.AllowDrop = True!!!
		//
		//Source Dragee Object:
		//           Private Sub anyControl_MouseDown(ByVal sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles anyControl.MouseDown
		//
		//               Dim objAnyObject As New clsMyObject(1)
		//               anyControl.DoDragDrop(objAnyObject, DragDropEffects.Copy)
		//
		//           End Sub
		//
		//Destination Control (Dropped onto Object)
		//           Private Sub destinationControl_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles destinationControl.DragEnter
		//               If e.Data.GetDataPresent(GetType(clsMyObject)) Then
		//                   e.Effect = DragDropEffects.Copy ' Yes We will Accept an object of type clsMyObject
		//                   destinationControl.BorderStyle = BorderStyle.FixedSingle  ' Lets Give user a visual of our acceptance.
		//               Else
		//                   e.Effect = DragDropEffects.None
		//               End If
		//           End Sub
		//
		//           Private Sub destinationControl_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles destinationControl.DragOver
		//               If e.Data.GetDataPresent(GetType(clsMyObject)) Then
		//                   If My.Computer.Keyboard.CtrlKeyDown = True Then
		//                       e.Effect = DragDropEffects.Move
		//                   Else
		//                       e.Effect = DragDropEffects.Copy
		//                   End If
		//                   destinationControl.BorderStyle = BorderStyle.FixedSingle  ' Lets Give user a visual of our acceptance.
		//               Else
		//                   e.Effect = DragDropEffects.None
		//               End If
		//           End Sub
		//
		//           Private Sub destinationControl_DragLeave(ByVal sender As Object, ByVal e As EventArgs) Handles destinationControl.DragLeave
		//               destinationControl.BorderStyle = BorderStyle.Fixed3D
		//           End Sub
		//
		//           Private Sub destinationControl_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles destinationControl.DragEnter
		//               If e.Data.GetDataPresent(GetType(clsMyObject)) Then
		//                   Dim objDropObject As clsMyObject = e.Data.GetData(GetType(clsMyObject)), clsMyObject)
		//                   e.Effect = DragDropEffects.Copy ' Yes We will Accept an object of type clsMyObject
		//                   destinationControl.BorderStyle = BorderStyle.FixedSingle  ' Lets Give user a visual of our acceptance.
		//               Else
		//                   e.Effect = DragDropEffects.None
		//               End If
		//           End Sub
		//
		//
		//
		[System.ComponentModel.DefaultValue(false)]
		public override bool AllowDrop {
//Return MyBase.AllowDrop
			get { return lvwA.AllowDrop; }
			set {
				base.AllowDrop = false;
				lvwA.AllowDrop = value;
			}
		}

		/// <summary>
		/// This event is fired upon completion of a Drag Drop event (should fire once)
		/// </summary>
		public event ActionDragDropEventHandler ActionDragDrop;
		public delegate void ActionDragDropEventHandler(object sender, System.Windows.Forms.DragEventArgs e);
		/// <summary>
		/// This event is fired when an object is dragged over the control (should fire once)
		/// </summary>
		public event ActionDragEnterEventHandler ActionDragEnter;
		public delegate void ActionDragEnterEventHandler(object sender, System.Windows.Forms.DragEventArgs e);
		/// <summary>
		/// This event is fired when an object is dragged over the control (should fire repeatedly)
		/// </summary>
		public event ActionDragOverEventHandler ActionDragOver;
		public delegate void ActionDragOverEventHandler(object sender, System.Windows.Forms.DragEventArgs e);
		/// <summary>
		/// This event is fired when an object is dragged off the control (should fire once)
		/// </summary>
		public event ActionDragLeaveEventHandler ActionDragLeave;
		public delegate void ActionDragLeaveEventHandler(object sender, System.EventArgs e);

		private void lvwA_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (lvwA.AllowDrop == false)
				return;
			if (ActionDragDrop != null) {
				ActionDragDrop(this, e);
			}
		}

		private void lvwA_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (ActionDragEnter != null) {
				ActionDragEnter(this, e);
			}
		}

		private void lvwA_DragLeave(object sender, System.EventArgs e)
		{
			if (ActionDragLeave != null) {
				ActionDragLeave(this, e);
			}
		}

		private void lvwA_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (ActionDragOver != null) {
				ActionDragOver(this, e);
			}
		}

		#endregion

		#region "    Button Clicking    "

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			try {
				InvokeRefreshButton();
			} catch (Exception ex) {
				Debug.Write(new ExpanderOfException(ex).Message);
			}
		}

		private void btnHTMLPreview_Click(System.Object sender, System.EventArgs e)
		{
			try {
				InvokePrintPreviewButton();
			} catch (Exception ex) {
				Debug.Write(new ExpanderOfException(ex).Message);
			}
		}

		private void btnItemRemove_Click(object sender, System.EventArgs e)
		{
			try {
				if (lvwA.SelectedItems.Count == 0)
					return;
				if (ActionItemRemoveButtonClick != null) {
					ActionItemRemoveButtonClick(this, new dlvSelectionChangedEventArgs(lvwA.SelectedIndices[0], lvwA.SelectedItems[0]));
				}
			} catch (Exception ex) {
				Debug.Write(new ExpanderOfException(ex).Message);
			}
		}

		private void btnAddItem_Click(object sender, System.EventArgs e)
		{
			try {
				if (lvwA.SelectedItems.Count == 0) {
					if (ActionItemAddButtonClick != null) {
						ActionItemAddButtonClick(this, new dlvSelectionChangedEventArgs());
					}
				} else {
					if (ActionItemAddButtonClick != null) {
						ActionItemAddButtonClick(this, new dlvSelectionChangedEventArgs(lvwA.SelectedIndices[0], lvwA.SelectedItems[0]));
					}
				}
			} catch (Exception ex) {
				Debug.Write(new ExpanderOfException(ex).Message);
			}
		}
		#endregion

		/// <summary>
		/// Raises ActionPrintPreviewClick Offering Consumer a chance to handle, if not handled then Creates an HTML file in the users Temp Dir and launches it with the systems default htm handler.
		/// </summary>
		public void InvokePrintPreviewButton()
		{
			HandleableEventArgs You = new HandleableEventArgs(Handling.IsHandledUnlessYouHandled);
			if (ActionPrintPreviewClick != null) {
				ActionPrintPreviewClick(this, You);
			}
			if (You.Handled == true)
				return;
			DataTable dt = GridDT;
			if (dt == null) {
				string strFile = ActionPrintToHtml(CaptionGrid, Strings.DateLongString(DateTime.Now));
				Files.OpenFileWithItsAssociation(strFile);
				return;
			}
			dt.Namespace = CaptionGrid;
			dt.TableName = Strings.DateLongString(DateTime.Now);
            Dry.Framework.Options.HTMLOutputOptions Opt = new Dry.Framework.Options.HTMLOutputOptions() { H1Title = CaptionGrid, H6Title = Strings.DateShortString(DateTime.Now) };
            string strTempFile = Files.TemporaryFileCreateAndReturnFileName(".html");
            Files.ExportHTMLWithStyle(dt, strTempFile, null);
            Files.OpenFileWithItsAssociation(strTempFile);
		}

		/// <summary>
		/// Raises ActionRefreshClick (normally occures when user click on little refresh button. (if ShowRefreshButton = True))
		/// </summary>
		public void InvokeRefreshButton()
		{
			if (ActionRefreshClick != null) {
				ActionRefreshClick(this, new EventArgs());
			}
		}

		private void lvwA_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (ActionMouseMove != null) {
				ActionMouseMove(this, e);
			}
		}

    } // End ucDataLView

    // #######################################################################################################
    // #######################################################################################################

	public class clsListView
	{

		public enum colType
		{
			ColumnSortText = 0,
			ColumnSortNumber = 1,
			ColumnSortDate = 2
		}


		private clsColumnHeaderExtender[] mColumnHeaders;
		#region "    Data Column Loading Routines    "

		///<summary> Load the Columns in a Data Table into a ListView</summary> 
		///<example> 
		///        Dim dtIN As System.Data.DataTable
		///
		///        dtIN = xDB.RetrieveDT(strSQL)
		///
		///        object.LoadColumns(lvwFields, dtIN)
		///
		///</example> 
		///<param name="lvwIN">ListView Object to Modify</param>
		///<param name="dtIN">DataTable containing Columns</param>
		///<param name="ynAddType">Add a Column for Data Type</param>
		///<param name="ynAddMaxLen">Add a Column for Field Max Length</param>
		///<param name="ynAddNull">Add a Column for Field Nullability</param>
		///<param name="ynAddDefault">Add a Column for Default Value</param>
		public static void LoadColumns(ListView lvwIN, System.Data.DataTable dtIN, bool ynAddType = false, bool ynAddMaxLen = false, bool ynAddNull = false, bool ynAddDefault = false)
		{
			try {
				System.Data.DataColumn[] dcFields = null;
				int i = 0;

				for (i = 0; i <= dtIN.Columns.Count - 1; i++) {
					Array.Resize(ref dcFields, i + 1);
                    dcFields[i] = new DataColumn(dtIN.Columns[i].ColumnName, dtIN.Columns[i].DataType, dtIN.Columns[i].Expression, dtIN.Columns[i].ColumnMapping);
				}
				LoadColumns(lvwIN, (DataColumn[])dcFields, ynAddType, ynAddMaxLen, ynAddNull, ynAddDefault);
			} catch (Exception ex) {
				Debug.WriteLine(ex);
				throw;
			}
		}

		///<summary> Load the Columns in a Data Column Array into a ListView</summary> 
		///<example> 
		///        Dim dtIN As System.Data.DataTable
		///        Dim dcFields() As System.Data.DataColumn
		///
		///        Dim i As Integer
		///
		///        dtIN = xDB.RetrieveDT(strSQL)
		///
		///        For i = 0 To dtIN.Columns.Count - 1
		///            With dtIN.Columns(i)
		///                ReDim Preserve dcFields(i)
		///                dcFields(i) = New DataColumn(.ColumnName, .DataType, .Expression, .ColumnMapping)
		///            End With
		///        Next
		///
		///        object.LoadColumns(lvwFields, CType(dcFields, DataColumn()))
		///</example> 
		///<param name="lvwIN">ListView Object to Modify</param>
		///<param name="dcIN">DataColumn Array</param>
		///<param name="ynAddType">Add a Column for Data Type</param>
		///<param name="ynAddMaxLen">Add a Column for Field Max Length</param>
		///<param name="ynAddNull">Add a Column for Field Nullability</param>
		///<param name="ynAddDefault">Add a Column for Default Value</param>
		public static void LoadColumns(ListView lvwIN, System.Data.DataColumn[] dcIN, bool ynAddType = false, bool ynAddMaxLen = false, bool ynAddNull = false, bool ynAddDefault = false)
		{
			try {
				ListViewItem ItmX = default(ListViewItem);
				int i = 0;

                lvwIN.Items.Clear();
                lvwIN.BeginUpdate();
				for (i = dcIN.GetLowerBound(0); i <= dcIN.GetUpperBound(0); i++) {
					ItmX = lvwIN.Items.Add(dcIN[i].ColumnName);
					try {
						ItmX.Tag = dcIN[i].Caption;
					} catch {
					}
					if (ynAddType) {
						ItmX.SubItems.Add(dcIN[i].DataType.ToString());
					}
					if (ynAddMaxLen) {
                        ItmX.SubItems.Add(dcIN[i].MaxLength.ToString());
					}
					if (ynAddNull) {
                        ItmX.SubItems.Add(dcIN[i].AllowDBNull.ToString());
					}
					if (ynAddDefault) {
                        ItmX.SubItems.Add(dcIN[i].DefaultValue.ToString());
					}
				}
			} catch (Exception ex) {
				Debug.WriteLine(ex);
				throw;
			} finally {
				lvwIN.EndUpdate();
			}

		}

		#endregion


		#region "    DATA LOADING METHODS    "


		///<summary> 
		///Loads the ListView From the contents of a DataSet
		///</summary> 
		///<example> 
		///<code>
		///dsWork = xDB.RetrieveDS("Select * FROM street")
		///object.LoadView(dsWork)
		///</code>
		///</example> 
		///<param name="lvwIN">ListView Object</param>
		///<param name="dsLoad">System.Data.DataSet object containing the records you wish to display</param> 
		///<param name="intTableNumber">optional Long Object, Defaults to 0.  Defines which table to load</param> 
		///<param name="strNullText">optional String object, Defaults to "Null".  Database Null Values are replaced with this value</param> 
		///<param name="lngMaxDisplayCount">Maximum Records To load into the Listview</param>
		public void LoadListView(ListView lvwIN, System.Data.DataSet dsLoad, int intTableNumber = 0, string strNullText = "", long lngMaxDisplayCount = 1000000)
		{
			try {
				if ((dsLoad.Tables[intTableNumber] != null)) {
					LoadListView(lvwIN, dsLoad.Tables[intTableNumber], strNullText, lngMaxDisplayCount);
				}

			} catch (Exception ex) {
			}
		}

		///<summary> 
		///Loads the ListView From the contents of a DataTable
		///</summary> 
		///<example> 
		///<code>
		///Dim dtWork as System.Data.DataTable
		///dtWork = xDB.RetrieveDT("Select * FROM street")
		///object.LoadView(dtWork)
		///</code>
		///</example> 
		///<param name="lvwIN">ListView Object</param>
		///<param name="dtLoad">System.Data.DataTable object containing the records you wish to display</param> 
		///<param name="strNullText">optional String object, Defaults to "Null".  Database Null Values are replaced with this value</param> 
		///<param name="lngMaxDisplayCount">Maximum Records To load into the Listview</param>
		public void LoadListView(ListView lvwIN, System.Data.DataTable dtLoad, string strNullText = "", long lngMaxDisplayCount = 1000000)
		{
			try {
				if ((dtLoad != null)) {
					LoadListView(lvwIN, dtLoad.Select(), strNullText, lngMaxDisplayCount);
				}

			} catch {}
		}


		#region "    Comments   "
		///<summary>                                                                                                 
		///Loads the ListView From the contents of a DataRow Array                                                   
		///</summary>                                                                                                
		///<example>                                                                                                 
		///<code>                                                                                                    
		///                                                                                                          
		///     Dim dsWork As System.Data.DataSet                   ' Create a DataSet                               
		///     Dim rwWork() As System.Data.DataRow                 ' Create an Array of Rows                        
		///     dsWork = xDB.RetrieveDS("SELECT * FROM code")       ' Load the DataSet                               
		///     rwWork = dsWork.Tables(0).Select("type = 'AX'", "") ' Fill the rows from a Filter of the DataSet     
		///     object.LoadView(rwWork)                                                                              
		///                                                                                                          
		///</code>                                                                                                   
		///</example>                                                                                                
		///<param name="lvwIN">ListView Object</param>
		///<param name="drLoad">System.Data.DataRow Array containing the records you wish to display</param> 
		///<param name="strNullText">optional String object, Defaults to "Null".  Database Null Values are replaced with this value</param> 
		///<param name="lngMaxDisplayCount">Maximum Records To load into the Listview</param>
		///<remarks></remarks>                                                                                       
		#endregion
		public void LoadListView(ListView lvwIN, System.Data.DataRow[] drLoad, string strNullText = "", long lngMaxDisplayCount = 1000000)
		{
			//string strE = null;
			string strT = null;
			int i = 0;
			int o = 0;
			System.Drawing.Color clrX = default(System.Drawing.Color);
			System.Windows.Forms.ListViewItem Itmx = default(System.Windows.Forms.ListViewItem);

			lvwIN.Clear();
			lvwIN.View = View.Details;

			lvwIN.SuspendLayout();
			lvwIN.Columns.Clear();
			mColumnHeaders = new clsColumnHeaderExtender[2];
			mColumnHeaders = new clsColumnHeaderExtender[drLoad[0].Table.Columns.Count + 2];
			lvwIN.FullRowSelect = true;
			if (drLoad.Length > 0) {
				o = 0;
				foreach (DataColumn dCol in drLoad[0].Table.Columns) {
					o = o + 1;
					mColumnHeaders[o] = new clsListView.clsColumnHeaderExtender(dCol);
					if (mColumnHeaders[o].strValue.Trim().Length > 0) {
						lvwIN.Columns.Add(mColumnHeaders[o].strValue, ColumnHeaderWidthFromDataColumn(dCol), HorizontalAlignment.Left);
					}
				}

				lvwIN.Refresh();

				foreach (DataRow dRow in drLoad) {
					Itmx = new System.Windows.Forms.ListViewItem();
					if (dRow.ItemArray[i] == null || dRow.ItemArray[i] == DBNull.Value) 
                         { strT = strNullText; } 
                    else { strT = dRow.ItemArray[0].ToString();}

					Itmx = lvwIN.Items.Add(strT);

					if (strT == strNullText)
						Itmx.ForeColor = System.Drawing.Color.DimGray;
					for (i = dRow.ItemArray.GetLowerBound(0) + 1; i <= dRow.ItemArray.GetUpperBound(0); i++) {
						if (dRow.ItemArray[i] == null || dRow.ItemArray[i] == DBNull.Value ) {
							strT = strNullText;
							clrX = System.Drawing.Color.DimGray;
						} else {
							strT = "";
							clrX = System.Drawing.Color.White;
							strT = dRow.ItemArray[i].ToString();
						}
						Itmx.SubItems.Add(strT).ForeColor = clrX;
					}
				}
			}
			lvwIN.ResumeLayout();
            //return;
            //LoadView_Err:
            //strE = Err.Number + " - " + Err.Description + Environment.NewLine + Err.Source + " (" + Err.Erl + ")" + strT;
            //Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //Debug.WriteLine(strE);
            //Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //switch (MessageBox.Show(strE, "Error Loading View", MessageBoxButtons.AbortRetryIgnore , MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)) {
            //    case DialogResult.Abort  :
            //        goto LoadView_Exit;
            //        break;
            //    case DialogResult.Retry:

            //        break;
            //    case DialogResult.Ignore:
            //         // ERROR: Not supported in C#: ResumeStatement

            //        break;
            //}
		}

		#endregion

		#region "    Selection Routines    "

		public static System.Windows.Forms.ListViewItem SelectItemByText(ref System.Windows.Forms.ListView lvwIN, string strText, bool ynThereCanBeOnlyOne = true)
		{
			int i = 0;
			int x = 0;
            lvwIN.BeginUpdate();
            for (i = 0; i <= lvwIN.Items.Count - 1; i++)
            {
                if (lvwIN.Items[i].Text == strText)
                {
                    lvwIN.Items[i].Selected = true;
					x = i;
				} else {
					if (ynThereCanBeOnlyOne) {
                        lvwIN.Items[i].Selected = false;
					}
				}
			}
            lvwIN.EndUpdate();
			if (x >= 0) {
                return lvwIN.Items[x];
			} else {
				return null;
			}

		}

        public static bool SelectNextListItem(ref ListView lvwObject)
        {
            int i = 0;
            var _with5 = lvwObject;
            if (_with5.SelectedItems.Count > 0)
            {
                i = lvwObject.Items.IndexOf(lvwObject.SelectedItems[0]);
                lvwObject.SelectedItems[0].Selected = false;
                if ((lvwObject.Items[i + 1] != null))
                {
                    lvwObject.Items[i + 1].Selected = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (lvwObject.SelectedItems.Count == 0)
            {
                if ((lvwObject.Items[0] != null))
                {
                    lvwObject.Items[0].Selected = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


        public static bool SelectPrevListItem(ref ListView lvwObject)
        {
            int i = 0;
            if (lvwObject.SelectedItems.Count > 0)
            {
                i = lvwObject.Items.IndexOf(lvwObject.SelectedItems[0]);
                lvwObject.SelectedItems[0].Selected = false;
                if ((lvwObject.Items[i - 1] != null))
                {
                    lvwObject.Items[i - 1].Selected = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (lvwObject.SelectedItems.Count == 0)
            {
                if ((lvwObject.Items[0] != null))
                {
                    lvwObject.Items[0].Selected = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

		#endregion

		public int ColumnHeaderWidthFromDataColumn(System.Data.DataColumn dColumn)
		{
			switch (Types.FromName(dColumn.DataType.Name)) {
				case  Dry.Framework.StandardTypes.BitType:
					return 4;
				case  Dry.Framework.StandardTypes.IntType:
					return 30;
				case  Dry.Framework.StandardTypes.MoneyType:
					return 30;
				case  Dry.Framework.StandardTypes.VarCharType: case Dry.Framework.StandardTypes.CharType:
					return 80;
				case  Dry.Framework.StandardTypes.DateTimeType:
					return 80;
				case  Dry.Framework.StandardTypes.GuidType:
					return 60;
				case  Dry.Framework.StandardTypes.BinaryType :
					return 25;
				default: return 30;
			}

		}

		public void RemoveAllSelected(ListView lvw, bool ynWhereSelectedIs)
		{
			for (int i = lvw.Items.Count - 1; i >= 0; i += -1) {
				if (lvw.Items[i].Selected == ynWhereSelectedIs) {
					lvw.Items[i].Remove();
				}
			}
		}

		public void SelectAllItems(ListView lvw)
		{
			for (int i = lvw.Items.Count - 1; i >= 0; i += -1) {
				if (lvw.Items[i].Selected == false) {
					lvw.Items[i].Selected = true;
				}
			}
		}

		public void SelectNone(ListView lvw)
		{
			for (int i = lvw.Items.Count - 1; i >= 0; i += -1) {
				if (lvw.Items[i].Selected == true) {
					lvw.Items[i].Selected = false;
				}
			}
		}

		public void SelectionInvert(ListView lvw)
		{
			for (int i = lvw.Items.Count - 1; i >= 0; i += -1) {
				lvw.Items[i].Selected = !lvw.Items[i].Selected;
			}
		}

		public void MoveListViewItems(ListView lvw, bool ynMoveUp)
		{
			string strCache = null;
			int intSelectedIndex = 0;

			if (ynMoveUp) {

				for (int intSelectedItem = 0; intSelectedItem <= lvw.SelectedItems.Count - 1; intSelectedItem++) {
					intSelectedIndex = lvw.SelectedItems[intSelectedItem].Index;


					// ignore moveup of row(0)
					if (intSelectedIndex == 0) {
						return;
					}
					object obj1 = lvw.Items[intSelectedIndex].Tag;
					object obj2 = lvw.Items[intSelectedIndex - 1].Tag;

					lvw.Items[intSelectedIndex].Tag = obj2;
					lvw.Items[intSelectedIndex - 1].Tag = obj1;

					// move the subitems for the previous row
					// to cache so we can move the selected row up
					for (int i = 0; i <= lvw.Items[intSelectedIndex].SubItems.Count - 1; i++) {
						strCache = lvw.Items[intSelectedIndex - 1].SubItems[i].Text;
						lvw.Items[intSelectedIndex - 1].SubItems[i].Text = lvw.Items[intSelectedIndex].SubItems[i].Text;
						lvw.Items[intSelectedIndex].SubItems[i].Text = strCache;
					}
					lvw.Items[intSelectedIndex - 1].Selected = true;
					lvw.Items[intSelectedIndex].Selected = false;
				}
				lvw.Refresh();
				lvw.Focus();
			} else {

				for (int intSelectedItem = lvw.SelectedItems.Count - 1; intSelectedItem >= 0; intSelectedItem += -1) {
					intSelectedIndex = lvw.SelectedItems[intSelectedItem].Index;
					// ignore move down of last row
					if (intSelectedIndex == lvw.Items.Count - 1) {
						return;
					}
					object obj1 = lvw.Items[intSelectedIndex].Tag;
					object obj2 = lvw.Items[intSelectedIndex + 1].Tag;

					lvw.Items[intSelectedIndex].Tag = obj2;
					lvw.Items[intSelectedIndex + 1].Tag = obj1;

					// move the subitems for the next row
					// to cache so we can move the selected row down
					for (int i = 0; i <= lvw.Items[intSelectedIndex].SubItems.Count - 1; i++) {
						strCache = lvw.Items[intSelectedIndex + 1].SubItems[i].Text;
						lvw.Items[intSelectedIndex + 1].SubItems[i].Text = lvw.Items[intSelectedIndex].SubItems[i].Text;
						lvw.Items[intSelectedIndex].SubItems[i].Text = strCache;
					}
					lvw.Items[intSelectedIndex + 1].Selected = true;
					lvw.Items[intSelectedIndex].Selected = false;
				}
				lvw.Refresh();
				lvw.Focus();
			}

		}

		#region "    Class: List View Column Header Extender    "

		public class clsColumnHeaderExtender : IComparable, ICloneable
		{

			//Property Information:
			//--------------------
			//strValue   Stores the Cleaned up Column Name for Display in a LVW Column Header 
			//strType    Stores the Type of the Field Data (String, Date...)
			//strField   Stores the Actual Field Name
			//SortType   Stores the ListView SortOrder
			//---------------------------------------------------------------------------------

			public colType SortType;

			#region "    Private mFields    "
			private string mstrValue;
			private string mstrField;
			private string mstrType;
            #endregion

			#region "   Constructor "

			public clsColumnHeaderExtender()
			{
				//Just to make the Constructor Parameter optional
				Clear();
				return;
			}

			///<summary>Overloaded Constructor Method</summary>
			///<param name="DataColumnToParse">A valid, System.Data.DataColumn Object</param>
			public clsColumnHeaderExtender(System.Data.DataColumn DataColumnToParse)
			{
				if (DataColumnToParse == null) {
					Clear();
					return;
				} else {
					//Upon Creation of this Object we will be Filling ourself from the DataColumn
					FillFromDataColumn(ref DataColumnToParse);
				}
			}
			#endregion

			#region "    Load the class from a DataColumn    "

			///<summary>Gives you the ability to Fill the Class Properties from a DataColumn Object </summary>
			///<param name="DataColumnToParse">A valid and filled DataColumn Object</param>
			///<returns>Boolean</returns>
			public bool FillFromDataColumn(ref System.Data.DataColumn DataColumnToParse)
			{
				strType = Types.ToDotNetName(DataColumnToParse.DataType.Name);
				if (Strings.SafeString(DataColumnToParse.Caption).Length > 0) {
					strValue = FixFieldName(DataColumnToParse.Caption);
				} else {
					strValue = FixFieldName(DataColumnToParse.ColumnName);
				}
				strField = DataColumnToParse.ColumnName;
				switch (Types.FromName(strType)) {
					case  Dry.Framework.StandardTypes.VarCharType: case Dry.Framework.StandardTypes.CharType: SortType = colType.ColumnSortText; break;
					case  Dry.Framework.StandardTypes.BitType: case Dry.Framework.StandardTypes.IntType: case Dry.Framework.StandardTypes.MoneyType: SortType = colType.ColumnSortNumber; break;
					case  Dry.Framework.StandardTypes.DateTimeType:
						SortType = colType.ColumnSortDate; break;
					case  Dry.Framework.StandardTypes.GuidType:
						SortType = colType.ColumnSortText;
						break;
					default:
                        SortType= colType.ColumnSortText;
						Debug.WriteLine("FillFromDataColumn UNHANDLED!!!:::  " + strType + "    <---------");
						break;
				}
				return true;
			}



			private string FixFieldName(string strFieldName)
			{
				 // ERROR: Not supported in C#: OnErrorStatement

				//
				// Fixes a Field name like:
				//
				//       FixFieldName("strVoter_Name")   Returns: Voter Name
				//       FixFieldName("strVoterName")    Returns: Voter Name
				//       FixFieldName("VoterName")       Returns: Voter Name
				//       FixFieldName("voter_name")      Returns: Voter Name
				//
				const string cStandardNamingPrefix3 = "*str*lng*txt*boo*int*cur*dtm*var*sng*dbl*typ*cls*mem*tbl*";
				const string cStandardNamingPrefix2 = "*yn*do*";
				const string cKnownProblemFieldName = "*street*type*";
				string strTmp = null;
				string strTm2 = null;
				bool ynProp = false;
				int iPos = 0;
				string sTmpName = null;
				ynProp = true;

				// This turns 'FirstName' into 'First Name'
				sTmpName = Strings.Left(strFieldName, 1);
				for (iPos = 1; iPos < strFieldName.Length; iPos++) {
					if (Convert.ToInt16(strFieldName.Substring(iPos, 1)[0]) <= Convert.ToInt16('Z')) {
						sTmpName = sTmpName + " ";
					}
					sTmpName = sTmpName + strFieldName.Substring(iPos, 1);
				}

				strTmp = Strings.Replace(Strings.Replace(Strings.Replace(Strings.Replace(sTmpName.Trim(), "_", " "), "-", " "), "[", ""), "]", "");
				strTm2 = Strings.Replace(strTmp, "  ", " ");
				strTmp = Strings.Replace(strTm2, "  ", " ");
				if (cKnownProblemFieldName.IndexOf(strTmp) == 0) {
					if (cStandardNamingPrefix3.IndexOf(Strings.Left(strTmp + "   ", 3)) == 0) {
						if (cStandardNamingPrefix2.IndexOf(Strings.Left(strTmp, 2)) == 0) {
							ynProp = true;
						} else {
							strTm2 = Strings.Right(strTmp, strTmp.Length - 2);
							strTmp = strTm2;
						}
					} else {
						strTm2 = Strings.Right(strTmp, strTmp.Length - 3);
						strTmp = strTm2;
					}
				}

				if (ynProp) {
					strTm2 = Strings.ToTitleCase(strTmp);
				} else {
					strTm2 = strTmp;
				}
				return strTm2.Trim();
			}
			#endregion

			#region "    Clear Method    "
			///<summary>Clear the ColumnHeaderExtender Object</summary> 
			///<example>object.Clear</example> 
			///<param name="ynSetDefaults">If False All Properties are set to Nothing, If True All Objects are Set to Their DB Defaults or Nothing if Defaults are not set</param> 
			///<remarks></remarks> 
			public void Clear(bool ynSetDefaults = true)
			{
				if (ynSetDefaults == true) 
                {
					strValue = "";
					strField = "";
					strType = "String";
				} 
                else 
                {
					strValue = null;
					strField = null;
					strType = null;
				}
				SortType = colType.ColumnSortText;
			}
			#endregion

			#region "    Base Class Overrides    "

			///<summary>ToString</summary> 
			///<example>obj.ToString</example> 
			///<returns>String</returns> 
			///<remarks>In order to add an object to a Listbox or combo box item collection, you must override the ToString method so that you will have a meaningful entry displayed in the list. </remarks> 
			public override string ToString()
			{
				//You must Override the ToString method of the BaseClass in order to put this class in a Listbox 
				//Return whatever fields you want to be displayed in the list box
				return this.strValue;
			}

			public override bool Equals(object Obj)
			{
				clsColumnHeaderExtender oItm = null;
				bool ynEqual = false;
				ynEqual = true;

				try {
					oItm = (clsColumnHeaderExtender)Obj;
				} catch (Exception ex) {
					ynEqual = false;
				}
				ynEqual = (oItm.strValue == this.strValue) & ynEqual;
				ynEqual = (oItm.strField == this.strField) & ynEqual;
				ynEqual = (oItm.strType == this.strType) & ynEqual;

				return ynEqual;
			}

            public override int GetHashCode() {	return base.GetHashCode();}

			#endregion

			#region "    Interface Implementations    "

			///<summary>CompareTo</summary> 
			///<example>obj.CompareTo</example> 
			///<param name="obj"></param> 
			///<returns>Integer</returns> 
			///<remarks>Overriding the CompareTo enables you to sort your class in a list box or combo box</remarks> 
			public int CompareTo(object obj)
			{
                try { return this.strValue.CompareTo(((clsColumnHeaderExtender)obj).strValue); }
                catch { return 0; }
			}

			public object Clone()
			{
				clsColumnHeaderExtender xCopy = new clsColumnHeaderExtender(){
				  strValue = this.strValue
				, strField = this.strField
				, strType  = this.strType
				, SortType = this.SortType};

				return xCopy;
			}

			#region "    IPropertyAutomation Interface Required   "
			//Requires the Interface: 
			//Public Interface IPropertyAutomation 
			//    Function PropertyPull(ByVal strName As String) As Object 
			//    Function PropertyPull(ByVal lngIndex As Long) As Object 
			//    Function PropertyName(ByVal lngIndex As Long) As String 
			//    Function PropertyCount() As Long 
			//    Function PropertyPush(ByVal strName As String, ByVal oValue As Object) As Boolean 
			//    Function PropertyPush(ByVal lngIndex As Long, ByVal oValue As Object) As Boolean 
			//End Interface 
			#endregion

            ///<summary>Returns the Number of Properties the Class has.</summary>
			///<example>
			///For i = 0 to plvObj.PropertyCount()
			///    Debug.WriteLine(plvObj.PropertyName(i)
			///Next i
			///</example>
			///<returns>Long - Count of Properties.</returns>
			[System.Diagnostics.DebuggerStepThrough()]
			public int PropertyCount()
			{
				return 3;
			}

			#region "    Comments   "
			///<summary>Gets a Property Value based on the Properties Ordinal Index.</summary>
			///<example>
			///strValue = plvObj.PropertyPull(2)
			///</example>
			///<param name="lngIndex ">Property Index</param>
			///<returns>Object Containing the Boxed Property</returns>
			///<remarks>IndexOutOfRangeException is Thrown if Property does not exist.</remarks>
			#endregion
			[System.Diagnostics.DebuggerStepThrough()]
			public object PropertyPull(int lngIndex)
			{
				switch (lngIndex) {
					case 0:
						return strValue;
					case 1:
						return strField;
					case 2:
						return strType;
					case 3:
						return SortType;
					default:
						throw new IndexOutOfRangeException("Index " + lngIndex.ToString() + " Does not exist");
				}
			}

			#region "    Comments   "
			///<summary>Gets a Property Value based on the Properties Name.</summary>
			///<example>
			///strLastName = plvObj.PropertyPull("strLastName").ToString
			///</example>
			///<param name="strPropertyName">Property Name</param>
			///<returns>Object Containing the Boxed Property</returns>
			///<remarks>IndexOutOfRangeException is Thrown if Property does not exist.</remarks>
			#endregion
			[System.Diagnostics.DebuggerStepThrough()]
			public object PropertyPull(string strPropertyName)
			{
				switch (strPropertyName.ToLower()) {
					case "strname":
						return strValue;
					case "strfield":
						return strField;
					case "strtype":
						return strType;
					case "sorttype":
						return SortType;
					default:
						throw new IndexOutOfRangeException("Property " + strPropertyName + " Does not exist");
				}
			}

			#region "    Comments   "
			///<summary>Returns a Property Name based on the Properties Ordinal Index.</summary>
			///<example>
			///strName = plvObj.PropertyName(2)
			///</example>
			///<param name="lngIndex ">Property Index</param>
			///<returns>String Containing the Property Name.</returns>
			///<remarks>IndexOutOfRangeException is Thrown if Property does not exist.</remarks>
			#endregion
			[System.Diagnostics.DebuggerStepThrough()]
			public string PropertyName(int lngIndex)
			{
				switch (lngIndex) {
					case 0:
						return "strName";
					case 1:
						return "strField";
					case 2:
						return "strType";
					case 3:
						return "SortType";
					default:
						throw new IndexOutOfRangeException("Index " + lngIndex.ToString() + " Does not exist");
				}
			}

			#region "    Comments   "
			///<summary>Sets a Property to a Value based on the Properties Name.</summary>
			///<example>
			///plvObj.PropertyPush("strName","Wombat")
			///</example>
			///<param name="strPropertyName">Property Name</param>
			///<param name="oValue">The Value you wish to change the property to.</param>
			///<returns>Boolean Indicating Pass/Fail.</returns>
			///<remarks>IndexOutOfRangeException is Thrown if Property does not exist.</remarks>
			#endregion
			[System.Diagnostics.DebuggerStepThrough()]
			public bool PropertyPush(string strPropertyName, object oValue)
			{
				switch (strPropertyName.ToLower()) {
					case "strname":
						strValue = Convert.ToString(oValue);
						break;
					case "strfield":
						strField = Convert.ToString(oValue);
						break;
					case "strtype":
						strType = Convert.ToString(oValue);
						break;
					case "sorttype":
						SortType = (colType)oValue;
						break;
					default:
						throw new IndexOutOfRangeException("Property " + strPropertyName + " Does not exist");
				}
				return true;
			}

			///<summary>Sets a Property to a Value based on the Properties Ordinal Index.</summary>
			///<example>
			///plvObj.PropertyPush(2,"Wombat")
			///</example>
			///<param name="lngIndex ">Property Index</param>
			///<param name="oValue">The Value you wish to change the property to.</param>
			///<returns>Boolean Indicating Pass/Fail.</returns>
			///<remarks>IndexOutOfRangeException is Thrown if Property does not exist.</remarks>
			[System.Diagnostics.DebuggerStepThrough()]
			public bool PropertyPush(int lngIndex, object oValue)
			{
				try {
					switch (lngIndex) {
						case 0:
							strValue = Convert.ToString(oValue);
							break;
						case 1:
							strField = Convert.ToString(oValue);
							break;
						case 2:
							strType = Convert.ToString(oValue);
							break;
						case 3:
							SortType = (colType)oValue;
							break;
						default:
							throw new IndexOutOfRangeException("Index " + lngIndex.ToString() + " Does not exist");
					}
					return true;
				} catch (Exception ex) {
					throw;
				}

			}

			public string PropertyDesc(int intIndex)
			{
				switch (intIndex) {
					case 0:
						return "Name";
					case 1:
						return "Field";
					case 2:
						return "Type";
					case 3:
						return "Sort Type";
					default:
						throw new IndexOutOfRangeException("Index " + intIndex.ToString() + " Does not exist");
				}
			}

			public string PropertyLabl(int intIndex)
			{
				switch (intIndex) {
					case 0:
						return "Name:";
					case 1:
						return "Field:";
					case 2:
						return "Type:";
					case 3:
						return "Sort Type:";
					default:
						throw new IndexOutOfRangeException("Index " + intIndex.ToString() + " Does not exist");
				}
			}


			/// <summary>List of Property Attributes</summary>
			public List<DatabaseColumnAttribute> PropertyAttributes()
			{
				List<DatabaseColumnAttribute> lstDCA = new List<DatabaseColumnAttribute>();
				for (int i = 0; i <= PropertyCount(); i++) {
					DatabaseColumnAttribute dca = new DatabaseColumnAttribute();
					dca.Description = PropertyDesc(i);
					dca.DisplayName = PropertyLabl(i);
					dca.FieldName = PropertyName(i);
					dca.DataType = Types.ToDotNetName(PropertyPull(i).GetType().FullName);
					lstDCA.Add(dca);
				}
				return lstDCA;
			}
			#endregion

			#region "    Properties    "

			///<summary>Property strName</summary> 
			///<example>strName = Object</example> 
			///<returns>String</returns> 
			public string strValue {
				[System.Diagnostics.DebuggerStepThrough()]
				get {
					 try{return mstrValue;}catch{return "";}
				}
				[System.Diagnostics.DebuggerStepThrough()]
				set {
					 try{mstrValue = value;}catch{}
				}
			}



            ///<summary>Property strField</summary> 
			///<example>strField = Object</example> 
			///<returns>String</returns> 
			public string strField {
				[System.Diagnostics.DebuggerStepThrough()]
				get {
					try{return mstrField;}catch{return "";}
				}
				[System.Diagnostics.DebuggerStepThrough()]
				set {
					 mstrField = value;
				}
			}


			///<summary>Property strType</summary> 
			///<example>strType = Object</example> 
			///<returns>String</returns> 
			public string strType {
				[System.Diagnostics.DebuggerStepThrough()]
				get {
					try{return mstrType;}catch{return "";}
				}
				[System.Diagnostics.DebuggerStepThrough()]
				set {
					 try{mstrType = value;}catch{}
				}
			}


			#endregion

		}
		// clsColumnHeaderExtender

		#endregion

		#region "    Class: LVW Sorter     "

		public class clsLvwSorter : IComparer<clsLvwSorter>, System.Collections.IComparer
        {

			private bool mynIgnoreCase;
			private System.Windows.Forms.SortOrder meSortOrder;
			private colType meColType;

			private int mintColNum;
			//// May want to give some thought to text vs. binary comparision of strings.
			//// Use the following enumeration to allow programmers to choose between
			//// text and binary comparison.
			//// Dim m_eCompareMethod As Microsoft.VisualBasic.CompareMethod


			public clsLvwSorter(int pintColumnNumber, colType pSortMethod, System.Windows.Forms.SortOrder pSortOrder)
			{
				mintColNum = pintColumnNumber;
				meColType = pSortMethod;

				//// The default method for comparing strings is case insensitive.
				mynIgnoreCase = true;

				//// Automatically invert the sort order.
				if (pSortOrder == System.Windows.Forms.SortOrder.Ascending) {
					SortOrder = System.Windows.Forms.SortOrder.Descending;
				} else if (pSortOrder == System.Windows.Forms.SortOrder.None) {
					SortOrder = System.Windows.Forms.SortOrder.Ascending;
				} else {
					SortOrder = System.Windows.Forms.SortOrder.Ascending;
				}
				meSortOrder = SortOrder;

			}

			//// Use this constructor if you want to override the default for
			//// text comparison.  This constructor is meaningful when comparing
			//// strings.

			public clsLvwSorter(int pintNumber, colType pSortMethod, System.Windows.Forms.SortOrder pSortOrder, bool pIgnoreCase)
			{
				mintColNum = pintNumber;
				meColType = pSortMethod;
				mynIgnoreCase = pIgnoreCase;

				//// Automatically invert sort order.
				if (pSortOrder == SortOrder.Ascending) {
					SortOrder = SortOrder.Descending;
				} else {
					SortOrder = SortOrder.Ascending;
				}
				//meSortOrder = SortOrder

			}

			public int ColumnNumber {
				get { return mintColNum; }
				set { mintColNum = value; }
			}

			public colType ColumnType {
				get { return meColType; }
				set { meColType = value; }
			}

			public int CompareTo(object o1, object o2)
			{
				int functionReturnValue = 0;

				object arg1 = null;
				object arg2 = null;
				ListViewItem lvwItem1 = default(ListViewItem);
				ListViewItem lvwItem2 = default(ListViewItem);

				if (! (o1 is ListViewItem)) {return 0;}
				if (!(o2 is ListViewItem)) {return 0;}
				lvwItem1 = (ListViewItem)o1;
				lvwItem2 = (ListViewItem)o2;


				int iSortVector = 0;
                try
                {
				switch (meSortOrder) {
					case SortOrder.Ascending:
						iSortVector = 1;
						break;
					case SortOrder.Descending:
						iSortVector = -1;
						break;
					case SortOrder.None:
						iSortVector = 0;
						break;
				}

				if (mintColNum == 0) {
					arg1 = lvwItem1.Text;
					arg2 = lvwItem2.Text;
				} else {
					if (mintColNum < lvwItem1.SubItems.Count) {
						arg1 = lvwItem1.SubItems[mintColNum].Text;
					}
					if (mintColNum < lvwItem2.SubItems.Count) {
						arg2 = lvwItem2.SubItems[mintColNum].Text;
					}
				}

				switch (meColType) {

					case colType.ColumnSortDate:
						System.DateTime cmp1 = default(System.DateTime);
						System.DateTime cmp2 = default(System.DateTime);
						cmp1 = Strings.SafeDate(arg1);
						cmp2 = Strings.SafeDate(arg2);


						return cmp1.CompareTo(cmp2) * iSortVector;
					case colType.ColumnSortNumber:
						double cmp1n = 0;
						double cmp2n = 0;

						cmp1n = Convert.ToDouble(arg1);
						cmp2n = Convert.ToDouble(arg2);
						return cmp1n.CompareTo(cmp2n) * iSortVector;

					case colType.ColumnSortText:
						string cmp1t = null;
						string cmp2t = null;

						cmp1t = Convert.ToString(arg1);
						cmp2t = Convert.ToString(arg2);
						if (cmp2t != null && cmp1t != null) {
							return cmp1t.CompareTo(cmp2t) * iSortVector;
						} else {
							return 0;
						}

						break;
				}
				//MethExt:
				return functionReturnValue;
                }
                catch
                {
				    meColType = colType.ColumnSortText;
				    return 0;
                }
			} // End Compare to

			public int Compare(clsLvwSorter o1, clsLvwSorter o2)
			{
				return CompareTo(o1, o2);
			}

			public bool IgnoreCase {
				get { return mynIgnoreCase; }
				set { mynIgnoreCase = value; }
			}

			public void InvertSortOrder()
			{
				if (meSortOrder == SortOrder.Ascending) {
					meSortOrder = SortOrder.Descending;
				} else {
					meSortOrder = SortOrder.Ascending;
				}
			}

            public int Compare(object x, object y)
            {
                return CompareTo(x, y);
            }

            public System.Windows.Forms.SortOrder SortOrder {
				get { return meSortOrder; }
				set { meSortOrder = value; }
			}

		} // End clsLvwSorter

		#endregion


	} // End clsListView



} // End Namespace
