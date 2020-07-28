using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContent : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 5f; // tốc độ
    private CharacterController controller; // đều phối
    private float verticalVelocity = 0.0f; // Vận Tốc Ngang
    private float gravity = 11.0f; // trọng lượng
    private float animationDuration = 3.0f;

    Vector3 vector3;
    private bool isDead = false;

    //su kien su ly va cham
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)// diem va cham
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        GetComponent<Score>().onDeath();
        Debug.Log("Death");
    }
    void Start()
    {


        controller = GetComponent<CharacterController>(); // ánh xạ
    }

    // Update is called once per frame
    void Update()
    {
        vector3 = Vector3.zero; // khởi tạo


        if (Time.time < animationDuration)
        {
            // di chuyển 
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        if (controller.isGrounded) // nếu là ground
        {
            verticalVelocity = -0.5f;

        }
        else // không phải là ground thì trọng lượng hút xuống
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        // định nghĩa di chuyển
        vector3.x = Input.GetAxisRaw("Horizontal") * speed;
        vector3.y = verticalVelocity;
        vector3.z = speed;
        controller.Move(vector3 * Time.deltaTime);
    }
    public void SetSpeed(float m)//ham thay doi toc do theo thoi gian
    {
        speed = 5.0f + m;
    }
}
