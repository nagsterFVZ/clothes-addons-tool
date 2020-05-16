using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace ClothesGUI
{
    public partial class Form1 : Form
    {
        //public List<string> files = new List<string>();
        List<ModFile> ModFileList = new List<ModFile>();
        List<ModFile> GTAFileList = new List<ModFile>();
        int[] jbib = new int[] { 0, 0 };
        int[] lowr = new int[] { 0, 0 };
        int[] decl = new int[] { 0, 0 };
        int[] feet = new int[] { 0, 0 };
        int[] accs = new int[] { 0, 0 };
        int[] task = new int[] { 0, 0 };
        int[] teef = new int[] { 0, 0 };
        int[] berd = new int[] { 0, 0 };
        int[] hair = new int[] { 0, 0 };
        int[] hand = new int[] { 0, 0 };
        int[] uppr = new int[] { 0, 0 };
        int[] head = new int[] { 0, 0 };
        int[] pHead = new int[] { 0, 0 };
        int[] pEyes = new int[] { 0, 0 };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtOut.Text = "Loading Files";
            ProcessDirectory("E:\\FiveM\\FiveMDev\\Addon Clothes\\Downloads\\EUP clothes\\Clothes");
        }

        public void ProcessGTADirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                ProcessGTAFile(fileName);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessGTADirectory(subdirectory);
        }

        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
            prgBar.Maximum = ModFileList.Count()+200;
            txtOut.Text = ModFileList.Count() + " files loaded";
        }
        public void proccessFiles()
        {
            foreach (var file in ModFileList)
            {
                if (file.Extension == "ydd")
                {
                    string textureName;
                    if (file.Type.Substring(0, 1) == "p")
                    {
                        file.Name = file.Name.Substring(2);
                        
                        textureName = file.Name.Substring(0, file.Name.IndexOf("_")) + "_diff_" + file.Name.Substring(file.Name.IndexOf("_") + 1, 3);
                        textureName = "p_" + textureName;
                    }
                    else
                    {
                        textureName = file.Name.Substring(0, file.Name.IndexOf("_")) + "_diff_" + file.Name.Substring(file.Name.IndexOf("_") + 1, 3);
                    }
                    setID(file);
                    copyFile(file);
                    int innerID = 0;
                    foreach (var inerFile in ModFileList)
                    {
                        if (inerFile.Extension == "ytd" && inerFile.Name.Substring(0, textureName.Length) == textureName)
                        {
                            if (inerFile.Path.Substring(0, inerFile.Path.LastIndexOf("\\")) == file.Path.Substring(0, file.Path.LastIndexOf("\\")))
                            {
                                inerFile.Id = innerID;
                                copyTextureFile(inerFile, file.Id);
                                innerID++;
                            }
                        }
                    }
                }
            }
            
            txtOut.AppendText(Environment.NewLine);
            txtOut.AppendText(String.Format("Done copying " + prgBar.Value + " files."));
            prgBar.Value = prgBar.Maximum;
        }

        public void setID(ModFile file)
        {
            int genderN;
            if(file.Gender == "m")
            {
                genderN = 0;
            }
            else
            {
                genderN = 1;
            }
            switch (file.Type)
            {
                case "jbib":
                    file.Id = jbib[genderN];
                    jbib[genderN]++;
                    break;
                case "lowr":
                    file.Id = lowr[genderN];
                    lowr[genderN]++;
                    break;
                case "decl":
                    file.Id = decl[genderN];
                    decl[genderN]++;
                    break;
                case "feet":
                    file.Id = feet[genderN];
                    feet[genderN]++;
                    break;
                case "accs":
                    file.Id = accs[genderN];
                    accs[genderN]++;
                    break;
                case "task":
                    file.Id = task[genderN];
                    task[genderN]++;
                    break;
                case "teef":
                    file.Id = teef[genderN];
                    teef[genderN]++;
                    break;
                case "berd":
                    file.Id = berd[genderN];
                    berd[genderN]++;
                    break;
                case "hair":
                    file.Id = hair[genderN];
                    hair[genderN]++;
                    break;
                case "hand":
                    file.Id = hand[genderN];
                    hand[genderN]++;
                    break;
                case "uppr":
                    file.Id = uppr[genderN];
                    uppr[genderN]++;
                    break;
                case "head":
                    file.Id = head[genderN];
                    head[genderN]++;
                    break;
                case "p_head":
                    file.Id = pHead[genderN];
                    pHead[genderN]++;
                    break;
                case "p_eyes":
                    file.Id = pEyes[genderN];
                    pEyes[genderN]++;
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }

        public void ProcessFile(string path)
        {
            int position = path.LastIndexOf("\\mp");
            string subpath = path.Substring(position + 1);
            string propCheck = subpath.Substring(subpath.IndexOf("\\") + 1, 1);
            string gender = (subpath.Substring(3, 1));
            string name = subpath.Substring(subpath.IndexOf("\\") + 1);
            string extension = subpath.Substring(subpath.IndexOf(".") + 1);
            if (gender == "m" || gender == "f")
            {
                if (propCheck == "p")
                {
                    string type = subpath.Substring(subpath.IndexOf("\\")+1);
                    type = type.Substring(0, type.IndexOf('_', type.IndexOf('_') + 1));
                    txtOut.AppendText(String.Format("Loaded: {0}'",path));
                    ModFileList.Add(new ModFile(gender, type, extension, path, name));
                }
                else
                {
                    string type = subpath.Substring(subpath.IndexOf("\\") + 1, 4);
                    ModFileList.Add(new ModFile(gender, type, extension, path, name));
                    txtOut.AppendText(String.Format("Loaded: {0}'", path));
                }
                txtOut.AppendText(Environment.NewLine);
            }
        }

        public void ProcessGTAFile(string path)
        {
            int position = path.LastIndexOf("\\mp");
            string subpath = path.Substring(position + 1);
            string propCheck = subpath.Substring(subpath.IndexOf("\\") + 1, 1);
            string gender = (subpath.Substring(3, 1));
            string name = subpath.Substring(subpath.IndexOf("\\") + 1);
            string extension = subpath.Substring(subpath.IndexOf(".") + 1);
            if (gender == "m" || gender == "f")
            {
                if (propCheck == "p")
                {
                    string type = subpath.Substring(subpath.IndexOf("\\") + 1);
                    type = type.Substring(0, type.IndexOf('_', type.IndexOf('_') + 1));
                    txtOut.AppendText(String.Format("Loaded: {0}'", path));
                    GTAFileList.Add(new ModFile(gender, type, extension, path, name));
                }
                else
                {
                    string type = subpath.Substring(subpath.IndexOf("\\") + 1, 4);
                    GTAFileList.Add(new ModFile(gender, type, extension, path, name));
                    txtOut.AppendText(String.Format("Loaded: {0}'", path));
                }
                txtOut.AppendText(Environment.NewLine);
            }
        }

        public void copyFile(ModFile file)
        {
            txtOut.AppendText(Environment.NewLine);
            txtOut.AppendText(String.Format("Copying: {0}'", file.Path));
            prgBar.Value++;
            string destination = "E:\\FiveM\\FiveMDev\\Addon Clothes\\Downloads\\EUP clothes\\testCopy";
            if (file.Gender == "m")
            {
                if (file.Type.Substring(0,1) == "p")
                {
                    destination = Path.Combine(destination, "mp_m_freemode_01_p\\props");
                    destination = Path.Combine(destination, file.Type.Substring(2));
                }
                else
                {
                    destination = Path.Combine(destination, "mp_m_freemode_01\\components");
                    destination = Path.Combine(destination, file.Type);
                }
            }
            else
            {
                if (file.Type.Substring(0, 1) == "p")
                {
                    destination = Path.Combine(destination, "mp_f_freemode_01_p\\props");
                    destination = Path.Combine(destination, file.Type.Substring(2));
                }
                else
                {
                    destination = Path.Combine(destination, "mp_f_freemode_01\\components");
                    destination = Path.Combine(destination, file.Type);
                }

            }
            File.Copy(file.Path, Path.Combine(destination, file.Id.ToString()) + ".ydd", true);
            createDir(destination, file.Id.ToString());
            file.Copied = true;
        }

        public void copyTextureFile(ModFile file, int id)
        {
            txtOut.AppendText(Environment.NewLine);
            txtOut.AppendText(String.Format("Copying: {0}'", file.Path));
            prgBar.Value++;
            string destination = "E:\\FiveM\\FiveMDev\\Addon Clothes\\Downloads\\EUP clothes\\testCopy";
            if (file.Gender == "m")
            {
                if (file.Type.Substring(0, 1) == "p")
                {
                    destination = Path.Combine(destination, "mp_m_freemode_01_p\\props");
                    destination = Path.Combine(destination, file.Type.Substring(2));
                }
                else
                {
                    destination = Path.Combine(destination, "mp_m_freemode_01\\components");
                    destination = Path.Combine(destination, file.Type);
                }
            }
            else
            {
                if (file.Type.Substring(0, 1) == "p")
                {
                    destination = Path.Combine(destination, "mp_f_freemode_01_p\\props");
                    destination = Path.Combine(destination, file.Type.Substring(2));
                }
                else
                {
                    destination = Path.Combine(destination, "mp_f_freemode_01\\components");
                    destination = Path.Combine(destination, file.Type);
                }

            }
            File.Copy(file.Path, Path.Combine(destination, id.ToString(), file.Id.ToString() + ".ytd"), true);
            file.Copied = true;
        }

        public void createDir(string path, string id)
        {
            path = Path.Combine(path, id);
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            proccessFiles();
        }

        public class ModFile
        {
            private string gender;
            private string type;
            private string extension;
            private string path;
            private string name;
            private int id;
            private bool copied = false;

            public ModFile(string gender, string type, string extension, string path, string name)
            {
                this.gender = gender;
                this.type = type;
                this.extension = extension;
                this.path = path;
                this.name = name;
            }

            public string Gender
            {
                get { return gender; }
                set { gender = value; }
            }
            public string Type
            {
                get { return type; }
                set { type = value; }
            }
            public string Extension
            {
                get { return extension; }
                set { extension = value; }
            }
            public string Path
            {
                get { return path; }
                set { path = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            public bool Copied
            {
                get { return copied; }
                set { copied = value; }
            }
        }

        private void prgBar_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtOut.Text = "";
            foreach (var file in ModFileList)
            {
                if (!file.Copied)
                {
                    txtOut.AppendText(String.Format(file.Path));
                    txtOut.AppendText(Environment.NewLine);
                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var file in ModFileList)
            {
                if (!file.Copied && file.Extension == "ytd")
                {
                    string semiPath = (file.Path.Substring(file.Path.LastIndexOf('\\', file.Path.LastIndexOf('\\') - 1) + 1));
                    string modelName = semiPath.Substring(semiPath.IndexOf('\\') + 1);
                    modelName = modelName.Substring(0, modelName.IndexOf("_diff_")) + "_" + modelName.Substring(modelName.IndexOf("_diff_") + 6);
                    modelName = modelName.Substring(0, modelName.LastIndexOf("_"));
                    modelName = modelName.Substring(0, modelName.LastIndexOf("_0") + 4);
                    string finalPath = semiPath.Substring(0, semiPath.IndexOf('\\')) + "\\" + modelName;
                    foreach (var fileGTA in GTAFileList)
                    {
                        if (fileGTA.Extension == "ydd")
                        {
                            string fileSearch = fileGTA.Path.Substring(fileGTA.Path.IndexOf("\\mp_") + 1);
                            fileSearch = fileSearch.Substring(0, fileSearch.LastIndexOf("_"));
                            if(fileSearch == finalPath)
                            {
                                txtOut.AppendText(Environment.NewLine);
                                txtOut.AppendText("Copying: " + fileGTA.Path);
                                File.Copy(fileGTA.Path, Path.Combine(file.Path.Substring(0, file.Path.LastIndexOf('\\')), fileGTA.Name), true);
                            }
                        }
                    }
                }
            }
            /*
            foreach (var file in GTAFileList)
            {
                if (file.Extension == "ydd")
                {
                    string textureName;
                    if (file.Type.Substring(0, 1) == "p")
                    {
                        file.Name = file.Name.Substring(2);

                        textureName = file.Name.Substring(0, file.Name.IndexOf("_")) + "_diff_" + file.Name.Substring(file.Name.IndexOf("_") + 1, 3);
                        textureName = "p_" + textureName;
                    }
                    else
                    {
                        textureName = file.Name.Substring(0, file.Name.IndexOf("_")) + "_diff_" + file.Name.Substring(file.Name.IndexOf("_") + 1, 3);
                    }
                    setID(file);
                    copyFile(file);
                    int innerID = 0;
                    foreach (var inerFile in ModFileList)
                    {
                        if (!file.Copied)
                        {
                            string semiPath = (inerFile.Path.Substring(inerFile.Path.LastIndexOf('\\', inerFile.Path.LastIndexOf('\\') - 1) + 1));
                            string modelName = semiPath.Substring(semiPath.IndexOf('\\') + 1);
                            modelName = modelName.Substring(0, modelName.IndexOf("_diff_")) + "_" + modelName.Substring(modelName.IndexOf("_diff_") + 6);
                            modelName = modelName.Substring(0, modelName.LastIndexOf("_")) + ".ydd";
                            string finalPath = semiPath.Substring(0, semiPath.IndexOf('\\')) + "\\" + modelName;
                            if (inerFile.Extension == "ytd" && inerFile.Name.Substring(0, textureName.Length) == textureName)
                            {
                                if (inerFile.Path.Substring(0, inerFile.Path.LastIndexOf("\\")) == file.Path.Substring(0, file.Path.LastIndexOf("\\")))
                                {
                                    inerFile.Id = innerID;
                                    copyTextureFile(inerFile, file.Id);
                                    innerID++;
                                }
                            }
                        }
                    }
                }
            }
            */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProcessGTADirectory("E:\\FiveM\\FiveMDev\\Addon Clothes\\Downloads\\EUP clothes\\AllGtaModels");
            
        }
    }
}
