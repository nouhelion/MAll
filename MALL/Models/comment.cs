//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MALL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class comment
    {
        public int IDC { get; set; }
        public string Name { get; set; }
        public string Comment1 { get; set; }
        [DisplayName("Prediction")]

        public string sentiment { get; set; }
    }
}
