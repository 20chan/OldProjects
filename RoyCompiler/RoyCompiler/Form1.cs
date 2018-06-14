using System;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using FastColoredTextBoxNS;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.CodeDom.Compiler;

namespace RoyCompiler
{
    public struct CodeFile
    {
        public string FileName;
        public string Code;
    }
    public partial class Form1 : Form
    {
        List<CodeFile> CodeFiles = new List<CodeFile>();
        string lang = "CSharp (custom highlighter)";

        //styles
        TextStyle BlueStyle = new TextStyle(new SolidBrush(Color.FromArgb(0x56, 0x9c, 0xd6)), null, FontStyle.Regular);
        TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        TextStyle MagentaStyle = new TextStyle(new SolidBrush(Color.FromArgb(181, 206, 168)), null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(new SolidBrush(Color.FromArgb(0, 128, 0)), null, FontStyle.Regular);
        TextStyle AnnotentionStyle = new TextStyle(new SolidBrush(Color.FromArgb(214, 157, 153)), null, FontStyle.Italic);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        public static List<string> ReferencedAssemblies = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
            InitStylesPriority();
            CodeFile c = new CodeFile() { Code = @"using System;

namespace First
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(" + "\"Hello, World!\"" + @");
            Console.ReadLine();
        }
    }
}", FileName = "Program.cs" };
            this.AddCodeFile(c);
            this.tabPage1.Text = "Program.cs";
            this.textBox1.Text = c.Code;
        }

        public Form1(string[] path)
        {
            InitializeComponent();
            string firstcode = System.IO.File.OpenText(path[0]).ReadToEnd();

            this.textBox1.Text = firstcode;
            this.tabControl1.TabPages[0].Text = path[0];
            foreach (string s in path)
            {
                CodeFile c = new CodeFile() { FileName = s, Code = System.IO.File.OpenText(s).ReadToEnd() };
                AddCodeFile(c);
            }
        }

        private void InitStylesPriority()
        {
            //add this style explicitly for drawing under other styles
            this.textBox1.AddStyle(SameWordsStyle);
        }

        private void RestoreAssemblies()
        {

        }

        public void CompileCode(string[] codes)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                CodeDomProvider codeDom = CodeDomProvider.CreateProvider("CSharp");
                CompilerParameters parameters = new CompilerParameters();
                foreach (string s in ReferencedAssemblies)
                    parameters.ReferencedAssemblies.Add(s + ".dll");


                parameters.GenerateExecutable = true;
                parameters.OutputAssembly = this.saveFileDialog1.FileName;

                CompilerResults results = codeDom.CompileAssemblyFromSource(parameters, codes);

                if (results.Errors.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (CompilerError error in results.Errors)
                    {
                        sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                    }
                    throw new InvalidOperationException(sb.ToString());


                }

                System.Diagnostics.Process.Start(this.saveFileDialog1.FileName);
            }
        }

        private void RestoreCodeFileListview()
        {
            this.listView1.Items.Clear();
            foreach(CodeFile c in this.CodeFiles)
            {
                this.listView1.Items.Add(c.FileName);
            }
        }

        private void AddCodeFile(CodeFile c)
        {
            foreach(CodeFile _c in CodeFiles)
            {
                if(_c.FileName == c.FileName)
                {
                    MessageBox.Show("이미 같은 이름의 코드가 있습니다!");
                    return;
                }
            }
            this.CodeFiles.Add(c);
            this.listView1.Items.Add(c.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] codes = new string[this.CodeFiles.Count];
                int i = 0;
                foreach (CodeFile c in this.CodeFiles)
                {
                    codes[i] = c.Code;
                    i++;

                }
                CompileCode(codes); // 여러개의 코드를 전부 합쳐서 컴파일
            }
            catch (Exception ex)
            {
                this.textBox2.Text = ex.Message;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //HighlightCodes();
        }

        private void 참조ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AssemblyReferences form = new AssemblyReferences();
            form.Show();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (((TabPage)((Control)sender).Parent) == null) return; // 이부분에서 아예 안됨. 차라리 열려있는 모든 코드를 저장하고, 그다음 컴파일 하는걸로.
                string filename = ((TabPage)((Control)sender).Parent).Text;
                int i = 0;
                foreach (CodeFile c in this.CodeFiles)
                {
                    if (c.FileName == filename)
                    {
                        break;
                    }
                    i++;
                }
                CodeFile code = new CodeFile() { FileName = filename, Code = ((FastColoredTextBox)sender).Text };
                CodeFiles.RemoveAt(i);
                CodeFiles.Insert(i, code);
            }
            catch { }
            finally
            {

                switch (lang)
                {
                    case "CSharp (custom highlighter)":
                        //For sample, we will highlight the syntax of C# manually, although could use built-in highlighter
                        CSharpSyntaxHighlight(e);//custom highlighting
                        break;
                    default:
                        break;//for highlighting of other languages, we using built-in FastColoredTextBox highlighter
                }

                if (textBox1.Text.Trim().StartsWith("<?xml"))
                {
                    textBox1.Language = Language.XML;

                    textBox1.ClearStylesBuffer();
                    textBox1.Range.ClearStyle(StyleIndex.All);
                    InitStylesPriority();
                    //textBox1.AutoIndentNeeded -= textBox1_AutoIndentNeeded;

                    textBox1.OnSyntaxHighlight(new TextChangedEventArgs(textBox1.Range));
                }
            }
        }

        private void CSharpSyntaxHighlight(TextChangedEventArgs e)
        {
            textBox1.LeftBracket = '(';
            textBox1.RightBracket = ')';
            textBox1.LeftBracket2 = '\x0';
            textBox1.RightBracket2 = '\x0';
            //clear style of changed range
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, AnnotentionStyle);

            //string highlighting
            e.ChangedRange.SetStyle(AnnotentionStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //comment highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            //number highlighting
            e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            //attribute highlighting
            e.ChangedRange.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);
            //class name highlighting
            e.ChangedRange.SetStyle(BoldStyle, @"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b");
            //keyword highlighting
            e.ChangedRange.SetStyle(BlueStyle, @"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b");

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.SetFoldingMarkers("/// <summary>", "/// </summary>");
            e.ChangedRange.SetFoldingMarkers("{", "}");//allow to collapse brackets block
            e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");//allow to collapse #region blocks
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");//allow to collapse comment block
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
