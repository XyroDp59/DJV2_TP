using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void RotateChildTowards(Transform child, Vector3 target)
    {
        child.LookAt(target);
    }

    public void Move(Vector3 dir, float speed)
    {
        rb.velocity = (dir.normalized * speed);
    }

}
