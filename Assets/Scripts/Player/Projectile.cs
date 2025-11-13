using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 3f;
    private float direction;
    private bool hit;
    private float timer;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        timer = 0f;
    }

    private void Update()
    {
        if (hit) return;

        transform.Translate(direction * speed * Time.deltaTime, 0, 0);

        timer += Time.deltaTime;
        if (timer > lifetime)
            Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
    }

    
    public void SetDireciton(float _direction)
    {
    direction = _direction;
    gameObject.SetActive(true);
    hit = false;
    boxCollider.enabled = true;

    anim.ResetTrigger("explode");
    anim.Play("Fireball", -1, 0f); // make sure this matches your actual animation name

    float localScaleX = transform.localScale.x;
    if (Mathf.Sign(localScaleX) != _direction)
    {
        localScaleX = -localScaleX;
    }
    transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }   
}
