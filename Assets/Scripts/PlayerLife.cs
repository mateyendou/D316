using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    [Header("Health")]
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private float startingHealth;
    [SerializeField] private float healthValue;
    public float currentHealth { get; private set; }
    [SerializeField] private AudioSource HitSoundEffect;
    [SerializeField] private AudioSource DeathSoundEffect;
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    public GameManager gamemanager;
    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            //Die();
            TakeDamage(1);
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
    private void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            HitSoundEffect.Play();
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            DeathSoundEffect.Play();
            Die();
            gamemanager.gameOver();
        }
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(0, 3, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(0, 3, false);
    }
}