using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    // The name of the scene to load when the player collides with the target
    [SerializeField] private string sceneToLoad;

    // Ensure this method detects trigger collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collided with the target object
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

