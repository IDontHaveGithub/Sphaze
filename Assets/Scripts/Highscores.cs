using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour {

    public string[] items;
    public Text scores;

    IEnumerator Start()
    {
        WWW itemsData = new WWW("http://localhost/fuck/ItemsData.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        items = itemsDataString.Split(';');
        scores.text = GetDataValue(items[0], "Cost:  " + "Type: ");
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
