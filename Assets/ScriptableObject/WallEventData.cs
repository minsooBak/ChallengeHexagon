using UnityEngine;



[CreateAssetMenu]
public class WallEventData<T> : ScriptableObject
{
    
    public WallEvent type;
    public T data;
}
