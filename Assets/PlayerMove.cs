using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public float speed = 5f;
    public float maxSpeed = 10f;

    public float deceleration = 5f;
    private Vector2 m_Input;
    public Vector2 rb_linear;

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        m_Input = new Vector2(h, v).normalized;

        rb_linear = rb.linearVelocity;
    }

    void FixedUpdate()
    {

        if (m_Input != Vector2.zero)
        {
            rb.linearVelocity = m_Input * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
        //if (m_Input != Vector2.zero)
        //{
        //    rb.AddForce(m_Input * speed, ForceMode2D.Impulse);
        //    if (rb.linearVelocity.magnitude > maxSpeed)
        //    {
        //        rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        //    }
        //}
        //else
        //{
        //    Vector2 vec = rb.linearVelocity;
        //    if (rb.linearVelocity.magnitude > 0.001f)
        //    {
        //        rb.AddForce(-rb.linearVelocity * deceleration, ForceMode2D.Impulse);
        //        if (Vector2.Dot(vec, rb.linearVelocity) < 0)
        //            rb.linearVelocity = Vector2.zero;
        //    }
        //}


    }
}
