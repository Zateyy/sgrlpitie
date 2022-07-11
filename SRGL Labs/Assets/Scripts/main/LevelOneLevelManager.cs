using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneLevelManager : MonoBehaviour
{
    //*********************************************************** VARIABLES

    // gants :
    bool glovesOn = false;
    bool glovesAreUnclean = false;

    // objet tenu :
    bool isHolding = false;
    GameObject objectHeld = null;

    // zone / vue
    string area = "paillasse"; // -> change json as it is stated as "paillaisse"

    //player
    bool mouseEnabled = true;

    //hand
    public GameObject handPlacement;

    //poids (temp)
    public float weightGoal;

    //protocole
    private Protocole protocole = new Protocole();

    //JSON
    public TextAsset jsonErrorFile;
    public TextAsset jsonObjectiveFile;

    ErrorManager allPossibleErrors; //erreurs


    //scale open
    public bool isScaleOpen = false;

    public GameObject scalePlaceholder;

    public bool isScaleBroken = false;

    public GameObject scaleDoorUp;

    //Variables pour sorbonne 
    public bool isInSorbonne = false; // "en vue sorbonne ?"

    //Liste des toggles (ordonnés en fonction des objectifs)
    public List<GameObject> toggleList1;
    public List<GameObject> toggleList2;

    //*********************************************************** FONCTIONS

    private void Awake() //inscription aux events
    {
        CameraManager.OnNewArea += SetArea; //changement de zone
        ContainerObjectScript.ObjectHadSomethingHappenEvent += this.protocole.checkIfOrderedObjectiveIsValidated; 
        HoldingTool.ObjectHadSomethingHappenEvent += this.protocole.checkIfOrderedObjectiveIsValidated;
        Protocole.OnObjectiveSuccessfullyCompletedEvent += ToggleUpdate;
    }

    //MAIN
    
    void Start()
    {
        //Call json
        //allPossibleErrors = this.protocole.DeserializeJSONErrors(jsonErrorFile);
        protocole.DeserializeJSONProtocole(jsonObjectiveFile);
    }

    void Update()
    {
        
    }

    //AUTRE

    void SetArea(int intArea) //0 = paillasse / 1 = balance / 2 = sorbonne
    {
        if (intArea == 0)
        {
            area = "paillasse";
        }
        else if (intArea == 1)
        {
            area = "balance";
        }
        else
        {
            area = "sorobnne";
        }
    }

    void ToggleUpdate()
    {
        toggleList1[this.protocole.objectivesCounter].GetComponent<Toggle>().isOn = true;
        toggleList2[this.protocole.objectivesCounter].GetComponent<Toggle>().isOn = true;
    }

    void OnScaleInteraction() //interaction avec la balance -> changement statut placeholder  //****************************************************************** CHANGER POSITIONS
    {
        Placeholderscripttest tempScalePlaceholder = scalePlaceholder.GetComponent<Placeholderscripttest>();
        tempScalePlaceholder.isReachable = isScaleOpen;

        if (!isScaleOpen && tempScalePlaceholder.occupyingObject != null && !isScaleBroken)
        {
            tempScalePlaceholder.scaleText.text = string.Format("{0:0.00}g", tempScalePlaceholder.occupyingObject.GetComponent<ContainerObjectScript>().weight);
        }

        if (!isScaleOpen) //si elle etait ouverte mais on va fermer
        {
            scaleDoorUp.LeanMoveLocalY(-0.055f, 0.3f);
        }
        else //si elle etait fermée mais on va ouvrir
        {
            scaleDoorUp.LeanMoveLocalY(0.055f, 0.3f);
        }

    }
}
