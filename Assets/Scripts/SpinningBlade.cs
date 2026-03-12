using UnityEngine;

public class SpinningBlade : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;
    public Transform pointA, pointB;
    private Vector3 targetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == pointA.position) {
            targetPosition = pointB.position;
        } else if (transform.position == pointB.position) {
            targetPosition = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);
    }
}
