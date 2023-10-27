using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeZumbies : MonoBehaviour
{
    
    public GameObject zombiePrefab;
    private float contadorTempo = 0;
    public float tempoGerarZombie = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform transform1 = transform;
        
        contadorTempo += Time.deltaTime;
        
        if (contadorTempo >= tempoGerarZombie)
        {
            contadorTempo = 0;
            Instantiate(zombiePrefab, transform1.position, transform1.rotation);
        }
        
    }
}
