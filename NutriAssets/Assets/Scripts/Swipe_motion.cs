using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Swipe_motion : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	
	private enum DraggedDirection
	{
		Up,
		Down,
		Right,
		Left
	}
	
	public GameObject ITEM;
	public Image drag_space;
	public Shooter shooter;
	private float Dirr;
	private float Force = 0f;

	public Camera cam;
	
	void Start()
	{
		
	}
	
 	public void OnBeginDrag(PointerEventData eventData)
	{
		
		cam = GetComponent<Camera>();

		//Vector3 direccion =  cam.ViewportToWorldPoint(new Vector3(eventData.position.x,eventData.position.y,cam.transform.rotation.z));
		//Physics.Raycast(new Vector3(eventData.position.x,eventData.position.y,cam.transform.rotation.z),cam.transform.forward,100,0);

	/* 
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,0))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }*/
    }

	
	public void OnDrag(PointerEventData eventData)
	{
	
	}
	
	
	public void OnEndDrag(PointerEventData eventData)
	{
		GameObject tool = Instantiate(ITEM,shooter.transform.position,Quaternion.identity);
		Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
		//Debug.Log("norm + " + dragVectorDirection);
		Rigidbody rg_tool = tool.GetComponent<Rigidbody>();
		Dirr = dragVectorDirection.x;
		Force = 250*dragVectorDirection.y;
		float Zrange = 250;//*(shooter.transform.rotation.y);

		if(Dirr < 0)
		{
		//Debug.Log("LEFT");
		rg_tool.AddForce(new Vector3(Force*dragVectorDirection.x,Force*dragVectorDirection.y,Force),ForceMode.Impulse);
		}
		else
		{
		//Debug.Log("RIGHT");
		rg_tool.AddForce(new Vector3(Force*dragVectorDirection.x,Force*dragVectorDirection.y,Force),ForceMode.Impulse);	
		}
	}
	
	
	
	private DraggedDirection GetDragDirection(Vector3 dragVector)
	{
		float positiveX = Mathf.Abs(dragVector.x);
		float positiveY = Mathf.Abs(dragVector.y);

		DraggedDirection draggedDir;
		
		if (positiveX > positiveY)
		{
			draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
		}
		else
		{
			draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
		}
		
		Debug.Log(draggedDir);
		return draggedDir;
	}

}
