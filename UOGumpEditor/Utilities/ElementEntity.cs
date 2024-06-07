using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public class ElementEntity
    {
        public BaseElement Element { get; private set; }

        public ElementEntity(BaseElement element)
        {
            Element = element;
        }

        public override string ToString()
        {
            return $"{UOEditorCore.MainUI?.CanvasPanel.Controls.Count} : {Element.ElementType}";
        }
    }
}
