using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private BaseHealth baseHealth;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int enemyMaxHealth = 10;
    [SerializeField] public int currentEnemyHealth;
    [SerializeField] private WaveManager WaveManager;
    private GameObject waypointfinder;
    private GameObject BaseHealthfinder;
    private GameObject WaveManagerFinder;

    [SerializeField] private Transform currentwaypoint;

    private void Awake()
    {
        currentEnemyHealth = enemyMaxHealth;

        waypointfinder = GameObject.FindWithTag("WaypointHolder");
        waypoints = waypointfinder.GetComponent<Waypoints>();

        BaseHealthfinder = GameObject.FindWithTag("Exit");
        baseHealth = BaseHealthfinder.GetComponent<BaseHealth>();

        WaveManagerFinder = GameObject.FindWithTag("WaveManager");
        WaveManager = WaveManagerFinder.GetComponent<WaveManager>();

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
            WaveManager.enemiesLeft -= 1;
            baseHealth.TakeDamage(currentEnemyHealth);
            Destroy(gameObject);
        }
	}


        public void EnemyTakeDamage(int amount)
    {
        currentEnemyHealth = currentEnemyHealth - amount;

        if (currentEnemyHealth == 0 || currentEnemyHealth >=0)
        {
            WaveManager.enemiesLeft -= 1;
            Destroy(gameObject);
        }
    }
}