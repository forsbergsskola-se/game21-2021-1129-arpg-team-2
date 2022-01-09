using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class QuestDetail : MonoBehaviour
{
    public void Set(List<QuestTodo> todoList)
    {
        var result = todoList.Aggregate("", (current, todo) => current + $"- {todo.Description} \n");
        GetComponent<TextMeshProUGUI>().text = result;
    }
}
