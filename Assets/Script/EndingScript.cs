using UnityEngine;

public class CloseGameOnCollision : MonoBehaviour
{

    // This method is called when the collider enters a collision with another collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the target tag
        if (other.GetComponent<HealthBossLevel>() != null)
        {
            Debug.Log("EndGame");
            // Close the game
            Application.Quit();
   
        }
    }
}
