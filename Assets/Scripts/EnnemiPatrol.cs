using UnityEngine;

public class EnnemiPatrol : MonoBehaviour
{
    public float speed;

    public SpriteRenderer graphics;

    public Transform[] waypoints;

    private Transform target;

    public int damage;

    private int destPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Check if Ennemy is close enough to its target destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
    }
}
