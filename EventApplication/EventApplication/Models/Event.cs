﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Models
{
    public class Event
    {
        public virtual int EventId { get; set; }

        [Display(Name = "Type")]
        public virtual int EventTypeId { get; set; }

        public virtual EventType EventType { get; set; }      // You need the class for the EvenType and not the ID or Type

        [Display(Name = "Title")]
        [Required]
        [StringLength(50)]
        public virtual string Title { get; set; }

        [Display(Name = "Event Description")]
        [StringLength(150)]
        public virtual string Description { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public virtual DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public virtual DateTime EndDate { get; set; }

        [MinLength(1, ErrorMessage = "Maximum Tickets cannot be 0")]
        [Display(Name = "Max Tickets")]
        [Required]
        public virtual string MaxTickets { get; set; }

        [MinLength(1, ErrorMessage = "Available Tickets cannot be 0")]
        [Display(Name = "Available Tickets")]
        [Required]
        public virtual string AvailableTickets { get; set; }

        [Display(Name = "Organizer")]
        [Required]
        public virtual string OrganizerName { get; set; }

        [Display(Name = "Organizer Contact Info")]
        public virtual string OrganizerContactInfo { get; set; }

        [Required]
        public virtual string City { get; set; }

        [Required]
        public virtual string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validation)
        {
            if ((StartDate == EndDate))
            {
                // error
                yield return (new ValidationResult("End Date cannot be the less than Event Start Date", new[] { "EndDate" }));
            }

            //Max Tickets cannot be 0
            if (MaxTickets.Length != 0)
            {
                // error
                yield return (new ValidationResult("Max Tickets cannot be 0", new[] { "MaxTickets" }));
            }

            // Available Tickets cannot be 0
            if (AvailableTickets.Length != 0)
            {
                // error
                yield return (new ValidationResult("Available Tickets cannot be 0", new[] { "AvailableTickets" }));
            }
        }
    }
}
