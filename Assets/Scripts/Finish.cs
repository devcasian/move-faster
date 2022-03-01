using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource _finishSound;
    private bool _isLevelCompleted;

    private void Start()
    {
        _finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "Player" || _isLevelCompleted) return;

        _finishSound.Play();
        _isLevelCompleted = true;
        Invoke(nameof(CompleteLevel), 2f);
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}