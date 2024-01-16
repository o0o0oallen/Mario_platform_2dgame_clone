using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float speed = 5f;
    public float speedY = 5f;
    public bool isDoublejump = true,winAble;    
    public int gamePoint=0,lives,maxPoint;
    public Text scoreText,livesText;
    
    public Vector3 respawnPoint;
    public GameObject fallDetector,UI;
    
        
    private Animator player; // nhanvat

    

    // Start is called before the first frame update
    void Start()
    {                
        player = GetComponent<Animator>(); //truy van nhan vat
        respawnPoint = transform.position;
        scoreText.text = "Score: " + gamePoint + " /" + maxPoint;
        livesText.text = "Lives: " + lives;
        gamePoint = 0;
        GetComponent<BoxCollider2D>().isTrigger = false;
        Time.timeScale = 1;        
    }
   
    // Update is called once per frame
    void Update()
    {        
        if (gamePoint == maxPoint)
        {
            winAble = true;
        }
        if(lives > 0)
        {           
            //trang thai
            player.SetBool("isRunning", false);
            player.SetBool("isStanding", true);
            
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))//sang trai
            {
                //trang thai
                player.SetBool("isRunning", true);
                player.SetBool("isStanding", false);                
               
                
                //Debug.Log("go left");
                /*transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }*/

            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))//sang phai
            {
                //trang thai
                player.SetBool("isRunning", true);
                player.SetBool("isStanding", false);
               
                
                //Debug.Log("go right");
                /*transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                } */                               
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))//nhay lên
            {
                if(GetComponentInChildren<eliminate_script>().jumpCount < 2)
                {
                    //trang thai
                    player.SetBool("isRunning", true);
                    player.SetBool("isStanding", false);
                    GetComponent<Collider2D>().isTrigger = true;


                    //Debug.Log(jumpCount);
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, speedY);
                    GetComponentInChildren<eliminate_script>().jumpCount++;
                }                
            }
            if (Input.GetKeyUp(KeyCode.P))
            {
                gamePause();
            }
            fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        }
        else
        {
            SceneManager.LoadScene("gameOver");
        }
    }
    void FixedUpdate()
    {
        UI.SetActive(false);
        if (gamePoint == maxPoint)
        {
            winAble = true;
        }
        if(lives > 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))//sang trai
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))//sang phai
            {
                //Debug.Log("go right");
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))//nhay lên
            {
                if (GetComponentInChildren<eliminate_script>().jumpCount < 2)
                {
                    /* //trang thai
                     player.SetBool("isRunning", true);
                     player.SetBool("isStanding", false);
                     //Debug.Log(jumpCount);*/

                    /*GetComponent<Collider2D>().isTrigger = true;*/
                    /*gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, speedY);
                    GetComponentInChildren<eliminate_script>().jumpCount++;*/
                }
            }
            fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        }
        
    }
    public void gamePause()
    {
        if(Time.timeScale > 0)
        {
            Time.timeScale = 0;
            UI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            UI.SetActive(false);
        }        
    }
   /* public void gameContinue()
    {
        Time.timeScale = 1;        
    }*/
    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        if(lives > 0)
        if (collisionData.collider.tag == "mysterybox" || collisionData.collider.tag == "wall")
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
        OnTriggerEnter2D(collisionData.collider);
    }

    public void reSpawning()
    {
        lives--;
        transform.position = respawnPoint;
        livesText.text = "Lives: " + lives;
    }
    void livesUpdate(GameObject mushroom)
    {
        Destroy(mushroom);
        lives++;
        livesText.text = "Lives: " + lives;
    }
    void pointUpdate(GameObject coin)
    {
        Destroy(coin);
        gamePoint++;
        //Debug.Log(gamePoint);
        scoreText.text = "Score: " + gamePoint + " /" + maxPoint;
    }

    private void OnTriggerEnter2D(Collider2D colliderData)
    {        
        if(colliderData.tag == "turd" || colliderData.tag == "sawBlade")// kiem tra roi
        {
            reSpawning();                       
        }        
        if(colliderData.tag == "mysterybox" || colliderData.tag == "wall")
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
        if(colliderData.tag == "coin")
        {
            pointUpdate(colliderData.gameObject);            
        }
        if(colliderData.tag == "mushroom")
        {
            livesUpdate(colliderData.gameObject);            
        }
        if (colliderData.tag == "portal"|| colliderData.tag == "endPortal")
        {
            if (winAble == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
   
}
