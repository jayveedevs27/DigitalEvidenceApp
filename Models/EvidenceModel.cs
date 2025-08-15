namespace DigitalEvidenceApp.Models;

public class EvidenceModel
{
    public int EvidenceID { get; set; }
    public int MatterID { get; set; }
    public string? Description { get; set; }
    public string? SerialNumber { get; set; }

    public MatterModel? Matter { get; set; }
}