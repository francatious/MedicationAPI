namespace MedicationAPI.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}