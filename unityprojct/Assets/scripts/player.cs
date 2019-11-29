using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    #region
    [Header(" ")][Range(0f,100f)]
    public float speed = 3.5f;
    [Header(" "),Range(100,2000)]
    public int junp = 300;
    public bool isGround = false;
    public string _name = "uYC";
    [Header("剛體")]
    public Rigidbody2D r2d;
    public Animator ani;
    #endregion
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        r2d.AddForce(new Vector2(speed*h,0));
        ani.SetBool("paobu", h != 0);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) transform.eulerAngles = new Vector3(0, 180, 0);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) transform.eulerAngles = new Vector3(0, 0, 0);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0,junp));
            ani.SetTrigger("junp");
        }
    }
    private void Dead()
    {
        
    }
    //事件
    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
        }
    }
}
