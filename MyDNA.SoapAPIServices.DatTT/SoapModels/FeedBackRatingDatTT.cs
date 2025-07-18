﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyDNA.SoapAPIServices.DatTT.SoapModels;
[DataContract]

public partial class FeedBackRatingDatTT
{
    [DataMember]
    public int FeedBackRatingDatTtid { get; set; }
    [DataMember]

    public int ServiceDatTtid { get; set; }
    [DataMember]

    [Required(ErrorMessage = "Rating is required.")]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public byte Rating { get; set; }
    [DataMember]

    [Required(ErrorMessage = "Writer Name is required.")]
    [RegularExpression("^\\s*[A-Z][a-zA-Z ]{1,49}\\s*$", ErrorMessage = "Writer Name must be a valid name.")]
    public string WriterName { get; set; }
    [DataMember]

    [Required(ErrorMessage = "Title is required.")]
    [RegularExpression("^\\s*[A-Z][a-zA-Z ]{1,49}\\s*$", ErrorMessage = "Title must be a valid.")]
    public string Title { get; set; }
    [DataMember]

    [MaxLength(300, ErrorMessage = "Content names should be within 300 characters")]
    public string Content { get; set; }
    [DataMember]

    public bool? IsVisible { get; set; }
    [DataMember]

    public DateTime? CreatedAt { get; set; }
    [DataMember]

    public DateTime? UpdatedAt { get; set; }
    [DataMember]

    [Required(ErrorMessage = "FeedbackScore is required.")]
    [Range(1, 100, ErrorMessage = "FeedbackScore must be between 1 and 100.")]
    public int FeedbackScore { get; set; }
    [DataMember]

    public virtual ServiceDatTT ServiceDatTt { get; set; }
}