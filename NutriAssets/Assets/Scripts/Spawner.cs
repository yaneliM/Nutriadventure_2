using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
   /* 
    public G_Foes Apple;
	public G_Foes Meat;
	public G_Foes Candy;
	public G_Foes Orange;
	public G_Foes MOrange;
	*/
	public Aux_Foe List_prefabs;
	
	
	public List<Foes> Foe_List = new List<Foes>(); 
	private int ct_frame;
	private int ct_sec;
	private int ct_enemies;
	//Crear lista 
 	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ct_enemies = Foe_List.Count;
		
		ct_frame++;
		if(ct_frame == 30)
		{
		
			ct_frame = 0;
			ct_sec++;
			
			if(ct_sec == 15)
			{
			
				ct_sec = 0;
				if(ct_enemies <= 5)
					Spawn();
			
			}
		
		}	
			
	}
	
	public void Spawn()
	{
		int List_size = List_prefabs.List_prefab.Count;
		Debug.Log("Tamaño de la lista: "+List_size);
		G_Foes food = List_prefabs.List_prefab[Random.Range(0,List_size-1)];//cambiar a List_prefabs

		Debug.Log(food.name);

		Foe_List.Add(food);

		Instantiate(food,Spawn_position(),Quaternion.identity);
		
	}

	Vector3 Spawn_position()
		{
			int SPx=0;
			int SPz=0;
			int Dirx = 0;
			int Dirz = 0;

			SPx = Random.Range(1,4);
			SPz = Random.Range(1,4);

			while(Dirx == 0)
			{
				Dirx = Random.Range(-1,2);
			}
			while(Dirz == 0)
			{
				Dirz = Random.Range(-1,2);
			}
			if(Dirx == -1)
			{
				//Debug.Log("Izquierda");
			}
			else
			{
				//Debug.Log("Derecha");
			}
			if(Dirz == -1)
			{
				//Debug.Log("Atras");
			}
			else
			{
				//Debug.Log("Enfrente");
			}



			return new Vector3(Dirx*SPx*10,0,Dirz*SPz*10); //Direccion * Distancia * 

		} 
	
}
	
	

