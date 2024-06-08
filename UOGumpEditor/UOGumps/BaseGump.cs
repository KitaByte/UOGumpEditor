namespace UOGumpEditor.UOGumps
{
    [Serializable]
    public class BaseGump
    {
        public string Name { get; set; }

        public List<GumpElement> Elements { get; set; }

        public BaseGump(string name)
        {
            Name = name;

            Elements = [];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

