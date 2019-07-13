using UnityEngine;

public class Sphere : CRenderObject
{
    MeshRenderer meshRender;
    Color mColor = Color.black;
    public Color color {
        get { return mColor; }
        set { Setup(value); }
    }

    public float mWidth = 0;
    public float width {
        get { return mWidth; }
        set { mWidth = value; transform.localScale = new Vector3(mWidth, mWidth, mWidth); }
    }

    public override void Hide() { gameObject.SetActive(false); }
    public override void Init(object[] args)
    {
        if (args.Length != 2) Debug.LogError("Sphere argument error, count:" + args.Length);

        meshRender = gameObject.GetComponent<MeshRenderer>();
        meshRender.material = new Material(Shader.Find("Standard"));
        Setup((Color)args[0], (float)args[1]);
    }

    public override void Setup(Color c, float w = -1)
    {
        if (w > 0) width = w;
        meshRender.material.color = c;
    }

    public override void Draw(params Vector3[] args)
    {
        if (args.Length != 1) return;

        Vector3 p = args[0];
        gameObject.transform.position = p;
        gameObject.SetActive(true);
    }
    public bool imColKCl = false;
    public override int getColKCl()
    {
        int res=0;
        if ((this.transform.position.x * this.transform.position.x + this.transform.position.z * this.transform.position.z) >= 40000 - 100) {
            res = 2;
        }
        if (imColKCl)
        {
            imColKCl = false;
            return res+1;
        }
        return res;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KCl")
        {
            //Debug.Log("³ª ²áÇØÂÇ");
            imColKCl = true;
            Destroy(other.gameObject);
        }
    }
}
