﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAI_NETSUITE.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=INDGDLSQL01;Initial Catalog=INDAR_INACTIONWMS;User ID=sa;Password=7In" +
            "d4r7;Connection Timeout=999")]
        public string INDAR_INACTIONWMSConnectionString {
            get {
                return ((string)(this["INDAR_INACTIONWMSConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=INDGDLSQL01;Initial Catalog=INDAR_INACTIONWMS;User ID=sa;Password=7In" +
            "d4r7;Connection Timeout=999")]
        public string INDAR_INACTIONWMSConnectionString1 {
            get {
                return ((string)(this["INDAR_INACTIONWMSConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.87.10;Initial Catalog=IndarNet;User ID=sa;Password=7Ind4r7;Co" +
            "nnection Timeout=999")]
        public string SERVER10 {
            get {
                return ((string)(this["SERVER10"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.87.5;Initial Catalog=SERVER87_5;User ID=sa;Password=7Ind4r7;C" +
            "onnection Timeout=999")]
        public string SERVER87_5 {
            get {
                return ((string)(this["SERVER87_5"]));
            }
        }
    }
}
