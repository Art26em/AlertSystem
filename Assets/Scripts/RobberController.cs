using UnityEngine;

[RequireComponent(typeof(Animator))]

public class RobberController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private readonly int _moveSpeed = Animator.StringToHash("MoveSpeed");
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime));
        _animator.SetFloat(_moveSpeed, Mathf.Abs(moveSpeed));
    }
}

