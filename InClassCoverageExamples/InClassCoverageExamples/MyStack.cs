using System;
namespace InClassCoverageExamples
{
	public class MyStack
	{
		public int[] stackArray;
		public int maxLength;   //Don't get bigger than
		public int size;   //Current Size

        public MyStack(int maxLength)
        {
            this.stackArray = new int[maxLength];
            this.maxLength = maxLength;
            this.size = 0;
        }
        public void push(int item)
        {
            if(size == maxLength)
            {
                throw new StackOverflowException();
            }
            stackArray[size] = item;
            size++;
        }
    }
}

