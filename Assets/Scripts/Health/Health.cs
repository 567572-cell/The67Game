using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float startingHealth = 3f; // 3 hearts
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (dead) return; // no more damage if dead

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
            dead = true;
        }
    }
    public void AddHealth(float _value)
    {
        if (dead) return; // can't heal if dead

        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
