using DigitalEvidenceApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DigitalEvidenceApp.Data
{
    public class DataAccess : IDataAccess
    {
        private readonly AppDbContext _db;
        private readonly ILogger<DataAccess> _logger;

        public DataAccess(AppDbContext db, ILogger<DataAccess> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<EvidenceModel>> GetAllEvidenceAsync()
        {
            _logger.LogInformation("Fetching all evidence records from the database.");

            try
            {
                var evidenceList = await _db.Evidence
                    .Include(e => e.Matter)
                    .OrderBy(e => e.EvidenceID)
                    .ToListAsync();

                _logger.LogInformation("Successfully retrieved {Count} evidence records.", evidenceList.Count);
                return evidenceList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving evidence records.");
                throw;
            }
        }

        public async Task<List<MatterModel>> GetAllMattersAsync()
        {
            _logger.LogInformation("Fetching all matter records from the database.");

            try
            {
                var matterList = await _db.Matters
                    .OrderBy(m => m.MatterName)
                    .ToListAsync();

                _logger.LogInformation("Successfully retrieved {Count} matter records.", matterList.Count);
                return matterList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving matter records.");
                throw;
            }
        }
    }
}
