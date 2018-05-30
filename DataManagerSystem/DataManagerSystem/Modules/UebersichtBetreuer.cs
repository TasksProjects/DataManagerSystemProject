
using DataManagerSystem.Verwaltungsbetreuer;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class UebersichtBetreuer : Form
    {
        int BetreuerID;
        VerwaltungVonBetreuer verwaltungVonBetreuer = new VerwaltungVonBetreuer();
        public UebersichtBetreuer()
        {
            InitializeComponent();
        }

        private void ÜbersichtBetreuer_Load(object sender, System.EventArgs e)
        {
            verwaltungVonBetreuer.ShowBetreuerInfo(dataGridView);
        }

        private void Schlißen_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void BetreuerHinzufuegen_Click(object sender, System.EventArgs e)
        {
            AddBetreuer addBetreuer = new AddBetreuer();
            addBetreuer.Show();
            this.Close();
        }


        private void BetreuerLoeschen_Click(object sender, System.EventArgs e)
        {
            verwaltungVonBetreuer.RemoveUser(BetreuerID);
            verwaltungVonBetreuer.ShowBetreuerInfo(dataGridView);

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];
                BetreuerID = (int)row.Cells["BetreuerID"].Value;
            }
        }
    }
}
