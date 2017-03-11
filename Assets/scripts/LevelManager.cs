using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public PlayerController _player;
    public GameObject _hidrante;
    public float hidranteSpeed = 0.2f;
    public GameObject instanced;
    public Camera _camera;
    
    // Use this for initialization
    void Start ()
    {
        _player = FindObjectOfType<PlayerController>();
        _camera = FindObjectOfType<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
    {        
        var horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;

        if (instanced == null)
            instanced =  Instantiate(_hidrante, _player.transform.position + new Vector3(20f,0,0) , transform.rotation);
         else
            instanced.transform.position = new Vector3(instanced.transform.position.x - 0.2f , instanced.transform.position.y, instanced.transform.position.z);

        Debug.Log(instanced.transform.position.x);
        Debug.Log(horzExtent);

        if (instanced.transform.position.x < (horzExtent*-1))
        {
            Destroy(instanced);
            instanced = null;
        }

    }
}
