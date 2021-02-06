#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Collections;
using UTTT.Ejemplo.Persona.Control;
using UTTT.Ejemplo.Persona.Control.Ctrl;
using System.Net.Mail;
using System.Net;
using System.Net.Configuration;
using System.Configuration;


#endregion

namespace UTTT.Ejemplo.Persona
{
    public partial class PersonaManager : System.Web.UI.Page
    {
        #region Variables

        private SessionManager session = new SessionManager();
        private int idPersona = 0;
        private UTTT.Ejemplo.Linq.Data.Entity.Persona baseEntity;
        private DataContext dcGlobal = new DcGeneralDataContext();
        private int tipoAccion = 0;

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Response.Buffer = true;
                this.session = (SessionManager)this.Session["SessionManager"];
                this.idPersona = this.session.Parametros["idPersona"] != null ?
                    int.Parse(this.session.Parametros["idPersona"].ToString()) : 0;
                if (this.idPersona == 0)
                {
                    this.baseEntity = new Linq.Data.Entity.Persona();
                    this.tipoAccion = 1;
                }
                else
                {
                    this.baseEntity = dcGlobal.GetTable<Linq.Data.Entity.Persona>().First(c => c.id == this.idPersona);
                    this.tipoAccion = 2;
                }

                if (!this.IsPostBack)
                {
                    if (this.session.Parametros["baseEntity"] == null)
                    {
                        this.session.Parametros.Add("baseEntity", this.baseEntity);
                    }
                    List<CatSexo> lista = dcGlobal.GetTable<CatSexo>().ToList();
                    CatSexo catTemp = new CatSexo();
                    catTemp.id = -1;
                    catTemp.strValor = "Seleccionar";
                    lista.Insert(0, catTemp);
                    this.ddlSexo.DataTextField = "strValor";
                    this.ddlSexo.DataValueField = "id";
                    this.ddlSexo.DataSource = lista;
                    this.ddlSexo.DataBind();

                    this.ddlSexo.SelectedIndexChanged += new EventHandler(ddlSexo_SelectedIndexChanged);
                    this.ddlSexo.AutoPostBack = true;
                    if (this.idPersona == 0)
                    {
                        this.lblAccion.Text = "Agregar";
                        DateTime tiempo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        this.FechaNaci.TodaysDate = tiempo;
                        this.FechaNaci.SelectedDate = tiempo;
                    }
                    else
                    {
                        this.lblAccion.Text = "Editar";
                        this.txtNombre.Text = this.baseEntity.strNombre;
                        this.txtAPaterno.Text = this.baseEntity.strAPaterno;
                        this.txtAMaterno.Text = this.baseEntity.strAMaterno;
                        this.txtClaveUnica.Text = this.baseEntity.strClaveUnica;
                        
                        this.txtHermanos.Text = this.baseEntity.strNHermanos.ToString();
                        this.txtCorreo.Text = this.baseEntity.strCorreo;
                        this.txtCPostal.Text = this.baseEntity.strCPostal;
                        this.txtRfc.Text = this.baseEntity.strRfc;
                      
                        DateTime? fechaNacimiento = this.baseEntity.strFechaN;
                        this.val.Value = fechaNacimiento.ToString();
                      
                        this.FechaNaci.TodaysDate = (DateTime)fechaNacimiento;
                        this.FechaNaci.SelectedDate = (DateTime)fechaNacimiento;
                        
                        this.setItem(ref this.ddlSexo, baseEntity.CatSexo.strValor);
                        
                        ddlSexo.Items.FindByValue("-1").Enabled = false;
                        int valor = baseEntity.CatSexo.id;
                        if (valor == 1)
                        {
                            ddlSexo.Items.FindByValue("2").Enabled = true;
                        }
                        else
                        {
                            ddlSexo.Items.FindByValue("1").Enabled = true;
                        }
                    }
                }

            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un problema al cargar la página");
                this.Response.Redirect("~/PersonaPrincipal.aspx", false);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DataContext dcGuardar = new DcGeneralDataContext();
                UTTT.Ejemplo.Linq.Data.Entity.Persona persona = new Linq.Data.Entity.Persona();
                if (this.idPersona == 0)
                {
                    persona.strClaveUnica = this.txtClaveUnica.Text.Trim();
                    persona.strNombre = this.txtNombre.Text.Trim();
                    persona.strAMaterno = this.txtAMaterno.Text.Trim();
                    persona.strAPaterno = this.txtAPaterno.Text.Trim();
                    persona.idCatSexo = int.Parse(this.ddlSexo.Text);
                    DateTime fechaNacimiento = this.FechaNaci.SelectedDate.Date;
                    persona.strFechaN = fechaNacimiento;
                    persona.strNHermanos = int.Parse(this.txtHermanos.Text);

                    

                    persona.strCorreo = this.txtCorreo.Text.Trim();
                    persona.strRfc = this.txtRfc.Text.Trim();
                    persona.strCPostal = this.txtCPostal.Text.Trim();
                    
                    String mensaje = String.Empty;
                    if (!this.validacion(persona, ref mensaje))
                    {
                        this.Error.Text = mensaje;
                        this.Error.Visible = true;
                        return;
                    }


                    if (!this.validaSql(ref mensaje))
                    {
                        this.Error.Text = mensaje;
                        this.Error.Visible = true;
                        return;
                    }

                    if (!this.validaHTML(ref mensaje))
                    {
                        this.Error.Text = mensaje;
                        this.Error.Visible = true;
                        return;
                    }

                    dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Persona>().InsertOnSubmit(persona);
                    dcGuardar.SubmitChanges();
                    this.showMessage("El registro se agrego correctamente.");
                    this.Response.Redirect("~/PersonaPrincipal.aspx", false);

                }
                if (this.idPersona > 0)
                {
                    persona = dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Persona>().First(c => c.id == idPersona);
                    persona.strClaveUnica = this.txtClaveUnica.Text.Trim();
                    persona.strNombre = this.txtNombre.Text.Trim();
                    persona.strAMaterno = this.txtAMaterno.Text.Trim();
                    persona.strAPaterno = this.txtAPaterno.Text.Trim();
                    persona.idCatSexo = int.Parse(this.ddlSexo.Text);
                    
                    DateTime fechaNacimiento = this.FechaNaci.SelectedDate.Date;
                    persona.strFechaN = fechaNacimiento;
                    persona.strNHermanos = int.Parse(this.txtHermanos.Text);

                    persona.strCorreo = this.txtCorreo.Text.Trim();
                    persona.strRfc = this.txtRfc.Text.Trim();
                    persona.strCPostal = this.txtCPostal.Text.Trim();

                    dcGuardar.SubmitChanges();
                    this.showMessage("El registro se edito correctamente.");
                    this.Response.Redirect("~/PersonaPrincipal.aspx", false);
                }
            }
            catch (Exception _e)
            {
                var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                string strHost = smtpSection.Network.Host;
                int port = smtpSection.Network.Port;
                string strUserName = smtpSection.Network.UserName;
                string strFromPass = smtpSection.Network.Password;

                SmtpClient smtp = new SmtpClient(strHost, port);
                MailMessage msg = new MailMessage();

                string body = "<h1>El Error Es: " + _e.Message + "</h1>";
                msg.From = new MailAddress(smtpSection.From, "Meliza");
                msg.To.Add(new MailAddress("18300498@uttt.edu.mx"));
                msg.Subject = "Se ha generado un  error";
                msg.IsBodyHtml = true;
                msg.Body = body;

                smtp.Credentials = new NetworkCredential(strUserName, strFromPass);
                smtp.EnableSsl = true;
                smtp.Send(msg);


                Response.Redirect("~/MensajeError.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/PersonaPrincipal.aspx", false);
            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un error inesperado");
            }
        }

        protected void ddlSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idSexo = int.Parse(this.ddlSexo.Text);
                Expression<Func<CatSexo, bool>> predicateSexo = c => c.id == idSexo;
                predicateSexo.Compile();
                List<CatSexo> lista = dcGlobal.GetTable<CatSexo>().Where(predicateSexo).ToList();
                CatSexo catTemp = new CatSexo();
                this.ddlSexo.DataTextField = "strValor";
                this.ddlSexo.DataValueField = "id";
                this.ddlSexo.DataSource = lista;
                this.ddlSexo.DataBind();
            }
            catch (Exception)
            {
                this.showMessage("Ha ocurrido un error inesperado");
            }
        }

        public bool validacion(UTTT.Ejemplo.Linq.Data.Entity.Persona _persona, ref String _mensaje)
        {
            if (_persona.idCatSexo == -1)
            {
                _mensaje = "Seleccione Masculino o Femenino";
                return false;
            }
            int i = 0;
            if (int.TryParse(_persona.strClaveUnica, out i) == false)
            {
                _mensaje = "La clave unica no es numero";
                return false;
            }
            if (_persona.strClaveUnica.Equals(String.Empty))
            {
                _mensaje = "Clave Unica esta vacio";
                return false;
            }
            if (int.Parse(_persona.strClaveUnica) < 000 || int.Parse(_persona.strClaveUnica) > 999)
            {
                _mensaje = "La clave debe de constar de 3 digitos";
                return false;
            }
            if (_persona.strNombre.Equals(String.Empty))
            {
                _mensaje = "Nombre esta vacio";
                return false;
            }
            if (_persona.strNombre.Length > 15)
            {
                _mensaje = "Los caracteres permitidos para nombre rebasan lo establecido";
                return false;
            }
            if (_persona.strAPaterno.Equals(String.Empty))
            {
                _mensaje = "Apellido Paterno esta vacio";
                return false;
            }
            if (_persona.strAPaterno.Length > 15)
            {
                _mensaje = "Los caracteres permitidos para Apellido Paterno rebasan lo establecido";
                return false;
            }
            if (int.TryParse(_persona.strNHermanos.ToString(), out i) == false)
            {
                _mensaje = "Numero de hermanos no es numero";
                return false;
            }
            if (_persona.strNHermanos < 0 || _persona.strNHermanos > 20)
            {
                _mensaje = "Los numeros de hermanos no deben ser menores a cero";
                return false;
            }
            if (_persona.strCorreo.Equals(String.Empty))
            {
                _mensaje = "Correo Electronico esta vacio";
                return false;
            }
            if (_persona.strCorreo.Length > 50)
            {
                _mensaje = "Los caracteres permitidos para Correo Electronico rebasan lo establecido";
                return false;
            }

            if (_persona.strRfc.Equals(String.Empty))
            {
                _mensaje = "RFC esta vacio";
                return false;
            }
            if (_persona.strRfc.Length > 50)
            {
                _mensaje = "Los caracteres permitidos para RFC rebasan lo establecido";
                return false;
            }

            if (int.TryParse(_persona.strCPostal, out i) == false)
            {
                _mensaje = "El codigo postal no es numero";
                return false;
            }
            if (_persona.strCPostal.Equals(String.Empty))
            {
                _mensaje = "Codigo Postal esta vacio";
                return false;
            }
            if (int.Parse(_persona.strCPostal) < 0000 || int.Parse(_persona.strCPostal) > 99999)
            {
                _mensaje = "El codigo postal debe de constar de 5 numeros";
                return false;
            }

            DateTime? fecha = this.baseEntity.strFechaN;
            this.val.Value = fecha.ToString();
            TimeSpan timeSpan = DateTime.Now - fecha.Value.Date;
            if (timeSpan.Days < 6570)
            {
                _mensaje = "La persona es menor de edad";
                return false;
            }
            return true;
        }




        private bool validaSql(ref String _mensaje)
        {
            ErrorCtr valida = new ErrorCtr();
            string mensajeFuncion = string.Empty;
            if (valida.sqlInyectionValida(this.txtNombre.Text.Trim(), ref mensajeFuncion, "Nombre", ref this.txtNombre))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.sqlInyectionValida(this.txtAPaterno.Text.Trim(), ref mensajeFuncion, "A Paterno", ref this.txtAPaterno))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.sqlInyectionValida(this.txtAMaterno.Text.Trim(), ref mensajeFuncion, "A Materno", ref this.txtAMaterno))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.sqlInyectionValida(this.txtCorreo.Text.Trim(), ref mensajeFuncion, "Correo Electronico", ref this.txtCorreo))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.sqlInyectionValida(this.txtRfc.Text.Trim(), ref mensajeFuncion, "RFC", ref this.txtRfc))
            {
                _mensaje = mensajeFuncion;
                return false;
            }

            return true;
        }

        private bool validaHTML(ref String _mensaje)
        {
            ErrorCtr valida = new ErrorCtr();
            string mensajeFuncion = string.Empty;
            if (valida.htmlInyectionValida(this.txtNombre.Text.Trim(), ref mensajeFuncion, "Nombre", ref this.txtNombre))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInyectionValida(this.txtAPaterno.Text.Trim(), ref mensajeFuncion, "A Paterno", ref this.txtAPaterno))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInyectionValida(this.txtAMaterno.Text.Trim(), ref mensajeFuncion, "A Materno", ref this.txtAMaterno))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInyectionValida(this.txtCorreo.Text.Trim(), ref mensajeFuncion, "Correo Electronico", ref this.txtCorreo))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInyectionValida(this.txtRfc.Text.Trim(), ref mensajeFuncion, "RFC", ref this.txtRfc))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInyectionValida(this.txtClaveUnica.Text.Trim(), ref mensajeFuncion, "Clave Unica", ref this.txtClaveUnica))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInyectionValida(this.txtCPostal.Text.Trim(), ref mensajeFuncion, "Codigo Postal", ref this.txtCPostal))
            {
                _mensaje = mensajeFuncion;
                return false;
            }


            return true;
        }


        #endregion

        #region Metodos

        public void setItem(ref DropDownList _control, String _value)
        {
            foreach (ListItem item in _control.Items)
            {
                if (item.Value == _value)
                {
                    item.Selected = true;
                    break;
                }
            }
            _control.Items.FindByText(_value).Selected = true;
        }

        #endregion

        protected void FechaNaci_SelectionChanged(object sender, EventArgs e)
        {
            val.Value = FechaNaci.SelectedDate.ToString();
        }
    }
}