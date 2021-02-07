using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform exit;
    [SerializeField]
    Transform[] directionPoints;
    [SerializeField]
    float navigation;

    int target = 0;
    Transform enemy;
    float navigationTime = 0;

    void Start()
    {
        enemy = GetComponent<Transform>();
    }

    void Update()
    {
        if (directionPoints != null)
        {
            navigationTime += Time.deltaTime;
            if (navigationTime > navigation)
            {
                if (target < directionPoints.Length)
                {
                    enemy.position=Vector2.MoveTowards(enemy.position,directionPoints[target].position,navigationTime);
                }
                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exit.position, navigationTime);
                }
                navigationTime = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DirectionPoint")
        {
            target += 1;
        }
        else if(collision.tag == "Finish")
        {
            GameController.Instance.RemoveEnemyFromScreen();
            Destroy(gameObject);
        }
    }
}
