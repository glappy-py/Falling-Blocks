using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D player;
    private Vector3 mousePos;
    private Vector2 direction;
    public float moveSpeed = 10f;
    private bool cursorVisible;
    public ParticleSystem engine1;
    public ParticleSystem engine2;
    public ParticleSystem engine3;
    public int score = 0;
    public bool gameOver = false;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePos - transform.position).normalized;
        player.velocity = new Vector2(direction.x * moveSpeed,0);
        if(Input.GetKeyDown(KeyCode.F)){
            Cursor.visible = !Cursor.visible;
        }

    }   

    public void selfDestruct(){
        gameOver = true;
        Destroy(gameObject);
    }
    public void startEngines(){
        engine1.Play();
        engine2.Play();
        engine3.Play();
        StartCoroutine("countScore");
    }
    IEnumerator countScore(){
        while (true)
        {   
            yield return new WaitForSeconds(0.5f);
            score++;
        }
    }
}
