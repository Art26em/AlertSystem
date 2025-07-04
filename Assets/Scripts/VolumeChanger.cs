using UnityEngine;

public class VolumeChanger
{
    public float GetVolume(float passedTime, float maxTime, bool ascending)
    {
        return ascending ? passedTime / maxTime : 1 - passedTime / maxTime;        
    }
}