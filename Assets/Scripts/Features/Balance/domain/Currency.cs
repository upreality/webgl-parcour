using UnityEngine;

namespace Features.Balance.domain
{
    public class Currency
    {
        public int ID;
        public string Name;
        public string Description;
        public Sprite Icon;

        public Currency(int id, string name, Sprite icon, string description = "")
        {
            ID = id;
            Name = name;
            Description = description;
            Icon = icon;
        }
    }
}