using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectHealth : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioSource CollectHealthSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vie"))
        {

            CollectHealthSoundEffect.Play();
            GetComponent<PlayerLife>().AddHealth(healthValue);
            //collision.GetComponent<PlayerLife>().AddHealth(healthValue);
            Destroy(collision.gameObject);
        }
    }

}
