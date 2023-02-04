using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool dead = false;
    [SerializeField] AudioSource deathSound;
    [SerializeField] AudioSource fallingSound;

    void Update()
    {
        if (transform.position.y < -5.0f && !dead)
        {
            if (transform.childCount > 0)
            {
                transform.GetChild(0).SetParent(null);
                fallingSound.Play();
            }
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        dead = true;
        Invoke(nameof(ReloadLevel), 1.3f);
        deathSound.Play();

    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
