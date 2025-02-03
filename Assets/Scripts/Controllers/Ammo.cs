using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Ammo : MonoBehaviour
{
    Mover mover;
    Vector3 dir;
    float speed;
    [SerializeField] AudioSource source;


    // Start is called before the first frame update
    void Awake()
    {
        mover = GetComponent<Mover>();
        source.Play();
    }

    private void OnDestroy()
    {
        source.transform.SetParent(transform.parent, true);
        source.Play();
        Destroy(source.gameObject, source.clip.length);
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
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
