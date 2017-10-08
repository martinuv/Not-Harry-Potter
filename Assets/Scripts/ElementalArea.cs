using UnityEngine;

public class ElementalArea : Elemental
{
    [SerializeField] FireIce startElement;

    private string curElement;

    void Start() {
        if (startElement == FireIce.fire)
            Ignite();
        else if (startElement == FireIce.ice)
            Freeze();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Orb>() != null) {
            Orb orb = other.gameObject.GetComponent<Orb>();
            if (curElement == Element.fire)
                orb.Ignite();
            else if (curElement == Element.ice)
                orb.Freeze();
        }
    }

    override public void Ignite()
    {
        curElement = Element.fire;
    }

    override public void Freeze()
    {
        curElement = Element.ice;
    }

    private enum FireIce
    {
        fire,
        ice
    }
}
