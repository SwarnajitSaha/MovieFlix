//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieFlix.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int commentId { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> movieId { get; set; }
        public string openion { get; set; }
    }
}
