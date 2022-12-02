using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                
                //Player
                if(GetComponent<PlayerMovement>() != null)
                    GetComponent<PlayerMovement>().enabled = false;

                //Enemy
                if (GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                }

                if (GetComponent<BeeEnemy>() != null)
                {
                    GetComponent<BeeEnemy>().enabled = false;
                    Destroy(gameObject);
                }

                if (GetComponent<SlimeEnemy>() != null)
                {
                    GetComponent<SlimeEnemy>().enabled = false;
                    Destroy(gameObject);
                }

                if (GetComponent<FlowerEnemy>() != null)
                {
                    GetComponent<FlowerEnemy>().enabled = false;
                    Destroy(gameObject);
                }

                dead = true;
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void Deactivate()
    {
        gameObject.gameObject.SetActive(false);
    }
}
