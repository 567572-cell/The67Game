using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
       
    }

    private void Start()
    {
       if (anim != null)
        {
            anim.GetComponent<Animator>();
        } 
        else
        {
            anim = this.GetComponent<Animator>();

        }
     
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth >0)
        {
            anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
            
        }

    }

    
}


