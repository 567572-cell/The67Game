using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = 1f; // full at start
    }

    private void Update()
    {
        // Simulate one attack per E press
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerHealth.TakeDamage(1f); // one hit = -1 heart
        }

        // Update bar (divides by 3 hearts)
        currenthealthBar.fillAmount = playerHealth.currentHealth / playerHealth.startingHealth;
    }
}
