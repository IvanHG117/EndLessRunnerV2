using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject Player;
    public Camera GameCamera;
    public GameObject[] BlockPrefab;
    public float GamePointer;
    public float safeSpawn = 12;
    public TMP_Text GameText;
    //public Text GameText;
    public bool Lose;
    // Start is called before the first frame update
    void Start()
    {
        GamePointer = -7;
        Lose = false ;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            GameCamera.transform.position = new Vector3(
            Player.transform.position.x,
            GameCamera.transform.position.y,
            GameCamera.transform.position.z
            );
            GameText.text = "Record: " + Mathf.Floor(Player.transform.position.x);
        }
        else
        {
            if(!Lose)
            {
                Lose = true ;
                GameText.text += "\nGame Over\nPrees R to restart";
            }
            if(Lose)
            {
                if (Input.GetKeyDown("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
        
        while(Player != null && GamePointer < Player.transform.position.x + safeSpawn)
        {
            int blockIndex = Random.RandomRange(0, BlockPrefab.Length - 1);
            if (GamePointer < 0)
            {
                blockIndex = 1;
            }
            GameObject objetoBloque = Instantiate(BlockPrefab[blockIndex]);
            objetoBloque.transform.SetParent(this.transform);
            Bloque bloque = objetoBloque.GetComponent<Bloque>();
            objetoBloque.transform.position = new Vector2(GamePointer + bloque.size / 2, 0);
            GamePointer += bloque.size;
        }
    }
}
