using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField]
    private Text cherriesText;

    [SerializeField]
    private AudioSource itemCollectSoundEffect;

    private int _cherries;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Cherry")) return;
        Destroy(col.gameObject);
        _cherries++;
        cherriesText.text = "Cherries: " + _cherries;
        itemCollectSoundEffect.Play();
    }
}