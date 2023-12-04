using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CustomLink : MonoBehaviour
{
    public List<CustomLink> connections;
    private CustomLink cl;
    // public List<> // здесь кешированные компоненты добавить
    public void AddLink(GameObject go)
    {
        cl = go.GetComponent<CustomLink>();
        if (cl != null)
        {
            connections.Add(cl);
            // ну и заполняем списки кешированных компонентов с этого объекта
        }
    }
    /*  public void DeleteLink(int index)
     {
         if (index >= 0 && index < connections.Count)
         {
             cl.Delete(index);
             // также удаляем кешированные компоненты
         }
     } */
}





