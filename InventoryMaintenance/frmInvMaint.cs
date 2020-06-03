using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMaintenance
{
/***************************************************************************
* Wk8 Murach Coding Assignments (Individual)		George Gachoki, 6/2/2020
* Extra 12-1 Create and use an inventor Item class:
* Module to implement Inventory Maintenance Form
****************************************************************************/
	public partial class frmInvMaint : Form
	{
		public frmInvMaint()
		{
			InitializeComponent();
		}

		// Add a statement here that declares the list of items.
		private List<InvItem> invItems = null; // new InvItemList();

		private void frmInvMaint_Load(object sender, EventArgs e)
		{
			// Add a statement here that gets the list of items.
			invItems = InvItemDB.GetItems();
			FillItemListBox();
		}

		private void FillItemListBox()
		{
			lstItems.Items.Clear();
			// Add code here that loads the list box with the items in the list.

			foreach (InvItem c  in invItems)
			{
				lstItems.Items.Add(c.GetDisplayText());
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			// Add code here that creates an instance of the New Item form
			frmNewItem newAddInvItemForm = new frmNewItem();

			// and then gets a new item from that form.
			InvItem invItem = newAddInvItemForm.GetNewItem();
			if (invItem != null)
			{
				invItems.Add(invItem);
				InvItemDB.SaveItems(invItems);
				FillItemListBox();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			int i = lstItems.SelectedIndex;
			if (i != -1) // check if an inventory item has been selected
			{
				// Add code here that displays a dialog box to confirm
				// the deletion and then removes the item from the list,
				// saves the list of products, and refreshes the list box
				// if the deletion is confirmed.
				InvItem invItem = invItems[i]; // create & set variable for selected inventory item
				string message = "Are you sure you want to delete: "
					+ invItem.ItemNo + " " + invItem.Description + "?"; // create delete confirmation message
				DialogResult button = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo,
					MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2); // display confirmation to delete
				if (button == DialogResult.Yes) // check if user confirmed deletion
				{
					invItems.Remove(invItem); // remove selected item from list
					InvItemDB.SaveItems(invItems); // save updated items list
					FillItemListBox(); // call method to refresh items list box
				}

			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			//this.Close();
			if (MessageBox.Show("Quit Inventory Application?", "Confirm Exit", MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) // display confirmation to Exit
			{
				this.Close(); // close form
			}
			btnExit.Focus();
		}
	}
}