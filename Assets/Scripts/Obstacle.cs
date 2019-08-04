/*  (c) Datal0re 2019
 *  Made for the GMTK 2019 Game Jam
 *  Theme: "Only One"
 */

using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector2(10, transform.position.y);
        transform.position = targetPos;
        _ = StartCoroutine("Move");
    }

    private IEnumerator Move()
    {
        while (transform.position.x > -9)
        {
            targetPos = new Vector2(transform.position.x - 1, transform.position.y);
            transform.position = targetPos;
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
