﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class Inventory
    {
        // The dictionary items consist of the item and the quantity
        private Dictionary<Item, int> items;

        public int AvailableSlots
        {
            get
            {
                return availableSlots;
            }
        }

        public int MaxSlots
        {
            get
            {
                return MaxSlots;
            }
        }


        // The available slots to add item, once it's 0, you cannot add any more items.
        private int availableSlots;

        // The max available slots which is set only in the constructor.
        private int maxSlots;
        public Inventory(int slots)
        {
            //availableSlots = maxSlots; this should be after maxSlots=slots
            maxSlots = slots;
            availableSlots = maxSlots;
        }

        /// <summary>
        /// Removes all the items, and restore the original number of slots.
        /// </summary>
        public void Reset()
        {
            items.Clear();
            availableSlots = maxSlots;
        }

        /// <summary>
        /// Removes the item from the items dictionary if the count is 1 otherwise decrease the quantity.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <param name="found">The item if found</param>
        /// <returns>True if you find the item, and false if it does not exist.</returns>
        bool TakeItem(string name, out Item found)
        {
            if(items.Count==0)
            {
                found = null;
                return false;
            }
            else
            {
                foreach (var item in items)
                {
                    if (item.Key.Name == name)
                    {
                        found = item.Key;
                        availableSlots = availableSlots + 1;
                        return true;
                    }
                }
                found = null;
                return false;
            }

            /*if (items.ContainsKey(name))
            {

            }*/
        }

        /// <summary>
        /// Checks if there is space for a unique item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool AddItem(Item item)
        {
            int location = 0;
            // Add it in the items dictionary and increment it the number if it already exist
            // Reduce the slot once it's been added.
            // returns false if the inventory is full
            if (availableSlots < maxSlots)
            {
                for (int i = 0; i <= items.Count; i++)
                {
                    location = i;
                }
                items.Add(item, location);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Iterates through the dictionary and create a list of all the items.
        /// </summary>
        /// <returns></returns>
        List<Item> ListAllItems()
        {
            // use a foreach loop to iterate through the key value pairs and duplicate the item base on the quantity.
            List<Item> ItemList = new List<Item>();
            foreach(var item in items)
            {
                ItemList.Add(item.Key);
                //Console.WriteLine("Key: {0}, Value: {1}", item.Value, item.Key);
            }
            return ItemList;
        }
    }
}
