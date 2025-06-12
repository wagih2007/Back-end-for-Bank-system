using Bank_mangement_system.DTOs;

namespace Bank_mangement_system.Rpos.IRepo
{
    public interface IBranchRepo
    {
        void AddBranchCustomers(BranchCustomerDto branchCustomerDto);
        List<GetBranchCustomerssDto> GetAllBranches();
        void Updata(int id,BranchCustomerDto branchCustomerDto);
        void DeleteBrach(int id);

    }
}
