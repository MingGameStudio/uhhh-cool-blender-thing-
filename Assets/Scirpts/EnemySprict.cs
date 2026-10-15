using UnityEngine;

public class EnemySprict : MonoBehaviour
{
    public Vector3 speed = new Vector3(3, 0, 1);
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
            }
            return;
        }
        Transform targetPoint = enemyPath.pathPoints[currPointIndex];
        speed = (targetPoint.position - transform.position).normalized * 1.0f; 
        transform.Translate(speed * Time.deltaTime);
        float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);
        if (distanceToTarget < 0.1f)
        {
            currPointIndex++;
        }
    }
}