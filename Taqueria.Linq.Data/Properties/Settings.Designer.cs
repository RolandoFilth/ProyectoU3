﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Taqueria.Linq.Data.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        //[global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-F5M8TGN;Initial Catalog=Taqueria_Tadeos;User ID=sa;Password=1" +
        //    "234")]
        //public string Taqueria_TadeosConnectionString {
        //    get {
        //        return ((string)(this["Taqueria_TadeosConnectionString"]));
        //    }




        //}


        [global::System.Configuration.DefaultSettingValueAttribute("data source=TaqueriaTadeos.mssql.somee.com;persist security info=False;initial catalog=TaqueriaTadeos;User Id=KAIJUBOY_SQLLogin_1;Password=lwyavr7hdx")]
        public string Taqueria_TadeosConnectionString
        {
            get
            {
                return ((string)(this["Taqueria_TadeosConnectionString"]));
            }




        }
    }
}
