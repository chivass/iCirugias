//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
namespace iCirugiasXAF.Module.BusinessObjects
{
  [DefaultClassOptions]
  public partial class Cirugia : XPObject
  {
    private System.String _especialidad;
    private System.String _nombre;
    public Cirugia(DevExpress.Xpo.Session session)
      : base(session)
    {
    }
    public System.String Nombre
    {
      get
      {
        return _nombre;
      }
      set
      {
        SetPropertyValue("Nombre", ref _nombre, value);
      }
    }
    public System.String Especialidad
    {
      get
      {
        return _especialidad;
      }
      set
      {
        SetPropertyValue("Especialidad", ref _especialidad, value);
      }
    }
  }
}
