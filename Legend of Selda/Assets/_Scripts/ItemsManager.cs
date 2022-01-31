using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{

    private List<GameObject> _questItems = new List<GameObject>();

    public List<GameObject> GetQuestItem()
    {
        return _questItems;
    }

    public QuestItem GetItemAt(int idx)
    {
        return _questItems[idx].GetComponent<QuestItem>();
    }

    public bool HasQuestItem(QuestItem item)
    {
        foreach (GameObject qi in _questItems)
        {
            if (qi.GetComponent<QuestItem>().itemName == item.itemName)
            {
                return true;
            }
        }

        return false;
    }

    public void AddQuestItem(GameObject newItem)
    {
        _questItems.Add(newItem);
    }
}
