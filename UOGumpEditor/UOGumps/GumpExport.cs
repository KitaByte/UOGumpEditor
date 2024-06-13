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
                                sb.AppendLine($"        AddImage({element.Location.X}, {element.Location.Y}, {entity.ID});");
                                
                                break;
                            }

                        case ElementTypes.Item:
                            {
                                sb.AppendLine($"        AddItem({element.Location.X}, {element.Location.Y}, {entity.ID});");
                                
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
                                sb.AppendLine($"        AddLabel({element.Location.X}, {element.Location.Y}, {element.ForeColor.ToArgb()}, \"{element.Text}\");");
                                
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

            int counter = 1;

            int txtCounter = 1;

            sb.AppendLine($"[FUNCTION f_{gumpName}_gump]");
            sb.AppendLine("SERV.NEWGUMP");

            foreach (var element in elements)
            {

                if (element.Tag is ArtEntity ae)
                {
                    entity = ae;

                    switch (element.ElementType)
                    {
                        case ElementTypes.AlphaRegion:
                            {
                                sb.AppendLine($"SERV.GUMPALPHA {element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}");
                                
                                break;
                            }

                        case ElementTypes.Background:
                            {
                                sb.AppendLine($"SERV.GUMPICON {element.Location.X}, {element.Location.Y}, {entity.ID}");
                                
                                break;
                            }

                        case ElementTypes.Button:
                            {
                                sb.AppendLine($"SERV.GUMPBUTTON {element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.ID + 1}, {counter}, 0");

                                counter++;

                                break;
                            }

                        case ElementTypes.CheckBox:
                            {
                                sb.AppendLine($"SERV.GUMPCHECKBOX {element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.ID + 1}, {counter}");

                                counter++;

                                break;
                            }

                        case ElementTypes.Image:
                            {
                                sb.AppendLine($"SERV.GUMPIMAGE {element.Location.X}, {element.Location.Y}, {entity.ID}");
                                
                                break;
                            }

                        case ElementTypes.Item:
                            {
                                sb.AppendLine($"SERV.GUMPITEM {element.Location.X}, {element.Location.Y}, {entity.ID}");
                                
                                break;
                            }

                        case ElementTypes.RadioButton:
                            {
                                sb.AppendLine($"SERV.GUMPRADIO {element.Location.X}, {element.Location.Y}, {entity.ID}, {entity.ID + 1}, {counter}");

                                counter++;

                                break;
                            }

                        case ElementTypes.TiledImage:
                            {
                                sb.AppendLine($"SERV.GUMPTILED {element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}, {entity.ID}");
                                
                                break;
                            }

                        case ElementTypes.TextEntry:
                            {
                                sb.AppendLine($"SERV.GUMPIMAGE {element.Location.X}, {element.Location.Y}, {entity.ID}");
                                sb.AppendLine($"SERV.GUMPTEXTENTRY {element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}, {txtCounter}, \"{element.Text}\"");

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
                                sb.AppendLine($"SERV.GUMPTEXTHTML {element.Location.X}, {element.Location.Y}, {element.Width}, {element.Height}, \"{element.Text}\"");
                                
                                break;
                            }

                        case ElementTypes.Label:
                            {
                                sb.AppendLine($"SERV.GUMPTEXT {element.Location.X}, {element.Location.Y}, \"{element.Text}\"");
                                
                                break;
                            }
                    }
                }
            }

            File.WriteAllText(Path.Combine(UOArtLoader.ExportFolder, $"{gumpName}Gump.scp"), sb.ToString());

            SendCompletedMsg($"{gumpName}Gump.scp");
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
                                sb.AppendLine($"            builder.AddImage({element.Location.X}, {element.Location.Y}, {entity.ID});");

                                break;
                            }

                        case ElementTypes.Item:
                            {
                                sb.AppendLine($"            builder.AddItem({element.Location.X}, {element.Location.Y}, {entity.ID});");

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
                                sb.AppendLine($"            builder.AddLabel({element.Location.X}, {element.Location.Y}, {element.ForeColor.ToArgb()}, \"{element.Text}\");");

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

