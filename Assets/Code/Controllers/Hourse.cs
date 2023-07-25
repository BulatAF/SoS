using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourse : MonoBehaviour
{
    	[SerializeField] private GameObject table1;
    	[SerializeField] private GameObject table2;
		void Start()
    {
        table1.SetActive(true);
		table2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CharacterController.ypos > -2.69f )
		{
			table2.SetActive(true);
			table1.SetActive(false);
		}
		else{
			table1.SetActive(true);
		table2.SetActive(false);
		}
    }
}
