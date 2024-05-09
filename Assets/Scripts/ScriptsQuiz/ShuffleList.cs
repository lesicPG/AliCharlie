using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShuffleList
{
    public static List<E> ShuffleListItems<E>(List<E> inputList)
    {
        List<E> originalList = new List<E>();
        originalList.AddRange(inputList);
        List<E> randomList = new List<E>();

        System.Random r = new System.Random();
        
        int randomIndex = originalList.Count - 1;
        
        while (originalList.Count > 0)
        {
            
           // randomIndex = r.Next(0, originalList.Count); //Choose a random object in the list
           // Debug.Log("random index " + randomIndex);
            randomList.Add(originalList[randomIndex]); //add it to the new, random list
            originalList.RemoveAt(randomIndex); //remove to avoid duplicates
            randomIndex--;
            
            
        }

        return randomList; //return the new random list
    }
}
