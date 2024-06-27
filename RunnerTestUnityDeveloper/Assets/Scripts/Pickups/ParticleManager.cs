using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

[Serializable]
public class MyParticle
{
    [SerializeField] private List<GameObject> myParticle = new List<GameObject>();
    [SerializeField] private string particleType;

    public void AddNewObject(GameObject go)
    {
        myParticle.Add(go);
    }

    public bool IsRequiredType(string type)
    {
        return particleType == type;
    }

    public GameObject GetInactive()
    {
        foreach (GameObject go in myParticle)
            if (go.activeSelf == false)
                return go;
        return null;
    }

    public GameObject GetActive()
    {
        foreach (GameObject go in myParticle)
            if (go.activeSelf == true)
                return go;
        return null;
    }
    
    public Transform GetMyParticleParent()
    {
        return myParticle[0].transform;
    }

    public void DeactivateAll()
    {
        foreach (GameObject go in myParticle)
            if (go.activeSelf)
                go.SetActive(false);
    }

    /*
    public bool IsActive()
    {
        return myParticle.activeSelf;
    }

    public void SetPosition(Vector3 newPos)
    {
        myParticle.transform.position = newPos;
    }

    public void SetRotation(Quaternion newRot)
    {
        myParticle.transform.rotation = newRot;
    }

    public void Activate()
    {
        myParticle.SetActive(true);
    }

    public void Deactivate()
    {
        myParticle.SetActive(false);
    }

    public GameObject GetMyParticle()
    {
        return myParticle;
    }
    
    public Text GetMyParticleText()
    {
        return myParticle.GetComponentInChildren<Text>();
    }
    */
}


public sealed class ParticleManager : MonoBehaviour
{
    [SerializeField] private List<MyParticle> allParticle = new List<MyParticle>();
    public static ParticleManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    public void ClearAllParticles()
    {
        foreach(MyParticle mp in allParticle)
        {
            mp.DeactivateAll();
        }
    }

    public void SetRequiredParticle(string type, Vector3 newPos)
    {
        if (type == "" || type == null)
            return;
        GameObject particle = GetRequiredParticle(type, newPos);
        particle.SetActive(true);
    }

    public void SetRequiredParticle(string type, Vector3 newPos, Quaternion newRot)
    {
        if (type == "" || type == null)
            return;
        GameObject particle = GetRequiredParticle(type, newPos, newRot);
        particle.SetActive(true);
    }

    /*
    public void SetRequiredParticle (string type, Vector3 newPos, string txt)
    {
        if (type == string.None)
            return;
        GameObject particle = GetRequiredParticle(type, newPos);
        particle.SetActive(true);
    }
    */

    public GameObject GetRequiredParticle(string type)
    {
        GameObject particle = null;
        foreach (MyParticle obj in allParticle)
        {
            if (obj.IsRequiredType(type))
            {
                particle = obj.GetInactive();
                break;
            }
        }
        if (particle == null)
            particle = InstantiateNewMyParticle(type);
        return particle;
    }

    public GameObject GetRequiredParticle(string type, Vector3 newPosition)
    {
        GameObject particle = GetRequiredParticle(type);
        particle.transform.position = newPosition;
        particle.SetActive(true);
        return particle;
    }

    public GameObject GetRequiredParticle(string type, Vector3 newPosition, Quaternion rot)
    {
        GameObject particle = GetRequiredParticle(type);
        particle.transform.position = newPosition;
        particle.transform.rotation = rot;
        particle.SetActive(true);
        return particle;
    }

    private GameObject InstantiateNewMyParticle(string type)
    {
        foreach (MyParticle obj in allParticle)
        {
            if (obj.IsRequiredType(type))
            {
                GameObject newObject = Instantiate(obj.GetActive(), obj.GetMyParticleParent().parent);
                obj.AddNewObject(newObject);
                return newObject;                
            }
        }
        throw new NullReferenceException("Missing Particle type in list");
    }
}

