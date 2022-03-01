using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    private AudioSource deathSoundEffect;

    private Rigidbody2D _rb;
    private Animator _anim;
    private static readonly int Death = Animator.StringToHash("death");

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Trap") && !col.gameObject.CompareTag("Border")) return;

        PlayerDie();
        deathSoundEffect.Play();
    }

    private void PlayerDie()
    {
        _rb.bodyType = RigidbodyType2D.Static;
        _anim.SetTrigger(Death);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}