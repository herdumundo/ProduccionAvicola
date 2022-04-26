using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionAvicola
{
    static class Global
    {
        private static string v_user_name = "";
        private static string v_perfil = "";
        private static string v_usuario = "";
        private static string v_versionsistema = "";
        private static string v_password = "";
        private static string v_servidor = "";
        private static string v_dbuser = "";
        private static string v_dbpassword = "";
        private static string v_nombreempresa = "";
        public static string conn = "Data Source=" + Properties.Settings.Default.sap_server + ";Persist Security Info=True;Initial Catalog=" + Properties.Settings.Default.sap_companydb + ";User ID=" + Properties.Settings.Default.sap_dbusername + ";Password=" + Properties.Settings.Default.sap_dbpassword;
        public static string conn_clasif = "Data Source=" + Properties.Settings.Default.sap_server + ";Persist Security Info=True;Initial Catalog=" + Properties.Settings.Default.sap_companydb_cla + ";User ID=" + Properties.Settings.Default.sap_dbusername + ";Password=" + Properties.Settings.Default.sap_dbpassword;
        public static string conn_vimar = "Data Source=" + Properties.Settings.Default.add_server + ";Persist Security Info=True;Initial Catalog=" + Properties.Settings.Default.add_db + ";User ID=" + Properties.Settings.Default.add_dbusername + ";Password=" + Properties.Settings.Default.add_dbpass;
        public static string str_conn_REP = "Provider=SQLOLEDB.1; Data Source=" + Properties.Settings.Default.sap_server + ";Persist Security Info=True;Initial Catalog=" + Properties.Settings.Default.sap_companydb + ";User ID=" + Properties.Settings.Default.sap_dbusername + ";Password=" + Properties.Settings.Default.sap_dbpassword;
        public static string str_conn_REP1 = "Provider=SQLOLEDB.1; Data Source=" + Properties.Settings.Default.sap_server + ";Persist Security Info=True;Initial Catalog=" + Properties.Settings.Default.sap_companydb_cla + ";User ID=" + Properties.Settings.Default.sap_dbusername + ";Password=" + Properties.Settings.Default.sap_dbpassword;

        public static string lista_generica = Properties.Settings.Default.lista_generica;

        public static string usuario_win;
        
        private static string v_deposito = "";       
        public static string nombre_usuario
        {
            get { return v_user_name; }
            set { v_user_name = value;}
        }
        public static string usuario
        {
            get{ return v_usuario;}
            set{ v_usuario = value;}
        }
        public static string password
        {
            get{ return v_password;}
            set { v_password = value; }
        }
        public static string servidor
        {
            get { return v_servidor; }
            set { v_servidor = value;}
        }
        public static string dbuser
        {
            get { return v_dbuser; }
            set { v_dbuser = value; }
        }
        public static string dbpassword
        {
            get { return v_dbpassword; }
            set { v_dbpassword = value; }
        }
        public static string deposito
        {
            get { return v_deposito; }
            set { v_deposito = value; }
        }
        public static string nombreempresa
        {
            get { return v_nombreempresa; }
            set { v_nombreempresa = value; }
        }
        public static string versionsistema
        {
            get { return v_versionsistema; }
            set { v_versionsistema = value; }
        }
    }
}
