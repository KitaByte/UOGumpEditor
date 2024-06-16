using System.Text;
using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public static class GumpExport
    {
        public static void ExportGump(ElementControl[] elements, string gumpName)
        {
            switch ((GumpTypes)UOSettings.Default.ExportType)
            {
                case GumpTypes.CSharp:
                    {
                        ExportToCSharp(elements, gumpName);

                        break;
                    }

                case GumpTypes.Sphere:
                    {
                        ExportToSphere(elements, gumpName);

                        break;
                    }

                case GumpTypes.MUO:
                    {
                        ExportToMUO(elements, gumpName);

                        break;
                    }
            }
        }

        private static void ExportToCSharp(ElementControl[] elements, string gumpName)
        {
            StringBuilder sb = new();

            ArtEntity? entity;

            int counter = 1;

            int txtCounter = 1;

            sb.AppendLine("using System;");
            sb.AppendLine("using Server;");
            sb.AppendLine("using Server.Gumps;");
            sb.AppendLine("using Server.Network;");
            sb.AppendLine();
            sb.AppendLine($"public class {gumpName}Gump : Gump");
            sb.AppendLine("{");
            sb.AppendLine($"    public {gumpName}Gump() : base(50, 50)");
            sb.AppendLine("    {");
            sb.AppendLine("        Closable = true;");
            sb.AppendLine("        Disposable = true;");
            sb.AppendLine("        Dragable = true;");
            sb.AppendLine("        Resizable = false;");
            sb.AppendLine();
            sb.AppendLine("        AddPage(0);");

            foreach (var element in elements)
            {
                if (element.Tag is ArtEntity ae)
                {
                    entity = ae;

                    switch (element.ElementType)
                    {
                        case ElementTypes.AlphaRegion:
                            {  
                                sb.AppendLine($"        AddAlphaRegion({element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height});");
                               
                                break;
                            }

                        case ElementTypes.Background:
                            {
                                sb.AppendLine($"        AddBackground({element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}, {entity.ID});");
                                   
                                break;
                            }

                        case ElementTypes.Button:
                            {
                                sb.AppendLine($"        AddButton({element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.ID + 1}, {counter}, GumpButtonType.Reply, 0);");

                                counter++;

                                break;
                            }

                        case ElementTypes.CheckBox:
                            {
                                sb.AppendLine($"        AddCheck({element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.ID + 1}, false, {counter});");

                                counter++;

                                break;
                            }

                        case ElementTypes.Image:
                            {
                                sb.AppendLine($"        AddImage({element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.Hue});");
                                
                                break;
                            }

                        case ElementTypes.Item:
                            {
                                sb.AppendLine($"        AddItem({element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.Hue});");
                                
                                break;
                            }

                        case ElementTypes.RadioButton:
                            {
                                sb.AppendLine($"        AddRadio({element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.ID + 1}, false, {counter});");

                                counter++;

                                break;
                            }

                        case ElementTypes.TiledImage:
                            {
                                sb.AppendLine($"        AddImageTiled({element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}, {entity.ID});");
                                
                                break;
                            }

                        case ElementTypes.TextEntry:
                            {
                                sb.AppendLine($"        AddImage({element.Location.X}, {element.Location.Y}, {entity.ID});");
                                sb.AppendLine($"        AddTextEntry({element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}, {txtCounter}, 0, \"{element.Text}\");");

                                txtCounter++;

                                break;
                            }
                    }
                }
                else
                {
                    switch (element.ElementType)
                    {
                        case ElementTypes.Html:
                            {
                                sb.AppendLine($"        AddHtml({element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}, \"{UOEditorCore.CombineMultiString(element.Text, false)}\", false, false);");
                                
                                break;
                            }

                        case ElementTypes.Label:
                            {
                                sb.AppendLine($"        AddLabel({element.Location.X}, {element.Location.Y}, {UOEditorCore.GetNumberFromColor(element.TextColor)}, \"{element.Text}\");");
                                
                                break;
                            }
                    }
                }
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            File.WriteAllText(Path.Combine(UOArtLoader.ExportFolder, $"{gumpName}Gump.cs"), sb.ToString());

            SendCompletedMsg($"{gumpName}Gump.cs");
        }

        private static void ExportToSphere(ElementControl[] elements, string gumpName)
        {
            StringBuilder sb = new();

            ArtEntity? entity;

            int buttonCounter = 1; 

            sb.AppendLine($"[DIALOG d_{gumpName}_gump]");
            sb.AppendLine("0,0");
            sb.AppendLine();
            sb.AppendLine("page 0");

            foreach (var element in elements)
            {
                if (element.Tag is ArtEntity ae)
                {
                    entity = ae;

                    switch (element.ElementType)
                    {
                        case ElementTypes.AlphaRegion:
                            {
                                sb.AppendLine($"checkertrans {element.Location.X} {element.Location.Y} {element.Width} {element.Height}");

                                break;
                            }

                        case ElementTypes.Background:
                            {
                                sb.AppendLine($"resizepic {element.Location.X} {element.Location.Y} {entity.ID} {element.Width} {element.Height}");

                                break;
                            }

                        case ElementTypes.Button:
                            {
                                sb.AppendLine($"button {element.Location.X} {element.Location.Y} {entity.ID} {entity.ID + 1} 1 0 {buttonCounter}");

                                buttonCounter++;

                                break;
                            }

                        case ElementTypes.CheckBox:
                            {
                                sb.AppendLine($"checkbox {element.Location.X} {element.Location.Y} {entity.ID} {entity.ID + 1} 0 {buttonCounter}");

                                buttonCounter++;

                                break;
                            }

                        case ElementTypes.Image:
                            {
                                sb.AppendLine($"gumppic {element.Location.X} {element.Location.Y} {entity.ID} {entity.Hue}");

                                break;
                            }

                        case ElementTypes.Item:
                            {
                                sb.AppendLine($"tilepic {element.Location.X} {element.Location.Y} {entity.ID}");

                                break;
                            }

                        case ElementTypes.RadioButton:
                            {
                                sb.AppendLine($"radio {element.Location.X} {element.Location.Y} {entity.ID} {entity.ID + 1} 0 {buttonCounter}");

                                buttonCounter++;

                                break;
                            }
                        case ElementTypes.TiledImage:
                            {
                                sb.AppendLine($"gumppictiled {element.Location.X} {element.Location.Y} {element.Width} {element.Height} {entity.ID}");

                                break;
                            }
                        case ElementTypes.TextEntry:
                            {
                                sb.AppendLine($"gumppic {element.Location.X} {element.Location.Y} {entity.ID}");
                                sb.AppendLine($"dtextentry {element.Location.X} {element.Location.Y} {element.Width} {element.Height} 0 {buttonCounter} {element.Text}");

                                buttonCounter++;

                                break;
                            }
                    }
                }
                else
                {
                    switch (element.ElementType)
                    {
                        case ElementTypes.Html:
                            {
                                sb.AppendLine($"htmlgump {element.Location.X} {element.Location.Y} {element.Width} {element.Height} \"{element.Text}\" 0 0");

                                break;
                            }
                        case ElementTypes.Label:
                            {
                                sb.AppendLine($"dtext {element.Location.X} {element.Location.Y} {UOEditorCore.GetNumberFromColor(element.TextColor)} {element.Text}");

                                break;
                            }
                    }
                }
            }

            sb.AppendLine();
            sb.AppendLine($"[DIALOG d_{gumpName}_gump button]");
            sb.AppendLine("on=0 // Exit");
            sb.AppendLine();

            for (int i = 1; i < buttonCounter; i++)
            {
                sb.AppendLine($"on={i} // Button {i}");
                sb.AppendLine();
            }

            File.WriteAllText(Path.Combine(UOArtLoader.ExportFolder, $"{gumpName}Gump.scp"), sb.ToString());

            SendCompletedMsg($"d_{gumpName}.scp");
        }

        private static void ExportToMUO(ElementControl[] elements, string gumpName)
        {
            StringBuilder sb = new();

            ArtEntity? entity;

            int counter = 1;
            int txtCounter = 1;

            sb.AppendLine("using System;");
            sb.AppendLine("using Server;");
            sb.AppendLine("using Server.Network;");
            sb.AppendLine();
            sb.AppendLine("namespace Server.Gumps;");
            sb.AppendLine();
            sb.AppendLine($"public class {gumpName}Gump : DynamicGump");
            sb.AppendLine("{");
            sb.AppendLine($"    public {gumpName}Gump() : base(50, 50)");
            sb.AppendLine("     {");
            sb.AppendLine("         protected sealed override void BuildLayout(ref DynamicGumpBuilder builder)");
            sb.AppendLine("         {");
            sb.AppendLine("             builder.AddPage();");
            sb.AppendLine("             builder.SetNoResize();");
            sb.AppendLine();

            foreach (var element in elements)
            {
                if (element.Tag is ArtEntity ae)
                {
                    entity = ae;

                    switch (element.ElementType)
                    {
                        case ElementTypes.AlphaRegion:
                            {
                                sb.AppendLine($"            builder.AddAlphaRegion({element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height});");

                                break;
                            }

                        case ElementTypes.Background:
                            {
                                sb.AppendLine($"            builder.AddBackground({element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}, {entity.ID});");

                                break;
                            }

                        case ElementTypes.Button:
                            {
                                sb.AppendLine($"            builder.AddButton({element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.ID + 1}, {counter});");

                                counter++;

                                break;
                            }

                        case ElementTypes.CheckBox:
                            {
                                sb.AppendLine($"            builder.AddCheck({element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.ID + 1}, false, {counter});");

                                counter++;

                                break;
                            }

                        case ElementTypes.Image:
                            {
                                sb.AppendLine($"            builder.AddImage({element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.Hue});");

                                break;
                            }

                        case ElementTypes.Item:
                            {
                                sb.AppendLine($"            builder.AddItem({element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.Hue});");

                                break;
                            }

                        case ElementTypes.RadioButton:
                            {
                                sb.AppendLine($"            builder.AddRadio({element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.ID + 1}, false, {counter});");

                                counter++;

                                break;
                            }

                        case ElementTypes.TiledImage:
                            {
                                sb.AppendLine($"            builder.AddImageTiled({element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}, {entity.ID});");

                                break;
                            }

                        case ElementTypes.TextEntry:
                            {
                                sb.AppendLine($"            builder.AddImage({element.Location.X}, {element.Location.Y}, {entity.ID});");
                                sb.AppendLine($"            builder.AddTextEntry({element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}, {txtCounter}, 0, \"{element.Text}\");");

                                txtCounter++;

                                break;
                            }
                    }
                }
                else
                {
                    switch (element.ElementType)
                    {
                        case ElementTypes.Html:
                            {
                                sb.AppendLine($"            builder.AddHtml({element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}, \"{element.Text}\", false, false);");

                                break;
                            }

                        case ElementTypes.Label:
                            {
                                sb.AppendLine($"            builder.AddLabel({element.Location.X}, {element.Location.Y}, {UOEditorCore.GetNumberFromColor(element.TextColor)}, \"{element.Text}\");");

                                break;
                            }
                    }
                }
            }

            sb.AppendLine("         }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            File.WriteAllText(Path.Combine(UOArtLoader.ExportFolder, $"{gumpName}Gump.cs"), sb.ToString());

            SendCompletedMsg($"{gumpName}Gump.cs");
        }

        private static void SendCompletedMsg(string fileName)
        {
            MessageBox.Show($"{fileName} Exported!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

