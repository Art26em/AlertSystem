using UnityEngine;

public class RobberController : MonoBehaviour
{
    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
    [SerializeField] private float _moveSpeed;
    
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * (_moveSpeed * Time.deltaTime));
        _animator.SetFloat(MoveSpeed, Mathf.Abs(_moveSpeed));
    }
}
