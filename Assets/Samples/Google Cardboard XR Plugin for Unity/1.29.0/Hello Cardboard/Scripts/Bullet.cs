using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force = 500f;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * force * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        rb.WakeUp();
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
        if (collision.gameObject.CompareTag("Destruible"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
