using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDataPersistence
{
    public int health;
    public int numOfHealth;
    public Image[] hearts; 
    public Sprite heart;
    public Sprite emtpy_heart;
    private Vector3 respawnPoint;
    private string SceneToLoad;

    private PlayerController playcon;
    [SerializeField] private float invincibleDuration;
    [SerializeField] private int numberFlash;
    private SpriteRenderer _sprite;
    [SerializeField] private float timeLostControl;
    public static Health healthcon;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        respawnPoint = transform.position;
        playcon = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (health > numOfHealth)
        {
            health = numOfHealth;
        }
        for (int i= 0; i< hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = heart;
            } 
            else
            {
                hearts[i].sprite = emtpy_heart;
            }
            if(i < numOfHealth)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
            if(health <= 0)
            {
                Respawn();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            Respawn();
            DataPersistenceManager.instance.SaveGame();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            AudioManager.Instance.PlaySFX("PlayerHit");
            TakeDamage();
        }
        if(collision.gameObject.tag == "heart")
        {
            numOfHealth += 1;
            health = numOfHealth;
            DataPersistenceManager.instance.SaveGame();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SavePoint"))
        {
            health = numOfHealth;
            print(numOfHealth);
        }
    }
    public void TakeDamage()
    {
        health = health - 1;
        if(health > 0)
        {
            StartCoroutine(Invunerability());
        }
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(9, 8, true);
        for(int i = 0; i < numberFlash; i++)
        {
            _sprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(invincibleDuration / (numberFlash * 2));
            _sprite.color = Color.white;
            yield return new WaitForSeconds(invincibleDuration / (numberFlash * 2));
        }
        Physics2D.IgnoreLayerCollision(9, 8, false);
    }
    public void KnockBack(Vector2 possition)
    {
        if(health > 0)
        {
            playcon.KnockBack(possition);
            LostControl();
        }
    }
    private IEnumerable LostControl()
    {
        playcon.canMove = false;
        yield return new WaitForSeconds(timeLostControl);
        playcon.canMove = true;
    }
    private void Respawn()
    {
        if (SceneToLoad == "")
        {
            SceneManager.LoadScene("SampleScene");
        }
        SceneManager.LoadScene(SceneToLoad);
        transform.position = respawnPoint;
        health = numOfHealth;
    }
    public void LoadData(GameData data)
    {
        this.numOfHealth = data.numOfHealth;
        this.SceneToLoad = data.SceneToLoad;
        this.respawnPoint = data.RespawnPoint;
    }
    public void SaveData(GameData data)
    {
        data.numOfHealth = this.numOfHealth;
    }
}
