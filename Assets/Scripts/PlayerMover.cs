using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Vector2 direction;
    private bool isForce = false;
    private bool isUpDirection = false;
    private float sqrt2 = Mathf.Sqrt(2f);
    private Rigidbody2D Rigidbody;
    [SerializeField] private float curontyForceMult =  100f;
    [SerializeField] private float rotationSpeed =  1f;
    [SerializeField] private bool inertionDemper = true;
    [SerializeField] private float dethInputSpace = 0.01f;

    public void Init(Rigidbody2D rigidbody)
    {
        Rigidbody = rigidbody;
    }

    public void StartForce(Vector2 vectorForce) 
    {
        isForce = false;
    }

    public void StopForce(Vector2 vectorForce)
    {
        direction = Vector2.zero;
        isForce = false;
    }

    public void AddDirection(Vector2 vectorForce)
    {
        direction = vectorForce;
        if (vectorForce.magnitude > dethInputSpace)
        {
            isForce = true;
            Vector2 directionUp = new Vector2(transform.up.x, transform.up.y);
            if ((vectorForce.normalized + directionUp).magnitude < sqrt2)
                isUpDirection = true;
            else isUpDirection = false;
        }
        else
        {
            isForce = false;
            isUpDirection = false;
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (isForce)
        {
            float force = direction.magnitude;
            if (isUpDirection)
            { AddForce(-force); }
            else
            { AddForce(force); }
        }
    }

    private void AddForce(float force)
    {
        Rigidbody.AddForce(transform.up * force * curontyForceMult * Time.fixedDeltaTime);
    }
}
