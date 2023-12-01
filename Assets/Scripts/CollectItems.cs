using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectItems : MonoBehaviour
{
    private int gems=0;
    [SerializeField] private Text varGems;
    [SerializeField] private AudioSource CollectGemsSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gems"))
        {
            CollectGemsSoundEffect.Play();
            Destroy(collision.gameObject);
            gems++;
            //Debug.Log("Vies: " + health);
            varGems.text = "x" + gems.ToString();
        }
    }

}
