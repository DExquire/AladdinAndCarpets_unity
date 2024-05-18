using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsBehaviour : MonoBehaviour
{
    public GameManager gameManager;
    public List<GameObject> columnsPref;
    public Transform columnsParent;
    public Transform positionInstance;
    public Transform limitPosition;
    public float upperLimit;
    public float lowerLimit;

    public float time;
    public float timeLimit;

    private void Update()
    {
        CreateColumn();
    }

    public void CreateColumn()
    {
        time += Time.deltaTime;
        if (time >= timeLimit)
        {
            var newColumn = Instantiate(columnsPref[Random.Range(0, columnsPref.Count)], positionInstance.position, Quaternion.identity, columnsParent);
            if(newColumn.tag != "Coin")
            { 
                newColumn.transform.localPosition = new(newColumn.transform.localPosition.x, -107, -1);
            }
            else
            {
                newColumn.transform.localPosition = new(newColumn.transform.localPosition.x, Random.Range(lowerLimit, upperLimit), -1);
            }
            newColumn.GetComponent<CoilBehaviour>().limitPoint = limitPosition;
            newColumn.GetComponent<CoilBehaviour>().gameManager = gameManager;

            time = 0;
        }

        
    }


}
