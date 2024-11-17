using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    [SerializeField] private float curontyForceMult =  1f;
    [SerializeField] private float rotationSpeed =  1f;
    [SerializeField] private bool inertionDemper = true;

    public void Init(Rigidbody2D rigidbody)
    {
        Rigidbody = rigidbody;
    }

    public void AddDirection(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            float force = direction.magnitude;
            AddForce(force);


        }
    }

    private void AddForce(float force)
    {
        Rigidbody.AddForce(transform.up * curontyForceMult * Time.deltaTime);
    }


}
