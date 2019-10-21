using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G_Foes : Foes
{
    private bool gyroenabled;
	private Gyroscope gyro;
	private Quaternion rot;


	
	Transform comida;
    Rigidbody cuerpo;
    int SigX;
    int SigZ;
    //float limite;
    int count;
	public G_Foes(string name, int points){
		
		this.Name = name;
		this.Points = points;
		
	}
	
	
    // Start is called before the first frame update
    void Start()
    {

		gyroenabled = EnableGyro();
		

        comida = this.GetComponent<Transform>();
        cuerpo = this.GetComponent<Rigidbody>();
       // Debug.Log("Get Position");
        Debug.Log(comida.position);
        //limite = (Mathf.Abs(comida.position.x) > Mathf.Abs(comida.position.z) ? Mathf.Abs(comida.position.x) : Mathf.Abs(comida.position.z));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if(count == 10)
        {
        movement_degree();
        count = 0;
        }
    }
	
    private void Update()
	{
		
        if(gyroenabled)
		{
			Quaternion q = gyro.attitude * rot;
			Debug.Log(q);
			q = new Quaternion(q.x,q.y,q.z,q.w);
			transform.localRotation = q;
           
			
		}
        
    }

    void movement_degree()
    {



        //Si calculo el angulo interno, y luego hago regla de 3 para sacar el nuevo largo de la hipotenusa
        //podria calcular los catetos, de forma independiente, con el angulo interno y el angulo recto-
   /*      SigX = (comida.position.x > 0  ?  1 : -1);
        SigZ = (comida.position.z > 0  ?  1 : -1);

            //comida.rotation = new Quaternion(comida.rotation.x,comida.rotation.y+0.1f,comida.rotation.z,1);
            cuerpo.drag = 30;

        if(SigX == 1 && SigZ == 1)
        {
            comida.position = new Vector3(comida.position.x-1,comida.position.y,comida.position.z+1);
        }  
        else if(SigX == -1 && SigZ == 1)
        {
            comida.position = new Vector3(comida.position.x-1,comida.position.y,comida.position.z-1);
        }
        else if(SigX == -1 && SigZ == -1)
        {
            comida.position = new Vector3(comida.position.x+1,comida.position.y,comida.position.z-1);
        }
        else
        {
            comida.position = new Vector3(comida.position.x+1,comida.position.y,comida.position.z+1);
        }
        */
    }
	
    private bool EnableGyro()
	{
		if(SystemInfo.supportsGyroscope)
		{
			gyro = Input.gyro;
			gyro.enabled = true;
			
			transform.rotation = Quaternion.Euler(90f,90f,0f);
			rot = new Quaternion(0,0,1,0);
					
			Debug.Log("enabled");
			return true;
		}
		else
		{
			Debug.Log("Disabled");
			return false;
			
		}
		
	}
	
	

	
	
}
