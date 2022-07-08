using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldObjectiveContains : Objective
{
    //liste de couples (�l�ment,quantit�) que l'on veut / que l'on a
    List<(string, int)> listOfElementsAndQuantityRequired;

    //Constructeur
    public OldObjectiveContains(List<(string, int)> list)
    {
        this.listOfElementsAndQuantityRequired = list;
    }

    //Verification du type de l'objectif re�u puis verification des elements de la liste de l'objectif re�u
    //Note : verifie que tous les elements voulus sont dans l'objet- pas de verification si il y a un/des �l�ments en trop dans l'objet
    public override bool Evaluate(Objective obj)
    {
        if (obj.GetType() == typeof(OldObjectiveContains))
        {
            OldObjectiveContains temp = (OldObjectiveContains)obj;
            bool flag = true;

            for (int k = 0; k < this.listOfElementsAndQuantityRequired.Count; k++)
            {
                if (!temp.listOfElementsAndQuantityRequired.Contains(this.listOfElementsAndQuantityRequired[k]))
                {
                    flag = false;
                    break;
                }
            }

            return flag;


        }
        else
        {
            return false;
        }

    }
}
