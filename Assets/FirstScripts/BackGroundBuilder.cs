using UnityEngine;
using System.Collections;

public class BackGroundBuilder : MonoBehaviour {
	public GameObject Black;
	public GameObject White;
	public int xStartPos;
	public int yStartPos;
	public int height;
	public int width;
    
    
	// Use this for initialization
	void Start () {
	
		for (int i=0; i< height; i++) {
			for(int k=0;k<width;k++)
			{
				if(i%2==0)
				{
					if(k%2==0)
					{
						Instantiate(White,new Vector3(xStartPos+ k,yStartPos+i,9),Quaternion.identity);
					}
					else
					{
						Instantiate(Black,new Vector3(xStartPos+ k,yStartPos+i,9),Quaternion.identity);
					}

				}
				else
				{
					if(k%2==0)
					{
						Instantiate(Black,new Vector3(xStartPos+ k,yStartPos+i,9),Quaternion.identity);
					}
					else
					{
						Instantiate(White,new Vector3(xStartPos+ k,yStartPos+i,9),Quaternion.identity);
					}

				}

			}
			
		
		}

		for (int i=0; i< height; i++) {
			for(int k=0;k<width;k++)
			{
				if(i%2==0)
				{
					if(k%2==0)
					{
						Instantiate(White,new Vector3(xStartPos+ k,-10,yStartPos+i),Quaternion.identity);
					}
					else
					{
						Instantiate(Black,new Vector3(xStartPos+ k,-10,yStartPos+i),Quaternion.identity);
					}
					
				}
				else
				{
					if(k%2==0)
					{
						Instantiate(Black,new Vector3(xStartPos+ k,-10,yStartPos+i),Quaternion.identity);
					}
					else
					{
						Instantiate(White,new Vector3(xStartPos+ k,-10,yStartPos+i),Quaternion.identity);
					}
					
				}
				
			}
			
			
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
