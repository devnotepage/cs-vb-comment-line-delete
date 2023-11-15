using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs_vb_comment_line_delete
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            textBoxOutput.Text = DeleteCommentLine(textBoxInput.Text);
        }

        /// <summary>
        /// VBコメント行を削除します。
        /// </summary>
        /// <param name="input">削除前の文字列</param>
        /// <returns>削除後の文字列</returns>
        private string DeleteCommentLine(string input)
        {
            try
            {
                var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var deletedLines = lines.Where(x => !x.TrimStart().StartsWith("'"));
                var deleted = string.Join(Environment.NewLine, deletedLines);
                return deleted;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return string.Empty;
            }
        }
    }
}
