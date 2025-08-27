using UnityEngine;
using UnityEngine.AI;

public class Enemycontroller : MonoBehaviour
{
    [SerializeField] Transform objetive;
    [SerializeField] GameObject chicken;
    [SerializeField] GameObject Waste;
    Collider own;
    NavMeshAgent agent;
    [SerializeField] bool Isalive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        own = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Isalive != false)
        {
            agent.SetDestination(objetive.position);
        }
    }

    public void Die()
    {
        own.isTrigger = true;
        Isalive = false;
        chicken.SetActive(false);
        Waste.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Playercontroller>().Die();
        }
    }
}
