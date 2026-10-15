using UnityEngine;

public class EnemySprict : MonoBehaviour
{
    public float speed = 10.0f;
    public EnemyPath enemyPath;
    int currPointIndex = 0;

    void Start()
    {
        if (enemyPath == null )
        {
            enemyPath = FindFirstObjectByType<EnemyPath>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (currPointIndex >= enemyPath.pathPoints.Length)
        {
            CastleController castle = FindFirstObjectByType<CastleController>();
            if (castle != null)
            {
                castle.TakeDamage(10); // Example damage value
                Destroy(gameObject); // Destroy the enemy after it reaches the castle
			}
            return;
        }
        Transform targetPoint = enemyPath.pathPoints[currPointIndex];
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
        float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);
        if (distanceToTarget < 0.1f)
        {
            currPointIndex++;
        }
    }
}