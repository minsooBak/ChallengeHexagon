using UnityEngine;

[CreateAssetMenu]
public class WallEventData : ScriptableObject
{
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
    public int hp = 0;
    public int maxHP = 0;
    public int speedP = 0;
    public int speedO = 0;
    public float scale = 0;
    public int damage = 0;
    public bool isMirror = false;
    public int number;
}
