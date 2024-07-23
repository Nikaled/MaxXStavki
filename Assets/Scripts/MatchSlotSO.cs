using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MatchSlot", menuName = "ScriptableObjects/MatchSlot", order = 52)]
public class MatchSlotSO : ScriptableObject
{
    public enum SportTypeEnum
    {
        Football= 0,
        Tennis = 1,
        Basketball= 2,
        Hockey=3,
        Volleyball=4
    }
    public enum SportFormatEnum
    {
        Live = 0,
        Line = 1,
        Sports = 2,
        Championship = 3
    }
    public SportTypeEnum SportType;
    public SportFormatEnum SportFormat;
    public string MatchTime;
    public string Command1;
    public string Command2;
    public string MatchName;
    public float P1;
    public float P2;
    public float BCount =2;
    public float BValue;
    public float MCount = 2;
    public float MValue;
    public Sprite Command1Logo;
    public Sprite Command2Logo;
}
