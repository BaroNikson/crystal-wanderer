
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePers : MonoBehaviour
{
    float time = 0;


 
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float gravity = 50f;
    [SerializeField] int crystal;
    [SerializeField] Text ScoreText;
    [SerializeField] Text TimeText;
    [SerializeField] private GameObject particle;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject Lose;



    private Vector3 direction;



   
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5;
        }
        if (controller.isGrounded)
        {
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            direction = transform.TransformDirection(direction) * speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpForce;
            }
            if (crystal < 5)
            {
                time += Time.deltaTime;
                TimeText.text = time.ToString();
                

            }
            else
            { 
                win.SetActive(true);
                GetComponent<PlayerLook>().enabled = false;

                Cursor.lockState = CursorLockMode.None;
            }
            
        }


        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Crystal")
        {

            crystal += 1;
            Destroy(collider.gameObject);
            Instantiate(particle, collider.transform.position, particle.transform.rotation);
            

            ScoreText.text = crystal.ToString();
        }
        if (collider.tag == "BigCrystal")
        {

            crystal += 2;
            Destroy(collider.gameObject);
            Instantiate(particle, collider.transform.position, particle.transform.rotation);

            ScoreText.text = crystal.ToString();
        }
        if(collider.tag=="GameOver")
        {

            Lose.SetActive(true);
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }


    }
    



}
    
     


