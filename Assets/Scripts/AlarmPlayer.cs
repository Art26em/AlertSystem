using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    public bool IsStopped {get; private set;}
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.volume = 0;
        IsStopped = false;
    }

    public void Play()
    {
        _audioSource.Play();
        IsStopped = false;
    }

    public void Stop()
    {
        IsStopped = true;
    }

    public bool IsPlaying()
    {
        return _audioSource.isPlaying;
    }
    
    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
        if (_audioSource.volume <= 0)
        {
            Stop();
        }
    }
    
}
