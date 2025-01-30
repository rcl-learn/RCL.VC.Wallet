using RCL.VC.Wallet.Data;

namespace RCL.VC.Wallet.Core
{
    public interface IHolderService
    {
        public Task<Holder> CreateHolderAsync(Holder holder);
        public Task<Holder> GetHolderByIdAsync(int id, string username);
        public Task<Holder> GetHolderByUsernameAsync(string username);
        public Task<Holder> UpdateHolderAsync(Holder holder, string username);
    }
}
