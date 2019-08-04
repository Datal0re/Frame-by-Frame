/*  (c) Datal0re 2019
 *  Made for the GMTK 2019 Game Jam
 *  Theme: "Only One"
 */

using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator Animator;

    private bool onGround = true;
    private Vector2 targetPos;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CheckJump();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    private void CheckJump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && onGround)
            _ = StartCoroutine("Jump");
    }

    private IEnumerator Jump()
    {
        onGround = false;
        Animator.SetBool("Jumping", true);

        targetPos = new Vector2(transform.position.x, transform.position.y + 1);
        transform.position = targetPos;
        yield return new WaitForEndOfFrame();

        targetPos = new Vector2(transform.position.x, transform.position.y + 1);
        transform.position = targetPos;
        yield return new WaitForEndOfFrame();

        targetPos = new Vector2(transform.position.x, transform.position.y - 1);
        transform.position = targetPos;
        yield return new WaitForEndOfFrame();

        targetPos = new Vector2(transform.position.x, transform.position.y - 1);
        transform.position = targetPos;

        onGround = true;
        Animator.SetBool("Jumping", false);
    }
}
