using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SAPbobsCOM;

namespace ProduccionAvicola
{
    public partial class frmOrdenTrabajo : Form
    {
        Company empresa = new Company();
        ServiceCalls OT;
        Contacts Actividad;
        UserTable Operarios;

        string clgcode;
        string nroOT;
        public frmOrdenTrabajo()
        {
            InitializeComponent();
        }
        private void conexion()
        {
            empresa.Server = Properties.Settings.Default.Properties["sap_server"].DefaultValue.ToString();
            empresa.CompanyDB = Properties.Settings.Default.Properties["sap_companydb"].DefaultValue.ToString();
            switch (Properties.Settings.Default.sap_servertype)
            {
                case "2008":
                    empresa.DbServerType = BoDataServerTypes.dst_MSSQL2008;
                    break;
                case "2014":
                    empresa.DbServerType = BoDataServerTypes.dst_MSSQL2014;
                    break;
            };
            empresa.LicenseServer = Properties.Settings.Default.sap_server;
            empresa.DbUserName = Properties.Settings.Default.sap_dbusername;
            empresa.DbPassword = Properties.Settings.Default.sap_dbpassword;
            empresa.UserName = Global.usuario;
            empresa.Password = Global.password;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (empresa.Connected == false)
                {
                    conexion();
                    if (empresa.Connect() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorDescription() + "; Código de error: " + empresa.GetLastErrorCode().ToString());
                        return;
                    }
                    else
                    {
                        SAPbobsCOM.GeneralService oGeneralService = null;
                        SAPbobsCOM.GeneralData oGeneralData = null;
                        SAPbobsCOM.GeneralDataParams oGeneralParams = null;
                        SAPbobsCOM.CompanyService sCmp = null;
                        SAPbobsCOM.GeneralData oChild = null;
                        SAPbobsCOM.GeneralDataCollection oChildren = null;
                        sCmp = empresa.GetCompanyService();
                        try
                        {
                            oGeneralService = sCmp.GetGeneralService("OTOPCAB");
                            // Get UDO record
                            oGeneralParams = ((SAPbobsCOM.GeneralDataParams)(oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams)));
                            oGeneralParams.SetProperty("Code", "2");
                            
                            oGeneralData = oGeneralService.GetByParams(oGeneralParams);
                            // Add lines on UDO Child Table
                            oChildren = oGeneralData.Child("OT_OP");
                            // Create data for rows in the child table
                            oChild = oChildren.Add();
                            oChild.SetProperty("Code", "2");
                            oChild.SetProperty("U_Id_Operario", "1");
                            oChild.SetProperty("U_Nombre_Operario", "Test");
                            // Update an existing line
                            //oChild = oChildren.Item(1);
                            //oChild.SetProperty("colUID", "TEST");
                            //Update the UDO Record
                            oGeneralService.Add(oGeneralData);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }                     

                        

                        //Crear Actividad
                        Actividad = empresa.GetBusinessObject(BoObjectTypes.oContacts);
                        Actividad.CardCode = "P" + tbRUC.Text;
                        Actividad.ActivityType = -1;
                        Actividad.Activity = BoActivities.cn_Other;
                        Actividad.Details = "Creación de la Orden de Trabajo";
                        Actividad.Notes = "Comentarios de la actividad";
                        Actividad.EndDuedate = DateTime.Now.Date;
                        Actividad.EndTime = DateTime.Parse(DateTime.Now.ToString("HH:mm"));
                        Actividad.Closed = BoYesNoEnum.tYES;

                        if (Actividad.Add() != 0)
                        {
                            MessageBox.Show(empresa.GetLastErrorDescription() + "; Código de error: " + empresa.GetLastErrorCode().ToString());
                            empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                            return;
                        }
                        else
                        {
                            clgcode = empresa.GetNewObjectKey();

                            OT = empresa.GetBusinessObject(BoObjectTypes.oServiceCalls);
                            OT.Activities.ActivityCode = int.Parse(clgcode);
                            OT.ServiceBPType = ServiceTypeEnum.srvcPurchasing;
                            OT.CustomerCode = "P" + tbRUC.Text;
                            OT.Subject = "Servicio de Reparación";
                            OT.Description = tbFalla.Text;                            
                            OT.Status = 1;

                            if (OT.Add() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorDescription() + "; Código de error: " + empresa.GetLastErrorCode().ToString());
                                empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                                return;
                            }
                            else
                            {
                                nroOT = empresa.GetNewObjectKey();

                                /*OT = empresa.GetBusinessObject(BoObjectTypes.oServiceCalls);

                                OT.GetByKey(int.Parse(nroOT));*/

                                Actividad = empresa.GetBusinessObject(BoObjectTypes.oContacts);

                                Actividad.CardCode = "P" + tbRUC.Text;
                                Actividad.ActivityType = 1;
                                Actividad.Activity = BoActivities.cn_Other;
                                Actividad.Notes = "Pend. Aprobación Jefe de Área";
                                Actividad.Recontact = DateTime.Now.Date;
                                Actividad.ContactTime = DateTime.Parse(DateTime.Now.ToString("HH:mm"));

                                if (Actividad.Add() != 0)
                                {
                                    MessageBox.Show(empresa.GetLastErrorDescription() + "; Código de error: " + empresa.GetLastErrorCode().ToString());
                                    empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                                    return;
                                }
                                else
                                {
                                    clgcode = empresa.GetNewObjectKey();

                                    OT.Activities.Add();
                                    OT.Activities.ActivityCode = int.Parse(clgcode);

                                    if (OT.Update() != 0)
                                    {
                                        MessageBox.Show(empresa.GetLastErrorDescription() + "; Código de error :" + empresa.GetLastErrorCode().ToString());
                                        return;
                                    };
                                };
                            };
                        };
                    };
                };
                //empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                MessageBox.Show("Orden de Trabajo registrada correctamente. OT N°: " + nroOT);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (empresa.Connected)
                {
                    empresa.Disconnect();
                };
                Cursor.Current = Cursors.Default;
            };
        }

        private void tbRUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }

        private void tbClienteNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }

        private void tbFalla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private static frmOrdenTrabajo frmDefInstance;
        public static frmOrdenTrabajo DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmOrdenTrabajo();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
    }
}
