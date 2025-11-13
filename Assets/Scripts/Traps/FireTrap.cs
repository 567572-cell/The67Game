using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;

public class FireTrap : MonoBehaviour
{

    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField]private float activationDelay;
    [SerializeField] private float activeTime;

    private Animator anim;
    public SpriteRenderer spriteRend;


    private bool triggered;// when the trap gets triggered
    private bool active;// when the trap is active and can hurt the player



    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            if(!triggered)
            {
                StartCoroutine(ActivateFiretrap());
            }
            if(active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        triggered = true;
        spriteRend.color = Color.red; //turn the sprite red to notify the player
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; //return back to initial color
        active = true;

        anim.SetBool("activated", true);
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
