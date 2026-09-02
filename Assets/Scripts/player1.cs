using UnityEditor.Rendering;
using UnityEngine;

public class player1 : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float speed;
    Rigidbody2D rb2d;

    [SerializeField] bool jumping;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        if(Input.GetKeyDown(KeyCode.Space) && jumping)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jumping = true;
        }
    }
}
