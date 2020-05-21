﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.Models
{
    public class Prescription
    {
        public Prescription()
        {
            PrescriptionsMed = new HashSet<PrescriptionMedicament>();
        }
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }

        public int IdDoctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Patient Doctor { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionsMed { get; set; }
    }
}