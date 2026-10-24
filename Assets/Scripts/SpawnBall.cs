
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject[] balls;
    public Transform point;

    public float moveSpeed = 4f;
    public float randomRangeX = 18f;
    public float randomRangeZ = 18f;
    public float minHeight = 2f;
    public float maxHeight = 8f;
    public float waitAtDestination = 1f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool returning;
    private bool waiting;
    private float waitTimer;

    private void Start()
    {
        startPosition = transform.position;
        ChooseDestination();
    }

    private void Update()
    {
        if (waiting)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0f)
            {
                waiting = false;
                returning = !returning;

                if (!returning)
                    ChooseDestination();
            }

            return;
        }

        Vector3 destination = returning
            ? startPosition
            : targetPosition;

        transform.position = Vector3.MoveTowards(
            transform.position,
            destination,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, destination) < 0.05f)
        {
            waiting = true;
            waitTimer = waitAtDestination;
        }
    }

    private void ChooseDestination()
    {
        targetPosition = startPosition + new Vector3(
            Random.Range(-randomRangeX, randomRangeX),
            Random.Range(minHeight - startPosition.y,
                         maxHeight - startPosition.y),
            Random.Range(-randomRangeZ, randomRangeZ)
        );
    }

    public void SpawnBallFromCube()
    {
        if (Random.value >= 0.8f)
            return;

        if (balls == null || balls.Length == 0 || point == null)
            return;

        int index = Random.Range(0, balls.Length);

        GameObject spawned = Instantiate(
            balls[index],
            point.position,
            point.rotation
        );

        Rigidbody rb = spawned.GetComponent<Rigidbody>();

        if (rb == null)
            rb = spawned.AddComponent<Rigidbody>();

        Vector3 direction = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-2f, -0.7f),
            Random.Range(-1f, 1f)
        ).normalized;

        rb.AddForce(
            direction * Random.Range(3f, 6f),
            ForceMode.Impulse
        );
    }
}
