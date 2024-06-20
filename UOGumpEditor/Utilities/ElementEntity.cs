using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public class ElementEntity(ElementControl element)
    {
        public ElementControl Element { get; private set; } = element;

        public override string ToString()
        {
            if (Element.Tag is ArtEntity artEntity)
            {
                return $"{artEntity.ToString().Split('-').Last().Trim()} : {artEntity.ID}";
            }

            return $"{Element.ElementType} : {Element.Text.Length}";
        }
    }
}
