using System;
using UnityEngine;

public class AreaScanner : MonoBehaviour
{
    private AlarmPlayer _alarmPlayer;

    private void Awake()
    {
        _alarmPlayer = GetComponent<AlarmPlayer>();;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<RobberController>(out _)) return;
        _alarmPlayer.Play();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent<RobberController>(out _)) return;
        _alarmPlayer.Stop();
    }
    
}