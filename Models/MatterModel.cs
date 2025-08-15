namespace DigitalEvidenceApp.Models;

public class MatterModel
{
    public int MatterID { get; set; }
    public string MatterName { get; set; } = string.Empty;
    public string? ClientName { get; set; }
    public ICollection<EvidenceModel> Evidences { get; set; } = new List<EvidenceModel>();
}