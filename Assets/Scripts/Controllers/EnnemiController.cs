using UnityEngine;

[RequireComponent(typeof(Mover))]
public class EnnemiController : MonoBehaviour
{
    [SerializeField] float speed;
    private int score;
    [SerializeField] Transform mesh;
    [SerializeField] EnemyData data;
    Health health;
    Damage damage;
    private Mover mover;

    // Start is called before the first frame update
    void Awake()
    {
        mover = GetComponent<Mover>();
        health = GetComponent<Health>();
        damage = GetComponent<Damage>();
        health.Die.AddListener(Death);
        Debug.Log(gameObject.name);
        Debug.Assert(data != null);

        LoadFromData();
    }

    private void LoadFromData()
    {
        speed = data.speed;
        health.SetMaxHealth(data.health);
        damage.SetDamage(data.damage);
        score = data.score;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = PlayerController.Singleton.transform.position;
        Vector3 dir = playerPos - transform.position;
        float _speed = Vector3.Distance(playerPos, transform.position) > 0.5f ? speed : 0;
        mover.Move(playerPos - transform.position, _speed);

        mover.RotateChildTowards(mesh, playerPos);
    }

    private void Death()
    {
        LevelController.Instance.AddToScore(score);
    }
}
