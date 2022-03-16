using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : IPoolable
{
    private Queue<T> pool;
    private Func<T> createFunction;
    

    public ObjectPool(Func<T> createFunction)
    {
        pool = new Queue<T>();
        this.createFunction = createFunction;
    }

    public T GetObjectFromPool()
    {
        T objectToReturn = pool.Count > 0 ? pool.Dequeue() : CreateObjectForPool();
        objectToReturn.RequestFromPool();
        return objectToReturn;
    }

    public void ReturnObjectToPool(T objectToReturn)
    {
        objectToReturn.ReturnToPool();
        pool.Enqueue(objectToReturn);
    }

    private T CreateObjectForPool()
    {
        return createFunction.Invoke();
    }
   
    // Start is called before the first frame update

}
