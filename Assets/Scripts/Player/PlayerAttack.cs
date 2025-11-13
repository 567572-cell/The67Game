using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())

            Attack();

        cooldownTimer += Time.deltaTime;
    }
    
    private void Attack()
{
    anim.SetTrigger("attack");
    cooldownTimer = 0;

    int fireballIndex = FindFireball(); // ✅ Cache index
    fireballs[fireballIndex].transform.position = firePoint.position;
    fireballs[fireballIndex].GetComponent<Projectile>().SetDireciton(Mathf.Sign(transform.localScale.x));
    Debug.Log("Firing fireball index: " + fireballIndex);

}

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
