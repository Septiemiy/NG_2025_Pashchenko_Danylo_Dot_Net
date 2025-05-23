﻿namespace TreatmentBL.Models;
public class TreatmentDto
{
    public string Name { get; set; }

    public bool IsExpired { get; set; }

    public DateTime InjectedAt { get; set; }

    public DateTime ExpirationDate { get; set; }

    public Guid PetId { get; set; }

    public Guid VendorId { get; set; }

    public Guid StoreId { get; set; }
}
