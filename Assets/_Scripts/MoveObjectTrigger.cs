using UnityEngine;

public class MoveObjectTrigger : MonoBehaviour
{
    public GameObject objectToMove;
    public Vector3 movementDirection;
    public float movementSpeed;

    private bool isMoving = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = true;
        }
        // Disable the trigger
        GetComponent<Collider>().enabled = false;
    }

    private void Update()
    {
        if (isMoving)
        {
            objectToMove.transform.Translate(movementDirection.normalized * movementSpeed * Time.deltaTime);
        }
    }
}
