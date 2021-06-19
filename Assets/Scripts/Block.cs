using UnityEngine;
public class Block : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D collider) {
        if(collider.gameObject.name == "blockEndPoint"){
            Destroy(gameObject);
        }else if(collider.gameObject.name == "player"){
            GetComponent<SpriteRenderer>().color = Color.red;
            FindObjectOfType<PlayerMovement>().selfDestruct();
            Cursor.visible = true;
        }
    }
}
