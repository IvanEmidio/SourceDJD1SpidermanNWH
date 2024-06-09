using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovemente_Test>() != null)
        {
            SceneManager.LoadScene(1);
        }
    }
}
