using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace DataManagerSystem.Configs
{
    public class WordDocCreator
    {
        Word.Application wordApp = new Word.Application();
        Word.Document WordDocx = null;
        object filename;
        object readOnly = false;
        object missing = Missing.Value;

        public WordDocCreator(object filename)
        {
            this.filename = filename;
            if (File.Exists((string)filename))
            {
                wordApp.Visible = false;
                WordDocx = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);
            }
            else
            {
                MessageBox.Show("File not found!");
            }
        }

        public void FindAndReplace(object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            WordDocx.Activate();

            wordApp.Selection.Find.Execute(ref ToFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }

        //Creeate the Doc Method
        public void CreateDocx(object SaveAs)
        {
            if (File.Exists((string)filename))
            {
                WordDocx.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

                WordDocx.Close();
                wordApp.Quit();

                MessageBox.Show("File Created!");
            }
            else
            {
                MessageBox.Show("No able To Save File!");
            }
        }
    }
}
