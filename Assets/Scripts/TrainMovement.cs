using UnityEngine;

public class TrainMovement : MonoBehaviour
{
   [SerializeField] public Transform[] points;
    public float speed = 1;
    private int currentPoint = 0;
    public VehicleUnlock vu;

    public float targetAngle = 90f;
    private Quaternion targetRotation;

    void Start()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
        transform.rotation = targetRotation;
    }


    void Update()
    {
        if (vu.trainUnlocked)
        {
            if (transform.position != points[currentPoint].position)
            {
                Vector3 target = points[currentPoint].position;
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

                if (currentPoint == 0)
                {
                    targetAngle = 90f;
                    Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
                    transform.rotation = targetRotation;
                }

                if (currentPoint == 1)
                {
                    targetAngle = 0f;
                    Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
                    transform.rotation = targetRotation;
                }

                if (currentPoint == 2)
                {
                    targetAngle = -40f;
                    Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
                    transform.rotation = targetRotation;
                }

                if (currentPoint == 4)
                {
                    targetAngle = -90f;
                    Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
                    transform.rotation = targetRotation;
                }

                if (currentPoint == 5)
                {
                    targetAngle = -120f;
                    Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
                    transform.rotation = targetRotation;
                }

                if (currentPoint == 6)
                {
                    targetAngle = -180f;
                    Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
                    transform.rotation = targetRotation;
                }

                if (currentPoint == 7)
                {
                    targetAngle = -230f;
                    Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
                    transform.rotation = targetRotation;
                }

                if (currentPoint == 8)
                {
                    targetAngle = -270f;
                    Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
                    transform.rotation = targetRotation;

                }
            }
            else
            {
                currentPoint++;
                if (currentPoint >= points.Length)
                {
                    currentPoint = 0;
                    vu.totalMetalCollected += 20;
                }
            }
        }
    }
}