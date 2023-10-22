using System;
using System.Collections.Generic;

namespace MedicationAPI.Repo.DataModels.MedicationDataModels;

public partial class Medication
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime CreationDate { get; set; }
}
