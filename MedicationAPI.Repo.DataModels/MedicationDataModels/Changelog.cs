using System;
using System.Collections.Generic;

namespace MedicationAPI.Repo.DataModels.MedicationDataModels;

public partial class Changelog
{
    public int Id { get; set; }

    public short? Type { get; set; }

    public string? Version { get; set; }

    public string Description { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Checksum { get; set; }

    public string InstalledBy { get; set; } = null!;

    public DateTime InstalledOn { get; set; }

    public bool Success { get; set; }
}
