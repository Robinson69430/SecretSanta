using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5f;
        private Rigidbody2D rb;
        private Vector2 movement;

        public Button _augmenterVitesse;
        
        
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            
            _augmenterVitesse.onClick.AddListener(() => VitesseSup());
        }

        void Update()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            movement = new Vector2(moveX, moveY).normalized;
        }

        void FixedUpdate()
        {
            rb.linearVelocity = movement * speed;
        }

        public void VitesseSup()
        {
            speed += 0.5f;
        }
    }
    
}