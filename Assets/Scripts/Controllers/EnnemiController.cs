using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Mover))]
public class EnnemiController : MonoBehaviour
{
    [Header("Components")]
    Health health;
    Damage damage;
    Mover mover;
    AudioSource source;

    [Header("Misc")]
    [SerializeField] float speed;
    private int score;
    [SerializeField] Transform mesh;
    [SerializeField] EnemyData data;
    [SerializeField] AudioClip hurtSFX;



    void Awake()
    {
        mover = GetComponent<Mover>();
        health = GetComponent<Health>();
        damage = GetComponent<Damage>();
        source = GetComponent<AudioSource>();
        health.Die.AddListener(Death);
        health.OnTakeDamage.AddListener(PlayHurtSFX);
        Debug.Log(gameObject.name);
        Debug.Assert(data != null);

        LoadFromData();
    }

    private void PlaySFX(AudioClip sfx)
    {
        source.clip = sfx;
        source.Play();
    }

    private void PlayHurtSFX()
    {
        PlaySFX(hurtSFX);
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
