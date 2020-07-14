using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform lookAt; // điểm theo dõi
    private Vector3 startOs;  // Khoảng cách 
    private Vector3 moveVt; // vector di chuyển
    private float transition; // ks  noi suy
    private float animationTine = 4.0f; // thời gian animation
    // khởi tạo
    private Vector3 animationOffct = new Vector3(0, 5, 5);

    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform; // ánh xạ đối tượng player
        // khởi tạo khoảng cách player
        startOs = transform.position - lookAt.position;

    }

    // Update is called once per frame
    void Update()
    {
        // camera di chuyển     
        moveVt = lookAt.position + startOs;
        // camera di chuyển trục x
        moveVt.x = 0f;

        // theo trục y 
        moveVt.y = Mathf.Clamp(moveVt.y,5,5);
        if(transition > 1.0f)
        {
            transform.position = moveVt; // di chuyển theo nhân vật

        }
        else
        {
            transform.position = Vector3.Lerp(moveVt + animationOffct,moveVt,transition);
            transition += Time.deltaTime * 1 / animationTine;
            transform.LookAt(lookAt.position + Vector3.up);

        }
    }
}
