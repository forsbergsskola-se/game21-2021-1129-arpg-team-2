using System.Collections.Generic;
using UnityEngine;

public class GenericListValue<T> : ScriptableObject
{
    private List<T> list = new List<T>();
    public List<T> List => list;
    public void AddToList(T t) => list.Add(t);
    public bool RemoveFromList(T t) => list.Remove(t);
}
