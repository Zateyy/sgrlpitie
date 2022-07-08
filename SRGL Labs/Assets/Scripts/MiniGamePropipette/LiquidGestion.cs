using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidGestion : MonoBehaviour
{
    public Material mat;
    public float fillInput;
    public Transform viderLaPoire;
    public Transform remplirLaPropipette;
    public Transform viderLaPropipette;
    public ScrollPipette scrollPipette;

    bool poireVid�e=false;
    // Start is called before the first frame update
    void Awake()
    {
        mat.SetFloat("_fill", fillInput);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0)) //tant que j'appuiz
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //print(hit.collider.gameObject);
                if (!scrollPipette.ICanScroll && poireVid�e) //si la poire est bien vid�e et bien plac�
                {
                  
                    if (hit.collider.transform == remplirLaPropipette)
                    {
                        fillInput += (0.15f * Time.deltaTime);
                    }
                    if (hit.collider.transform == viderLaPropipette)
                    {
                        fillInput -= (0.05f * Time.deltaTime);
                    }
                   
                }
                if (hit.collider.transform == viderLaPoire)
                {
                    poireVid�e = true;
                }
            }
        }
        
        

        mat.SetFloat("_fill",fillInput);
        if (fillInput < 0) //evite de partir dans les negatifs
        {
            fillInput = 0;
        }

    }
}
