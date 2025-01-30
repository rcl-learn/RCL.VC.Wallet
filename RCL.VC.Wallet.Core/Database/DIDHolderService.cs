#nullable disable

using Microsoft.EntityFrameworkCore;
using RCL.VC.Wallet.Data;

namespace RCL.VC.Wallet.Core
{   
    internal class DIDHolderService
    {
        private readonly VCWalletDbContext _db;

        public DIDHolderService(VCWalletDbContext db)
        {
            _db = db;
        }

        public async Task<List<HolderDID>> GetHolderDIDsByUserAsync(string username)
        {
            try
            {
                List<HolderDID> dids = await _db.HolderDIDs
                    .Where(w => w.holderUsername == username)
                    .AsNoTracking()
                    .ToListAsync();

                return dids;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<HolderDID> GetGlobalDIDAsync(string did)
        {
            try
            {
                HolderDID _did = await _db.HolderDIDs
                    .Where(w => w.did == did)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return _did;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<HolderDID> AddHolderDIDAsync(HolderDID holderDID)
        {
            try
            {
                HolderDID existigDID = await GetGlobalDIDAsync(holderDID.did);

                if(!string.IsNullOrEmpty(existigDID?.holderUsername))
                {
                    throw new Exception("Cannot add a duplicate DID");
                }

                _db.HolderDIDs.Add(holderDID);
                await _db.SaveChangesAsync();

                return holderDID;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
