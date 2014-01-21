using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EtiquetasMaster
{
    public partial class frmPrincipal : Form
    {

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.ref_mahleTableAdapter.Fill(this.dsEtiMahle.ref_mahle);
            this.etiretfmTableAdapter.Fill(this.dsEtiRetFM.etiretfm);
            this.etitorfmpTableAdapter.Fill(this.dsEtiTorFM.etitorfmp);
            this.etijuefmpgTableAdapter.Fill(this.dsEtiJueFM.etijuefmpg);
            this.etiquetasNoEnCatalogoTableAdapter.Fill(this.dsEtiquetasNoEnCatalogo.EtiquetasNoEnCatalogo);
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            int R=Datos.CopiaReferencia(tbReferenciaOrigen.Text, tbReferenciaNueva.Text);
            if (R == -1) MessageBox.Show("No ejecutado el proceso.");
            if (R == 0) MessageBox.Show("Referencia copiada.");
            if (R == 1) MessageBox.Show("La referencia "+tbReferenciaNueva.Text+" ya existe.");
            if (R == 2) MessageBox.Show("Error al ejecutar CopiaReferencia.");

        }

        private void bbiSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiSalirMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gcEtiNoEnCata_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                if (MessageBox.Show("¿Seguro que quieres borrar?", "Confirma borrado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gvEtiNoEnCata.DeleteSelectedRows();
                }
                e.Handled = true;
            }
            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {
                try
                {
                    this.Validate();
                    this.etiquetasNoEnCatalogoBindingSource.EndEdit();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error: no se pudo salvar gcEtiNoEnCata_EmbeddedNavigator_ButtonClick:" + ex.Message);
                }
            }
            this.etiquetasNoEnCatalogoTableAdapter.Update(this.dsEtiquetasNoEnCatalogo.EtiquetasNoEnCatalogo);            
        }

        private void gcFMTornillos_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                if (MessageBox.Show("¿Seguro que quieres borrar?", "Confirma borrado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gvFMTornillos.DeleteSelectedRows();
                }
                e.Handled = true;
            }
            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {
                try
                {
                    this.Validate();
                    this.etitorfmpBindingSource.EndEdit();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error: no se pudo salvar gcFMTornillos_EmbeddedNavigator_ButtonClick:" + ex.Message);
                }
            }
            this.etitorfmpTableAdapter.Update(this.dsEtiTorFM.etitorfmp);
        }

        private void gcFMRetenes_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                if (MessageBox.Show("¿Seguro que quieres borrar?", "Confirma borrado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    gvFMRetenes.DeleteSelectedRows();
                }
                e.Handled = true;
            }
            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {
                try
                {
                    this.Validate();
                    this.etiretfmBindingSource.EndEdit();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error: no se pudo salvar gcFMRetenes_EmbeddedNavigator_ButtonClick:" + ex.Message);
                }
            }
            this.etiretfmTableAdapter.Update(this.dsEtiRetFM.etiretfm);
        }

        private void gcFMJuegos_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                if (MessageBox.Show("¿Seguro que quieres borrar?", "Confirma borrado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gvFMJuegos.DeleteSelectedRows();
                }
                e.Handled = true;
            }
            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {
                try
                {
                    this.Validate();
                    this.etijuefmpgBindingSource.EndEdit();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error: no se pudo salvar gcFMJuegos_EmbeddedNavigator_ButtonClick:" + ex.Message);
                }
            }
            this.etijuefmpgTableAdapter.Update(this.dsEtiJueFM.etijuefmpg);
        }

        private void gcMahle_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                if (MessageBox.Show("¿Seguro que quieres borrar?", "Confirma borrado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gvMahle.DeleteSelectedRows();
                }
                e.Handled = true;
            }
            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {
                try
                {
                    this.Validate();
                    this.refmahleBindingSource.EndEdit();
                    this.ref_mahleTableAdapter.Update(this.dsEtiMahle.ref_mahle);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error: no se pudo salvar gcEtiNoEnCata_EmbeddedNavigator_ButtonClick:" + ex.Message);
                }
            }
            this.ref_mahleTableAdapter.Update(this.dsEtiMahle.ref_mahle);
        }

        private void gcEtiNoEnCata_EmbeddedNavigator_Click(object sender, EventArgs e)
        {

        }

    }
}
