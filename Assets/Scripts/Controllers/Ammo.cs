using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Ammo : MonoBehaviour
{
    Mover mover;
    Vector3 dir;
    float speed;
    // Start is called before the first frame update
    void Awake()
    {
        mover = GetComponent<Mover>();
    }

    public void SetSpeedAndDir(float speed, Vector3 dir)
    {
        this.speed = speed;
        this.dir = dir;
    }

    private void Update()
    {
        mover.Move(dir, speed);
    }
}
