using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{

/***************************************************************************
* Wk8 Murach Coding Assignments (Individual)		George Gachoki, 6/2/2020
* Extra 12-1 Create and use an inventor Item class:
* InvItem Class (Inventory Item)
****************************************************************************/
    public class InvItem
    {
        private int itemNo;
        private string description;
        private decimal price;

        public InvItem() // constructor for default values
        {
        }
        public InvItem(int itemNo, string description, decimal price) // constructor for specific values
        {
            // Class properties
            this.itemNo = itemNo;
            this.description = description;
            this.price = price;
        }

        /********** properties setters and getters section *******************/
        public int ItemNo 
        {
            get
            {
                return itemNo;
            }
            set
            {
                itemNo = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public string GetDisplayText() // public method to display item details
        {
            return itemNo + "    " + description + " (" + price.ToString("c") + ")";
        }
    }
}
