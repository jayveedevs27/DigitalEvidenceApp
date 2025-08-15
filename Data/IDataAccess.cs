using DigitalEvidenceApp.Models;

namespace DigitalEvidenceApp.Data;

public interface IDataAccess
{
    Task<List<EvidenceModel>> GetAllEvidenceAsync();
    Task<List<MatterModel>> GetAllMattersAsync();
}