using System;
using FinalExamInventory;

namespace Final_Exam_API
{
	public class EmptyDB : IDBManager
	{
        public List<Item> getItems()
        {
            List<Item> items = new List<Item>();
            return items;
        }
    }
}