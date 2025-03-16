using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] int rayDistance;
    [SerializeField] LayerMask targetMask;

    [HideInInspector] public int maxAmmo;

    [HideInInspector] public int currentAmmo;

    [HideInInspector] public int kills;

    private int damage;

    [SerializeField] LightGun lightGun;

    InputReader inputReader;

    private void Awake()
    {
        inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        inputReader.OnShootInput += OnShoot;
        GameEvents.OnEnemyDeath += OnKill;
    }
    private void OnDisable()
    {
        inputReader.OnShootInput -= OnShoot;
        GameEvents.OnEnemyDeath -= OnKill;
    }

    private void Start()
    {
        maxAmmo = lightGun.magasineSize;
        currentAmmo = maxAmmo;
        damage = lightGun.damage;
    }
    void OnShoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, targetMask))
        {
            if (hit.collider != null)
            {
                hit.collider.GetComponent<EnemyHealth>().OnEnemyTakeDamage?.Invoke(damage);
            }
        }

        currentAmmo--;
    }

    void OnKill(EnemyHealth enemy)
    {
        Debug.Log("KILLED");
        kills += enemy.price;
    }
}
