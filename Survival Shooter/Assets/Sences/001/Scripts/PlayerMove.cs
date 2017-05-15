using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 5;
    private Animator _anim;
    private int _groundLayerIndex;
    void Start()
    {
        _anim = this.GetComponent<Animator>();
        _groundLayerIndex = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        //控制移动
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        //transform.Translate(new Vector3(h, 0, v) * Speed * Time.deltaTime);
        this.GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(h, 0, v) * Speed * Time.deltaTime);
        //控制转向
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100, _groundLayerIndex))
        {
            Vector3 target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
        //控制动画
        if (h != 0 || v != 0)
        {
            _anim.SetBool("Move", true);
        }
        else
        {
            _anim.SetBool("Move", false);
        }
    }
}
