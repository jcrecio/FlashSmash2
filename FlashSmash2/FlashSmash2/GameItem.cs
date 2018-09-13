namespace ChangeMe
{
    using Microsoft.Xna.Framework;
    using System.Runtime.Serialization;

    [DataContract]
    public class GameItem
    {
        [DataMember]
        public int ItemType { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public int GetItemType
        {
            get { return (int)ItemType; }
            private set { ItemType = value; }
        }

        public GameItem(int itemType)
        :this(itemType,1){}

        public GameItem(int itemType, int amount)
        {
            this.ItemType = itemType;
            this.Amount = amount;
        }

        public void Apply(Level levelWhereApply, Game gameToUpdate)
        {

        }

        public void Add()
        {
            this.Amount++;
        }

        public void Substract()
        {
            this.Amount--;
        }
    }
    [DataContract]
    public enum GameItemTypes
    {
        Bomb = 0,
        Fire = 1,
        Rocket = 2,
        Star = 3,
        Thunder = 4,
        StarDark = 5
    }
}
