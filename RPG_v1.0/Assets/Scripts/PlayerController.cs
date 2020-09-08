using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    float InputX = 0;
    float InputY = 0;
    public float speed = 2.5f;
    bool Movimento = false;
 
    // Start is called before the first frame update
    void Start()
    {
        Movimento = false;   
    }
 
    // Update is called once per frame
    void Update()
    {
        InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");
        Movimento = (InputX != 0 || InputY != 0);
 
        if (Movimento)
        {
            var move = new Vector3(InputX, InputY, 0).normalized;
            transform.position += move * speed * Time.deltaTime;
            playerAnimator.SetFloat("InputX", InputX);
            playerAnimator.SetFloat("InputY", InputY);
        }
 
        playerAnimator.SetBool("Movimento", Movimento);
 
        if (Input.GetButtonDown("Fire1"))
            playerAnimator.SetTrigger("attack");
    }
}
