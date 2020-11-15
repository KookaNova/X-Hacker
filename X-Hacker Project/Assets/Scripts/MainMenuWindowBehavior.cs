using System;
using UnityEngine;

public class MainMenuWindowBehavior : MonoBehaviour
{
    public GameObject controlsPrefab, printShopPrefab, closePrefab;
    private GameObject controlsInst, printShopInst, closeInst;
    public Vector3SO socketOneLoc, socketTwoLoc, socketThreeLoc;
    private Vector3 instLoc;
    
    [Serializable]
    public struct Socket
    {
        public bool inUse;
        public GameObject objInSocket;
    }

    public Socket[] socketList;

    private void LocationCheck()
    {
        if (!socketList[0].inUse)
        {
            instLoc = socketOneLoc.data;
        } 
        else if (!socketList[1].inUse)
        {
            instLoc = socketTwoLoc.data;
        }
        else
        {
            instLoc = socketThreeLoc.data;
        }
    }

    private void AssignSocket(GameObject obj)
    {
        if (!socketList[0].inUse)
        {
            socketList[0].objInSocket = obj;
            socketList[0].inUse = true;
        } 
        else if (!socketList[1].inUse)
        {
            socketList[1].objInSocket = obj;
            socketList[1].inUse = true;
        }
        else
        {
            socketList[2].objInSocket = obj;
            socketList[2].inUse = true;
        }
    }

    public void InstControlWindow()
    {
        if (controlsInst == null)
        {
            LocationCheck();
            controlsInst = Instantiate(controlsPrefab, gameObject.transform);
            controlsInst.transform.localPosition = instLoc;
            AssignSocket(controlsInst);
            UpdateSocketStatus();
        }
    }
    
    public void InstPrintShopWindow()
    {
        if (printShopInst == null)
        {
            LocationCheck();
            printShopInst = Instantiate(printShopPrefab, gameObject.transform);
            printShopInst.transform.localPosition = instLoc;
            AssignSocket(printShopInst);
            UpdateSocketStatus();
        }
    }
    
    public void InstCloseWindow()
    {
        if (closeInst == null)
        {
            LocationCheck();
            closeInst = Instantiate(closePrefab, gameObject.transform);
            closeInst.transform.localPosition = instLoc;
            AssignSocket(closeInst);
            UpdateSocketStatus();
        }
    }

    public void RemoveControlWindow()
    {
        for (int i = 0; i < socketList.Length; i++)
        {
            if (socketList[i].objInSocket == controlsInst)
            {
                socketList[i].objInSocket = null;
            }
        }

        controlsInst.gameObject.GetComponent<DestroyBehavior>().DestroyObj();
        UpdateSocketStatus();
        UpdateWindowPosition();
    }
    
    public void RemovePrintShopWindow()
    {
        for (int i = 0; i < socketList.Length; i++)
        {
            if (socketList[i].objInSocket == printShopInst)
            {
                socketList[i].objInSocket = null;
            }
        }

        printShopInst.gameObject.GetComponent<DestroyBehavior>().DestroyObj();
        UpdateSocketStatus();
        UpdateWindowPosition();
    }
    
    public void RemoveCloseWindow()
    {
        for (int i = 0; i < socketList.Length; i++)
        {
            if (socketList[i].objInSocket == closeInst)
            {
                socketList[i].objInSocket = null;
            }
        }

        closeInst.gameObject.GetComponent<DestroyBehavior>().DestroyObj();
        UpdateSocketStatus();
        UpdateWindowPosition();
    }

    private void UpdateSocketStatus()
    {
        for (int i = 0; i < socketList.Length; i++)
        {
            if (socketList[i].objInSocket == null)
            {
                socketList[i].inUse = false;
            }
        }
    }

    private void UpdateWindowPosition()
    {
        //First socket not in use
        if (!socketList[0].inUse && socketList[1].inUse && !socketList[2].inUse) //Second socket in use, not Third
        {
            socketList[0].inUse = socketList[1].inUse;
            socketList[0].objInSocket = socketList[1].objInSocket;
            socketList[0].objInSocket.transform.localPosition = socketOneLoc.data;
            socketList[1].inUse = false;
            socketList[1].objInSocket = null;
        } 
        else if (!socketList[0].inUse && !socketList[1].inUse && socketList[2].inUse) //Second socket not in use, Third is
        {
            socketList[0].inUse = socketList[2].inUse;
            socketList[0].objInSocket = socketList[2].objInSocket;
            socketList[0].objInSocket.transform.localPosition = socketOneLoc.data;
            socketList[2].inUse = false;
            socketList[2].objInSocket = null;
        }
        else if (!socketList[0].inUse && socketList[1].inUse && socketList[2].inUse) //Both Second and Third socket in use
        {
            socketList[0].inUse = socketList[1].inUse;
            socketList[0].objInSocket = socketList[1].objInSocket;
            socketList[0].objInSocket.transform.localPosition = socketOneLoc.data;
            
            socketList[1].inUse = socketList[2].inUse;
            socketList[1].objInSocket = socketList[2].objInSocket;
            socketList[1].objInSocket.transform.localPosition = socketTwoLoc.data;
            
            socketList[2].inUse = false;
            socketList[2].objInSocket = null;
        }

        //Second socket not in use
        if (!socketList[1].inUse && socketList[2].inUse)
        {
            socketList[1].inUse = socketList[2].inUse;
            socketList[1].objInSocket = socketList[2].objInSocket;
            socketList[1].objInSocket.transform.localPosition = socketTwoLoc.data;
            
            socketList[2].inUse = false;
            socketList[2].objInSocket = null;
        }
    }
}