using UnityEngine;

namespace Basic
{
    public class RobberController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        private Animator _animator;
    
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime));
            _animator.SetFloat(MoveSpeed, Mathf.Abs(moveSpeed));
        }
    }
}
