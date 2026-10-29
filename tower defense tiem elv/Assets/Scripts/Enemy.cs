using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private BaseHealth baseHealth;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int enemyMaxHealth = 10;
    [SerializeField] public int currentEnemyHealth;
    private GameObject waypointfinder;
    private GameObject BaseHealthfinder;

    [SerializeField] private Transform currentwaypoint;

    private void Awake()
    {
        currentEnemyHealth = enemyMaxHealth;

        waypointfinder = GameObject.FindWithTag("Waypoints");
        waypoints = waypointfinder.GetComponent<Waypoints>();

        BaseHealthfinder = GameObject.FindWithTag("Exit");
        baseHealth = BaseHealthfinder.GetComponent<BaseHealth>();

        currentwaypoint = waypoints.GetNextWaypoint(currentwaypoint);
        transform.position = currentwaypoint.position;

        transform.LookAt(currentwaypoint);

        if (gameObject.GetComponent<SphereCollider>() == null)
        {
            gameObject.AddComponent<SphereCollider>();
            gameObject.GetComponent<SphereCollider>().isTrigger = true;
        }
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentwaypoint.position, moveSpeed * Time.deltaTime);
        transform.LookAt(currentwaypoint);
    }
    
    public void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.CompareTag("Waypoints")) 
		{
            currentwaypoint = waypoints.GetNextWaypoint(currentwaypoint);
		}
        else if (other.gameObject.CompareTag("Exit"))
        {
            baseHealth.TakeDamage(gameObject.GetComponent<Enemy>().currentEnemyHealth);
        }
	}
}