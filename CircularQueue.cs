using System;
using System.Collections;
using System.Collections.Generic;

public class CircularQueue<T> : IEnumerable<T>
{
    int LastSetItemPointer = 0;
    T[] myQueue;
    uint lastUsed = 0;
    public CircularQueue(uint QueueSize)
    {
        myQueue = new T[QueueSize];
    }

    HashSet<T> myObjects = new HashSet<T>();
    public void Resize(uint Capacity)
    {
        Array.Resize(ref myQueue, (int)Capacity);
    }
    int ItemCount = 0;
    public uint Count { get { return (uint)ItemCount; } }

    public void SwapPosition(ref T ReturnedItem, int Position)
    {
        var ReturnVal = myQueue[Position];
        myQueue[Position] = ReturnedItem;
        ReturnedItem = ReturnVal;
        return;
    }

    public int Insert(T myItem, ref T ReturnVal)
    {
        int Position = -1;
        myObjects.Add(myItem);
        ReturnVal = myQueue[LastSetItemPointer];
        Position = LastSetItemPointer;
        if (ReturnVal == null)
            ItemCount++; //it's a new Item
        else
            myObjects.Remove(ReturnVal);
        myQueue[LastSetItemPointer] = myItem;
        LastSetItemPointer++;
        if (LastSetItemPointer == myQueue.Length)
        {
            LastSetItemPointer = 0;
        }
        return Position;
    }



    public int Insert(T myItem)
    {
        int Position = -1;
        myObjects.Add(myItem);
        var ReturnVal = myQueue[LastSetItemPointer];
        Position = LastSetItemPointer;
        if (ReturnVal == null)
            ItemCount++; //it's a new Item
        else
            myObjects.Remove(ReturnVal);
        myQueue[LastSetItemPointer] = myItem;
        LastSetItemPointer++;
        if (LastSetItemPointer == myQueue.Length)
        {
            LastSetItemPointer = 0;
        }
        return Position;
    }


    public T this[uint position]
    {
        get
        {
            return myQueue[position];
        }
        set
        {
            myQueue[position] = value;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return myQueue.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return myQueue.GetEnumerator() as IEnumerator<T>;
    }


}