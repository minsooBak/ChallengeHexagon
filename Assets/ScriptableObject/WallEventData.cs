using UnityEngine;

public enum WallEvent
{
    Damage,
    HP,
    HP_MAX,
    SPEED_P,
    SPEED_O,
    SCALE_P,
    MIRROR,
}

[CreateAssetMenu]
public class WallEventData<T> : ScriptableObject
{
    
    public WallEvent type;
    public T data;
}
