using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] int rayDistance;
    [SerializeField] LayerMask targetMask;

    private int magasineCapacity;

    public int currentAmmo { get; private set; }

    private int damage;

    [SerializeField] LightGun lightGun;
    
    private void OnEnable()
    {
        InputReader.OnShootInput += OnShootEnemy;
    }
    private void OnDisable()
    {
        InputReader.OnShootInput -= OnShootEnemy;
    }

    private void Start()
    {
        magasineCapacity = lightGun.magasineSize;
        currentAmmo = magasineCapacity;
        damage = lightGun.damage;
    }

    private void Update()
    {
        Debug.Log(currentAmmo);
    }
    void OnShootEnemy()
    {
        if (DoesHaveAmmo())
        {
            Ray ray = new Ray(transform.position, transform.forward);
            
            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, targetMask))
            {
                if (hit.collider != null)
                {
                    hit.collider.GetComponent<EnemyHealth>().OnEnemyTakeDamage?.Invoke(damage);
                }
            }

            UseAmmo();
        }
        else
        {
            Debug.Log("No ammo");
        }
    }

    private void UseAmmo()
    {
        currentAmmo--;
    }
    private bool DoesHaveAmmo()
    {
        if(currentAmmo > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
