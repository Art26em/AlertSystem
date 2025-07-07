using UnityEngine;

[RequireComponent(typeof(AlarmPlayer))]

public class SignalizationController : MonoBehaviour
{
    [SerializeField] private float alertAscendingTime;
    [SerializeField] private float alertDescendingTime;
    
    private AlarmPlayer _alarmPlayer;
    private AreaScanner _areaScanner;
    private VolumeChanger _volumeChanger;
    private float _passedTime;

    private void Awake()
    {
        _volumeChanger = new VolumeChanger();
        _alarmPlayer = GetComponent<AlarmPlayer>();
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;
        if (_alarmPlayer.IsPlaying())
        {
            _alarmPlayer.SetVolume(_volumeChanger.GetVolume(_passedTime, alertAscendingTime, true));
        }
        else
        {
            _passedTime = 0;
        }
        
        if (_alarmPlayer.IsStopped)
        {
            _alarmPlayer.SetVolume(_volumeChanger.GetVolume(_passedTime, alertDescendingTime, false));    
        }
    }
    
}