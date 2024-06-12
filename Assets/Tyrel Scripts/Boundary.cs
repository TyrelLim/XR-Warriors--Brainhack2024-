using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Boundary : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject Cam;
    public GameObject Locomotion;
    float V,H;
    int L,R;
    public float VL,HL;
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Debug.Log("Vertical Input" + verticalInput + "Horizontal Input" + horizontalInput);
        
        RaycastHit hit;

        for(int i = 0; i < 360; i += 10)
        {   
            L = i-90;
            R = i+90;
            if(L > 360)
            {
                L -=360;
            }
            else if(L < 0)
            {
                L +=360;
            }
            if(R > 360)
            {
                R -=360;
            }
            else if(R < 0)
            {
                R +=360;
            }
            if (i < 90)
            {
                V = 1 - (i / 90f);
            }
            else if (i < 180)
            {
                V = -((i % 90) / 90f);
            }
            else if (i < 270)
            {
                V = -(1 - ((i % 90) / 90f));
            }
            else
            {
                V = (i % 90) / 90f;
            }

            // Calculate H based on angle i
            if (i <= 90)
            {
                H = i / 90f;
            }
            else if (i <= 180)
            {
                H = 1 - ((i & 90) / 90f);
            }
            else if (i <= 270)
            {
                H = -((i % 90) / 90f);
            }
            else
            {
                H = -(1 - ((i % 90) / 90f));
            }

            // Calculate VL based on angle L
            if (L < 90)
            {
                VL = 1 - (L / 90f);
            }
            else if (L < 180)
            {
                VL = -((L % 90) / 90f);
            }
            else if (L < 270)
            {
                VL = -(1 - ((L % 90) / 90f));
            }
            else
            {
                VL = (L % 90) / 90f;
            }

            // Calculate HL based on angle L
            if (L <= 90)
            {
                HL = L / 90f;
            }
            else if (L <= 180)
            {
                HL = 1 - ((L & 90) / 90f);
            }
            else if (L <= 270)
            {
                HL = -((L % 90) / 90f);
            }
            else
            {
                HL = -(1 - ((L % 90) / 90f));
            }


            Vector3 direction = Quaternion.Euler(0, i, 0) * Cam.transform.forward;
            if(Physics.Raycast(Cam.transform.position, direction, out hit, 0.1f ,layerMask))
            {
                Debug.Log("wasap");
                if(V > 0 && H > 0)
                {
                    if(verticalInput > VL || horizontalInput > -HL)
                    {
                        Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
                    }
                    else
                    {
                        Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
                    }
                }
                else if(V < 0 && H > 0)
                {
                    if(verticalInput < -VL || horizontalInput > HL)
                    {
                        Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
                    }
                    else
                    {
                        Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
                    }
                }
                else if(V < 0 && H < 0)
                {
                    if(verticalInput < VL || horizontalInput < -HL)
                    {
                        Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
                    }
                    else
                    {
                        Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
                    }
                }
                else if(V > 0 && H < 0)
                {
                    if(verticalInput > -VL || horizontalInput < HL)
                    {
                        Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
                    }
                    else
                    {
                        Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
                    }
                }
                else
                {
                    Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
                }
            }


        }

    }
}
