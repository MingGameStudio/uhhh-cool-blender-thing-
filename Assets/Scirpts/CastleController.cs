using UnityEngine; 
using UnityEngine.UI;

public class CastleController : MonoBehaviour
{ 
    public int health = 100; 
    public Slider healthSlider;

    public void TakeDamage(int damage)
    {
        Debug.Log("Castle took " + damage + " damage. Remaining health: " + health);
        health -= damage;
        healthSlider.value = health;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
      void Start()
    {

     healthSlider.minValue = 0;
     healthSlider.maxValue = health;
     healthSlider.value = health;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}