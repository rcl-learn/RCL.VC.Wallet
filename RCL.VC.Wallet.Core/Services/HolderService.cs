#nullable disable

using Microsoft.EntityFrameworkCore;
using RCL.VC.Wallet.Data;

namespace RCL.VC.Wallet.Core
{
    internal class HolderService : IHolderService
    {
        private readonly VCWalletDbContext _db;

        public HolderService(VCWalletDbContext db)
        {
            _db = db;
        }

        public async Task<Holder> CreateHolderAsync(Holder holder)
        {
            try
            {
                _db.Holders.Add(holder);
                await _db.SaveChangesAsync();
                return holder;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Holder> GetHolderByIdAsync(int id, string username)
        {
            try
            {
                var _holder = await _db.Holders
                    .Where(w => w.id == id && w.username == username)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return _holder;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Holder> GetHolderByUsernameAsync(string username)
        {
            try
            {
                var _holder = await _db.Holders
                    .Where(w => w.username == username)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return _holder;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Holder> UpdateHolderAsync(Holder holder, string username)
        {
            try
            {
                var _holder = await GetHolderByUsernameAsync(username);

                if(!string.IsNullOrEmpty(_holder?.username))
                {
                    _db.Attach(holder).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return holder;
                }
                else
                {
                    throw new Exception("Holder not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
