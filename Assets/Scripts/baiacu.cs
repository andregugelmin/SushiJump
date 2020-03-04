using UnityEngine;

public class baiacu : MonoBehaviour
{
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        force = Random.Range(10.5f, 12.5f);
        GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.y < 0 && transform.position.y < -5.5f)
        {           
            Destroy(gameObject);
        }
    }
}