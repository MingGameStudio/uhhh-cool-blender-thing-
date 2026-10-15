using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2.0f;
    private float spawnIntervalTimer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnIntervalTimer += Time.deltaTime;
       if (spawnIntervalTimer <= 0)
       {
           Instantiate(enemyPrefab, transform.position, transform.rotation);
           spawnIntervalTimer = spawnInterval;
       }
    }
}
