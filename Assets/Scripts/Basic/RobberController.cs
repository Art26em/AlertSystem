using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberController : MonoBehaviour
{
    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
    [SerializeField] private float _moveSpeed;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * (_moveSpeed * Time.deltaTime));
        _animator.SetFloat(MoveSpeed, Mathf.Abs(_moveSpeed));
    }
}
