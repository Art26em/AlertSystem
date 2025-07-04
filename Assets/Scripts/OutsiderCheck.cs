using UnityEngine;

public class OutsiderCheck : MonoBehaviour
{
    [SerializeField] private float alertAscendingTime;
    [SerializeField] private float alertDescendingTime;

    private AudioSource _audioSource;
    private bool _outsiderEntered;
    private bool _outsiderGone;
    private float _passedTime;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.volume = 0;
    }

    void Update()
    {
        if (_outsiderEntered)
        {
            _passedTime += Time.deltaTime;
            _audioSource.volume = _passedTime / (alertAscendingTime == 0 ? 1f : alertAscendingTime);
        }
        
        if (_outsiderGone)
        {
            _passedTime += Time.deltaTime;
            _audioSource.volume = 1 - (_passedTime / (alertDescendingTime == 0 ? 1 : alertDescendingTime));
            if (_audioSource.volume <= 0.1f)
            {
                _audioSource.Stop();
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<RobberController>(out _))
        {
            _audioSource.Play();
            _outsiderEntered = true;
            _outsiderGone = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<RobberController>(out _))
        {
            _outsiderEntered = false;
            _outsiderGone = true;       
        }
    }
    
}
