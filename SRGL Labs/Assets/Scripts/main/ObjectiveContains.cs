using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveContains : Objective
{
    public string container;
    public Dictionary<string, float> content;
    public bool melange;
    public int numero;

    public ObjectiveContains(string name, Dictionary<string, float> dictionary, bool mix, int nb)
    {
        this.content = dictionary;
        this.container = name;
        this.melange = mix;
        this.numero = nb;
    }

    public override bool Evaluate(Objective obj)
    {
        //add ignore a specific element if needed

        //verification du dictionnaire (stricte)
        ObjectiveContains temp = (ObjectiveContains)obj;

        bool flag = temp.content.Count == this.content.Count;

        if (flag)
        {
            foreach (KeyValuePair<string, float> pair in this.content)
            {

                if (!(temp.content.ContainsKey(pair.Key)) || (pair.Value !=-1 && !(temp.content[pair.Key] == pair.Value)))
                {
                    flag = false;
                    break;
                }
            }
        }

        //verification du reste
        return flag && this.container.Equals(temp.container) && this.melange == temp.melange;
    }
}
