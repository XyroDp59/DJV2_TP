using UnityEngine;

[RequireComponent(typeof(Mover))]
public class EnnemiController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform mesh;
    private Mover mover;

    // Start is called before the first frame update
    void Awake()
    {
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = PlayerController.Singleton.transform.position;
        Vector3 dir = playerPos - transform.position;
        float _speed = Vector3.Distance(playerPos, transform.position) > 1f ? speed : 0;
        mover.Move(playerPos - transform.position, _speed);

        mover.RotateChildTowards(mesh, playerPos);
    }
}
